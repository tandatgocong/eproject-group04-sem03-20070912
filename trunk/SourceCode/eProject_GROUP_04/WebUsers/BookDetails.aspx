<%@ Page Title="" Language="C#" MasterPageFile="~/WebUsers/UsersMasterPage.master" AutoEventWireup="true" CodeFile="BookDetails.aspx.cs" Inherits="WebUsers_BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
       <tr>
            <td style="background-image: url('Images/tmnbg.jpg')" >
            
              <center> 
                  <asp:Label ID="Label1" runat="server" Text="BOOK DETAIL" Font-Bold="True" 
                    Font-Size="Large" ForeColor="White"></asp:Label></center>
            </td>
        </tr>
        <tr>
            <td style="height: 20px">
             
                <asp:FormView ID="FormView1" runat="server">
                    <ItemTemplate>
                        <table style="width:100%;">
                            <tr>
                                <td style="width: 110px" rowspan="2">
                                    <asp:ImageButton ID="ImageButton2" runat="server" Height="291px" 
                                        ImageUrl='<%# "~/ClientBin/Images/"+ Eval("bookImg") %>' Width="221px" />
                                </td>
                                <td 
            style="text-align: left; vertical-align: text-top; width: 421px;">
                                    <table 
                style="width:103%; vertical-align:text-top; height: 264px;">
                                        <tr>
                                            <td style="height: 36px; width: 70px">
                                                <asp:Label ID="title" runat="server" Text="Tên Sách :"></asp:Label>
                                            </td>
                                            <td style="height: 36px">
                                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("bookName") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="text-align:left; vertical-align:top;">
                                            <td style="width: 70px; height: 82px;">
                                                <asp:Label ID="Label5" runat="server" Text="Mô Tả :"></asp:Label>
                                            </td>
                                            <td style="height: 82px">
                                                Viết cái gì đó</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px; height: 24px;">
                                                <asp:Label ID="Label1" runat="server" Text="Năm XB :"></asp:Label>
                                            </td>
                                            <td style="height: 24px">
                                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("bookYear") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <asp:Label ID="Gia" runat="server" Text="Giá Bán :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("bookPrice")+" VND" %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 421px">
                                    <asp:ImageButton ID="ImageButton3" runat="server" 
                ImageUrl="~/WebUsers/Images/add_to_cart_en.gif" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:FormView>
             
            </td>
        </tr>
    </table>
</asp:Content>

