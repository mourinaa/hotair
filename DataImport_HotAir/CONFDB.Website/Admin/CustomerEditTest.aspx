<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerEditTest.aspx.cs" Inherits="CustomerEdit" Title="Customer Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CustomerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Customer not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CustomerDataSource ID="CustomerDataSource" runat="server"
			SelectMethod="GetById" OnAfterInserted="CustomerDataSource_AfterInserted" 
			InsertDateTimeNames="CreatedDate,LastModified"
			UpdateDateTimeNames="LastModified" OnInserting="CustomerDataSource_Inserting"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
			</Parameters>
		</data:CustomerDataSource>
		
		<br />

		<asp:Panel ID="ProductRateValuePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ProductRateValueImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Product Rate Value Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ProductRateValueLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ProductRateValuePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewProductRateValue" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewProductRateValue_SelectedIndexChanged"			 			 
			DataSourceID="ProductRateValueDataSource3"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductRateValue.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
<%--				<data:HyperLinkField HeaderText="Product Rate" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
--%>				<data:HyperLinkField HeaderText="Product Rate" DataContainer="ProductRateIdSource" DataTextField="Name" />

				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression="[SellRate]" />				
<%--				<data:HyperLinkField HeaderText="Sell Rate Currency" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SellRateCurrencyIdSource" DataTextField="LongName" />
--%>				<data:HyperLinkField HeaderText="Sell Rate Currency" DataContainer="SellRateCurrencyIdSource" DataTextField="LongName" />

<%--				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression="[BuyRate]" />				
				<asp:BoundField DataField="BuyRateCurrencyId" HeaderText="Buy Rate Currency Id" SortExpression="[BuyRateCurrencyID]" />				
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />				
				<asp:BoundField DataField="StartDate" HeaderText="Start Date" SortExpression="[StartDate]" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
--%>			</Columns>
			<EmptyDataTemplate>
				<b>No Product Rate Value Found! </b>
				<asp:HyperLink runat="server" ID="hypProductRateValue" NavigateUrl="~/admin/ProductRateValueEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductRateValueDataSource ID="ProductRateValueDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<%--<data:ProductRateValueProperty Name="Wholesaler"/> 
					<data:ProductRateValueProperty Name="Customer"/> --%>
					<data:ProductRateValueProperty Name="Currency"/> 
					<data:ProductRateValueProperty Name="ProductRate"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductRateValueFilter  Column="CustomerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductRateValueDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="Customer_FeaturePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="Customer_FeatureImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Customer Feature Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="Customer_FeatureLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="Customer_FeaturePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomer_Feature" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomer_Feature_SelectedIndexChanged"			 			 
			DataSourceID="Customer_FeatureDataSource4"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Customer_Feature.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<data:HyperLinkField HeaderText="Feature Id" DataNavigateUrlFormatString="FeatureEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Feature Option Id" DataNavigateUrlFormatString="FeatureOptionEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureOptionIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="FeatureOptionValue" HeaderText="Feature Option Value" SortExpression="[FeatureOptionValue]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Feature Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomer_Feature" NavigateUrl="~/admin/Customer_FeatureEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:Customer_FeatureDataSource ID="Customer_FeatureDataSource4" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Customer_FeatureProperty Name="Feature"/> 
					<data:Customer_FeatureProperty Name="FeatureOption"/> 
					<data:Customer_FeatureProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:Customer_FeatureFilter  Column="CustomerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:Customer_FeatureDataSource>		
		
		<br />
		</asp:Panel>
		
		<asp:Panel ID="DepartmentPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="DepartmentImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Department Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="DepartmentLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="DepartmentPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewDepartment" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewDepartment_SelectedIndexChanged"			 			 
			DataSourceID="DepartmentDataSource8"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Department.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="ParentId" HeaderText="Parent Id" SortExpression="[ParentID]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Department Found! </b>
				<asp:HyperLink runat="server" ID="hypDepartment" NavigateUrl="~/admin/DepartmentEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:DepartmentDataSource ID="DepartmentDataSource8" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DepartmentProperty Name="Wholesaler"/> 
					<data:DepartmentProperty Name="Customer"/> 
					<%--<data:DepartmentProperty Name="ModeratorCollection" />--%>
					<%--<data:DepartmentProperty Name="MonthlyDepartmentSummaryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:DepartmentFilter  Column="CustomerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:DepartmentDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="ModeratorPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ModeratorImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Moderator Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ModeratorLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ModeratorPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewModerator" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewModerator_SelectedIndexChanged"			 			 
			DataSourceID="ModeratorDataSource11"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Moderator.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]" />				
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]" />				
				<asp:BoundField DataField="ExternalModeratorNumber" HeaderText="External Moderator Number" SortExpression="[ExternalModeratorNumber]" />				
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]" />				
				<asp:BoundField DataField="PassCode" HeaderText="Pass Code" SortExpression="[PassCode]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="[PhoneNumber]" />				
				<asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="[EmailAddress]" />				
				<data:HyperLinkField HeaderText="Department Id" DataNavigateUrlFormatString="DepartmentEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="[Address1]" />				
				<asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="[Address2]" />				
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]" />				
				<data:HyperLinkField HeaderText="Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]" />				
				<asp:BoundField DataField="SecContactName" HeaderText="Sec Contact Name" SortExpression="[SecContactName]" />				
				<asp:BoundField DataField="SecContactPhoneNumber" HeaderText="Sec Contact Phone Number" SortExpression="[SecContactPhoneNumber]" />				
				<asp:BoundField DataField="SecContactEmailAddress" HeaderText="Sec Contact Email Address" SortExpression="[SecContactEmailAddress]" />				
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="UniqueModeratorId" HeaderText="Unique Moderator Id" SortExpression="[UniqueModeratorID]" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Moderator Found! </b>
				<asp:HyperLink runat="server" ID="hypModerator" NavigateUrl="~/admin/ModeratorEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ModeratorDataSource ID="ModeratorDataSource11" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ModeratorProperty Name="Customer"/> 
					<data:ModeratorProperty Name="Department"/> 
					<data:ModeratorProperty Name="User"/> 
					<%--<data:ModeratorProperty Name="CdrCollection" />--%>
					<%--<data:ModeratorProperty Name="Moderator_FeatureCollection" />--%>
					<%--<data:ModeratorProperty Name="BridgeRequestCollection" />--%>
					<%--<data:ModeratorProperty Name="Moderator_DnisCollection" />--%>
					<%--<data:ModeratorProperty Name="MiscellaneousChargeCollection" />--%>
					<%--<data:ModeratorProperty Name="BridgeQueueCollection" />--%>
					<%--<data:ModeratorProperty Name="RatedCdrCollection" />--%>
					<%--<data:ModeratorProperty Name="TicketCollection" />--%>
					<%--<data:ModeratorProperty Name="DnisidDnisCollection_From_Moderator_Dnis" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ModeratorFilter  Column="CustomerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ModeratorDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRateValue" runat="Server" TargetControlID="ProductRateValuePanel1"
            ExpandControlID="ProductRateValuePanel2" CollapseControlID="ProductRateValuePanel2" Collapsed="True"
            TextLabelID="ProductRateValueLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ProductRateValueImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer_Feature" runat="Server" TargetControlID="Customer_FeaturePanel1"
            ExpandControlID="Customer_FeaturePanel2" CollapseControlID="Customer_FeaturePanel2" Collapsed="True"
            TextLabelID="Customer_FeatureLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="Customer_FeatureImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeDepartment" runat="Server" TargetControlID="DepartmentPanel1"
            ExpandControlID="DepartmentPanel2" CollapseControlID="DepartmentPanel2" Collapsed="True"
            TextLabelID="DepartmentLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="DepartmentImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


<ajaxToolkit:CollapsiblePanelExtender ID="cpeModerator" runat="Server" TargetControlID="ModeratorPanel1"
            ExpandControlID="ModeratorPanel2" CollapseControlID="ModeratorPanel2" Collapsed="True"
            TextLabelID="ModeratorLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ModeratorImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

