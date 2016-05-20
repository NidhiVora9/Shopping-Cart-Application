<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewCart.aspx.cs" Inherits="ViewCart" %>

<%@ Register Src="ShoppingCart.ascx" TagPrefix="uc1" TagName="ShoppingCart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td colspan="2">
            <uc1:ShoppingCart runat="server" ID="ShoppingCart" />
        </td>
    </tr>

        <tr>
            <td>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCheckOut" CssClass="mainButton" runat="server" Text="Check Out " OnClick="btnCheckOut_Click" />
            </td>
            <td>
                <asp:Button ID="btnContinueShopping" CssClass="mainButton" runat="server" Text="Continue Shopping" OnClick="btnContinueShopping_Click" />
            </td>
        </tr>
    </table>
    
    
</asp:Content>

