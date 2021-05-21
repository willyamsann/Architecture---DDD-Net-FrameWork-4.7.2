using System.ComponentModel.DataAnnotations;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //Used by WebAPI
    public class RemoveLoginViewModel
    {
        [Required]
        [Display(Name = "Login provider")]
        public string LoginProvider { get; set; }

        [Required]
        [Display(Name = "Provider key")]
        public string ProviderKey { get; set; }
    }
}
