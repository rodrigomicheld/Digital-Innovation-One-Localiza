using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        public string Passoword { get; set; }
    }
}
