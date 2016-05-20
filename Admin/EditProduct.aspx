<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditProduct.aspx.cs" Inherits="Admin_EditProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="jumbotron" >
    <table class="table">
        <tr>
            <td>
                 Product ID
            </td>
            <td>
                <asp:Label ID="lblProductID" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 Category
            </td>
            <td>
                <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                 Short Description
            </td>
            <td>
                <asp:TextBox ID="txtShortDesc" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 Long Description
            </td>
            <td>
                <asp:TextBox ID="txtLongDesc" runat="server" MaxLength="50" Rows="5"
                    TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                 Price
            </td>
            <td>
                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                 Image File Name
            </td>
            <td>
                <asp:Label ID="lblProdImage" runat="server"></asp:Label>
                
            </td>
             <td>
                  <asp:FileUpload ID="fUpload" runat="server" />
             </td>
            <td>   
                <asp:Button ID="btnUploadPImage" Text="Upload Product Image" runat="server" OnClick="btnUploadPImage_Click"/>
            </td>
            
        </tr>
         <tr>
             <td>
                 Image:
             </td>
             <td colspan="3">
                  <asp:Image ID="imgProduct" runat="server" Height="268px" Width="329px" />
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
                  Inventory
            </td>
            <td>
              <asp:TextBox ID="txtInventory" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCancel" CssClass="mainButton" runat="server" Text="Cancel" />
            </td>
            <td>
                <asp:Button ID="btnUpdate" CssClass="mainButton" runat="server" Text="Update Product" OnClick="btnUpdate_Click" />
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

