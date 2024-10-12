using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Название товара обязательно")]
        [StringLength(255, ErrorMessage = "Название товара не может превышать 255 символов")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Описание товара не может превышать 255 символов")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Цена товара обязательна")]
        [Range(0, double.MaxValue, ErrorMessage = "Цена товара должна быть неотрицательной")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Идентификатор категории обязателен")]
        public int CategoryId { get; set; }


        public ProductCategory Category { get; set; }
    }
}
