

using System.ComponentModel.DataAnnotations;

namespace curso.api.Models.ViewModels
{
    public class UserViewModel
    {
       
        public int Codigo { get; set; }
        public string Login { get; set; }  
        public string Email { get; set; }

        
    }
}
