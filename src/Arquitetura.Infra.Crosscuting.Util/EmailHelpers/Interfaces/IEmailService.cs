using Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Models;
using System;
using System.Threading.Tasks;

namespace Arquitetura.Infra.Crosscuting.Util.EmailHelpers.Interfaces
{
    public interface IEmailService : IDisposable
    {
        Task SendAsync(EmailMessage message);
    }
}
