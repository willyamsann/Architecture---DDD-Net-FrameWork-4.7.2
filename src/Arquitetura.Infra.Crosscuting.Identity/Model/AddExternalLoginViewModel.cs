using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //User by WebApi
    public class AddExternalLoginViewModel
    {
        [Required]
        [Display(Name = "External access token")]
        public string ExternalAccessToken { get; set; }
    }
}
