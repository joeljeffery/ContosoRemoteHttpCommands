using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Remote.Core.HttpCommands
{
    /// <summary>
    /// Control language settings in the site (SPWeb) level
    /// </summary>
    public class RequestLanguageSettings : RemoteOperation
    {
        #region CONSTRUCTORS

        public RequestLanguageSettings(string TargetUrl, AuthenticationType authType, string User, string Password, string Domain = "")
            : base(TargetUrl, authType, User, Password, Domain)
        {
            this.Languages = new List<int>();
            this.OverrideMUI = true;
        }

        #endregion

        #region PROPERTIES

        public override string OperationPageUrl
        {
            get
            {
                return "/_layouts/15/muisetng.aspx";
            }
        }

        public List<int> Languages
        {
            get;
            set;
        }

        public bool OverrideMUI
        {
            get;
            set;
        }

        #endregion

        #region METHODS

        public override void AnalyzeRequestResponse(string page)
        {
            base.AnalyzeRequestResponse(page);

            // Loop through language options in the page to see the one's requested
            for (int i = 0; i < 100; i++)
            {
                string languageValue = Utilities.ReadInputFieldById(page, string.Format("ctl00_PlaceHolderMain_MUISettings_AlternateLanguagesSection_ctlSelectLanguages_CblAlternateLanguages_{0}", i));
                // leave when empty as we've iterated all supported languages
                if (languageValue.Length == 0)
                {
                    break;
                }

                // If we found one, set that as checked
                if (this.Languages.Contains(int.Parse(languageValue)))
                {
                    PostParameters.Add(string.Format("ctl00$PlaceHolderMain$MUISettings$AlternateLanguagesSection$ctlSelectLanguages$CblAlternateLanguages${0}", i), languageValue);
                }
            }
        }

        public override void SetPostVariables()
        {
            // Set operation specific parameters
            this.PostParameters.Add("__EVENTTARGET", "ctl00$PlaceHolderMain$ctl00$RptControls$BtnCreate");
            if (this.OverrideMUI)
            {
                this.PostParameters.Add("ctl00$PlaceHolderMain$MUISettings$OverwriteTranslationsSection$ctlOverwriteMUI$overwriteMUI", "RadOverwriteMUIYes");
            }
            else
            {
                this.PostParameters.Add("ctl00$PlaceHolderMain$MUISettings$OverwriteTranslationsSection$ctlOverwriteMUI$overwriteMUI", "RadOverwriteMUINo");
            }
        }

        #endregion
    }
}
