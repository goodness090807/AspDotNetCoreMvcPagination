using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myfirstmvc.ViewModels.User
{
    public class UserUpdateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="姓名為必填欄位")]
        [DisplayName("姓名")]
        public string UserName { get; set; }

        [Required(ErrorMessage="性別為必選欄位")]
        [DisplayName("性別")]
        public int Gender { get; set; }
    }
}