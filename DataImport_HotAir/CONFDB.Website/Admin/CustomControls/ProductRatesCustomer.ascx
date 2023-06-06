<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRatesCustomer.ascx.cs"
    Inherits="ProductRatesCustomer" %>
<asp:UpdatePanel ID="UpdatePanelProductRateValueCustomer" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelProductRateValueCustomer"
            DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <div class="">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                    Please Wait...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.--%>
        <asp:Label Visible="false" ID="lblCustomerID" runat="server" />
        <asp:Label ID="Label2" runat="server" Text="Product Type Filter:"></asp:Label>
        <data:EntityDropDownList runat="server" ID="ddlFilterProductName" DataTextField="Name"
            DataValueField="Id" AppendNullItem="true" Required="false" NullItemText="All"
            ErrorText="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterProductName_SelectedIndexChanged" />
        <asp:Label ID="Label1" runat="server" Text="Product Rate Type Filter:"></asp:Label>
        <data:EntityDropDownList runat="server" ID="ddlFilterProdRateTypeName" DataSourceID="ProductRateTypeDataSource"
            DataTextField="DisplayName" DataValueField="Id" AppendNullItem="true" Required="false"
            NullItemText="All" ErrorText="Required" AutoPostBack="true" OnSelectedIndexChanged="ddlFilterProdRateTypeName_SelectedIndexChanged" />
        <data:ProductRateTypeDataSource ID="ProductRateTypeDataSource" runat="server" SelectMethod="GetAll" />
        <data:EntityGridView ID="GridViewProductRateValue" runat="server" AutoGenerateColumns="False"
            DataKeyNames="ProductRateValueID" AllowMultiColumnSorting="False" DefaultSortDirection="Ascending"
            ExcelExportFileName="Export_ProductRateValue.xls" PageSize="20" PageSelectorPageSizeInterval="20"
            OnPageIndexChanging="GridViewProductRateValue_PageIndexChanging" OnSelectedIndexChanged="GridViewProductRateValue_SelectedIndexChanged"
            AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" RecordsCount="0"
            OnPageSizeChanged="GridViewProductRateValue_PageSizeChanged" Visible="<%# this.Visible %>"
            Enabled="<%# this.Enabled %>" OnSorting="GridViewProductRateValue_Sorting">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Save" />
                <asp:BoundField DataField="Wholesaler_ProductName" HeaderText="Product" />
                <asp:BoundField DataField="ProductTypeDisplayName" HeaderText="Product Type" />
                <asp:BoundField DataField="ProductRateDisplayName" HeaderText="Product Rate" SortExpression="[ProductRateDisplayName]" />
                <asp:TemplateField HeaderText="Sell Rate">
                    <ItemTemplate>
                        <asp:TextBox ID="txtSellRate" runat="server" Text='<%# Eval("ProductRateValueSellRate") %>'
                            Width="100px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProductRateValueSellRateCurrencyID" HeaderText="Sell Rate Currency" />
                <asp:BoundField DataField="ProductRateTypeDisplayName" HeaderText="Product Rate Type" />
            </Columns>
            <EmptyDataTemplate>
                <b>No Product Rate Value Found! </b>
            </EmptyDataTemplate>
        </data:EntityGridView>
    </ContentTemplate>
</asp:UpdatePanel>
