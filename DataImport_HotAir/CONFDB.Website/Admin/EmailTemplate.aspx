
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="EmailTemplate.aspx.cs" Inherits="EmailTemplate" Title="EmailTemplate List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Email Template List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="EmailTemplateDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_EmailTemplate.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" ShowDeleteButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="SmtpServer" HeaderText="Smtp Server" SortExpression="[SMTPServer]"  />
				<asp:BoundField DataField="SmtpUserName" HeaderText="Smtp User Name" SortExpression="[SMTPUserName]"  />
				<asp:BoundField DataField="SmtpPassword" HeaderText="Smtp Password" SortExpression="[SMTPPassword]"  />
				<asp:BoundField DataField="BaseFileDirectory" HeaderText="Base File Directory" SortExpression="[BaseFileDirectory]"  />
				<asp:BoundField DataField="TemplateName" HeaderText="Template Name" SortExpression="[TemplateName]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="[FileName]"  />
				<asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="[Subject]"  />
				<asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="[Sender]"  />
				<asp:BoundField DataField="BccList" HeaderText="Bcc List" SortExpression="[BCCList]"  />
				<asp:BoundField DataField="CcList" HeaderText="Cc List" SortExpression="[CCList]"  />
				<data:BoundRadioButtonField DataField="SendToContact" HeaderText="Send To Contact" SortExpression="[SendToContact]"  />
				<data:BoundRadioButtonField DataField="SendToModerator" HeaderText="Send To Moderator" SortExpression="[SendToModerator]"  />
				<data:BoundRadioButtonField DataField="IncludeAttachment" HeaderText="Include Attachment" SortExpression="[IncludeAttachment]"  />
				<asp:BoundField DataField="AttachmentFileName" HeaderText="Attachment File Name" SortExpression="[AttachmentFileName]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="EmailTemplateContentTypeId" HeaderText="Email Template Content Type Id" SortExpression="[EmailTemplateContentTypeID]"  />
				<asp:BoundField DataField="EmailTemplateGroupId" HeaderText="Email Template Group Id" SortExpression="[EmailTemplateGroupID]"  />
				<data:HyperLinkField HeaderText="Call Flow Id" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Language Id" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No EmailTemplate Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnEmailTemplate" OnClientClick="javascript:location.href='EmailTemplateEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:EmailTemplateDataSource ID="EmailTemplateDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmailTemplateProperty Name="CallFlow"/> 
					<data:EmailTemplateProperty Name="Wholesaler"/> 
					<data:EmailTemplateProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:EmailTemplateDataSource>
	    		
</asp:Content>



