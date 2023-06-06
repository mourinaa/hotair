<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signon.aspx.cs" Inherits="signon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Redback Conferencing - Admin Site</title>
</head>
<body>
   <form id="form1" runat="server" defaultbutton="btnSubmit">
    <table width="" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td colspan="2" align="left" valign="top" style="width:880px">
            <div id="header" style="background-image: url(Images/header.gif);">
	            <img src="Images/logo.gif" width="200" height="80"/>
            </div>
        </td>
    </tr>
    <tr><td colspan="2">    
        <H2>Welcome to Redback Conferencing Admin Portal</H2>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="LabelUSerID" runat="server" CssClass="label" Text="User Name:"></asp:Label>&nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtBoxUserID" runat="server" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserID" runat="server"  ControlToValidate="txtBoxUserID" ErrorMessage="User ID Required">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="labelPwd" runat="server" CssClass="label" Text="Password:"></asp:Label>&nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtBoxPwd" runat="server" TextMode="Password" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBoxPwd" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
        </td> 
    </tr>
    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>
        </td>
        <td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        </td>
    </tr>

    <tr><td colspan="2">&nbsp;</td></tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="" />
        </td>
    </tr>
    </table>  
    </form>

</body>
</html>
