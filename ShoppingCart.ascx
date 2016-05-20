<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ShoppingCart.ascx.cs" Inherits="ShoppingCart" %>
 <script src="scripts/jquery-1.9.0.min.js" type="text/javascript"></script>
<table>
    <tr>
        <td colspan="6">
            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="PID" HeaderText="Product ID" />
                    <asp:BoundField DataField="ProdName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Price" HeaderText="Price" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                          
                        <asp:RegularExpressionValidator id="RegularExpressionValidator1"
                         ControlToValidate="txtqty"
                        ValidationExpression="\d+"
                         Display="Static"
                        EnableClientScript="true"
                        ErrorMessage="Please enter valid quantity"
                        runat="server"></asp:RegularExpressionValidator>
                        
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ShippingCost" HeaderText="Shipping Cost" />
                    <asp:BoundField DataField="PriceTotal" HeaderText="Total" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="removeItem" runat="server" OnCommand="removeItem_Command" Text="Remove Item" CommandName="Remove" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                        </ItemTemplate> 
                    </asp:TemplateField>
                   
                   
                </Columns>
            </asp:GridView>     
           

        </td>
    </tr>
    <tr>
        <td colspan="5">
            Total Amount:
        </td>
        <td colspan="5">
            <asp:Label ID="total_amount" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnCancel" CssClass="mainButton" runat="server" Text="Cancel changes" OnClick="btnCancel_Click" />

        </td>
        <td colspan="2">
          <asp:Button ID="btnUpdate" CssClass="mainButton" runat="server" Text="Update Cart" OnClick="btnUpdate_Click" />
        </td>
        <td colspan="2">
          <asp:Button ID="btnClear" CssClass="mainButton" runat="server" Text="Clear All" OnClick="btnClear_Click" />
        </td>
    </tr>

</table>
<asp:Label ID="lblStatus" runat="server"></asp:Label>