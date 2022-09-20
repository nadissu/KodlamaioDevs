using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Kodlama.io.Devs.Application.Features.Auth.Dtos;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommand:IRequest<RegisterUserDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserDto>
        {
            IUserRepository _userRepository;
            IMapper _mapper;
            ITokenHelper _tokenHelper;


            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
            }

            public async Task<RegisterUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                User mappedUser = _mapper.Map<User>(request);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                User user = await  _userRepository.AddAsync(mappedUser);
                RegisterUserDto mappedRegisterUser = _mapper.Map<RegisterUserDto>(user);
                
                //normalde userın operation claimleri çekilmesi gerekir
                AccessToken token = _tokenHelper.CreateToken(user, new List<OperationClaim>());
                mappedRegisterUser.Token = token.Token;
                return mappedRegisterUser;
            }
        }
    }
}
