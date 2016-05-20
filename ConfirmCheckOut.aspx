<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConfirmCheckOut.aspx.cs" Inherits="ConfirmCheckOut" %>

<%@ Register Src="ShoppingCart.ascx" TagPrefix="uc1" TagName="ShoppingCart" %>
<%@ Register Src="ShoppingCart.ascx" TagPrefix="uc2" TagName="ShoppingCart" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 8px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td>
                <uc2:ShoppingCart runat="server" ID="ShoppingCart" />
            </td>
        </tr>
    </table>
    <hr />

    <div class="table-responsive">
    <table class="table">
        <tr>
            <td>
                First Name:
            </td>
            <td>
                <asp:Label ID="lblfirstname" runat="server"></asp:Label>
            </td>
        </tr>
          <tr>
            <td>
                Last Name:
            </td>
            <td>
                <asp:Label ID="lbllastname" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Address:
            </td>
            <td>
                <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <p align="right">
                    City</p>
            </td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
               State
                <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
               Zip Code
                <asp:TextBox ID="txtZipcode" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Email</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">
                Credit Card Number</td>
            <td>
               <asp:TextBox ID="txtCCNumber" runat="server"></asp:TextBox>
                <td align="right" class="auto-style1">
                    &nbsp;</td>

            </td>

        </tr>
         <tr>
            <td align="right" style="height: 8px">
                Credit Card Type</td>
            <td style="height: 8px">
                <asp:DropDownList ID="ddlCCType" runat="server">
                    <asp:ListItem Value="VISA">Visa</asp:ListItem>
                    <asp:ListItem Value="MASTERCARD">MasterCard</asp:ListItem>
                    <asp:ListItem Value="AMERICANEXPRESS">AmericanExpress</asp:ListItem>
                    <asp:ListItem Value="DISCOVER">Discover</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right">
                Expiration Date</td>
            <td>
                <asp:TextBox ID="txtExpiration" runat="server" Width="104px"></asp:TextBox>&nbsp;
                (mm/yy)</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnUpdateInfo" runat="server" CssClass="mainButton" Text="Update Info"
                   OnClick="btnUpdateInfo_Click" /></td>
            <td>
                <asp:Button ID="btnConfirmCheckOut" runat="server"  CssClass="mainButton"  Text="Confirm Check Out"
                   OnClick="btnConfirmCheckOut_Click" /></td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Label ID="lblStatus" runat="server" Width="353px"></asp:Label></td>
        </tr>
              </table>
     </div>
</asp:Content>

