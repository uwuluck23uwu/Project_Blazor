using System.ComponentModel.DataAnnotations;

namespace Tangy_Models
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณากรอกข้อมูล")]
        public string Name { get; set; }
    }
}
