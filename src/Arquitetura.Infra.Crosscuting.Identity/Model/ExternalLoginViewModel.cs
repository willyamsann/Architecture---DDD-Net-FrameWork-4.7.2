using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Infra.Crosscuting.Identity.Model
{
    //Used by MVC Or WebAPI(Old WebAPI name = ExternalLoginBindingModel)
    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
}
