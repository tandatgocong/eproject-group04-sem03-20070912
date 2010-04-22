using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace UtilitiesLayers
{
    public class MessageBox
    {
        public MessageBox()
        {
        }
        public static void Show(System.Web.UI.Page CPage, string Message)
        {
            CPage.ClientScript.RegisterStartupScript(CPage.GetType(), "alert", "alert('" + Message + "')", true);
        }
    }
}
