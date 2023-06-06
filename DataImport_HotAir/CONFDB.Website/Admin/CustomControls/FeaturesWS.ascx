<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturesWS.ascx.cs" Inherits="FeaturesWS" %>
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
        <asp:Label Visible="false" ID="lblWholesalerID" runat="server" />
        <data:EntityGridView ID="GridViewFeature" runat="server" AutoGenerateColumns="False" SkinID="CustomGrid"
            DataKeyNames="Wholesaler_Product_FeatureID" AllowMultiColumnSorting="False" DefaultSortDirection="Ascending"
            ExcelExportFileName="Export_Feature.xls" PageSize="20" PageSelectorPageSizeInterval="20"
            OnPageIndexChanging="GridViewFeature_PageIndexChanging" OnSelectedIndexChanged="GridViewFeature_SelectedIndexChanged"
            AllowExportToExcel="True" AllowSorting="True" ExportToExcelText="Excel" RecordsCount="0"
            OnPageSizeChanged="GridViewFeature_PageSizeChanged" 
            AllowPaging="false"
            Visible="<%# this.Visible %>" Enabled="<%# this.Enabled %>"
            >
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Save" />
                <asp:TemplateField HeaderText="Update Customers" Visible="false">
                    <itemtemplate>
                        <%--Not implemented yet.--%>
                        <asp:CheckBox ID="chkUpdateCustomer" runat="server" Checked="false" CssClass="ToolTipWithHelp" ToolTip="If selected then changes made to the Feature setting will be pushed down to all the Customers."  />
				    </itemtemplate>
                    <itemstyle horizontalalign="Center"></itemstyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Update Moderators" Visible="false">
                    <itemtemplate>
                        <%--Not implemented yet.--%>
                        <asp:CheckBox ID="chkUpdateModerator" runat="server" Checked="false" CssClass="ToolTipWithHelp" ToolTip="If selected then changes made to the Feature setting will be pushed down to all the Moderators."  />
				    </itemtemplate>
                    <itemstyle horizontalalign="Center"></itemstyle>
                </asp:TemplateField>
                <asp:BoundField DataField="Wholesaler_ProductName" HeaderText="Product" />
                <asp:TemplateField HeaderText="Feature">
                    <ItemTemplate>
                        <asp:Label ID="lblFeatureDisplayName" runat="server" CssClass="ToolTipWithHelp" Text='<%# Eval("FeatureDisplayName") %>' ToolTip='<%# Eval("FeatureDescription") %>'></asp:Label>
                        <asp:Label ID="lblFeatureID" Visible="False" runat="server" Text='<%# Eval("Wholesaler_Product_FeatureFeatureID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Feature Option">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlFeatureOption" runat="server" width="200px"
                        DataSource='<%# GetFeatureOptionByFeatureID(Eval("Wholesaler_Product_FeatureFeatureID").ToString()) %>' 
                        DataValueField="ID" DataTextField="DisplayName" SelectedValue='<%# Eval("Wholesaler_Product_FeatureFeatureOptionID").ToString() %>' 
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

