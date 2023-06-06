<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="TestPage.aspx.cs" Inherits="Admin_TestPage" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Panel ID="CustomerDnisPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="CustomerDnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                DNIS Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="CustomerDnisLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="CustomerDnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
DNIS Details
    </asp:Panel>
   testing
    <asp:Panel ID="MarketingServicePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="MarketingServiceImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Marketing Services</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="MarketingServiceLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="MarketingServicePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <asp:Label ID="Label1" runat="server">Testing Panel</asp:Label>
        <br />
    </asp:Panel>



    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerDnis" runat="Server" TargetControlID="CustomerDnisPanel1"
        ExpandControlID="CustomerDnisPanel2" CollapseControlID="CustomerDnisPanel2" Collapsed="True"
        TextLabelID="CustomerDnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="CustomerDnisImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
                
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeMarketingService" runat="Server" TargetControlID="MarketingServicePanel1" 
        ExpandControlID="MarketingServicePanel2" CollapseControlID="MarketingServicePanel2" Collapsed="True"
        TextLabelID="MarketingServiceLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" 
        ImageControlID="MarketingServiceImage" ExpandedImage="~/images/collapse_blue.jpg" 
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />

</asp:Content>

