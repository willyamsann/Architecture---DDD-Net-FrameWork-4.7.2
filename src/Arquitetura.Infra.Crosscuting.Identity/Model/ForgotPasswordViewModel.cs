using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
