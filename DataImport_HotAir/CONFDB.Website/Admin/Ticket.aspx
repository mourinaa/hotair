
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Ticket.aspx.cs" Inherits="Ticket" Title="Ticket List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ticket List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TicketDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Ticket.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]"  />

				<asp:templatefield headertext='Issue Description Preview'>
				<itemtemplate>
					<ajaxToolkit:ModalPopupExtender id='ModalPopupExtender1' runat='server'
						TargetControlID='LinkButton1' 
						PopupControlID='Panel1' 
						OkControlID='Button1'
						BackgroundCssClass='ModalBackground' 
						DynamicControlID='lblPreview'
						DynamicContextKey='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
						DynamicServiceMethod='GetIssueDescriptionContent' />
					<asp:LinkButton ID='LinkButton1' runat='server' Text='Preview' />
				</itemtemplate>
				</asp:templatefield>
	
				<asp:BoundField DataField="ClientContactInfo" HeaderText="Client Contact Info" SortExpression="[ClientContactInfo]"  />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<data:HyperLinkField HeaderText="Status Id" DataNavigateUrlFormatString="TicketStatusEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="StatusIdSource" DataTextField="Abbreviation" />

				<asp:templatefield headertext='Resolution Text Preview'>
				<itemtemplate>
					<ajaxToolkit:ModalPopupExtender id='ModalPopupExtender6' runat='server'
						TargetControlID='LinkButton6' 
						PopupControlID='Panel1' 
						OkControlID='Button1'
						BackgroundCssClass='ModalBackground' 
						DynamicControlID='lblPreview'
						DynamicContextKey='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
						DynamicServiceMethod='GetResolutionTextContent' />
					<asp:LinkButton ID='LinkButton6' runat='server' Text='Preview' />
				</itemtemplate>
				</asp:templatefield>
	
				<data:HyperLinkField HeaderText="Ticket Priority Id" DataNavigateUrlFormatString="TicketPriorityEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketPriorityIdSource" DataTextField="Name" />
				<asp:BoundField DataField="CreatedByUserId" HeaderText="Created By User Id" SortExpression="[CreatedByUserID]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="AssignedToUserId" HeaderText="Assigned To User Id" SortExpression="[AssignedToUserID]"  />
				<asp:BoundField DataField="AssignedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Assigned Date" SortExpression="[AssignedDate]"  />
				<asp:BoundField DataField="FixedByUserId" HeaderText="Fixed By User Id" SortExpression="[FixedByUserID]"  />
				<asp:BoundField DataField="FixedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Fixed Date" SortExpression="[FixedDate]"  />
				<asp:BoundField DataField="ClosedByUserId" HeaderText="Closed By User Id" SortExpression="[ClosedByUserID]"  />
				<asp:BoundField DataField="ClosedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Closed Date" SortExpression="[ClosedDate]"  />
				<data:HyperLinkField HeaderText="Ticket Product Id" DataNavigateUrlFormatString="TicketProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Ticket Category Id" DataNavigateUrlFormatString="TicketCategoryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketCategoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DuplicateTicketId" HeaderText="Duplicate Ticket Id" SortExpression="[DuplicateTicketID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Ticket Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTicket" OnClientClick="javascript:location.href='TicketEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
	<asp:Panel ID="Panel1" runat="server" CssClass="popup" >
	    <h2>Content Preview <asp:Button ID="Button1" runat="server"  Text="Close Preview"/></h2><hr /> 
	    <asp:Label ID='lblPreview' runat="server" ></asp:Label>
	</asp:Panel>
		<data:TicketDataSource ID="TicketDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:TicketProperty Name="Customer"/> 
					<data:TicketProperty Name="Wholesaler"/> 
					<data:TicketProperty Name="TicketProduct"/> 
					<data:TicketProperty Name="TicketStatus"/> 
					<data:TicketProperty Name="TicketPriority"/> 
					<data:TicketProperty Name="TicketCategory"/> 
					<data:TicketProperty Name="Moderator"/> 
					<%--<data:TicketProperty Name="TicketStatusHistory" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:TicketDataSource>
	    		
</asp:Content>



