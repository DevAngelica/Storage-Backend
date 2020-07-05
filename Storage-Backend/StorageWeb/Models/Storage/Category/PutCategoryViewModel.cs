using System.ComponentModel.DataAnnotations;

namespace StorageWeb.Models.Storage.Category
{
    public class PutCategoryViewModel
    {
        [Required]
        public int idcategory { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "No shorter than 3 characters longer than 50 characters.")]
        public string name { get; set; }
        [StringLength(256)]
        public string description { get; set; }
    }
}

