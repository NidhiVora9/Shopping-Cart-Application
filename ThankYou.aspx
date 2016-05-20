<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ThankYou.aspx.cs" Inherits="ThankYou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblSummary" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnContinueShopping" CssClass="mainButton" runat="server" Text="Continue Shopping" />
            </td>
            <td>
                <asp:Button ID="btnLogout" runat="server" CssClass="mainButton" Text="Logout" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server" ></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

