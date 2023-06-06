<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeFile="AccessType_ProductRateEdit.aspx.cs" Inherits="AccessType_ProductRateEdit"
    Title="AccessType_ProductRate Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Access Type Product Rate - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanelAccessTypeProductRates" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" CssClass="NormalBold" />
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal" valign="top">
                        <asp:Label ID="lbldataAccessTypeId" runat="server" Text="Access Type:" AssociatedControlID="dataAccessTypeId" /></td>
                    <td valign="top">
                        <data:EntityDropDownList runat="server" ID="dataAccessTypeId" DataSourceID="AccessTypeIdAccessTypeDataSource"
                            DataTextField="Name" DataValueField="Id" AppendNullItem="true" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:AccessTypeDataSource ID="AccessTypeIdAccessTypeDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                    <td class="literal" valign="top">
                        <asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate:" AssociatedControlID="lstProductRates" /></td>
                    <td valign="top">
                        <asp:ListBox runat="server" ID="lstProductRates" DataSourceID="dsDefaultProductRates"
                            DataTextField="DDLDescription" DataValueField="ProductRateId" Rows="10" SelectionMode="multiple"
                            ToolTip="Hold down the CTRL key to select mulitple items." />
                        <data:Vw_DefaultProductRatesDataSource ID="dsDefaultProductRates" runat="server"
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="WhereClause" Value="RatingTypeID <> 4 AND SellRateCurrencyID ='AUD'" ConvertEmptyStringToNull="false" />
                                <data:CustomParameter Name="OrderBy" Value="ProductDisplayOrder, ProductRateTypeDisplayOrder ASC, ProductRateDisplayOrder ASC, ProductRateDisplayName ASC"
                                    ConvertEmptyStringToNull="false" />
                            </Parameters>
                        </data:Vw_DefaultProductRatesDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Insert" OnClick="InsertButton_Click" />
                        <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" OnClick="CancelButton_Click" />
                    </td>
                    <td>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelAccessTypeProductRates" DynamicLayout="false" DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" /> Please Wait...
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress> 
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="AccessType_ProductRatePanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="AccessType_ProductRateImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px;font-weight:bold;">
                        Access Type Product Rate Details</div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="AccessType_ProductRateLabel" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="AccessType_ProductRatePanel1" runat="server" CssClass="collapsePanel"
                Height="0">
                <data:EntityGridView ID="EntityGridView1" runat="server" AutoGenerateColumns="False"
                    DataSourceID="AccessType_ProductRateDataSource1" DataKeyNames="AccessType_ProductRateId"
                    AllowMultiColumnSorting="False" DefaultSortDirection="Ascending" ExcelExportFileName="Export_AccessType_ProductRate.xls"
                    PageSize="50" OnRowDeleting="EntityGridView1_RowDeleting" OnRowUpdating="EntityGridView1_RowUpdating"
                    AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="10"
                    RecordsCount="0">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" CausesValidation="False" />
                        <asp:BoundField DataField="AccessType_ProductRateId" HeaderText="AccessType_ProductRateId" ReadOnly="True" Visible="False" />

                        <asp:TemplateField HeaderText="Access Type Id">
                            <edititemtemplate>
                                <data:EntityDropDownList runat="server" ID="dataAccessTypeIdEdit" DataSourceID="AccessTypeIdAccessTypeDataSource2"
                                    DataTextField="DisplayName" DataValueField="Id" SelectedValue='<%# Bind("AccessTypeId") %>'
                                    AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                                <data:AccessTypeDataSource ID="AccessTypeIdAccessTypeDataSource2" runat="server" SelectMethod="GetAll" />
                            </edititemtemplate>
                            <itemtemplate>
                                <asp:Label runat="server" Text='<%# Bind("AccessTypeId") %>' id="Label1"></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Product Rate Id">
                            <edititemtemplate>
                                <data:EntityDropDownList runat="server" ID="dataProductRateIdEdit" DataSourceID="ProductRateIdProductRateDataSource"
                                    DataTextField="DisplayName" DataValueField="Id" SelectedValue='<%# Bind("ProductRateId") %>'
                                    AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                                <data:ProductRateDataSource ID="ProductRateIdProductRateDataSource" runat="server" SelectMethod="GetAll" />
                            </edititemtemplate>
                            <itemtemplate>
                                <asp:Label runat="server" Text='<%# Bind("ProductRateId") %>' id="Label2"></asp:Label>
                            </itemtemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="AccessTypeDisplayName" HeaderText="Access Type" ReadOnly="True" />
                        <asp:BoundField DataField="ProductRateDisplayName" HeaderText="Product Rate" ReadOnly="True" />
                        <asp:BoundField DataField="ProductRateTypeDisplayName" HeaderText="Product Rate Type" ReadOnly="True" />
                        <asp:BoundField DataField="ProductName" HeaderText="Product" ReadOnly="True" />
                        <asp:BoundField DataField="RatingTypeDisplayName" HeaderText="Rating Type" ReadOnly="True" />
                    </Columns>
                    <EmptyDataTemplate>
                        <b>No Access Type Product Rate Found! </b>
                        <asp:HyperLink runat="server" ID="hypAccessType_ProductRate" NavigateUrl="~/admin/AccessType_ProductRateEdit.aspx">Add New</asp:HyperLink>
                    </EmptyDataTemplate>
                </data:EntityGridView>
                
                <data:Vw_AccessType_ProductRatesDataSource ID="AccessType_ProductRateDataSource1"
                    runat="server" SelectMethod="GetPaged" OnDeleting="AccessType_ProductRateDataSource1_Deleting" OnUpdating="AccessType_ProductRateDataSource1_Updating">
                    <Parameters>
                        <data:CustomParameter Name="OrderBy" Value="ProductDisplayOrder, AccessTypeID ASC, ProductRateTypeDisplayOrder ASC, ProductRateDisplayOrder ASC"
                            ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:Vw_AccessType_ProductRatesDataSource>
                
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeAccessType_ProductRate" runat="Server"
                TargetControlID="AccessType_ProductRatePanel1" ExpandControlID="AccessType_ProductRatePanel2"
                CollapseControlID="AccessType_ProductRatePanel2" Collapsed="True" TextLabelID="AccessType_ProductRateLabel"
                ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="AccessType_ProductRateImage"
                ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                SuppressPostBack="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
