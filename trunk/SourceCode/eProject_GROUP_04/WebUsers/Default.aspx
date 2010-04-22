<%@ Page Title="" Language="C#" MasterPageFile="~/WebUsers/UsersMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="WebUsers_Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <table style="width:100%;">
    <tr>
            <td style="background-image: url('Images/tmnbg.jpg')" >
            
              <center> 
                  <asp:Label ID="Label1" runat="server" Text="::" Font-Bold="True" 
                    Font-Size="Large" ForeColor="White"></asp:Label></center>
            </td>
        </tr>
        
    <tr>
        <td>   
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="3" 
                RepeatDirection="Horizontal" GridLines="Both">
                <ItemTemplate>
                    <table style="width:40%;">
                        <tr>
                            <td colspan="2">
                                <asp:ImageButton ID="ImageButton2" runat="server"  Height="223px" 
                                    ImageUrl='<%# "~/ClientBin/Images/"+ Eval("bookImg") %>'   Width="176px" 
                                    PostBackUrl='<%# "BookDetails.aspx?id=" +  Eval("bookID") %>' />
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red" 
                                    Text='<%# "Price : "+  Eval("bookPrice") +"VND" %>'></asp:Label>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 82px">
                                <asp:LinkButton ID="LinkButton3" runat="server" 
                                    PostBackUrl='<%# "BookDetails.aspx?id=" +  Eval("bookID") %>'>More details</asp:LinkButton>
                            </td>
                            <td style="width: 64px">
                                <asp:ImageButton ID="ImageButton3" runat="server" 
                                    ImageUrl="~/WebUsers/Images/add_to_cart_en.gif" />
                            </td>
                        </tr>
                    </table>
                    <hr />
                </ItemTemplate>
            </asp:DataList>
            <br />
    </td>       
    </tr>
   </table>
     
       
  
</asp:Content>

