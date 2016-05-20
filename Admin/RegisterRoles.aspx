<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RegisterRoles.aspx.cs" Inherits="Admin_RegisterRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <table class="table">
            <tr>
                <td>
                    Role Name:
                </td>
                <td>
                    <asp:TextBox ID="txtRoleName" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
                    Role Description:
                </td>
                <td>
                    <asp:TextBox ID="txtRoleDesc" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegisterRoles" runat="server" Text="Register Role" OnClick="btnRegisterRoles_Click" />
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

