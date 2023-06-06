<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EmailsModerator.ascx.cs" Inherits="EmailsModerator" %>
<asp:UpdatePanel ID="UpdatePanelEmailTemplateModerator" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelEmailTemplateModerator"
            DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <div class="">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                    Please Wait...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control.--%>
        <asp:Label Visible="false" ID="lblModeratorID" runat="server" />
        <table id="tblEmailTemplate" runat="server" visible="<%# this.Visible %>" class="TableStyle1">
            <tr class="TableStyle1-header">
                <th>
                    <asp:Label ID="Label1" runat="server" CssClass="Normal" Text="Email Template"></asp:Label>
                </th>
                <th>
                    <asp:Label ID="Label2" runat="server" CssClass="Normal" Text="Send To Customer Admin"></asp:Label></th>
                <th>
                    <asp:Label ID="Label3" runat="server" CssClass="Normal" Text="Send To Moderator"></asp:Label></th>
<%--JS Mod: Dec 9/2014 - use default from database settings, so don't pass anything to web services.
                <th>
                    <asp:Label ID="Label4" runat="server" CssClass="Normal" Text="Include Attachment"></asp:Label></th>
--%>
                <th style="width: 135px">
                    <asp:Label ID="Label5" runat="server" CssClass="NormalWithHelp" Text="CC List"
                        ToolTip="A semi-colon delimited list of people you wish copy on this email."></asp:Label></th>
                <th>
                </th>
                <th>
                </th>
            </tr>
            <tr align="center" valign="baseline">
                <td>
                    <asp:DropDownList ID="ddlEmailTemplate" runat="server" CssClass="Normal" DataValueField="TemplateName"
                        DataTextField="Description">
                    </asp:DropDownList></td>
                <td>
                    <asp:CheckBox ID="chkSendToCustomer" runat="server" CssClass="Normal" Checked="False"
                        TextAlign="Left"></asp:CheckBox></td>
                <td>
                    <asp:CheckBox ID="chkSendToMod" runat="server" CssClass="Normal" Checked="False"
                        TextAlign="Left"></asp:CheckBox></td>
<%--JS Mod: Dec 9/2014 - use default from database settings, so don't pass anything to web services.
                <td>
                    <asp:CheckBox ID="chkIncludeAttachment" runat="server" CssClass="Normal" Checked="False"
                        TextAlign="Left"></asp:CheckBox></td>
--%>
                <td style="width: 135px">
                    <asp:TextBox ID="txtCCList" runat="server" CssClass="Normal" ToolTip="A semi-colon delimited list of people you wish copy on this email."></asp:TextBox></td>
                <td>
                    <asp:Button ID="cmdSendEmail" runat="server" CssClass="Normal" Text="Send Email" OnClick="cmdSendEmail_Click" /></td>
                <td style="width: 250px">
                    <asp:Label ID="lblResults" runat="server" CssClass="NormalGreen"></asp:Label></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
