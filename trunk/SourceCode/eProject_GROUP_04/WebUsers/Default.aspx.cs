using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using BusinessLayers;
using DataAccessLayers;
using System.Xml;

public partial class WebUsers_Default : System.Web.UI.Page
{
    Books book = new Books();
    protected void Page_Load(object sender, EventArgs e)
    {
        Binddata();      

    }    
    public void Binddata()
    {
        this.DataList1.DataSource = book.getListBooks();
        this.DataList1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
      //  GridView1.PageIndex = e.NewPageIndex;
        Binddata();
    }
}
