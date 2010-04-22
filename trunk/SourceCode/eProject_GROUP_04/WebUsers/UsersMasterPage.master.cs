using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class WebUsers_UsersMasterPage : System.Web.UI.MasterPage
{
     #region Private Member Variables

    string imageRotatorDiv = ConfigurationManager.AppSettings["ImageRotatorDivID"];

    #endregion
    public void SilverlightLoad01()
    {
        string browserWindowOptions = "resizable=1|scrollbars=1|menubar=1|status=1|toolbar=1|titlebar=1|width=700|height=800|left=0|top=0";

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
				initParams += ",borderThickness=" + "0";
				initParams += ",argb=" + argb;
				initParams += ",imageRotatorDiv=" + imageRotatorDiv;
				initParams += ",browserWindowOptions=" + browserWindowOptions;                

				Silverlight1.InitParameters = initParams;
               
             
			}
    }
    public void SilverlightLoad02()
    {
        string browserWindowOptions = "resizable=1|scrollbars=1|menubar=1|status=1|toolbar=1|titlebar=1|width=700|height=800|left=0|top=0";

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
            initParams += ",borderThickness=" + "1";
            initParams += ",argb=" + argb;
            initParams += ",imageRotatorDiv=" + imageRotatorDiv;
            initParams += ",browserWindowOptions=" + browserWindowOptions;
                     
            Silverlight2.InitParameters = initParams;

        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
      
       BusinessLayers.Business writexml = new BusinessLayers.Business();
       writexml.WriteXML(@"eProject_GROUP_04\ClientBin\SlideShowImages01.xml", "ASC");
       writexml.WriteXML(@"eProject_GROUP_04\ClientBin\SlideShowImages02.xml", "DESC");
    
        SilverlightLoad01();
        SilverlightLoad02();
    }

    protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
    {
        BusinessLayers.Business business = new BusinessLayers.Business();
        
        Login login = (Login)this.LoginView1.FindControl("Login2");
        e.Authenticated = business.CheckLogin(login.UserName, login.Password);
    }
    protected void Login2_LoggedIn(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.PathAndQuery);
    }
}
