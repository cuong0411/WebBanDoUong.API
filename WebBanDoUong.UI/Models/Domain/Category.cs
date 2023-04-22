using System.ComponentModel.DataAnnotations;

namespace WebBanDoUong.UI.Models.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
