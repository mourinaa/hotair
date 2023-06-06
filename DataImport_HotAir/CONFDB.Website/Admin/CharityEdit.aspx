<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CharityEdit.aspx.cs" Inherits="CharityEdit" Title="Charity Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Charity - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CharityDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CharityFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CharityFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Charity not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CharityDataSource ID="CharityDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:CharityDataSource>
		
		<br />

		<asp:Panel ID="UserPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="UserImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">User Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="UserLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="UserPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewUser" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewUser_SelectedIndexChanged"			 			 
			DataSourceID="UserDataSource1"
			DataKeyNames="UserId"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_User.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Username" HeaderText="Username" SortExpression="[Username]" />				
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]" />				
				<asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="[Telephone]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<data:HyperLinkField HeaderText="Company Id" DataNavigateUrlFormatString="CompanyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyIdSource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesPersonIdSource" DataTextField="FullName" />
				<data:HyperLinkField HeaderText="Role Id" DataNavigateUrlFormatString="RoleEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RoleIdSource" DataTextField="Name" />
				<asp:BoundField DataField="MustChangePassword" HeaderText="Must Change Password" SortExpression="[MustChangePassword]" />				
				<asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="[Address1]" />				
				<asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="[Address2]" />				
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />				
				<data:HyperLinkField HeaderText="Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]" />				
				<data:HyperLinkField HeaderText="Charity Id" DataNavigateUrlFormatString="CharityEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CharityIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WebMemberId" HeaderText="Web Member Id" SortExpression="[WebMemberID]" />				
				<asp:BoundField DataField="UserUniqueId" HeaderText="User Unique Id" SortExpression="[UserUniqueID]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No User Found! </b>
				<asp:HyperLink runat="server" ID="hypUser" NavigateUrl="~/admin/UserEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:UserDataSource ID="UserDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:UserProperty Name="Charity"/> 
					<data:UserProperty Name="Country"/> 
					<data:UserProperty Name="Role"/> 
					<data:UserProperty Name="SalesPerson"/> 
					<data:UserProperty Name="State"/> 
					<data:UserProperty Name="Company"/> 
					<%--<data:UserProperty Name="MarketingServiceIdMarketingServiceCollection_From_User_MarketingService" />--%>
					<%--<data:UserProperty Name="ModeratorCollection" />--%>
					<%--<data:UserProperty Name="User_MarketingServiceCollection" />--%>
					<%--<data:UserProperty Name="CustomerCollection" />--%>
					<%--<data:UserProperty Name="EventManagerCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:UserFilter  Column="CharityId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:UserDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeUser" runat="Server" TargetControlID="UserPanel1"
            ExpandControlID="UserPanel2" CollapseControlID="UserPanel2" Collapsed="True"
            TextLabelID="UserLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="UserImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

