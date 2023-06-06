
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Conference.aspx.cs" Inherits="Conference" Title="Conference List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Conference List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session">
            <FieldsToExclude>
                <data:Field Value="WholesalerID" />
                <data:Field Value="CustomerID" />
                <data:Field Value="CompanyID" />
                <data:Field Value="SalesPersonID" />
                <data:Field Value="SalesPerson" />
                <data:Field Value="LastWalletCardSentdate" />
                <data:Field Value="UserID" />
            </FieldsToExclude>
        </data:GridViewSearchPanel>
		<br />
		<asp:Button Visible="false" runat="server" ID="btnModerator" OnClientClick="javascript:location.href='ConferenceEdit.aspx'; return false;" Text="Add New"></asp:Button>
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ConferenceDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="[CompanyName]" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Conference.xls"  		
			>
			<Columns>
            <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
            <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />
            <asp:BoundField DataField="AdminName" HeaderText="Admin Name" SortExpression="[AdminName]" />
            <asp:BoundField DataField="ModeratorName" HeaderText="Moderator Name" SortExpression="[ModeratorName]"/>
            <asp:BoundField DataField="ConferenceName" HeaderText="Conference Name" />
            <asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" />
            <asp:BoundField DataField="PassCode" HeaderText="Pass Code" />
            <asp:BoundField DataField="Enabled" HeaderText="Enabled" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Conference Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
	</ContentTemplate>
	</asp:UpdatePanel>	
    <data:Vw_ConferenceListDataSource ID="ConferenceDataSource" runat="server" SelectMethod="GetPaged"
        EnablePaging="True" EnableSorting="True">
        <Parameters>
            <data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
            <%--<data:CustomParameter Name="OrderBy" Value="CompanyName,AdminName,ModeratorName" ConvertEmptyStringToNull="false" />--%>
            <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                Type="Int32" />
            <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                Type="Int32" />
            <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
        </Parameters>
    </data:Vw_ConferenceListDataSource>
	    		
</asp:Content>



