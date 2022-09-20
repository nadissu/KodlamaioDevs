using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    public class SocialMediaCreateDto
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
    }
}
