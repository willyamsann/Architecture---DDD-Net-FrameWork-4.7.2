using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Arquitetura.Infra.Crosscuting.Identity.Configuration
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            //Utilizando TWILIO como SMS Provider.
            //https://www.twilio.com/docs/sms/quickstart/csharp-dotnet-framework

            //TODO: Caso necessário ativar o serviço de SMS, adicionar a referência do TWILIO.api
            //const string accountSid = "SEU ID";
            //const string authToken = "SEU TOKEN";

            //var client = new TwilioRestClient(accountSid, authToken);

            //client.SendMessage("Seu Telefone", message.Destination, message.Body);

            return Task.FromResult(0);
        }
    }
}
