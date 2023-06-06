<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeFile="User_MarketingServiceEdit.aspx.cs" Inherits="User_MarketingServiceEdit"
    Title="User_MarketingService Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    User Marketing Service - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:MultiFormView ID="FormView1" DataKeyNames="MarketingServiceId, UserId" runat="server"
        DataSourceID="User_MarketingServiceDataSource">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/User_MarketingServiceFields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/User_MarketingServiceFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>User_MarketingService not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:User_MarketingServiceDataSource ID="User_MarketingServiceDataSource" runat="server"
        SelectMethod="GetByMarketingServiceIdUserId">
        <Parameters>
            <asp:QueryStringParameter Name="MarketingServiceId" QueryStringField="MarketingServiceId"
                Type="String" />
            <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
        </Parameters>
    </data:User_MarketingServiceDataSource>
    <br />
</asp:Content>
