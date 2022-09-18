using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class LanguageTechnology:Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }
        public LanguageTechnology()
        {
        }

        public LanguageTechnology(int id,int pogrammingLanguageId, string name):this()
        {
            Id= id;
            ProgrammingLanguageId = pogrammingLanguageId;
            Name = name;
        }
    }
}
