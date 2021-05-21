using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Arquitetura.Infra.Crosscuting.MvcFilters
{
    public class GlobalActionLogger : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //TODO: Neste espaço podem ser gerados vários tipos de logs, como logs de auditoria por exemplo
            //Podem ser gravadas informações do usuário, ação realizada, ip da máquina e outras coisas...

            if (filterContext.Exception != null)
            {
                var errorCode = Guid.NewGuid().ToString();
                var errorMessage = filterContext.Exception.Message;
                var source = filterContext.Exception.Source;
                var stackTrace = filterContext.Exception.StackTrace;

                filterContext.Controller.TempData["ErrorCode"] = errorCode;
                filterContext.Controller.TempData["ErrorMessage"] = errorCode;

                LocalErrorLog(errorCode, errorMessage, source, stackTrace);

                if (filterContext.Result.GetType().Name.Equals("EmptyResult"))
                    filterContext.Result = new RedirectResult("~/Error/Index");

                filterContext.ExceptionHandled = true;
            }

            base.OnActionExecuted(filterContext);
        }

        private void LocalErrorLog(string errorCode, string errorMessage, string source, string stackTrace) 
        {
            var directory = @"C:\Log\";
            var txtFile = "ArquiteturaLog_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".txt";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(directory + txtFile))
            {
                var text = new List<string>();
                text.Add("=========================");
                text.Add("| Log de erros da Arquitetura |");
                text.Add("=========================");
                File.WriteAllLines(directory + txtFile, text);
            }

            using (StreamWriter file = new StreamWriter(directory + txtFile, true))
            {
                file.WriteLine("Código do erro: " + errorCode);
                file.WriteLine("Data/Hora: " + DateTime.Now);
                file.WriteLine("Mensagem do erro: " + errorMessage);
                file.WriteLine("Fonte: " + source);
                file.WriteLine("Rastreamento de pilha: ");
                file.WriteLine(stackTrace);
                file.WriteLine("");
                file.WriteLine("======================================================================");
            }
        }
    }
}
