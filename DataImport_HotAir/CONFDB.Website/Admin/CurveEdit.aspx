<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CurveEdit.aspx.cs" Inherits="CurveEdit" Title="Curve Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Curve - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CurveDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CurveFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CurveFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Curve not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CurveDataSource ID="CurveDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:CurveDataSource>
		
		<br />

		<asp:Panel ID="ForExPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ForExImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">For Ex Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ForExLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ForExPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewForEx" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewForEx_SelectedIndexChanged"			 			 
			DataSourceID="ForExDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ForEx.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="FromCcy" HeaderText="From Ccy" SortExpression="[FromCcy]" />				
				<asp:BoundField DataField="ToCcy" HeaderText="To Ccy" SortExpression="[ToCcy]" />				
				<asp:BoundField DataField="Rate" HeaderText="Rate" SortExpression="[Rate]" />				
				<data:HyperLinkField HeaderText="Curve Id" DataNavigateUrlFormatString="CurveEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CurveIdSource" DataTextField="Description" />
				<asp:BoundField DataField="EffectiveDate" HeaderText="Effective Date" SortExpression="[EffectiveDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No For Ex Found! </b>
				<asp:HyperLink runat="server" ID="hypForEx" NavigateUrl="~/admin/ForExEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ForExDataSource ID="ForExDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ForExProperty Name="Curve"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ForExFilter  Column="CurveId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ForExDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeForEx" runat="Server" TargetControlID="ForExPanel1"
            ExpandControlID="ForExPanel2" CollapseControlID="ForExPanel2" Collapsed="True"
            TextLabelID="ForExLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ForExImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

