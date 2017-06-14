using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Remote.Core.HttpCommands
{
    /// <summary>
    /// Sends HTTP commands to trust specified App Instance within specified Host Web.
    /// </summary>
    public class RemoteTrustAddin : RemoteOperation
    {
        #region CONSTRUCTORS
        public RemoteTrustAddin(string targetUrl, AuthenticationType authType, string user, string password, string domain = "") : base(targetUrl, authType, user, password, domain)
        {
        }
        #endregion

        #region PROPERTIES
        public override string OperationPageUrl
        {
            get
            {
                return string.Format("/_layouts/15/AppInv.aspx?Manage=1&AppInstanceId={0}", AppInstanceId);
            }
        }

        public string AppInstanceId { get; set; }

        #endregion 

        #region METHODS
        public override void SetPostVariables()
        {
            this.PostParameters.Add("__EVENTTARGET", "ctl00$PlaceHolderMain$LnkRetrust");
        }
        #endregion 
    }
}
