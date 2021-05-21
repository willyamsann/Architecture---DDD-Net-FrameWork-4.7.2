using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Application.Modules.UsersManager.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("Email")]
        [MaxLength(256, ErrorMessage = "Este campo aceita no máximo {0} caracteres")]
        public string Email { get; set; }

        [DisplayName("Nome do Usuário")]
        [MaxLength(256, ErrorMessage = "Este campo aceita no máximo {0} caracteres")]
        public string UserName { get; set; }
    }
}
