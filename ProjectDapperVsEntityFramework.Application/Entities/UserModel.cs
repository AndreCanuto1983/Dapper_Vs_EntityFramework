using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectDapperVsEntityFramework.Application.Entities
{
    public class UserModel : IdentityUser
    {
        public UserModel()
        {
            CreationDate = DateTime.UtcNow;
            UpdateDate = CreationDate;
        }

        public string Name { get; set; }
                
        [MaxLength(14)]
        public string Cpf { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }                
    }
}
