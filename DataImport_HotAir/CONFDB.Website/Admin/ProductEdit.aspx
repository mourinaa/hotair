<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductEdit.aspx.cs" Inherits="ProductEdit" Title="Product Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Product not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductDataSource ID="ProductDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ProductDataSource>
		
		<br />

		<asp:Panel ID="Wholesaler_ProductPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="Wholesaler_ProductImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Wholesaler Product Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="Wholesaler_ProductLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="Wholesaler_ProductPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewWholesaler_Product" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewWholesaler_Product_SelectedIndexChanged"			 			 
			DataSourceID="Wholesaler_ProductDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Wholesaler_Product.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" SortExpression="[DisplayNameAlt]" />				
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" SortExpression="[DescriptionAlt]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler Product Found! </b>
				<asp:HyperLink runat="server" ID="hypWholesaler_Product" NavigateUrl="~/admin/Wholesaler_ProductEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:Wholesaler_ProductDataSource ID="Wholesaler_ProductDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Wholesaler_ProductProperty Name="Wholesaler"/> 
					<data:Wholesaler_ProductProperty Name="Product"/> 
					<%--<data:Wholesaler_ProductProperty Name="Wholesaler_Product_FeatureCollection" />--%>
					<%--<data:Wholesaler_ProductProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:Wholesaler_ProductFilter  Column="ProductId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:Wholesaler_ProductDataSource>		
		
		<br />
		</asp:Panel>
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
			DataSourceID="ProductRateDataSource2"
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
		
		<data:ProductRateDataSource ID="ProductRateDataSource2" runat="server" SelectMethod="Find"
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
					<%--<data:ProductRateProperty Name="AccessType_ProductRateCollection" />--%>
					<%--<data:ProductRateProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductRateFilter  Column="ProductId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductRateDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="FeaturePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="FeatureImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Feature Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="FeatureLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="FeaturePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewFeature" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewFeature_SelectedIndexChanged"			 			 
			DataSourceID="FeatureDataSource3"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Feature.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" SortExpression="[DisplayNameAlt]" />				
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" SortExpression="[DescriptionAlt]" />				
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="DisplayOnlyToCustomer" HeaderText="Display Only To Customer" SortExpression="[DisplayOnlyToCustomer]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Feature Found! </b>
				<asp:HyperLink runat="server" ID="hypFeature" NavigateUrl="~/admin/FeatureEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:FeatureDataSource ID="FeatureDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FeatureProperty Name="Product"/> 
					<%--<data:FeatureProperty Name="Wholesaler_Product_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="Customer_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="Moderator_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="FeatureOptionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:FeatureFilter  Column="ProductId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:FeatureDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeWholesaler_Product" runat="Server" TargetControlID="Wholesaler_ProductPanel1"
            ExpandControlID="Wholesaler_ProductPanel2" CollapseControlID="Wholesaler_ProductPanel2" Collapsed="True"
            TextLabelID="Wholesaler_ProductLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="Wholesaler_ProductImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRate" runat="Server" TargetControlID="ProductRatePanel1"
            ExpandControlID="ProductRatePanel2" CollapseControlID="ProductRatePanel2" Collapsed="True"
            TextLabelID="ProductRateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ProductRateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeFeature" runat="Server" TargetControlID="FeaturePanel1"
            ExpandControlID="FeaturePanel2" CollapseControlID="FeaturePanel2" Collapsed="True"
            TextLabelID="FeatureLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="FeatureImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

