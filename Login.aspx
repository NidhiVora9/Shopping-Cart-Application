<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="content_box">
       <table id="content_center_box" style="border-spacing: 20px">
            <tr>
                <td colspan="2" style="text-align: center">
                <label class="lblheading">LOGIN</label>
                </td>
            </tr>
            <tr>
                <td><label id="lblusername" class="label_style">Username:</label> </td>
                <td><asp:TextBox ID="txtusername" runat="server" CssClass="txtbox"></asp:TextBox> </td>

            </tr>
            <tr>
                <td><label id="lblpassword" class="label_style">Password:</label> </td>
                <td><asp:TextBox ID="txtpassword" runat="server" CssClass="txtbox" TextMode="Password"></asp:TextBox> </td>

            </tr>
            <tr style="text-align: center">
               <td colspan="2"><asp:Button ID="btnlogin" CssClass="btnstyle" runat="server" Text="Login" BorderStyle="None" OnClick="btnlogin_Click"/> </td>
            </tr>
            <tr style="text-align: center">
                <td colspan="2"><asp:Label ID="lblStatus" CssClass="lbl_status_style" runat="server"></asp:Label></td>
            </tr>
        </table>
        </div>
</asp:Content>

