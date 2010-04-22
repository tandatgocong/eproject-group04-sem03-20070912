<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="SlideShowImages.Web.WebUsers.WebForm2" %>

<%@ Register assembly="System.Web.Silverlight" namespace="System.Web.UI.SilverlightControls" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <div id="imageRotatorDiv">
        <asp:Silverlight ID="imageRotator" runat="server" Height="408px" 
            Source="~/ClientBin/SlideShowImages.xap" Width="473px">
        </asp:Silverlight>
        </div>
    
    </div>
    </form>
</body>
</html>
