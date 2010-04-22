using System;
using System.Configuration;

namespace SlideShowImages.Web
{
	public partial class ImageRotatorTestPage : System.Web.UI.Page
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
			string browserWindowOptions = "resizable=1|scrollbars=1|menubar=1|status=1|toolbar=1|titlebar=1|width=300|height=200|left=1|top=1";

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

		/// <summary>
		/// Setup initParamaters for silverlight control when refresh button is clicked, 
		/// special characters must be escaped with ASCII character.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void refresh_Click(object sender, EventArgs e)
		{
			string browserWindowOptions = "resizable=1|scrollbars=1|menubar=1|status=1|toolbar=1|titlebar=1|width=900|height=725|left=5|top=5";

			string initParams = "autoPlay=" + autoPlay.Checked.ToString();
			initParams += ",autoPlayInterval=" + autoPlayInterval.Text;
			initParams += ",numberedNavigation=" + numberedNavigation.Checked.ToString();
			initParams += ",arrowNavigation=" + arrowNavigation.Checked.ToString();
			initParams += ",stopStartAutoPlay=" + stopStartAutoPlay.Checked.ToString();
			initParams += ",animation=" + animation.Checked.ToString();
			initParams += ",border=" + border.Checked.ToString();
			initParams += ",borderThickness=" + borderThickness.SelectedValue;
			initParams += ",argb=" + a.Text + "|" + r.Text + "|" + g.Text + "|" + b.Text;
			initParams += ",imageRotatorDiv=" + imageRotatorDiv;
			initParams += ",browserWindowOptions=" + browserWindowOptions;
			imageRotator.InitParameters = initParams;
		}
	}
}
