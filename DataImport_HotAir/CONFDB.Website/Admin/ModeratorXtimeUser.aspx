
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ModeratorXtimeUser.aspx.cs" Inherits="ModeratorXtimeUser" Title="ModeratorXtimeUser List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Moderator Xtime User List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ModeratorXtimeUserDataSource"
				DataKeyNames="ModeratorId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ModeratorXtimeUser.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]" ReadOnly />
				<asp:BoundField DataField="FirstCallDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="First Call Date" SortExpression="[FirstCallDate]"  />
				<asp:BoundField DataField="FirstCallProductId" HeaderText="First Call Product Id" SortExpression="[FirstCallProductID]"  />
				<asp:BoundField DataField="FirstCallNotes" HeaderText="First Call Notes" SortExpression="[FirstCallNotes]"  />
				<asp:BoundField DataField="ThirdCallDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Third Call Date" SortExpression="[ThirdCallDate]"  />
				<asp:BoundField DataField="ThirdCallProductId" HeaderText="Third Call Product Id" SortExpression="[ThirdCallProductID]"  />
				<asp:BoundField DataField="ThirdCallNotes" HeaderText="Third Call Notes" SortExpression="[ThirdCallNotes]"  />
				<asp:BoundField DataField="SecondCallDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Second Call Date" SortExpression="[SecondCallDate]"  />
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[UserID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ModeratorXtimeUser Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnModeratorXtimeUser" OnClientClick="javascript:location.href='ModeratorXtimeUserEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ModeratorXtimeUserDataSource ID="ModeratorXtimeUserDataSource" runat="server"
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
		</data:ModeratorXtimeUserDataSource>
	    		
</asp:Content>



