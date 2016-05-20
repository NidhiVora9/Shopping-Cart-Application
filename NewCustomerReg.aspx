<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCustomerReg.aspx.cs" Inherits="NewCustomerReg" %>

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
            <td>
                First Name</td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>
                Last Name

            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName"
                    ErrorMessage="Last name cannot be empty"></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td>
                Address

            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" ></asp:TextBox>

            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Address  cannot be empty"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                City</td>
            <td>
                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="City  cannot be empty" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                State</td>
            <td>
                <asp:TextBox ID="txtState" runat="server" ></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtState"
                    ErrorMessage="RequiredFieldValidator" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">
                Zipcode</td>
            <td>
                <asp:TextBox ID="txtZipcode" runat="server"></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtZipcode"
                    ErrorMessage="invalid zipcode" ValidationExpression="\d{5}(-\d{4})?"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td >
                Email Address</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox></td>
            <td>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="invalid email address" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td >
                Credit Card Number</td>
            <td>
                <asp:TextBox ID="txtCCNumber" runat="server" BackColor="#FFFFC0" Width="168px"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>
                Credit Card Type</td>
            <td>
                <asp:DropDownList ID="ddlCCType" runat="server" BackColor="#FFFFC0">
                    <asp:ListItem Value="VISA">Visa</asp:ListItem>
                    <asp:ListItem Value="MASTERCARD">MasterCard</asp:ListItem>
                    <asp:ListItem Value="AMERICANEXPRESS">AmericanExpress</asp:ListItem>
                    <asp:ListItem Value="DISCOVER">Discover</asp:ListItem>
                </asp:DropDownList></td>
            <td >
            </td>
        </tr>
        <tr>
            <td>
                Credit Card Expiration</td>
            <td>
                <asp:TextBox ID="txtCCExpiration" runat="server" BackColor="#FFFFC0" Width="64px"></asp:TextBox>
                (mm/yy)</td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCCExpiration"
                    ErrorMessage="expiration cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td >
                Username</td>
            <td>
                <asp:TextBox ID="txtUsername" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Username cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Password</td>
            <td>
                <asp:TextBox ID="txtPW" runat="server" BackColor="#FFFFC0"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtPW"
                    ErrorMessage="Password cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td>
                Confirm Password</td>
            <td>
                <asp:TextBox ID="txtConfirmPW" runat="server"></asp:TextBox></td>
            <td>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPW"
                    ControlToValidate="txtConfirmPW" ErrorMessage="passwords are not identical"></asp:CompareValidator></td>
        </tr>
        <tr>
            <td >
                Password Hint Question</td>
            <td>
                <asp:TextBox ID="txtPWHintQ" runat="server" ></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPWHintQ"
                    ErrorMessage="password hint cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td >
                Password Hint Answer</td>
            <td>
                <asp:TextBox ID="txtPWHintA" runat="server" ></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPWHintA"
                    ErrorMessage="password hint answer cannot be empty"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td >
            </td>
            <td>
                <asp:Button ID="btnRegister" runat="server" 
                    Text="Register"  OnClick="btnRegister_Click" />
               </td>
            <td>
                <input type="reset" value="Reset" /></td>
        </tr>
    </table>
</asp:Content>

