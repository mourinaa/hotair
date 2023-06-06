<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturesModerator.ascx.cs" Inherits="FeaturesModerator" %>
<asp:UpdatePanel ID="UpdatePanelFeaturesCustomer" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelFeaturesCustomer" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
            <div class="">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" /> Please Wait...
            </div>
            </ProgressTemplate>
        </asp:UpdateProgress>       
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.--%>
        <asp:Label Visible="false" ID="lblModeratorID" runat="server" />
        <data:EntityGridView ID="GridViewFeature" runat="server" AutoGenerateColumns="False" SkinID="CustomGrid"
            DataKeyNames="Moderator_FeatureID" AllowMultiColumnSorting="False" DefaultSortDirection="Ascending"
            ExcelExportFileName="Export_Feature.xls" PageSize="20" PageSelectorPageSizeInterval="20"
            OnPageIndexChanging="GridViewFeature_PageIndexChanging" OnSelectedIndexChanged="GridViewFeature_SelectedIndexChanged"
            AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" RecordsCount="0"
            OnPageSizeChanged="GridViewFeature_PageSizeChanged" 
            AllowPaging="false"
            Visible="<%# this.Visible %>" Enabled="<%# this.Enabled %>"
            >
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Save" />
                <asp:BoundField DataField="Wholesaler_ProductName" HeaderText="Product" />
                <asp:TemplateField HeaderText="Feature">
                    <ItemTemplate>
                        <asp:Label ID="lblFeatureDisplayName" runat="server" CssClass="ToolTipWithHelp" Text='<%# Eval("FeatureDisplayName") %>' ToolTip='<%# Eval("FeatureDescription") %>'></asp:Label>
                        <asp:Label ID="lblFeatureID" Visible="False" runat="server" Text='<%# Eval("Moderator_FeatureFeatureID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Feature Option">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlFeatureOption" runat="server" width="200px"
                        DataSource='<%# GetFeatureOptionByFeatureID(Eval("Moderator_FeatureFeatureID").ToString()) %>' 
                        DataValueField="ID" DataTextField="DisplayName" SelectedValue='<%# Eval("Moderator_FeatureFeatureOptionID").ToString() %>' 
                        ToolTip='<%# Eval("FeatureOptionDescription") %>'
                        />
				    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <b>No Feature Found! </b>
            </EmptyDataTemplate>
        </data:EntityGridView>
    </ContentTemplate>
</asp:UpdatePanel>

