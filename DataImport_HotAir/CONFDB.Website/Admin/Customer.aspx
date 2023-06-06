<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Customer.aspx.cs" Inherits="Customer" Title="Customer List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session">
		    <FieldsToExclude>
		        <data:Field Value="WholesalerID" />
                <data:Field value="PrimaryContactCountry"/>
                <data:Field value="PrimaryContactRegion"/>
                <data:Field value="PrimaryContactFaxNumber"/>
                <data:Field value="BillingContactCountry"/>
                <data:Field value="BillingContactRegion"/>
                <data:Field value="BillingContactFaxNumber"/>
                <data:Field value="WebsiteURL"/>
                <data:Field value="SalesPersonID"/>
                <data:Field value="VerticalID"/>
                <data:Field value="CompanyID"/>
                <data:Field value="CurrencyID"/>
                <data:Field value="TaxableID"/>
                <data:Field value="CreditCardExp"/>
                <data:Field value="CreditCardVerCode"/>
                <data:Field value="CreditCardTypeName"/>
                <data:Field value="CreatedDate"/>
                <data:Field value="LastModified"/>
                <data:Field value="UserID"/>
                <data:Field value="WebGroupID"/>
                <data:Field value="PrimaryContactPostalCode"/>
                <data:Field value="CreditCardNameOnCard"/>
                <data:Field value="CreditCardNumber"/>
                <data:Field value="Password"/>
                <data:Field value="RoleID"/>
                <data:Field value="MustChangePassword"/>
                <data:Field value="CharityID"/>
                <data:Field value="WebMemberID"/>
                <data:Field value="DDLDescription"/>
                <data:Field value="SalesManagerID"/>                
                <data:Field value="UserEnabled"/>                
		    </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />
		<asp:Button runat="server" ID="btnCustomer" OnClientClick="javascript:location.href='CustomerEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<br />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"	
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="False"
				DefaultSortColumnName="[PrimaryContactName]" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Customer.xls" AllowExportToExcel="True" AllowSorting="True" 
				ExportToExcelText="Excel" PageSelectorPageSizeInterval="10" RecordsCount="0"
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />				
                <asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="[CompanyName]"  />
                <asp:BoundField DataField="PrimaryContactName" HeaderText="Primary Contact Name" SortExpression="[PrimaryContactName]"  />
                <asp:BoundField DataField="UserName" HeaderText="User Login" SortExpression="[UserName]"  />
                <asp:BoundField DataField="PrimaryContactPhoneNumber" HeaderText="Primary Contact Phone Number" SortExpression="[PrimaryContactPhoneNumber]"  />
                <asp:BoundField DataField="PrimaryContactAddress1" HeaderText="Primary Contact Address1" SortExpression="[PrimaryContactAddress1]"  />
                <asp:BoundField DataField="PrimaryContactCountry" HeaderText="Primary Contact Country" />
                <asp:BoundField DataField="PrimaryContactRegion" HeaderText="Primary Contact Region" />
                <asp:BoundField DataField="BillingContactName" HeaderText="Billing Contact Name" SortExpression="[BillingContactName]"  />
                <asp:BoundField DataField="BillingContactPhoneNumber" HeaderText="Billing Contact Phone Number" SortExpression="[BillingContactPhoneNumber]"  />
                <asp:BoundField DataField="BillingContactEmailAddress" HeaderText="Billing Contact Email Address" SortExpression="[BillingContactEmailAddress]"  />
                <asp:BoundField DataField="BillingContactAddress1" HeaderText="Billing Contact Address1" SortExpression="[BillingContactAddress1]"  />
                <asp:BoundField DataField="BillingContactAddress2" HeaderText="Billing Contact Address2" SortExpression="[BillingContactAddress2]"  />
                <asp:BoundField DataField="BillingContactCity" HeaderText="Billing Contact City" SortExpression="[BillingContactCity]"  />
                <asp:BoundField DataField="BillingContactCountry" HeaderText="Billing Contact Country" />
                <asp:BoundField DataField="BillingContactRegion" HeaderText="Billing Contact Region" />
                <asp:BoundField DataField="BillingContactPostalCode" HeaderText="Billing Contact Postal Code" SortExpression="[BillingContactPostalCode]"  />
                <asp:BoundField DataField="SalesPerson" HeaderText="Sales Person" SortExpression="[SalesPerson]"  />
                <asp:BoundField DataField="VerticalDescription" HeaderText="Vertical" SortExpression="[VerticalDescription]"  />
                <asp:BoundField DataField="BillingPeriodCutoff" HeaderText="Billing Cutoff"  SortExpression="BillingPeriodCutoff" />
                <asp:CheckBoxField DataField="UserEnabled" HeaderText="Enabled" SortExpression="[UserEnabled]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
	</ContentTemplate>
	</asp:UpdatePanel>
		
		<data:Vw_CustomerListDataSource ID="CustomerDataSource" runat="server"
			SelectMethod="GetPaged" EnablePaging="True" EnableSorting="True"
			>
			<Parameters>
                <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:Vw_CustomerListDataSource>
	    		
</asp:Content>



