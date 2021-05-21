using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
