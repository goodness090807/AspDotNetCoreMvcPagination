using System.ComponentModel.DataAnnotations;

namespace myfirstmvc.ViewModels.Post
{
    public class PostCreateViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage="標題為必填欄位")]
        [MaxLength(20, ErrorMessage="標題最多只能20個中文字")]
        public string Title { get; set; }

        [Required(ErrorMessage="內文為必填欄位")]
        public string Content { get; set; }
    }
}