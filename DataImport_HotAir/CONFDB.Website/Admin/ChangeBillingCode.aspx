<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeBillingCode.aspx.cs" Inherits="ChangeBillingCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="css/default.css" rel="stylesheet" type="text/css" />

<title>Untitled Page</title>

<script>    
function CloseAndRefresh()
{
    window.opener.document.forms[0].submit();    
    self.close();
    return false;
}
</script>
   
</head>



<body onload="self.focus();">
    <form id="form1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" style="width: 460px; height:100px">
    <tr>
    <td colspan="2" style="width: 548px"><h3>Cost Code</h3></td>
    </tr>
    <tr>
        <td>Please Enter a Cost Code:&nbsp<br />(Set it to blank to remove code)</td>
        <td valign="top"><asp:TextBox ID="txtBillingCode" runat="server" Width="220px"></asp:TextBox> </td>
    </tr>
        <tr>
            <td  colspan="2" align="center">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label></td>
        </tr>
    <tr><td colspan="2" align="center">
        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="special" OnClick="btnSubmit_Click" >Submit</asp:LinkButton>
        &nbsp;
        </td>
    </tr>
        <tr><td colspan="2">&nbsp;</td></tr>

    <tr><td colspan="2" align="center" style="height: 20px">
        <a href="javascript:CloseAndRefresh()" class="special">Close Window</a> 
        </td>
    </tr>
    </table> 
     
    </form>
</body>
</html>
