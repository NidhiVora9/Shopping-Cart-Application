<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignNewRoles.aspx.cs" Inherits="Admin_RegisterRoles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <table class="table">
            <tr>
                <td>
                    Username:
                </td>
                <td>
                   <asp:DropDownList ID="ddlUserNames" runat="server">

                   </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>
                    Role:
                </td>
                <td>
                   <asp:DropDownList ID="ddlRoles" runat="server">

                   </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAssignRole" runat="server" Text="Assign Role" OnClick="btnAssignRole_Click"  />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

