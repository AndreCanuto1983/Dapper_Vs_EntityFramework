using System.ComponentModel.DataAnnotations;

namespace ProjectDapperVsEntityFramework.Application.Entities
{
    public abstract class ModelBase
    {           
        protected ModelBase()
        {
            CreationDate = DateTime.UtcNow;
            UpdateDate = CreationDate;
        }
                
        [Required]
        public DateTime CreationDate { get; set; }
                
        [Required]
        public DateTime UpdateDate { get; set; }
                
        [Required]
        public bool IsDeleted { get; set; }
    }
}
