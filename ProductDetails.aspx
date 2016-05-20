<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="row-center">
        <div class="col-sm-3 col-md-9">
        <table id="prods" align="center">
            <tr>
            <td rowspan="4">
                <img src="PImages/<%=dt.Rows[0]["ProductImage"].ToString()%>" width="300" height="200"/>
            </td>
            <td>
                <asp:Label ID="lblProdDesc" runat="server" CssClass="myheading" Text="Label"></asp:Label>
            </td>

        </tr>
        <tr>
            <td width="325">
                <p align="justify"><%=dt.Rows[0]["ProductLDesc"].ToString() %></p>
            </td>
        </tr>
        <tr>    
            <td>
                Price: <asp:Label ID="lblPrice" CssClass="label label-info" runat="server" Font-Size="Medium"></asp:Label>
            </td>
           
        </tr>
        <tr>    
            
            <td>
               Shipping and Handling: <asp:Label ID="lblShipping" CssClass="label label-info" runat="server" Font-Size="Medium"></asp:Label></td>
        </tr>
    </table>
    </div>
        <div class="col-sm-9 col-md-3">
            <table  id="cartinfo" align="center">
        <tr style="font-size: medium; font-weight: bold; font-style: normal; color: #333333">
            <td>
                Quantity:
            </td>
            <td>
               
                <asp:DropDownList ID="ddl" runat="server" OnSelectedIndexChanged="ddl_OnSelectedIndexChanged">
                    
                 </asp:DropDownList>
            </td>
        </tr>  
        <tr>
            <td colspan="2">
                <asp:Button ID="btnAddToCart" CssClass="mainButton" runat="server" Text="Add to Cart" BorderStyle="None" OnClick="btnAddToCart_Click" />
            </td>
            </tr>
            <tr>
             <td colspan="2">
                <asp:Label ID="lblAddToCart" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnViewCart" CssClass="mainButton" runat="server" Text="View Cart" BorderStyle="None" OnClick="btnViewCart_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStatus" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
        </div>
    
        </div>
</asp:Content>

