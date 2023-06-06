<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerTransactionTypeEdit.aspx.cs" Inherits="CustomerTransactionTypeEdit" Title="CustomerTransactionType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Transaction Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CustomerTransactionTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerTransactionTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerTransactionTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CustomerTransactionType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CustomerTransactionTypeDataSource ID="CustomerTransactionTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:CustomerTransactionTypeDataSource>
		
		<br />

		<asp:Panel ID="CustomerTransactionPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerTransactionImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Customer Transaction Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerTransactionLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerTransactionPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomerTransaction" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomerTransaction_SelectedIndexChanged"			 			 
			DataSourceID="CustomerTransactionDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CustomerTransaction.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]" />				
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]" />				
				<data:HyperLinkField HeaderText="Customer Transaction Type Id" DataNavigateUrlFormatString="CustomerTransactionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerTransactionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="TransactionDescription" HeaderText="Transaction Description" SortExpression="[TransactionDescription]" />				
				<asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="[TransactionDate]" />				
				<asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="[TransactionAmount]" />				
				<asp:BoundField DataField="LocalTaxRate" HeaderText="Local Tax Rate" SortExpression="[LocalTaxRate]" />				
				<asp:BoundField DataField="FederalTaxRate" HeaderText="Federal Tax Rate" SortExpression="[FederalTaxRate]" />				
				<asp:BoundField DataField="LocalTaxAmount" HeaderText="Local Tax Amount" SortExpression="[LocalTaxAmount]" />				
				<asp:BoundField DataField="FederalTaxAmount" HeaderText="Federal Tax Amount" SortExpression="[FederalTaxAmount]" />				
				<asp:BoundField DataField="TransactionTotal" HeaderText="Transaction Total" SortExpression="[TransactionTotal]" />				
				<asp:BoundField DataField="CustomerBalance" HeaderText="Customer Balance" SortExpression="[CustomerBalance]" />				
				<data:HyperLinkField HeaderText="Wholesaler Product Id" DataNavigateUrlFormatString="Wholesaler_ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="Wholesaler_ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Id" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]" />				
				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression="[SellRate]" />				
				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression="[BuyRate]" />				
				<asp:BoundField DataField="WsTransactionAmount" HeaderText="Ws Transaction Amount" SortExpression="[WSTransactionAmount]" />				
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]" />				
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]" />				
				<asp:BoundField DataField="PostedDate" HeaderText="Posted Date" SortExpression="[PostedDate]" />				
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="PostedToInvoice" HeaderText="Posted To Invoice" SortExpression="[PostedToInvoice]" />				
				<asp:BoundField DataField="PostedToInvoiceDate" HeaderText="Posted To Invoice Date" SortExpression="[PostedToInvoiceDate]" />				
				<asp:BoundField DataField="ElapsedTimeSeconds" HeaderText="Elapsed Time Seconds" SortExpression="[ElapsedTimeSeconds]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Transaction Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomerTransaction" NavigateUrl="~/admin/CustomerTransactionEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerTransactionDataSource ID="CustomerTransactionDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerTransactionProperty Name="CustomerTransactionType"/> 
					<data:CustomerTransactionProperty Name="ProductRate"/> 
					<data:CustomerTransactionProperty Name="Wholesaler_Product"/> 
					<data:CustomerTransactionProperty Name="Wholesaler"/> 
					<data:CustomerTransactionProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerTransactionFilter  Column="CustomerTransactionTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerTransactionDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerTransaction" runat="Server" TargetControlID="CustomerTransactionPanel1"
            ExpandControlID="CustomerTransactionPanel2" CollapseControlID="CustomerTransactionPanel2" Collapsed="True"
            TextLabelID="CustomerTransactionLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerTransactionImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

