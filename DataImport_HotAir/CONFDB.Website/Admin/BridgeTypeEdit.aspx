<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BridgeTypeEdit.aspx.cs" Inherits="BridgeTypeEdit" Title="BridgeType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bridge Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="BridgeTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>BridgeType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:BridgeTypeDataSource ID="BridgeTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:BridgeTypeDataSource>
		
		<br />

		<asp:Panel ID="BridgePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="BridgeImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Bridge Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="BridgeLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="BridgePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewBridge" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewBridge_SelectedIndexChanged"			 			 
			DataSourceID="BridgeDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Bridge.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="IpAddress" HeaderText="Ip Address" SortExpression="[IPAddress]" />				
				<asp:BoundField DataField="WebRequestSecurityToken" HeaderText="Web Request Security Token" SortExpression="[WebRequestSecurityToken]" />				
				<asp:BoundField DataField="WebRequestApiurl" HeaderText="Web Request Apiurl" SortExpression="[WebRequestAPIURL]" />				
				<asp:BoundField DataField="WebRequestMethod" HeaderText="Web Request Method" SortExpression="[WebRequestMethod]" />				
				<asp:BoundField DataField="WebRequestContentType" HeaderText="Web Request Content Type" SortExpression="[WebRequestContentType]" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" />				
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]" />				
				<data:HyperLinkField HeaderText="Bridge Type Id" DataNavigateUrlFormatString="BridgeTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DbConnectionString" HeaderText="Db Connection String" SortExpression="[DBConnectionString]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Bridge Found! </b>
				<asp:HyperLink runat="server" ID="hypBridge" NavigateUrl="~/admin/BridgeEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BridgeDataSource ID="BridgeDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BridgeProperty Name="BridgeType"/> 
					<%--<data:BridgeProperty Name="BridgeQueueCollection" />--%>
					<%--<data:BridgeProperty Name="RatedCdrCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BridgeFilter  Column="BridgeTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BridgeDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeBridge" runat="Server" TargetControlID="BridgePanel1"
            ExpandControlID="BridgePanel2" CollapseControlID="BridgePanel2" Collapsed="True"
            TextLabelID="BridgeLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="BridgeImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

