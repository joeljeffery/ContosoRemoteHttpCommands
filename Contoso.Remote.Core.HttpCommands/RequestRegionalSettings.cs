using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Remote.Core.HttpCommands
{
    /// <summary>
    /// For modifying the regional settings in the page.
    /// <remarks>Supports only setting regional settings in high level and ignores time and day settings.</remarks>
    /// </summary>
    public class RequestRegionalSettings : RemoteOperation
    {

        #region CONSTRUCTORS

        public RequestRegionalSettings(string TargetUrl, AuthenticationType authType, string User, string Password, string Domain = "") 
            : base(TargetUrl, authType, User, Password, Domain)
        {
            //Set the default language as English UK for demo purposes
            this.LanguageId = 2057;
        }

        #endregion

        #region PROPERTIES

        public int LanguageId
        {
            get;
            set;
        }

        public override string OperationPageUrl
        {
            get
            {
                return "/_layouts/15/regionalsetng.aspx";
            }
        }

        #endregion

        #region METHODS

        public override void SetPostVariables()
        {
            // Set operation specific parameters
            this.PostParameters.Add("__EVENTTARGET", "ctl00$PlaceHolderMain$ctl06$RptControls$BtnUpdateRegionalSettings");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl02$ctl01$DdlwebLCID", this.LanguageId.ToString());
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl01$ctl01$DdlwebTimeZone", "13");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl09$ctl01$DdlwebCollation", "25");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl03$ctl01$DdlwebCalType", "1");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl04$ctl01$DdlwebAltCalType", "0");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl01$ChkListWeeklyMultiDays$1", "mo");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl01$ChkListWeeklyMultiDays$2", "tu");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl01$ChkListWeeklyMultiDays$3", "we");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl01$ChkListWeeklyMultiDays$4", "th");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl01$ChkListWeeklyMultiDays$5", "fr");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl02$DdlFirstDayOfWeek", "1");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl02$DdlStartTime", "08:00");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl02$DdlFirstWeekOfYear", "2");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl05$ctl02$DdlEndTime", "17:00");
            this.PostParameters.Add("ctl00$PlaceHolderMain$ctl10$ctl01$DdlTimeFormat", "1");
            this.PostParameters.Add("Cmd", "UPDATEPROJECT");
            this.PostParameters.Add("NextUsing", "_layouts/15/settings.aspx");
        }

        #endregion

    }
}
