using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Models
{
    public class EmailMessage
    {
        public string Destination { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public enum EmailHtml
        {
            TicketOpened = 0,
            TicketAproved = 1
        }
    }
}
