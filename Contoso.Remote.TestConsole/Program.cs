using Contoso.Remote.Core.HttpCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Remote.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestAccessRequestSettings access = new RequestAccessRequestSettings("http://dev.contoso.com", 
                                                        AuthenticationType.DefaultCredentials, string.Empty, string.Empty);
            access.EnableAccessRequests = true;
            access.EmailAddresses = "demo@contoso.com";
            access.Execute();

            RequestRegionalSettings regional = new RequestRegionalSettings("http://dev.contoso.com", 
                                                        AuthenticationType.NetworkCredentials, "danj", "pass@word1","contoso");
            regional.LanguageId = 1035;
            regional.Execute();

            RequestLanguageSettings language = new RequestLanguageSettings("https://joona.sharepoint.com/sites/sampleteam", 
                                                    AuthenticationType.Office365, "keizersoze@joona.onmicrosoft.com", "pass@word1");
            language.Languages.Add(1035);
            language.Execute();

            // trust the add-in specified by instance id
            RemoteTrustAddin trust = new RemoteTrustAddin(
                "<site url>",
                AuthenticationType.Office365,
                "<username>",
                "<password>");

            trust.AppInstanceId = "<app instance guid>";
            trust.Execute();
        }
    }
}
