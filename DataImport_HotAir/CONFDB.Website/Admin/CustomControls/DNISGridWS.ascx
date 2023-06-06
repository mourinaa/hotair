<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DNISGridWS.ascx.cs" Inherits="DNISGridWS" %>
<asp:UpdatePanel ID="UpdatePanelDNISWholesaler" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelDNISWholesaler" DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
            <div class="">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" /> Please Wait...
            </div>
            </ProgressTemplate>
        </asp:UpdateProgress>    
        <%--		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" 
		    OnSearchButtonClicked="GridViewSearchPanel1_SearchButtonClicked" >
		    <FieldsToExclude>
		        <data:Field Value="WholesalerID" />
		        <data:Field Value="AccessTypeID" />
		    </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />--%>
        <data:EntityGridView ID="GridViewDnisWholesaler" runat="server" AutoGenerateColumns="False"
            DataSourceID="DnisDataSourceWholesaler" DataKeyNames="Id" AllowMultiColumnSorting="False" AllowSorting="False"
            DefaultSortColumnName="[DisplayOrder]" DefaultSortDirection="Ascending" ExcelExportFileName="Export_Dnis.xls"
            Visible="<%# this.Visible %>" PageSize="20">
            <Columns>
                <%--Force buttons to read-only when not in the right role--%>
                <asp:CommandField ShowEditButton="True" />
                <data:HyperLinkField HeaderText="Dnis Type" DataContainer="DnisTypeIdSource" DataTextField="Name" />
                <asp:BoundField DataField="DnisNumber" HeaderText="Dnis Number" SortExpression="[DNISNumber]" />
                <asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />
                <data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />
                <data:BoundEntityDropDownField HeaderText="Access Type" DataField="AccessTypeId"
                    DataSourceID="AccessTypeDataSource" DataTextField="Name" DataValueField="Id" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />
                <data:BoundRadioButtonField DataField="DefaultOption" HeaderText="Default Option"
                    SortExpression="[DefaultOption]" />
                <data:BoundEntityDropDownField HeaderText="Call Flow" DataField="CallFlowId" DataSourceID="CallFlowDataSource"
                    DataTextField="Name" DataValueField="Id" />
                <data:BoundEntityDropDownField HeaderText="Prompt Set" DataField="PromptSetId" DataSourceID="PromptSetDataSource"
                    DataTextField="Name" DataValueField="Id" />
            </Columns>
            <EmptyDataTemplate>
                <b>No Dnis Found! </b>
                <asp:HyperLink runat="server" ID="hypDnis" NavigateUrl="~/admin/DnisEdit.aspx">Add New</asp:HyperLink>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <br />
        <%--Hide the add new button if not in the correct role--%>
        <asp:Button Visible="<%# this.Visible %>" runat="server" ID="btnDnis" OnClientClick="javascript:location.href='DnisEdit.aspx'; return false;"
            Text="Add New"></asp:Button>
        <data:DnisDataSource ID="DnisDataSourceWholesaler" runat="server" SelectMethod="Find"
            EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:DnisProperty Name="DnisType" />
                    <data:DnisProperty Name="AccessType" />
                    <data:DnisProperty Name="PromptSet" />
                    <data:DnisProperty Name="CallFlow" />
                    <%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
                    <%--<data:DnisProperty Name="Moderator_DnisCollection" /> //Load data from Mod/Dnis table by DNISID --%>
                    <%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
                    <%--<data:DnisProperty Name="Customer_DnisCollection" //Load data from Cust/Dnis table by DNISID/>--%>
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <data:SqlParameter Name="Parameters">
                    <Filters>
                        <data:DnisFilter Column="WholesalerId" DefaultValue="<%$ AppSettings:WholesalerID %>" />
                    </Filters>
                </data:SqlParameter>
                <data:CustomParameter Name="OrderBy" Value="DNISTypeID, DisplayOrder" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:DnisDataSource>
        <data:AccessTypeDataSource ID="AccessTypeDataSource" runat="server" SelectMethod="GetAll"
            CacheDuration="5" EnableCaching="true" />
        <data:CallFlowDataSource ID="CallFlowDataSource" runat="server" SelectMethod="GetAll"
            CacheDuration="5" EnableCaching="true" />
        <data:PromptSetDataSource ID="PromptSetDataSource" runat="server" SelectMethod="GetAll"
            CacheDuration="5" EnableCaching="true" />
    </ContentTemplate>
</asp:UpdatePanel>
