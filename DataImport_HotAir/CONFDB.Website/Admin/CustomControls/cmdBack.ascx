<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cmdBack.ascx.cs" Inherits="cmdBack" %>
<asp:Button ID="btnBack" runat="server" CausesValidation="False" OnClick="cmdBack_Click"
    Text="<%# this.Text %>" CssClass="<%# this.CssClass %>" Visible="<%# this.Visible %>" Width="80px" EnableViewState="true" />
&nbsp;
