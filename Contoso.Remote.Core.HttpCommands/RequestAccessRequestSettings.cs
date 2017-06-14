using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Contoso.Remote.Core.HttpCommands
{
    /// <summary>
    /// Control access request settings.
    /// <remarks>Some of the settings are only valid in the Office365</remarks>
    /// </summary>
    public class RequestAccessRequestSettings : RemoteOperation
    {
        #region CONSTRUCTORS
        public RequestAccessRequestSettings(string TargetUrl, AuthenticationType authType, string User, string Password, string Domain = "")
            : base(TargetUrl, authType, User, Password, Domain)
        {
            this.EnableAccessRequests = true;
            this.AllowMembersToShareFile = true;
            this.AllowMembersToShareSite = true;
            this.EmailAddresses = "someone@contoso.com";
        }

        #endregion

        #region PROPERTIES

        public override string OperationPageUrl
        {
            get
            {
                return "/_layouts/15/setrqacc.aspx?type=web&Source=%2F%5Flayouts%2F15%2Fuser%2Easpx&IsDlg=1";
            }
        }
        public bool EnableAccessRequests
        {
            get;
            set;
        }

        public bool AllowMembersToShareFile
        {
            get;
            set;
        }

        public bool AllowMembersToShareSite
        {
            get;
            set;
        }

        public string EmailAddresses
        {
            get;
            set;
        }

        #endregion

        #region METHODS

        public override void SetPostVariables()
        {
            // Set operation specific parameters
            this.PostParameters.Add("__EVENTTARGET", "ctl00$PlaceHolderMain$ctl01$RptControls$btnSubmit");
            this.PostParameters.Add("ctl00%24PlaceHolderMain%24ctl00%24txtEmail", this.EmailAddresses);
            if (this.EnableAccessRequests)
            {
                // Present if we enable access request.
                this.PostParameters.Add("ctl00%24PlaceHolderMain%24ctl00%24chkRequestAccess", "on");
            }

            if (AllowMembersToShareFile)
            {
                this.PostParameters.Add("ctl00%24PlaceHolderMain%24ctl00%24chkMembersCanShare", "on");
            }

            if (AllowMembersToShareSite)
            {
                this.PostParameters.Add("ctl00%24PlaceHolderMain%24ctl00%24chkMembersCanAddToGroup", "on");
            }
        }

        #endregion

    }
}
