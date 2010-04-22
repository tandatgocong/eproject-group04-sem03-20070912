using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilitiesLayers;
using DataModelLayers;
using BusinessLayers;

public partial class WebUsers_UsersRegistry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         MaintainScrollPositionOnPostBack = true;
       
    }
    protected void _cmdCalendar_Click(object sender, ImageClickEventArgs e)
    {
        this.Calendar1.Visible = true;

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        this._txtdateofBirth.Text = Calendar1.SelectedDate.ToShortDateString();
        this.Calendar1.Visible = false;

    }
    protected void _cmdClear_Click(object sender, EventArgs e)
    {
        this._txtAddress.Text = null;
        this._txtcomfrimPass.Text = null;
        this._txtdateofBirth.Text = null;
        this._txtMail.Text = null;
        this._txtName.Text = null;
        this._txtpass.Text = null;
        this._txtPhone.Text = null;
        this._txtuserName.Text = null;

    }
    protected void _cmdResgistry_Click(object sender, EventArgs e)
    {
            
        
        Customers obj = new Customers();
        
        
        CustomerInfo info = new CustomerInfo("", this._txtuserName.Text, _txtName.Text, _txtpass.Text, DateTime.Parse(this._txtdateofBirth.Text), this._txtAddress.Text, this._txtPhone.Text, this._txtMail.Text);
        if (obj.InsertCustomer(info) == true)
        {
            MessageBox.Show(this,"Đăng ký thành công.");
            Response.Redirect("Default.aspx");
        }
        else {
            MessageBox.Show(this,"Đăng ký không thành công.");
        }

           
    }
}
