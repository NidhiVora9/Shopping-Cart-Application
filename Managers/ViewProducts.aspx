<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewProducts.aspx.cs" Inherits="Admin_ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <table>
            <tr>
                <asp:Label ID="lblStatus" CssClass="statusLabel" runat="server"></asp:Label>
                <asp:Button ID="btnLogoff" runat="server" Text="Admin Logout" />
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="0" GridLines="None" Height="365px" Width="767px" RowHeaderColumn="none">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit Products">
                                <ItemTemplate >
                                    <a href='EditProduct.aspx?PID=<%# Eval("ProductID") %>'>
								     Edit </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ProductSDesc" HeaderText="Product Name" />
						   <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>
						  
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>

        </table>
    </div>
</asp:Content>

