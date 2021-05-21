using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //Used by Mvc or WebAPI(Old WebAPI name = UserLoginBindingModel)
    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
