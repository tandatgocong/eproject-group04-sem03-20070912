<%@ Page Title="" Language="C#" MasterPageFile="~/WebUsers/UsersMasterPage.master" AutoEventWireup="true" CodeFile="UsersRegistry.aspx.cs" Inherits="WebUsers_UsersRegistry" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;" border="1">
        <tr>
            <td style="background-image: url('Images/tmnbg.jpg')" >
            
              <center> 
                  <asp:Label ID="Label1" runat="server" Text="ĐĂNG KÝ TÀI KHOẢN" Font-Bold="True" 
                    Font-Size="Large" ForeColor="White"></asp:Label></center>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Thông Tin Cá Nhân"></asp:Label>
                &nbsp;<br />
            </td>
        </tr>
        <tr>
            <td>
            <center>
                <table style="width: 81%; text-align:left">
                    <tr >
                        <td class="style4" style="width: 97px">
                            Họ Và Tên</td>
                        <td>
                            <asp:TextBox ID="_txtName" runat="server" Width="217px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ControlToValidate="_txtName" ErrorMessage="Họ và tên không được trống.">(*)</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 97px">
                            Ngày Sinh</td>
                        <td>
                            <asp:TextBox ID="_txtdateofBirth" runat="server" Width="217px"></asp:TextBox>
                            <asp:ImageButton ID="_cmdCalendar" runat="server" Height="20px" 
                                ImageUrl="~/WebUsers/Images/Calendar.png" onclick="_cmdCalendar_Click" 
                                Width="25px" CausesValidation="False" />
                            <asp:CustomValidator ID="CustomValidator1" runat="server" 
                                ClientValidationFunction="CheckYearsOld" ControlToValidate="_txtdateofBirth" 
                                ErrorMessage="Tuổi &gt; 18">(*)</asp:CustomValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                ControlToValidate="_txtdateofBirth" ErrorMessage="Ngày Sinh Không được trống">(*)</asp:RequiredFieldValidator>
                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
                                BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest" 
                                Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" 
                                onselectionchanged="Calendar1_SelectionChanged" 
                                Visible="False" Width="220px" CellPadding="1" SelectedDate="2010-04-18" 
                                UseAccessibleHeader="False">
                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                <WeekendDayStyle BackColor="#CCCCFF" />
                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                <DayHeaderStyle BackColor="#99CCCC" Height="1px" ForeColor="#336666" />
                                <TitleStyle BackColor="#003399" Font-Bold="True" Font-Size="10pt" 
                                    ForeColor="#CCCCFF" BorderColor="#3366CC" BorderWidth="1px" 
                                    Height="25px" />
                            </asp:Calendar>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 97px">
                            Địa Chỉ </td>
                        <td>
                            <asp:TextBox ID="_txtAddress" runat="server" Width="217px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ControlToValidate="_txtAddress" ErrorMessage="Địa chỉ không được trống">(*)</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 97px">
                            Điện Thoại</td>
                        <td>
                            <asp:TextBox ID="_txtPhone" runat="server" Width="217px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                ControlToValidate="_txtPhone" ErrorMessage="Số điện  thoại không hợp lệ." 
                                ValidationExpression="0\d\d\d\d\d\d\d\d\d">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 97px">
                            Email</td>
                        <td>
                            <asp:TextBox ID="_txtMail" runat="server" Width="217px"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="_txtMail" ErrorMessage="Email không đúng định dạng." 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">(*)</asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="True" 
                    Text="Thông Tin Đăng Nhập"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <center>
                <table style="width: 81%; text-align:left">
                    <tr>
                        <td class="style5">
                            Tên Đăng Nhập</td>
                        <td class="style6">
                            <asp:TextBox ID="_txtuserName" runat="server" Width="217px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Mật Khẩu</td>
                        <td>
                            <asp:TextBox ID="_txtpass" runat="server" Width="217px" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4">
                            Xác Nhận Mật Khẩu</td>
                        <td>
                            <asp:TextBox ID="_txtcomfrimPass" runat="server" Width="217px" 
                                TextMode="Password"></asp:TextBox>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" 
                                ControlToCompare="_txtpass" ControlToValidate="_txtcomfrimPass" 
                                ErrorMessage="Xác Nhận Mật khẩu không giống">Xác Nhận Mật khẩu không giống</asp:CompareValidator>
                        </td>
                    </tr>
                </table>
                </center>
            </td>
        </tr>
        <tr>
            <td><center>
                <asp:Button ID="_cmdResgistry" runat="server" Text="Submit" 
                    onclick="_cmdResgistry_Click" />
&nbsp;
                <asp:Button ID="_cmdClear" runat="server" Text="Clear" CausesValidation="False" 
                    onclick="_cmdClear_Click" />
                </center>
            </td>
        </tr>
        </table>
</asp:Content>

