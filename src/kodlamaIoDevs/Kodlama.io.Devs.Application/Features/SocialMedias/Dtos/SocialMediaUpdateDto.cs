using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.SocialMedias.Dtos
{
    public class SocialMediaUpdateDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
