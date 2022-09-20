using Core.Persistence.Repositories;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class SocialMedia:Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
       public SocialMedia() { }

        public SocialMedia(int id,string name, string url, int userId, User user)
        {
            Id = id;
            Name = name;
            Url = url;
            UserId = userId;
            User = user;
        }
    }
 
}
