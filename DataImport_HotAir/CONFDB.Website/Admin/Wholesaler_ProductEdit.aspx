<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Wholesaler_ProductEdit.aspx.cs" Inherits="Wholesaler_ProductEdit" Title="Wholesaler_Product Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Wholesaler Product - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="Wholesaler_ProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Wholesaler_ProductFieldsEdit.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Wholesaler_ProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Wholesaler_Product not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:Wholesaler_ProductDataSource ID="Wholesaler_ProductDataSource" runat="server"
			SelectMethod="GetById" OnAfterInserted="Wholesaler_ProductDataSource_AfterInserted" 
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:Wholesaler_ProductDataSource>
		
		<br />

		<asp:Panel ID="Wholesaler_Product_FeaturePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="Wholesaler_Product_FeatureImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Wholesaler Product Feature Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="Wholesaler_Product_FeatureLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="Wholesaler_Product_FeaturePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewWholesaler_Product_Feature" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewWholesaler_Product_Feature_SelectedIndexChanged"			 			 
			DataSourceID="Wholesaler_Product_FeatureDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Wholesaler_Product_Feature.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Product" DataContainer="Wholesaler_ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Feature" DataContainer="FeatureIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Feature Option" DataContainer="FeatureOptionIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="FeatureOptionValue" HeaderText="Feature Option Value" SortExpression="[FeatureOptionValue]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler Product Feature Found! </b>
				<asp:HyperLink runat="server" ID="hypWholesaler_Product_Feature" NavigateUrl="~/admin/Wholesaler_Product_FeatureEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:Wholesaler_Product_FeatureDataSource ID="Wholesaler_Product_FeatureDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Wholesaler_Product_FeatureProperty Name="Wholesaler_Product"/> 
					<data:Wholesaler_Product_FeatureProperty Name="Feature"/> 
					<data:Wholesaler_Product_FeatureProperty Name="FeatureOption"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:Wholesaler_Product_FeatureFilter  Column="Wholesaler_ProductId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:Wholesaler_Product_FeatureDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeWholesaler_Product_Feature" runat="Server" TargetControlID="Wholesaler_Product_FeaturePanel1"
            ExpandControlID="Wholesaler_Product_FeaturePanel2" CollapseControlID="Wholesaler_Product_FeaturePanel2" Collapsed="True"
            TextLabelID="Wholesaler_Product_FeatureLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="Wholesaler_Product_FeatureImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

