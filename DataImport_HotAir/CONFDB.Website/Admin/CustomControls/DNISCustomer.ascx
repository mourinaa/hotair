<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DNISCustomer.ascx.cs" Inherits="DNISCustomer" %>

<asp:UpdatePanel ID="UpdatePanelDNISCustomer" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelDNISCustomer" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
            <div class="">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" /> Please Wait...
            </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.--%>
        <asp:Label Visible="false" ID="lblCustomerID" runat="server" />
        <data:EntityGridView ID="GridViewDnisCustomer" runat="server" SkinID="CustomGrid"
            AutoGenerateColumns="False" DataSourceID="DnisDataSourceCustomer" DataKeyNames="Id"
            AllowMultiColumnSorting="false" ExcelExportFileName="Export_Dnis.xls" OnSelectedIndexChanged="GridViewDnisCustomer_SelectedIndexChanged"
            Visible="<%# this.Visible %>" Enabled="<%# this.Enabled %>">
            <Columns>
                <asp:CommandField ShowSelectButton="True" SelectText="Save" />
                <asp:TemplateField HeaderText="Update Moderators">
                    <itemtemplate>
                        <asp:CheckBox ID="chkUpdateModerators" runat="server" Checked="false" CssClass="ToolTipWithHelp" ToolTip="If selected then changes made to the DNIS setting will be pushed down to all the Moderators."  />
				    </itemtemplate>
                    <itemstyle horizontalalign="Center"></itemstyle>
                </asp:TemplateField>
                <data:HyperLinkField HeaderText="Dnis Type" DataContainer="DnisTypeIdSource" DataTextField="DisplayName" />
                <asp:TemplateField HeaderText="DNIS">
                    <itemtemplate>                 
                        <asp:DropDownList ID="ddlDNIS" runat="server" DataSource='<%# GetDNISByDNISTypeID(Eval("DnisTypeID").ToString()) %>' DataValueField="DNISID" DataTextField="DDLInfo" SelectedValue='<%# Eval("ID").ToString() %>' />
                        <asp:Label Visible="false" ID="lblDNISTypeID" runat="server" Text='<%# Eval("DnisTypeID") %>'/> <%--Hidden value used in Update--%>
                    </itemtemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <b>No Dnis Found! </b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:DnisDataSource ID="DnisDataSourceCustomer" runat="server" SelectMethod="GetByCustomerIdFromCustomer_Dnis"
            EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:DnisProperty Name="DnisType" />
                    <data:DnisProperty Name="PromptSet" />
                    <data:DnisProperty Name="CallFlow" />
                    <%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
                    <%--<data:DnisProperty Name="Moderator_DnisCollection" /> //Load data from Mod/Dnis table by DNISID --%>
                    <%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
                    <%--<data:DnisProperty Name="Customer_DnisCollection" />--%>
                    <%--//Load data from Cust/Dnis table by DNISID--%>
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <%--NetTiers Controls don't handle the <%# this.CustomerID %> syntax correctly used a ControlParameter so use a hidden control.--%>
                <asp:ControlParameter Name="CustomerId" ControlID="lblCustomerID" PropertyName="Text"
                    Type="int32" />
                <%--<data:CustomParameter Name="CustomerId" Value='14' Type="int32" ConvertEmptyStringToNull="false" />--%>
                <data:CustomParameter Name="OrderBy" Value="DNISTypeID, DisplayOrder" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:DnisDataSource>
    </ContentTemplate>
</asp:UpdatePanel>