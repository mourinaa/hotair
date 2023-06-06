<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductRateEdit.aspx.cs" Inherits="ProductRateEdit" Title="ProductRate Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Rate - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ProductRateDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductRateFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ProductRateFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ProductRate not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ProductRateDataSource ID="ProductRateDataSource" runat="server"
			SelectMethod="GetById" oninserting="ProductRateDataSource_Inserting" onupdating="ProductRateDataSource_Inserting"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ProductRateDataSource>
				
		<br />
		
		<asp:Panel ID="AccessType_ProductRatePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="AccessType_ProductRateImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Access Type Product Rate Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="AccessType_ProductRateLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="AccessType_ProductRatePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewAccessType_ProductRate" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewAccessType_ProductRate_SelectedIndexChanged"			 			 
			DataSourceID="AccessType_ProductRateDataSource4"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AccessType_ProductRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Access Type" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Access Type Product Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypAccessType_ProductRate" NavigateUrl="~/admin/AccessType_ProductRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AccessType_ProductRateDataSource ID="AccessType_ProductRateDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AccessType_ProductRateProperty Name="AccessType"/> 
					<data:AccessType_ProductRateProperty Name="ProductRate"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AccessType_ProductRateFilter  Column="ProductRateId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AccessType_ProductRateDataSource>		
		
		
		<br />
		</asp:Panel>
		

<ajaxToolkit:CollapsiblePanelExtender ID="cpeAccessType_ProductRate" runat="Server" TargetControlID="AccessType_ProductRatePanel1"
            ExpandControlID="AccessType_ProductRatePanel2" CollapseControlID="AccessType_ProductRatePanel2" Collapsed="True"
            TextLabelID="AccessType_ProductRateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="AccessType_ProductRateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

</asp:Content>

