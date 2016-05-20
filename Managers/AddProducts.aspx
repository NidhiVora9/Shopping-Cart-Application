<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProducts.aspx.cs" Inherits="Admin_AddProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="jumbotron">
  <asp:Panel ID="Panel1" runat="server">
    <table  id="tbladdProducts" class="table">
        <tr>
            <td>
                Product Name:
            </td>
            <td>
                 <asp:TextBox ID="txtShortDesc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Category:
            </td>
            <td>
                <asp:Label ID="lblCategory" runat="server" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 Long Description:
            </td>
            <td>
                <asp:TextBox ID="txtLongDesc" MaxLength="50" Rows="5"
                    TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 Price:
            </td>
            <td>
                  <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
              <td>
                    <asp:FileUpload ID="fUpload" runat="server" />
                </td>
                <td>
                    <asp:Label ID="lblProdImage" runat="server" ></asp:Label>
                </td>
        </tr>
        <tr>
            <td>
                Image File Name:
            </td>
            
            <td>
                    <asp:Button ID="btnUploadPImage" runat="server" Text="Upload Product Image" OnClick="btnUploadPImage_Click" />
           </td>
        </tr>
        <tr>
            <td>
                In Stock
            </td>
            <td>
                <asp:CheckBox ID="chkInStock" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                 Inventory:
            </td>
            <td>
                 <asp:TextBox ID="txtInventory" runat="server"></asp:TextBox>
                 <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Incorrect Inventory"
                    MaximumValue="1000" MinimumValue="1" Type="Integer" ControlToValidate="txtInventory"></asp:RangeValidator>
            </td>
        </tr>
        <tr>
            <td>
                Shipping and Handling Cost:
            </td>
            <td>
                <asp:TextBox ID="txtShipping" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <input id="Reset1" type="reset" class="mainButton" value="Reset" style="border-style: 0; border-color: 0; border-width: 0px;" />
            </td>
            <td> 
                 <asp:Button ID="btnAddProduct" CssClass="mainButton" runat="server" Text="Add Product" BorderStyle="None" OnClick="btnAddProduct_Click" />
            </td>
        </tr>    
    </table>
   </asp:Panel>
    <asp:Label ID="lblStatus" runat="server" ></asp:Label>
</div>
</asp:Content>

