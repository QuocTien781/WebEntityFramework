using System.ComponentModel.DataAnnotations;

namespace WebEntityFramework.Models
{
    
    public class Article
    {
        public int ID { get; set; }
        [StringLength(100,MinimumLength =3, ErrorMessage ="{0} phải từ {2} đến {1} ký tự")]
        [Required(ErrorMessage ="{0} không được bỏ trống")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public string Content { set; get; }
    }
}
