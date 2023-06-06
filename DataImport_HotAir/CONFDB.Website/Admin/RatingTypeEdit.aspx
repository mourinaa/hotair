<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="RatingTypeEdit.aspx.cs" Inherits="RatingTypeEdit" Title="RatingType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Rating Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="RatingTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RatingTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RatingTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>RatingType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:RatingTypeDataSource ID="RatingTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:RatingTypeDataSource>
		
		<br />

		<asp:Panel ID="ProductRatePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ProductRateImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Product Rate Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ProductRateLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ProductRatePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewProductRate" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewProductRate_SelectedIndexChanged"			 			 
			DataSourceID="ProductRateDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Type Id" DataNavigateUrlFormatString="ProductRateTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Interval Id" DataNavigateUrlFormatString="ProductRateIntervalEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIntervalIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Taxable Id" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Country Id" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountryIdSource" DataTextField="Description" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="MinimumTimeBeforeChargedSec" HeaderText="Minimum Time Before Charged Sec" SortExpression="[MinimumTimeBeforeChargedSec]" />				
				<data:HyperLinkField HeaderText="Rating Type Id" DataNavigateUrlFormatString="RatingTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RatingTypeIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypProductRate" NavigateUrl="~/admin/ProductRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductRateDataSource ID="ProductRateDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductRateProperty Name="Country"/> 
					<data:ProductRateProperty Name="RatingType"/> 
					<data:ProductRateProperty Name="Taxable"/> 
					<data:ProductRateProperty Name="ProductRateType"/> 
					<data:ProductRateProperty Name="ProductRateInterval"/> 
					<data:ProductRateProperty Name="Product"/> 
					<%--<data:ProductRateProperty Name="ProductRateValueCollection" />--%>
					<%--<data:ProductRateProperty Name="CommissionCollection" />--%>
					<%--<data:ProductRateProperty Name="AccessTypeIdAccessTypeCollection_From_AccessType_ProductRate" />--%>
					<%--<data:ProductRateProperty Name="AccessType_ProductRateCollection" />--%>
					<%--<data:ProductRateProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductRateFilter  Column="RatingTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductRateDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRate" runat="Server" TargetControlID="ProductRatePanel1"
            ExpandControlID="ProductRatePanel2" CollapseControlID="ProductRatePanel2" Collapsed="True"
            TextLabelID="ProductRateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ProductRateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

