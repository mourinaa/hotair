<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CompanyEdit.aspx.cs" Inherits="CompanyEdit" Title="Company Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Company - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<asp:Label ID="lblError" runat="server" CssClass="ErrorMessage" Visible="false"></asp:Label>
		    
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CompanyDataSource" OnItemInserted="FormView1_ItemInserted" OnItemUpdated="FormView1_ItemUpdated" >
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CompanyFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CompanyFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Company not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Submit" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
				<asp:Button runat="server" ID="btnAddNew" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' OnClientClick="javascript:location.href='CompanyEdit.aspx'; return false;" Text="Add New"></asp:Button>
			</FooterTemplate>

		</data:MultiFormView>
        		
		<data:CompanyDataSource ID="CompanyDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
			</Parameters>
		</data:CompanyDataSource>
		<br />
<%--CompanyID hidden control. Used to allow other items ie. datasource control, user controls, etc. 
    to bind to it--%>
		<asp:Label ID="lblCompanyID" runat="server" visible="false"></asp:Label>

		<asp:Panel ID="CustomerPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Customer Admin Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerPanel1" runat="server" CssClass="collapsePanel" Height="0">
	    <asp:LinkButton runat="server" ID="hypCustomer" OnClick="hypCustomer_Click" CausesValidation="false">Add New</asp:LinkButton>
        <br />
		<data:EntityGridView ID="GridViewCustomer" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Customer.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField Visible="False" HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Company" DataNavigateUrlFormatString="CompanyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyIdSource" DataTextField="Description" />
				<asp:BoundField DataField="PrimaryContactName" HeaderText="Primary Contact Name" SortExpression="[PrimaryContactName]"  />
				<data:HyperLinkField HeaderText="User Login" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username" />
				<asp:BoundField DataField="PrimaryContactPhoneNumber" HeaderText="Primary Contact Phone Number" SortExpression="[PrimaryContactPhoneNumber]"  />
				<asp:BoundField DataField="PrimaryContactAddress1" HeaderText="Primary Contact Address1" SortExpression="[PrimaryContactAddress1]"  />
				<data:HyperLinkField HeaderText="Primary Contact Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PrimaryContactCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Primary Contact Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PrimaryContactRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingContactName" HeaderText="Billing Contact Name" SortExpression="[BillingContactName]"  />
				<asp:BoundField DataField="BillingContactPhoneNumber" HeaderText="Billing Contact Phone Number" SortExpression="[BillingContactPhoneNumber]"  />
				<asp:BoundField DataField="BillingContactEmailAddress" HeaderText="Billing Contact Email Address" SortExpression="[BillingContactEmailAddress]"  />
				<asp:BoundField DataField="BillingContactAddress1" HeaderText="Billing Contact Address1" SortExpression="[BillingContactAddress1]"  />
				<asp:BoundField DataField="BillingContactAddress2" HeaderText="Billing Contact Address2" SortExpression="[BillingContactAddress2]"  />
				<asp:BoundField DataField="BillingContactCity" HeaderText="Billing Contact City" SortExpression="[BillingContactCity]"  />
				<data:HyperLinkField HeaderText="Billing Contact Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingContactCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Billing Contact Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingContactRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingContactPostalCode" HeaderText="Billing Contact Postal Code" SortExpression="[BillingContactPostalCode]"  />
                <data:HyperLinkField HeaderText="Sales Person" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesPersonIdSource" DataTextField="FullName" />
				<data:HyperLinkField HeaderText="Vertical" DataNavigateUrlFormatString="VerticalEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="VerticalIdSource" DataTextField="Description" />
                <asp:BoundField DataField="BillingPeriodCutoff" HeaderText="Billing Cutoff"  SortExpression="BillingPeriodCutoff" />
				<asp:CheckBoxField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No customer found or you don't have permissions to access this customer. </b>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDataSource ID="CustomerDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerProperty Name="Company"/> 
					<%--<data:CustomerProperty Name="Currency"/>--%> 
					<data:CustomerProperty Name="Country"/> 
					<data:CustomerProperty Name="State"/> 
					<data:CustomerProperty Name="User"/> 
					<data:CustomerProperty Name="SalesPerson"/> 
					<%--<data:CustomerProperty Name="Taxable"/> --%>
					<data:CustomerProperty Name="Vertical"/> 
					<data:CustomerProperty Name="Wholesaler"/> 
					<%--<data:CustomerProperty Name="TicketCollection" />--%>
					<%--<data:CustomerProperty Name="CustomerDocumentCollection" />--%>
					<%--<data:CustomerProperty Name="ProductRateValueCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionRuleCollection" />--%>
					<%--<data:CustomerProperty Name="CustomerTransactionCollection" />--%>
					<%--<data:CustomerProperty Name="ParticipantListCollection" />--%>
					<%--<data:CustomerProperty Name="DepartmentCollection" />--%>
					<%--<data:CustomerProperty Name="Customer_DnisCollection" />--%>
					<%--<data:CustomerProperty Name="DnisidDnisCollection_From_Customer_Dnis" />--%>
					<%--<data:CustomerProperty Name="Customer_FeatureCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionCollection" />--%>
					<%--<data:CustomerProperty Name="ModeratorCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerFilter Column="CompanyId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDataSource>		
		
		<br />
		</asp:Panel>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer" runat="Server" TargetControlID="CustomerPanel1"
            ExpandControlID="CustomerPanel2" CollapseControlID="CustomerPanel2" Collapsed="False"
            TextLabelID="CustomerLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

