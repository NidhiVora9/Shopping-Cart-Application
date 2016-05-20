<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddUsers.aspx.cs" Inherits="Admin_AddUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="jumbotron">
            <table class="table">
                <tr>
                    <td>
                        Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtusername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Password:
                    </td>
                    <td>
                        <asp:TextBox  ID="txtpassword" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        PasswordQues:
                    </td>
                    <td>
                        <asp:TextBox ID="txtpaswordques" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        PasswordAns:
                    </td>
                    <td>
                        <asp:TextBox ID="txtpasswordans" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnAddUsers" runat="server" Text="Add User" OnClick="btnAddUsers_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
         </div>
</asp:Content>

