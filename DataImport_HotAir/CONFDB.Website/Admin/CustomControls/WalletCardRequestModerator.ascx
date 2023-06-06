<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WalletCardRequestModerator.ascx.cs" Inherits="WalletCardRequestModerator" %>
<asp:UpdatePanel ID="UpdatePanelWalletCardRequestModerator" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelWalletCardRequestModerator"
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
        <table id="tblWalletCardRequest" runat="server" visible="<%# this.Visible %>" class="TableStyle1">
            <tr class="TableStyle1-header">
                <th>
                    <asp:Label ID="Label1" runat="server" CssClass="NormalWithHelp" Text="Notes"
                    ToolTip="Optional - Enter any notes for this request."></asp:Label>
                </th>
                <th>
                </th>
                <th>
                </th>
            </tr>
            <tr align="center" valign="baseline">
                <td>
                    <asp:TextBox ID="txtNotes" runat="server" CssClass="Normal" MaxLength="500" TextMode="MultiLine" Rows="4"
                    Width="300px" ToolTip="Optional - Enter any notes for this request."></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="cmdSend" runat="server" CssClass="Normal" Text="Send Request" OnClick="cmdSend_Click" /></td>
                <td style="width: 250px">
                    <asp:Label ID="lblResults" runat="server" CssClass="NormalGreen"></asp:Label></td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
