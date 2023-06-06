<%@ Control Language="C#" ClassName="TicketStatusHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTicketId" runat="server" Text="Ticket Id:" AssociatedControlID="dataTicketId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataTicketId" DataSourceID="TicketIdTicketDataSource" DataTextField="Title" DataValueField="Id" SelectedValue='<%# Bind("TicketId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketDataSource ID="TicketIdTicketDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatusId" runat="server" Text="Status Id:" AssociatedControlID="dataStatusId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataStatusId" DataSourceID="StatusIdTicketStatusDataSource" DataTextField="Abbreviation" DataValueField="Id" SelectedValue='<%# Bind("StatusId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketStatusDataSource ID="StatusIdTicketStatusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStatusDate" runat="server" Text="Status Date:" AssociatedControlID="dataStatusDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStatusDate" Text='<%# Bind("StatusDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStatusDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataStatusDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataStatusDate" id="calext_dataStatusDate" /><asp:RequiredFieldValidator ID="ReqVal_dataStatusDate" runat="server" Display="Dynamic" ControlToValidate="dataStatusDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


