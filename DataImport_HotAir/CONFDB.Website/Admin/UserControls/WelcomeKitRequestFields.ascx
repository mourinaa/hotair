<%@ Control Language="C#" ClassName="WelcomeKitRequestFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataModeratorId" DataSourceID="ModeratorIdModeratorDataSource" DataTextField="WholesalerId" DataValueField="Id" SelectedValue='<%# Bind("ModeratorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ModeratorDataSource ID="ModeratorIdModeratorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNotes" runat="server" Text="Notes:" AssociatedControlID="dataNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNotes" Text='<%# Bind("Notes") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestedBy" runat="server" Text="Requested By:" AssociatedControlID="dataRequestedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRequestedBy" Text='<%# Bind("RequestedBy") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModifiedBy" runat="server" Text="Last Modified By:" AssociatedControlID="dataLastModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModifiedBy" Text='<%# Bind("LastModifiedBy") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModified" Text='<%# Bind("LastModified", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModified" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataLastModified" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataLastModified" id="calext_dataLastModified" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModified" runat="server" Display="Dynamic" ControlToValidate="dataLastModified" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestProcessed" runat="server" Text="Request Processed:" AssociatedControlID="dataRequestProcessed" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRequestProcessed" SelectedValue='<%# Bind("RequestProcessed") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestCompletedDate" runat="server" Text="Request Completed Date:" AssociatedControlID="dataRequestCompletedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRequestCompletedDate" Text='<%# Bind("RequestCompletedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRequestCompletedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataRequestCompletedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataRequestCompletedDate" id="calext_dataRequestCompletedDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestCompletedBy" runat="server" Text="Request Completed By:" AssociatedControlID="dataRequestCompletedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRequestCompletedBy" Text='<%# Bind("RequestCompletedBy") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBilledDate" runat="server" Text="Billed Date:" AssociatedControlID="dataBilledDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBilledDate" Text='<%# Bind("BilledDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBilledDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataBilledDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataBilledDate" id="calext_dataBilledDate" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


