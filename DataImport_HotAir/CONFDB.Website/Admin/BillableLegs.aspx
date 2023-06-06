
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BillableLegs.aspx.cs" Inherits="BillableLegs" Title="BillableLegs List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Billable Legs List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="BillableLegsDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_BillableLegs.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<asp:BoundField DataField="ConferenceId" HeaderText="Conference Id" SortExpression="[ConferenceID]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]"  />
				<asp:BoundField DataField="PassCode" HeaderText="Pass Code" SortExpression="[PassCode]"  />
				<asp:BoundField DataField="ModeratorName" HeaderText="Moderator Name" SortExpression="[ModeratorName]"  />
				<asp:BoundField DataField="Moderator" HeaderText="Moderator" SortExpression="[Moderator]"  />
				<asp:BoundField DataField="ExternalCustomerNumber" HeaderText="External Customer Number" SortExpression="[ExternalCustomerNumber]"  />
				<asp:BoundField DataField="ExternalModeratorNumber" HeaderText="External Moderator Number" SortExpression="[ExternalModeratorNumber]"  />
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]"  />
				<asp:BoundField DataField="StartTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Time" SortExpression="[StartTime]"  />
				<asp:BoundField DataField="EndTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Time" SortExpression="[EndTime]"  />
				<asp:BoundField DataField="ElapsedTime" HeaderText="Elapsed Time" SortExpression="[ElapsedTime]"  />
				<asp:BoundField DataField="BridgeId" HeaderText="Bridge Id" SortExpression="[BridgeID]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="AuxiliaryConferenceId" HeaderText="Auxiliary Conference Id" SortExpression="[AuxiliaryConferenceID]"  />
				<asp:BoundField DataField="Dnis" HeaderText="Dnis" SortExpression="[DNIS]"  />
				<asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]"  />
				<asp:BoundField DataField="Ani" HeaderText="Ani" SortExpression="[ANI]"  />
				<asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" SortExpression="[ParticipantName]"  />
				<asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="[Destination]"  />
				<asp:BoundField DataField="AccessTypeId" HeaderText="Access Type Id" SortExpression="[AccessTypeID]"  />
				<asp:BoundField DataField="ConnectProductRateId" HeaderText="Connect Product Rate Id" SortExpression="[ConnectProductRateID]"  />
				<asp:BoundField DataField="BridgeProductRateId" HeaderText="Bridge Product Rate Id" SortExpression="[BridgeProductRateID]"  />
				<asp:BoundField DataField="LdProductRateId" HeaderText="Ld Product Rate Id" SortExpression="[LDProductRateID]"  />
				<asp:BoundField DataField="ProductRateTaxableValue" HeaderText="Product Rate Taxable Value" SortExpression="[ProductRateTaxableValue]"  />
				<asp:BoundField DataField="CustomerTaxableValue" HeaderText="Customer Taxable Value" SortExpression="[CustomerTaxableValue]"  />
				<asp:BoundField DataField="WsTaxableValue" HeaderText="Ws Taxable Value" SortExpression="[WSTaxableValue]"  />
				<asp:BoundField DataField="RetailConnectCharge" HeaderText="Retail Connect Charge" SortExpression="[RetailConnectCharge]"  />
				<asp:BoundField DataField="RetailBridgeRate" HeaderText="Retail Bridge Rate" SortExpression="[RetailBridgeRate]"  />
				<asp:BoundField DataField="RetailLdRate" HeaderText="Retail Ld Rate" SortExpression="[RetailLDRate]"  />
				<asp:BoundField DataField="RetailCurrency" HeaderText="Retail Currency" SortExpression="[RetailCurrency]"  />
				<asp:BoundField DataField="RetailBillingInterval" HeaderText="Retail Billing Interval" SortExpression="[RetailBillingInterval]"  />
				<asp:BoundField DataField="RetailTotalConnectCharge" HeaderText="Retail Total Connect Charge" SortExpression="[RetailTotalConnectCharge]"  />
				<asp:BoundField DataField="RetailTotalBridge" HeaderText="Retail Total Bridge" SortExpression="[RetailTotalBridge]"  />
				<asp:BoundField DataField="RetailTotalLd" HeaderText="Retail Total Ld" SortExpression="[RetailTotalLD]"  />
				<asp:BoundField DataField="RetailTotal" HeaderText="Retail Total" SortExpression="[RetailTotal]"  />
				<asp:BoundField DataField="RetailLocalTaxRate" HeaderText="Retail Local Tax Rate" SortExpression="[RetailLocalTaxRate]"  />
				<asp:BoundField DataField="RetailFederalTaxRate" HeaderText="Retail Federal Tax Rate" SortExpression="[RetailFederalTaxRate]"  />
				<asp:BoundField DataField="RetailLocalTax" HeaderText="Retail Local Tax" SortExpression="[RetailLocalTax]"  />
				<asp:BoundField DataField="RetailFederalTax" HeaderText="Retail Federal Tax" SortExpression="[RetailFederalTax]"  />
				<asp:BoundField DataField="RetailTotalTax" HeaderText="Retail Total Tax" SortExpression="[RetailTotalTax]"  />
				<asp:BoundField DataField="WsConnectCharge" HeaderText="Ws Connect Charge" SortExpression="[WSConnectCharge]"  />
				<asp:BoundField DataField="WsBridgeRate" HeaderText="Ws Bridge Rate" SortExpression="[WSBridgeRate]"  />
				<asp:BoundField DataField="WsldRate" HeaderText="Wsld Rate" SortExpression="[WSLDRate]"  />
				<asp:BoundField DataField="WsCurrency" HeaderText="Ws Currency" SortExpression="[WSCurrency]"  />
				<asp:BoundField DataField="WsBillingInterval" HeaderText="Ws Billing Interval" SortExpression="[WSBillingInterval]"  />
				<asp:BoundField DataField="WsTotalConnectCharge" HeaderText="Ws Total Connect Charge" SortExpression="[WSTotalConnectCharge]"  />
				<asp:BoundField DataField="WsTotalBridge" HeaderText="Ws Total Bridge" SortExpression="[WSTotalBridge]"  />
				<asp:BoundField DataField="WsTotalLd" HeaderText="Ws Total Ld" SortExpression="[WSTotalLD]"  />
				<asp:BoundField DataField="WsTotal" HeaderText="Ws Total" SortExpression="[WSTotal]"  />
				<asp:BoundField DataField="WsLocalTaxRate" HeaderText="Ws Local Tax Rate" SortExpression="[WSLocalTaxRate]"  />
				<asp:BoundField DataField="WsFederalTaxRate" HeaderText="Ws Federal Tax Rate" SortExpression="[WSFederalTaxRate]"  />
				<asp:BoundField DataField="WsLocalTax" HeaderText="Ws Local Tax" SortExpression="[WSLocalTax]"  />
				<asp:BoundField DataField="WsFederalTax" HeaderText="Ws Federal Tax" SortExpression="[WSFederalTax]"  />
				<asp:BoundField DataField="WsTotalTax" HeaderText="Ws Total Tax" SortExpression="[WSTotalTax]"  />
				<asp:BoundField DataField="BillingStatus" HeaderText="Billing Status" SortExpression="[BillingStatus]"  />
				<asp:BoundField DataField="BilledDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Billed Date" SortExpression="[BilledDate]"  />
				<asp:BoundField DataField="ProcessedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Processed Date" SortExpression="[ProcessedDate]"  />
				<data:BoundRadioButtonField DataField="RatedToZero" HeaderText="Rated To Zero" SortExpression="[RatedToZero]"  />
				<asp:BoundField DataField="ProductName" HeaderText="Product Name" SortExpression="[ProductName]"  />
				<asp:BoundField DataField="ProductNameAlt" HeaderText="Product Name Alt" SortExpression="[ProductNameAlt]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No BillableLegs Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBillableLegs" OnClientClick="javascript:location.href='BillableLegsEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:BillableLegsDataSource ID="BillableLegsDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:BillableLegsDataSource>
	    		
</asp:Content>



