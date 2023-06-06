<%@ Control Language="C#" ClassName="EmailTemplateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSmtpServer" runat="server" Text="Smtp Server:" AssociatedControlID="dataSmtpServer" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataSmtpServer" Text='<%# Bind("SmtpServer") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSmtpServer" runat="server" Display="Dynamic" ControlToValidate="dataSmtpServer" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSmtpUserName" runat="server" Text="Smtp User Name:" AssociatedControlID="dataSmtpUserName" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataSmtpUserName" Text='<%# Bind("SmtpUserName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSmtpPassword" runat="server" Text="Smtp Password:" AssociatedControlID="dataSmtpPassword" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataSmtpPassword" Text='<%# Bind("SmtpPassword") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBaseFileDirectory" runat="server" Text="Base File Directory:" AssociatedControlID="dataBaseFileDirectory" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataBaseFileDirectory" Text='<%# Bind("BaseFileDirectory") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBaseFileDirectory" runat="server" Display="Dynamic" ControlToValidate="dataBaseFileDirectory" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTemplateName" runat="server" Text="Template Name:" AssociatedControlID="dataTemplateName" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataTemplateName" Text='<%# Bind("TemplateName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTemplateName" runat="server" Display="Dynamic" ControlToValidate="dataTemplateName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFileName" runat="server" Text="File Name:" AssociatedControlID="dataFileName" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataFileName" Text='<%# Bind("FileName") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFileName" runat="server" Display="Dynamic" ControlToValidate="dataFileName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSubject" runat="server" Text="Subject:" AssociatedControlID="dataSubject" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataSubject" Text='<%# Bind("Subject") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSubject" runat="server" Display="Dynamic" ControlToValidate="dataSubject" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSender" runat="server" Text="Sender:" AssociatedControlID="dataSender" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataSender" Text='<%# Bind("Sender") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSender" runat="server" Display="Dynamic" ControlToValidate="dataSender" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBccList" runat="server" Text="Bcc List:" AssociatedControlID="dataBccList" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataBccList" Text='<%# Bind("BccList") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCcList" runat="server" Text="Cc List:" AssociatedControlID="dataCcList" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataCcList" Text='<%# Bind("CcList") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSendToContact" runat="server" Text="Send To Contact:" AssociatedControlID="dataSendToContact" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSendToContact" SelectedValue='<%# Bind("SendToContact") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSendToModerator" runat="server" Text="Send To Moderator:" AssociatedControlID="dataSendToModerator" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSendToModerator" SelectedValue='<%# Bind("SendToModerator") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIncludeAttachment" runat="server" Text="Include Attachment:" AssociatedControlID="dataIncludeAttachment" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataIncludeAttachment" SelectedValue='<%# Bind("IncludeAttachment") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAttachmentFileName" runat="server" Text="Attachment File Name:" AssociatedControlID="dataAttachmentFileName" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataAttachmentFileName" Text='<%# Bind("AttachmentFileName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailTemplateContentTypeId" runat="server" Text="Email Template Content Type Id:" AssociatedControlID="dataEmailTemplateContentTypeId" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataEmailTemplateContentTypeId" Text='<%# Bind("EmailTemplateContentTypeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailTemplateContentTypeId" runat="server" Display="Dynamic" ControlToValidate="dataEmailTemplateContentTypeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEmailTemplateContentTypeId" runat="server" Display="Dynamic" ControlToValidate="dataEmailTemplateContentTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailTemplateGroupId" runat="server" Text="Email Template Group Id:" AssociatedControlID="dataEmailTemplateGroupId" /></td>
        <td>
					<asp:TextBox Width="305px" runat="server" ID="dataEmailTemplateGroupId" Text='<%# Bind("EmailTemplateGroupId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailTemplateGroupId" runat="server" Display="Dynamic" ControlToValidate="dataEmailTemplateGroupId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataEmailTemplateGroupId" runat="server" Display="Dynamic" ControlToValidate="dataEmailTemplateGroupId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCallFlowId" runat="server" Text="Call Flow Id:" AssociatedControlID="dataCallFlowId" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataCallFlowId" DataSourceID="CallFlowIdCallFlowDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CallFlowId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CallFlowDataSource ID="CallFlowIdCallFlowDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLanguageId" runat="server" Text="Language Id:" AssociatedControlID="dataLanguageId" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataLanguageId" DataSourceID="LanguageIdLanguageDataSource" DataTextField="DisplayName" DataValueField="Id" SelectedValue='<%# Bind("LanguageId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:LanguageDataSource ID="LanguageIdLanguageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


