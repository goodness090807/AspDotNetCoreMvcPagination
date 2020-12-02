

using System.ComponentModel.DataAnnotations;

namespace myfirstmvc.Enums
{
    public enum Gender
    {
        [Display(Name = "女")]
        female,
        [Display(Name = "男")]
        male,
    }
}
