

using System.ComponentModel.DataAnnotations;

namespace StorageEntities.Storage
{
    public class Category
    {
        public int idcategory { get; set;}
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No shorter than 3 characters longer than 50 characters.")]
        public string name { get; set; }
        [StringLength(256)]
        public string description { get; set; }
        public bool condition { get; set; }
    }
}
