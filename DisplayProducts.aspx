<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DisplayProducts.aspx.cs" Inherits="DisplayProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <table align="center" >
            <tr>
                <td>
                    <asp:Label ID="lblProducts" CssClass="statusLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblStatus" CssClass="statusLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0" GridLines="None" Height="365px" Width="767px" RowHeaderColumn="none">
                        <Columns>
                            <asp:ImageField DataImageUrlField="ProductImage" ItemStyle-CssClass="hr" ControlStyle-Height="120" ControlStyle-Width="100"  DataImageUrlFormatString="~/PImages/{0}" >
                            <ControlStyle Height="100px" Width="100px"></ControlStyle>
                            </asp:ImageField>
                             <asp:HyperLinkField DataTextField="ProductSDesc" DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="ProductDetails.aspx?PID={0}" ItemStyle-CssClass="hr" >  </asp:HyperLinkField>
                            </Columns>
                        <RowStyle BorderStyle="None" />
                    
                    </asp:GridView>

                </td>
            </tr>
        </table>
</asp:Content>

