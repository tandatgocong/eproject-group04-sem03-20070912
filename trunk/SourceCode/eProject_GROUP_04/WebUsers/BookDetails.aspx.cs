using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayers;

public partial class WebUsers_BookDetails : System.Web.UI.Page
{
    Books book = new Books();
    protected void Page_Load(object sender, EventArgs e)
    {
      
        this.FormView1.DataSource = book.getBookDetail(Request.QueryString["id"]);
        this.FormView1.DataBind();

    }
}
