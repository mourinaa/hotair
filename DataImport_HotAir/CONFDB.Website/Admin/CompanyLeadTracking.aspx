
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CompanyLeadTracking.aspx.cs" Inherits="CompanyLeadTracking" Title="CompanyLeadTracking List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Company Lead Tracking List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CompanyLeadTrackingDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CompanyLeadTracking.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<data:HyperLinkField HeaderText="Company Info Id" DataNavigateUrlFormatString="CompanyInfoEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyInfoIdSource" DataTextField="LeadId" />
				<asp:BoundField DataField="ProjectedRevenue" HeaderText="Projected Revenue" SortExpression="[ProjectedRevenue]"  />
				<data:HyperLinkField HeaderText="Lead Product Id" DataNavigateUrlFormatString="LeadProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Source Id" DataNavigateUrlFormatString="LeadSourceEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadSourceIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Stage Id" DataNavigateUrlFormatString="LeadStageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadStageIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ExpectedCloseDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Expected Close Date" SortExpression="[ExpectedCloseDate]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]"  />
				<data:HyperLinkField HeaderText="Lead Period Id" DataNavigateUrlFormatString="LeadPeriodEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadPeriodIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Churn Reason Id" DataNavigateUrlFormatString="LeadChurnReasonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadChurnReasonIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No CompanyLeadTracking Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCompanyLeadTracking" OnClientClick="javascript:location.href='CompanyLeadTrackingEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CompanyLeadTrackingDataSource ID="CompanyLeadTrackingDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyLeadTrackingProperty Name="LeadPeriod"/> 
					<data:CompanyLeadTrackingProperty Name="CompanyInfo"/> 
					<data:CompanyLeadTrackingProperty Name="LeadSource"/> 
					<data:CompanyLeadTrackingProperty Name="LeadChurnReason"/> 
					<data:CompanyLeadTrackingProperty Name="LeadProduct"/> 
					<data:CompanyLeadTrackingProperty Name="LeadStage"/> 
					<%--<data:CompanyLeadTrackingProperty Name="CompanyLeadTrackingNotesCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CompanyLeadTrackingDataSource>
	    		
</asp:Content>



