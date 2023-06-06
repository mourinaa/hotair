
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerReview.aspx.cs" Inherits="CustomerReview" Title="CustomerReview List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Review List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerReviewDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CustomerReview.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<asp:BoundField DataField="CompanyId" HeaderText="Company Id" SortExpression="[CompanyID]"  />
				<asp:BoundField DataField="GeneralSatisfaction" HeaderText="General Satisfaction" SortExpression="[GeneralSatisfaction]"  />
				<asp:BoundField DataField="AreasOfImprovement" HeaderText="Areas Of Improvement" SortExpression="[AreasOfImprovement]"  />
				<asp:BoundField DataField="ProductDiscussed" HeaderText="Product Discussed" SortExpression="[ProductDiscussed]"  />
				<data:BoundRadioButtonField DataField="Referrals" HeaderText="Referrals" SortExpression="[Referrals]"  />

				<asp:templatefield headertext='Notes Preview'>
				<itemtemplate>
					<ajaxToolkit:ModalPopupExtender id='ModalPopupExtender1' runat='server'
						TargetControlID='LinkButton1' 
						PopupControlID='Panel1' 
						OkControlID='Button1'
						BackgroundCssClass='ModalBackground' 
						DynamicControlID='lblPreview'
						DynamicContextKey='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
						DynamicServiceMethod='GetNotesContent' />
					<asp:LinkButton ID='LinkButton1' runat='server' Text='Preview' />
				</itemtemplate>
				</asp:templatefield>
	
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CustomerReview Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCustomerReview" OnClientClick="javascript:location.href='CustomerReviewEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
	<asp:Panel ID="Panel1" runat="server" CssClass="popup" >
	    <h2>Content Preview <asp:Button ID="Button1" runat="server"  Text="Close Preview"/></h2><hr /> 
	    <asp:Label ID='lblPreview' runat="server" ></asp:Label>
	</asp:Panel>
		<data:CustomerReviewDataSource ID="CustomerReviewDataSource" runat="server"
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
		</data:CustomerReviewDataSource>
	    		
</asp:Content>



