using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace SlideShowImages.Web.WebUsers
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        #region Private Member Variables

        string imageRotatorDiv = ConfigurationManager.AppSettings["ImageRotatorDivID"];

        #endregion

        /// <summary>
        /// Setup initParamaters for silverlight control when page initially loads, 
        /// special characters must be escaped with ASCII character. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string browserWindowOptions = "resizable=1|scrollbars=1|menubar=1|status=1|toolbar=1|titlebar=1|width=1000|height=725|left=5|top=5";

            if (!this.Page.IsPostBack)
            {
                string autoPlay = ConfigurationManager.AppSettings["EnableAutoPlay"].ToLower();
                string autoPlayInterval = ConfigurationManager.AppSettings["AutoPlayInterval"];
                string numberedNavigation = ConfigurationManager.AppSettings["DisplayNumberedNavigation"].ToLower();
                string arrowNavigation = ConfigurationManager.AppSettings["DisplayArrowNavigation"].ToLower();
                string stopStartAutoPlay = ConfigurationManager.AppSettings["EnableStopStartAutoPlay"].ToLower();
                string animation = ConfigurationManager.AppSettings["EnableAnimations"].ToLower();
                string border = ConfigurationManager.AppSettings["DisplayBorder"].ToLower();
                string borderThickness = ConfigurationManager.AppSettings["BorderThickness"];
                string argb = ConfigurationManager.AppSettings["ARGB"];

                string initParams = "autoPlay=" + autoPlay;
                initParams += ",autoPlayInterval=" + autoPlayInterval;
                initParams += ",numberedNavigation=" + numberedNavigation;
                initParams += ",arrowNavigation=" + arrowNavigation;
                initParams += ",stopStartAutoPlay=" + stopStartAutoPlay;
                initParams += ",animation=" + animation;
                initParams += ",border=" + border;
                initParams += ",borderThickness=" + borderThickness;
                initParams += ",argb=" + argb;
                initParams += ",imageRotatorDiv=" + imageRotatorDiv;
                initParams += ",browserWindowOptions=" + browserWindowOptions;

                imageRotator.InitParameters = initParams;
            }
        }

    }
}
