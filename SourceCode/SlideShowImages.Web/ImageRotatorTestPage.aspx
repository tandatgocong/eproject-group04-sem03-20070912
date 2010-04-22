<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageRotatorTestPage.aspx.cs" Inherits="SlideShowImages.Web.ImageRotatorTestPage" %>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>ImageRotator</title>
	
	<style type="text/css">
		#wrapper {
			text-align: left;
			margin: 0px auto;
			padding: 0px;
			border:0;
			width: 1000px;
			background: url("/path/to/your/background_cols.gif") repeat;
			border: solid 1px #868686;
		}

		#header 
		{
			padding: 5px;
			margin: 0 0 15px 0;
			font-size: 32px;
			font-weight: bold;
			background: #414141;
		}

		#imageRotatorDiv 
		{
			padding: 5px;
			float: left;
			width: 400px;
		}

		#formControlsDiv { 
			margin-left: 10px;
			float: left;
			width: 480px;
			padding: 5px;
			height: 1% /* Holly hack for Peekaboo Bug */
		}

		#footer 
		{
			padding: 5px;
			clear: both;
			background: #414141;
		}
		
		a {
		  font: italic 100%/1.0 Arial;
		  text-decoration: none;
		}
		
		a:link { 
		  color: #d0eb55;
		  text-decoration: none;
		}
		
		a:visited {
		  color: #d0eb55;
		  text-decoration: none;
		}
		
		a:hover {
		  color: #d0eb55;
		  text-decoration: underline;
		}
		
		a:active { 
		  color: #d0eb55;
		  text-decoration: none;
		}

	</style>
</head>
<body style="background-color: #3d3d3d; color: #d0eb55; font-family: Arial;">

    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
	<div id="wrapper">

		<div id="header">
			Configurable Silverlight Image Rotator
		</div>

		<div id="container">

			<div id="imageRotatorDiv">
				<asp:Silverlight ID="imageRotator" runat="server" Width="100%" Height="100%" Source="~/ClientBin/SlideShowImages.xap"
					MinimumVersion="2.0.30923.0" />
			</div>
		
			<div id="formControlsDiv" style="background: #414141;">
				<div style="font-weight: bold; padding-bottom: 5px; vertical-align: top; margin: 6px;">
					Auto Play
				</div>
				<div style="padding-left: 30px; color: White; margin: 6px;">
					Enabled:
					<asp:CheckBox ID="autoPlay" runat="server" Checked="true" />
				</div>
				<div style="padding-left: 60px; color: White; margin: 6px;">
					Interval:
					<asp:TextBox ID="autoPlayInterval" runat="server" Width="50" Text="7"></asp:TextBox>&nbsp;(in
					seconds)
				</div>
				<div style="font-weight: bold; padding-top: 15px; padding-bottom: 5px;">
					Navigation</div>
				<div style="padding-left: 30px; color: White; margin: 6px;">
					Display Numbered Navigation Buttons:
					<asp:CheckBox ID="numberedNavigation" runat="server" Checked="true" />
				</div>
				<div style="padding-left: 30px; color: White; margin: 6px;">
					Display Arrow Navigation Buttons:
					<asp:CheckBox ID="arrowNavigation" runat="server" Checked="true" />
				</div>
				<div style="padding-left: 60px; color: White; margin: 6px;">
					Enable Stop/Start Auto Play:
					<asp:CheckBox ID="stopStartAutoPlay" runat="server" Checked="true" />
				</div>
				<div style="font-weight: bold; padding-top: 15px; padding-bottom: 5px;">
					Animation</div>
				<div style="padding-left: 30px; color: White;">
					Enabled:
					<asp:CheckBox ID="animation" runat="server" Checked="true" />
				</div>
				<div style="font-weight: bold; padding-top: 15px; padding-bottom: 5px;">
					Border</div>
				<div style="padding-left: 30px; color: White; margin: 6px;">
					Enabled:
					<asp:CheckBox ID="border" runat="server" Checked="true" />
				</div>
				<div style="padding-left: 60px; color: White; margin: 6px;">
					Border Thickness:
					<asp:DropDownList ID="borderThickness" runat="server">
						<asp:ListItem Text="0" Value="0"></asp:ListItem>
						<asp:ListItem Text="1" Value="1"></asp:ListItem>
						<asp:ListItem Text="2" Value="2" Selected="True"></asp:ListItem>
						<asp:ListItem Text="3" Value="3"></asp:ListItem>
						<asp:ListItem Text="4" Value="4"></asp:ListItem>
						<asp:ListItem Text="5" Value="5"></asp:ListItem>
						<asp:ListItem Text="6" Value="6"></asp:ListItem>
						<asp:ListItem Text="7" Value="7"></asp:ListItem>
						<asp:ListItem Text="8" Value="8"></asp:ListItem>
						<asp:ListItem Text="9" Value="9"></asp:ListItem>
						<asp:ListItem Text="10" Value="10"></asp:ListItem>
					</asp:DropDownList>
				</div>
				<div style="padding-left: 60px; color: White; margin: 6px;">
					ARGB:&nbsp;<span style="padding-left: 0px;">(A)&nbsp;<asp:TextBox ID="a" runat="server" Width="50"
						Text="255"></asp:TextBox></span> <span style="padding-left: 5px;">(R)&nbsp;<asp:TextBox
							ID="r" runat="server" Width="50" Text="0"></asp:TextBox></span> <span style="padding-left: 5px;">
								(G)&nbsp;<asp:TextBox ID="g" runat="server" Width="50" Text="0"></asp:TextBox></span>
					<span style="padding-left: 5px;">(B)&nbsp;<asp:TextBox ID="b" runat="server" Width="50"
						Text="0"></asp:TextBox></span>
				</div>
				<div style="margin-top: 15px; margin-left: 6px; margin-top: 15px;">
					<asp:Button ID="refresh" runat="server" Text="Refresh" OnClick="refresh_Click" />
				</div>
			</div>
		</div>
		<div id="footer">
			<a href="http://www.anothercodesite.com/Blog/2008/12/default.aspx">AnotherCodeSite.com</a>
		</div>
    </div>
    </form>
</body>
</html>
