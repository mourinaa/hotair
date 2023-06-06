
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerDocument.aspx.cs" Inherits="CustomerDocument" Title="CustomerDocument List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Document List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerDocumentDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CustomerDocument.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="DocumentDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Document Date" SortExpression="[DocumentDate]"  />
				<data:HyperLinkField HeaderText="Document Type Id" DataNavigateUrlFormatString="DocumentTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DocumentTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="KbSize" HeaderText="Kb Size" SortExpression="[KBSize]"  />
				<asp:BoundField DataField="DocumentDirectory" HeaderText="Document Directory" SortExpression="[DocumentDirectory]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]"  />
				<data:HyperLinkField HeaderText="Language Id" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CustomerDocument Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCustomerDocument" OnClientClick="javascript:location.href='CustomerDocumentEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CustomerDocumentDataSource ID="CustomerDocumentDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerDocumentProperty Name="Customer"/> 
					<data:CustomerDocumentProperty Name="Wholesaler"/> 
					<data:CustomerDocumentProperty Name="DocumentType"/> 
					<data:CustomerDocumentProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CustomerDocumentDataSource>
	    		
</asp:Content>



