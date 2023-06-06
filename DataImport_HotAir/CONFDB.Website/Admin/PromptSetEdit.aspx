<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PromptSetEdit.aspx.cs" Inherits="PromptSetEdit" Title="PromptSet Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Prompt Set - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="PromptSetDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PromptSetFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/PromptSetFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>PromptSet not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:PromptSetDataSource ID="PromptSetDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:PromptSetDataSource>
		
		<br />

		<asp:Panel ID="DnisPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="DnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Dnis Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="DnisLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="DnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewDnis" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewDnis_SelectedIndexChanged"			 			 
			DataSourceID="DnisDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Dnis.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Access Type Id" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Dnis Type Id" DataNavigateUrlFormatString="DnisTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DnisTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DnisNumber" HeaderText="Dnis Number" SortExpression="[DNISNumber]" />				
				<asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />				
				<data:HyperLinkField HeaderText="Call Flow Id" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Prompt Set Id" DataNavigateUrlFormatString="PromptSetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PromptSetIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Dnis Found! </b>
				<asp:HyperLink runat="server" ID="hypDnis" NavigateUrl="~/admin/DnisEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:DnisDataSource ID="DnisDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DnisProperty Name="AccessType"/> 
					<data:DnisProperty Name="CallFlow"/> 
					<data:DnisProperty Name="DnisType"/> 
					<data:DnisProperty Name="PromptSet"/> 
					<data:DnisProperty Name="Wholesaler"/> 
					<%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
					<%--<data:DnisProperty Name="Moderator_DnisCollection" />--%>
					<%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
					<%--<data:DnisProperty Name="Customer_DnisCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:DnisFilter  Column="PromptSetId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:DnisDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeDnis" runat="Server" TargetControlID="DnisPanel1"
            ExpandControlID="DnisPanel2" CollapseControlID="DnisPanel2" Collapsed="True"
            TextLabelID="DnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="DnisImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

