<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeFile="AccessTypeEdit.aspx.cs" Inherits="AccessTypeEdit"
    Title="AccessType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Access Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="AccessTypeDataSource">
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/AccessTypeFields.ascx" />
        </EditItemTemplatePaths>
        <InsertItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/AccessTypeFields.ascx" />
        </InsertItemTemplatePaths>
        <EmptyDataTemplate>
            <b>AccessType not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
            <asp:Button Visible="true" runat="server" ID="AddNewButton" OnClientClick="javascript:location.href='AccessTypeEdit.aspx'; return false;"
                Text="Add New"></asp:Button>
        </FooterTemplate>
    </data:MultiFormView>
    <data:AccessTypeDataSource ID="AccessTypeDataSource" runat="server" SelectMethod="GetById">
        <Parameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
        </Parameters>
    </data:AccessTypeDataSource>
    <br />
    <asp:Panel ID="DnisPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="DnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Dnis Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="DnisLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="DnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
        <data:EntityGridView ID="GridViewDnis" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GridViewDnis_SelectedIndexChanged" DataSourceID="DnisDataSource1"
            DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending"
            ExcelExportFileName="Export_Dnis.xls" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
                <data:HyperLinkField HeaderText="Access Type Id" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
                <data:HyperLinkField HeaderText="Dnis Type Id" DataNavigateUrlFormatString="DnisTypeEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="DnisTypeIdSource" DataTextField="Name" />
                <asp:BoundField DataField="DnisNumber" HeaderText="Dnis Number" SortExpression="[DNISNumber]" />
                <asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />
                <asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />
                <asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />
                <data:HyperLinkField HeaderText="Call Flow Id" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
                <data:HyperLinkField HeaderText="Prompt Set Id" DataNavigateUrlFormatString="PromptSetEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="PromptSetIdSource" DataTextField="Name" />
            </Columns>
            <EmptyDataTemplate>
                <b>No Dnis Found! </b>
                <asp:HyperLink runat="server" ID="hypDnis" NavigateUrl="~/admin/DnisEdit.aspx">Add New</asp:HyperLink>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:DnisDataSource ID="DnisDataSource1" runat="server" SelectMethod="Find" EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:DnisProperty Name="Wholesaler" />
                    <data:DnisProperty Name="AccessType" />
                    <data:DnisProperty Name="DnisType" />
                    <data:DnisProperty Name="PromptSet" />
                    <data:DnisProperty Name="CallFlow" />
                    <%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
                    <%--<data:DnisProperty Name="Moderator_DnisCollection" />--%>
                    <%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
                    <%--<data:DnisProperty Name="Customer_DnisCollection" />--%>
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <data:SqlParameter Name="Parameters">
                    <Filters>
                        <data:DnisFilter Column="AccessTypeId" QueryStringField="Id" />
                    </Filters>
                </data:SqlParameter>
                <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:DnisDataSource>
        <br />
    </asp:Panel>
    <asp:Panel ID="AccessType_ProductRatePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="AccessType_ProductRateImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Access Type Product Rate Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="AccessType_ProductRateLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="AccessType_ProductRatePanel1" runat="server" CssClass="collapsePanel"
        Height="0">
        <data:EntityGridView ID="GridViewAccessType_ProductRate" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GridViewAccessType_ProductRate_SelectedIndexChanged"
            DataSourceID="AccessType_ProductRateDataSource3" DataKeyNames="Id" AllowMultiColumnSorting="false"
            DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_AccessType_ProductRate.xls"
            Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <data:HyperLinkField HeaderText="Access Type" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
                <data:HyperLinkField HeaderText="Product Rate" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}"
                    DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
            </Columns>
            <EmptyDataTemplate>
                <b>No Access Type Product Rate Found! </b>
                <asp:HyperLink runat="server" ID="hypAccessType_ProductRate" NavigateUrl="~/admin/AccessType_ProductRateEdit.aspx">Add New</asp:HyperLink>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:AccessType_ProductRateDataSource ID="AccessType_ProductRateDataSource3" runat="server"
            SelectMethod="Find" EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:AccessType_ProductRateProperty Name="AccessType" />
                    <data:AccessType_ProductRateProperty Name="ProductRate" />
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <data:SqlParameter Name="Parameters">
                    <Filters>
                        <data:AccessType_ProductRateFilter Column="AccessTypeId" QueryStringField="Id" />
                    </Filters>
                </data:SqlParameter>
                <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:AccessType_ProductRateDataSource>
        <br />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDnis" runat="Server" TargetControlID="DnisPanel1"
        ExpandControlID="DnisPanel2" CollapseControlID="DnisPanel2" Collapsed="True"
        TextLabelID="DnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="DnisImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeAccessType_ProductRate" runat="Server"
        TargetControlID="AccessType_ProductRatePanel1" ExpandControlID="AccessType_ProductRatePanel2"
        CollapseControlID="AccessType_ProductRatePanel2" Collapsed="True" TextLabelID="AccessType_ProductRateLabel"
        ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="AccessType_ProductRateImage"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
</asp:Content>
