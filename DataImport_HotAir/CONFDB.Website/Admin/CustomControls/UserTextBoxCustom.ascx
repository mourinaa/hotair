<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserTextBoxCustom.ascx.cs" Inherits="UserTextBoxCustom" %>
<%@ Register Src="~/Admin/CustomControls/UserGridCustom.ascx" TagName="UserGridCustom" TagPrefix="uc1" %>

<%--NOTE: Used when adding a new User in the Customer and Moderator aspx pages. Placed in user control as UpatePanel wasn't working.
NOTE2: Couldn't get this to work inside of the FormView control so had to put the code in the FormView on the Page.
--%>

    <asp:UpdatePanel ID="UpdatePanelUser" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <tr valign="baseline">
                <td class="literal">
                    <asp:Label ID="lbldataUserId" runat="server" Text="User Login:" CssClass="ToolTipWithHelp"
                        ToolTip="Enter a unique user name and password to create a web login." AssociatedControlID="txtUserName" />
                    <asp:Button ID="btnCheckUser" runat="server" Text="Check User" OnClick="btnCheckUser_Click"  />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelUser" DynamicLayout="false" DisplayAfter="1">
                        <ProgressTemplate>Checking...</ProgressTemplate>
                    </asp:UpdateProgress> 
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    <%--In case JS turned off. Server side check done.--%>
                    <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: User name is not unique. Please select a new one and try your request again." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtUserName" 
                            WatermarkCssClass="watermarked" WatermarkText="<Enter User Name>" />
                    <br />
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                     <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidPassword" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: Password is invalid. It must be a minimum of length of 8. Please select a new one and try your request again." />
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtPassword" 
                            WatermarkCssClass="watermarked" WatermarkText="<Enter Password>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword" 
                            ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8." Display="Dynamic"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </ContentTemplate>
    </asp:UpdatePanel>             
