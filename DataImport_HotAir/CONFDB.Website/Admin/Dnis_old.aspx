
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Dnis_old.aspx.cs" Inherits="Dnis" Title="Dnis List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dnis List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" 
		    OnSearchButtonClicked="GridViewSearchPanel1_SearchButtonClicked" >
		    <FieldsToExclude>
		        <data:Field Value="WholesalerID" />
		        <data:Field Value="AccessTypeID" />
		    </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DnisDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"
				ExcelExportFileName="Export_Dnis.xls"
				PageSize="50"
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Access Type" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Dnis Type" DataNavigateUrlFormatString="DnisTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DnisTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DnisNumber" HeaderText="Dnis Number" SortExpression="[DNISNumber]"  />
				<asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]"  />
				<data:BoundRadioButtonField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]"  />
				<data:HyperLinkField HeaderText="Call Flow" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Prompt Set" DataNavigateUrlFormatString="PromptSetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PromptSetIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Dnis Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDnis" OnClientClick="javascript:location.href='DnisEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:DnisDataSource ID="DnisDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DnisProperty Name="DnisType"/> 
					<data:DnisProperty Name="AccessType"/> 
					<data:DnisProperty Name="PromptSet"/> 
					<data:DnisProperty Name="CallFlow"/> 
					<%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
					<%--<data:DnisProperty Name="Moderator_DnisCollection" />--%>
					<%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
					<%--<data:DnisProperty Name="Customer_DnisCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="DNISTypeID, DisplayOrder,Description" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DnisDataSource>
	    		
</asp:Content>



