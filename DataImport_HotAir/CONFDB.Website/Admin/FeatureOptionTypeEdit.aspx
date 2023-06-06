<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="FeatureOptionTypeEdit.aspx.cs" Inherits="FeatureOptionTypeEdit" Title="FeatureOptionType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Feature Option Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="FeatureOptionTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FeatureOptionTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/FeatureOptionTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>FeatureOptionType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:FeatureOptionTypeDataSource ID="FeatureOptionTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:FeatureOptionTypeDataSource>
		
		<br />

		<asp:Panel ID="FeatureOptionPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="FeatureOptionImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Feature Option Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="FeatureOptionLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="FeatureOptionPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewFeatureOption" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewFeatureOption_SelectedIndexChanged"			 			 
			DataSourceID="FeatureOptionDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_FeatureOption.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Feature Id" DataNavigateUrlFormatString="FeatureEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" SortExpression="[DisplayNameAlt]" />				
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" SortExpression="[DescriptionAlt]" />				
				<asp:BoundField DataField="Value" HeaderText="Value" SortExpression="[Value]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<data:HyperLinkField HeaderText="Feature Option Type Id" DataNavigateUrlFormatString="FeatureOptionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureOptionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="RegularExpression" HeaderText="Regular Expression" SortExpression="[RegularExpression]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Feature Option Found! </b>
				<asp:HyperLink runat="server" ID="hypFeatureOption" NavigateUrl="~/admin/FeatureOptionEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:FeatureOptionDataSource ID="FeatureOptionDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FeatureOptionProperty Name="Feature"/> 
					<data:FeatureOptionProperty Name="FeatureOptionType"/> 
					<%--<data:FeatureOptionProperty Name="Wholesaler_Product_FeatureCollection" />--%>
					<%--<data:FeatureOptionProperty Name="Moderator_FeatureCollection" />--%>
					<%--<data:FeatureOptionProperty Name="Customer_FeatureCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:FeatureOptionFilter  Column="FeatureOptionTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:FeatureOptionDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeFeatureOption" runat="Server" TargetControlID="FeatureOptionPanel1"
            ExpandControlID="FeatureOptionPanel2" CollapseControlID="FeatureOptionPanel2" Collapsed="True"
            TextLabelID="FeatureOptionLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="FeatureOptionImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

