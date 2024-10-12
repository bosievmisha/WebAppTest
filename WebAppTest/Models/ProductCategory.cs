using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Название категории обязательно")]
        [StringLength(100, ErrorMessage = "Название категории не может превышать 100 символов")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Описание категории не может превышать 255 символов")]
        public string Description { get; set; }
    }
}
