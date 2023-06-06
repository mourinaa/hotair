
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="OmnoviaHostedArchiveParticipant.aspx.cs" Inherits="OmnoviaHostedArchiveParticipant" Title="OmnoviaHostedArchiveParticipant List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Omnovia Hosted Archive Participant List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="OmnoviaHostedArchiveParticipantDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_OmnoviaHostedArchiveParticipant.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="HostedArchiveId" HeaderText="Hosted Archive Id" SortExpression="[HostedArchiveID]"  />
				<asp:BoundField DataField="Firstname" HeaderText="Firstname" SortExpression="[Firstname]"  />
				<asp:BoundField DataField="Lastname" HeaderText="Lastname" SortExpression="[Lastname]"  />
				<asp:BoundField DataField="Company" HeaderText="Company" SortExpression="[Company]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Created" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created" SortExpression="[created]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No OmnoviaHostedArchiveParticipant Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnOmnoviaHostedArchiveParticipant" OnClientClick="javascript:location.href='OmnoviaHostedArchiveParticipantEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:OmnoviaHostedArchiveParticipantDataSource ID="OmnoviaHostedArchiveParticipantDataSource" runat="server"
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
		</data:OmnoviaHostedArchiveParticipantDataSource>
	    		
</asp:Content>



