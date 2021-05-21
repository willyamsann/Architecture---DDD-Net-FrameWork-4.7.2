
namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //Used by Mvc or WebAPI(Old WebAPI name = UserInfoBindingModel)
    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }
}
