<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BridgeEdit.aspx.cs" Inherits="BridgeEdit" Title="Bridge Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bridge - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="BridgeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Bridge not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:BridgeDataSource ID="BridgeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:BridgeDataSource>
		
		<br />

		<asp:Panel ID="BridgeQueuePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="BridgeQueueImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Bridge Queue Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="BridgeQueueLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="BridgeQueuePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewBridgeQueue" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewBridgeQueue_SelectedIndexChanged"			 			 
			DataSourceID="BridgeQueueDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_BridgeQueue.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<data:HyperLinkField HeaderText="Bridge Id" DataNavigateUrlFormatString="BridgeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ProcessFlag" HeaderText="Process Flag" SortExpression="[ProcessFlag]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Bridge Queue Found! </b>
				<asp:HyperLink runat="server" ID="hypBridgeQueue" NavigateUrl="~/admin/BridgeQueueEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BridgeQueueDataSource ID="BridgeQueueDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BridgeQueueProperty Name="Bridge"/> 
					<data:BridgeQueueProperty Name="Moderator"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BridgeQueueFilter  Column="BridgeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BridgeQueueDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="RatedCdrPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="RatedCdrImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Rated Cdr Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="RatedCdrLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="RatedCdrPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewRatedCdr" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewRatedCdr_SelectedIndexChanged"			 			 
			DataSourceID="RatedCdrDataSource2"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_RatedCdr.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="ConferenceId" HeaderText="Conference Id" SortExpression="[ConferenceID]" />				
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]" />				
				<asp:BoundField DataField="PassCode" HeaderText="Pass Code" SortExpression="[PassCode]" />				
				<asp:BoundField DataField="ModeratorName" HeaderText="Moderator Name" SortExpression="[ModeratorName]" />				
				<asp:BoundField DataField="Moderator" HeaderText="Moderator" SortExpression="[Moderator]" />				
				<asp:BoundField DataField="ExternalCustomerNumber" HeaderText="External Customer Number" SortExpression="[ExternalCustomerNumber]" />				
				<asp:BoundField DataField="ExternalModeratorNumber" HeaderText="External Moderator Number" SortExpression="[ExternalModeratorNumber]" />				
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]" />				
				<asp:BoundField DataField="ConferenceStartTime" HeaderText="Conference Start Time" SortExpression="[ConferenceStartTime]" />				
				<asp:BoundField DataField="ConferenceEndTime" HeaderText="Conference End Time" SortExpression="[ConferenceEndTime]" />				
				<asp:BoundField DataField="ConferenceElapsedTime" HeaderText="Conference Elapsed Time" SortExpression="[ConferenceElapsedTime]" />				
				<asp:BoundField DataField="StartTime" HeaderText="Start Time" SortExpression="[StartTime]" />				
				<asp:BoundField DataField="EndTime" HeaderText="End Time" SortExpression="[EndTime]" />				
				<asp:BoundField DataField="ElapsedTime" HeaderText="Elapsed Time" SortExpression="[ElapsedTime]" />				
				<data:HyperLinkField HeaderText="Bridge Id" DataNavigateUrlFormatString="BridgeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]" />				
				<asp:BoundField DataField="AuxiliaryConferenceId" HeaderText="Auxiliary Conference Id" SortExpression="[AuxiliaryConferenceID]" />				
				<asp:BoundField DataField="Dnis" HeaderText="Dnis" SortExpression="[DNIS]" />				
				<asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]" />				
				<asp:BoundField DataField="Ani" HeaderText="Ani" SortExpression="[ANI]" />				
				<asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" SortExpression="[ParticipantName]" />				
				<asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="[Destination]" />				
				<data:HyperLinkField HeaderText="Access Type Id" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ConnectProductRateId" HeaderText="Connect Product Rate Id" SortExpression="[ConnectProductRateID]" />				
				<asp:BoundField DataField="BridgeProductRateId" HeaderText="Bridge Product Rate Id" SortExpression="[BridgeProductRateID]" />				
				<asp:BoundField DataField="LdProductRateId" HeaderText="Ld Product Rate Id" SortExpression="[LDProductRateID]" />				
				<asp:BoundField DataField="ProductRateTaxableValue" HeaderText="Product Rate Taxable Value" SortExpression="[ProductRateTaxableValue]" />				
				<asp:BoundField DataField="CustomerTaxableValue" HeaderText="Customer Taxable Value" SortExpression="[CustomerTaxableValue]" />				
				<asp:BoundField DataField="WsTaxableValue" HeaderText="Ws Taxable Value" SortExpression="[WSTaxableValue]" />				
				<asp:BoundField DataField="RetailConnectCharge" HeaderText="Retail Connect Charge" SortExpression="[RetailConnectCharge]" />				
				<asp:BoundField DataField="RetailBridgeRate" HeaderText="Retail Bridge Rate" SortExpression="[RetailBridgeRate]" />				
				<asp:BoundField DataField="RetailLdRate" HeaderText="Retail Ld Rate" SortExpression="[RetailLDRate]" />				
				<asp:BoundField DataField="RetailCurrency" HeaderText="Retail Currency" SortExpression="[RetailCurrency]" />				
				<asp:BoundField DataField="RetailBillingInterval" HeaderText="Retail Billing Interval" SortExpression="[RetailBillingInterval]" />				
				<asp:BoundField DataField="RetailTotalConnectCharge" HeaderText="Retail Total Connect Charge" SortExpression="[RetailTotalConnectCharge]" />				
				<asp:BoundField DataField="RetailTotalBridge" HeaderText="Retail Total Bridge" SortExpression="[RetailTotalBridge]" />				
				<asp:BoundField DataField="RetailTotalLd" HeaderText="Retail Total Ld" SortExpression="[RetailTotalLD]" />				
				<asp:BoundField DataField="RetailTotal" HeaderText="Retail Total" SortExpression="[RetailTotal]" />				
				<asp:BoundField DataField="RetailTotalCredit" HeaderText="Retail Total Credit" SortExpression="[RetailTotalCredit]" />				
				<asp:BoundField DataField="RetailLocalTaxRate" HeaderText="Retail Local Tax Rate" SortExpression="[RetailLocalTaxRate]" />				
				<asp:BoundField DataField="RetailFederalTaxRate" HeaderText="Retail Federal Tax Rate" SortExpression="[RetailFederalTaxRate]" />				
				<asp:BoundField DataField="RetailLocalTax" HeaderText="Retail Local Tax" SortExpression="[RetailLocalTax]" />				
				<asp:BoundField DataField="RetailFederalTax" HeaderText="Retail Federal Tax" SortExpression="[RetailFederalTax]" />				
				<asp:BoundField DataField="RetailTotalTax" HeaderText="Retail Total Tax" SortExpression="[RetailTotalTax]" />				
				<asp:BoundField DataField="WsConnectCharge" HeaderText="Ws Connect Charge" SortExpression="[WSConnectCharge]" />				
				<asp:BoundField DataField="WsBridgeRate" HeaderText="Ws Bridge Rate" SortExpression="[WSBridgeRate]" />				
				<asp:BoundField DataField="WsldRate" HeaderText="Wsld Rate" SortExpression="[WSLDRate]" />				
				<asp:BoundField DataField="WsCurrency" HeaderText="Ws Currency" SortExpression="[WSCurrency]" />				
				<asp:BoundField DataField="WsBillingInterval" HeaderText="Ws Billing Interval" SortExpression="[WSBillingInterval]" />				
				<asp:BoundField DataField="WsTotalConnectCharge" HeaderText="Ws Total Connect Charge" SortExpression="[WSTotalConnectCharge]" />				
				<asp:BoundField DataField="WsTotalBridge" HeaderText="Ws Total Bridge" SortExpression="[WSTotalBridge]" />				
				<asp:BoundField DataField="WsTotalLd" HeaderText="Ws Total Ld" SortExpression="[WSTotalLD]" />				
				<asp:BoundField DataField="WsTotal" HeaderText="Ws Total" SortExpression="[WSTotal]" />				
				<asp:BoundField DataField="WsLocalTaxRate" HeaderText="Ws Local Tax Rate" SortExpression="[WSLocalTaxRate]" />				
				<asp:BoundField DataField="WsFederalTaxRate" HeaderText="Ws Federal Tax Rate" SortExpression="[WSFederalTaxRate]" />				
				<asp:BoundField DataField="WsLocalTax" HeaderText="Ws Local Tax" SortExpression="[WSLocalTax]" />				
				<asp:BoundField DataField="WsFederalTax" HeaderText="Ws Federal Tax" SortExpression="[WSFederalTax]" />				
				<asp:BoundField DataField="WsTotalTax" HeaderText="Ws Total Tax" SortExpression="[WSTotalTax]" />				
				<asp:BoundField DataField="BillingStatus" HeaderText="Billing Status" SortExpression="[BillingStatus]" />				
				<asp:BoundField DataField="BilledDate" HeaderText="Billed Date" SortExpression="[BilledDate]" />				
				<asp:BoundField DataField="ProcessedDate" HeaderText="Processed Date" SortExpression="[ProcessedDate]" />				
				<asp:BoundField DataField="SeeVoghMeetingId" HeaderText="See Vogh Meeting Id" SortExpression="[SeeVoghMeetingID]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Rated Cdr Found! </b>
				<asp:HyperLink runat="server" ID="hypRatedCdr" NavigateUrl="~/admin/RatedCdrEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:RatedCdrDataSource ID="RatedCdrDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:RatedCdrProperty Name="AccessType"/> 
					<data:RatedCdrProperty Name="Bridge"/> 
					<data:RatedCdrProperty Name="Moderator"/> 
					<data:RatedCdrProperty Name="Wholesaler"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:RatedCdrFilter  Column="BridgeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:RatedCdrDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeBridgeQueue" runat="Server" TargetControlID="BridgeQueuePanel1"
            ExpandControlID="BridgeQueuePanel2" CollapseControlID="BridgeQueuePanel2" Collapsed="True"
            TextLabelID="BridgeQueueLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="BridgeQueueImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeRatedCdr" runat="Server" TargetControlID="RatedCdrPanel1"
            ExpandControlID="RatedCdrPanel2" CollapseControlID="RatedCdrPanel2" Collapsed="True"
            TextLabelID="RatedCdrLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="RatedCdrImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

