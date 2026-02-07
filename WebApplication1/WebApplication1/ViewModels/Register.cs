
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class Register
    {

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Passowrd { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Passowrd), ErrorMessage ="Password and confirmation password did not match")]
        public string ConfirmPassword { get; set; }


    }
}
