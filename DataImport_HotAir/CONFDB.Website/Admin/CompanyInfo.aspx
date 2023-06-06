
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CompanyInfo.aspx.cs" Inherits="CompanyInfo" Title="CompanyInfo List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Company Info List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CompanyInfoDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CompanyInfo.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<asp:BoundField DataField="LeadId" HeaderText="Lead Id" SortExpression="[LeadID]"  />
				<asp:BoundField DataField="CompanyId" HeaderText="Company Id" SortExpression="[CompanyID]"  />
				<asp:BoundField DataField="SlaEndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Sla End Date" SortExpression="[SLAEndDate]"  />
				<asp:BoundField DataField="Address" HeaderText="Address" SortExpression="[Address]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<data:HyperLinkField HeaderText="Country Id" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountryIdSource" DataTextField="Description" />
				<asp:BoundField DataField="Postal" HeaderText="Postal" SortExpression="[Postal]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CompanyInfo Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCompanyInfo" OnClientClick="javascript:location.href='CompanyInfoEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CompanyInfoDataSource ID="CompanyInfoDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyInfoProperty Name="Country"/> 
					<%--<data:CompanyInfoProperty Name="CompanyLeadTrackingCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CompanyInfoDataSource>
	    		
</asp:Content>



