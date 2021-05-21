using System.Collections.Generic;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //Used by Mvc or WebAPI(Old WebAPI name = ManageInfoBindingModel)
    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }
}
