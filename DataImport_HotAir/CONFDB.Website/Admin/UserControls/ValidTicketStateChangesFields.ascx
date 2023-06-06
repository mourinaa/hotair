<%@ Control Language="C#" ClassName="ValidTicketStateChangesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataFromStatusId" runat="server" Text="From Status Id:" AssociatedControlID="dataFromStatusId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFromStatusId" DataSourceID="FromStatusIdTicketStatusDataSource" DataTextField="Abbreviation" DataValueField="Id" SelectedValue='<%# Bind("FromStatusId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketStatusDataSource ID="FromStatusIdTicketStatusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataToStatusId" runat="server" Text="To Status Id:" AssociatedControlID="dataToStatusId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataToStatusId" DataSourceID="ToStatusIdTicketStatusDataSource" DataTextField="Abbreviation" DataValueField="Id" SelectedValue='<%# Bind("ToStatusId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TicketStatusDataSource ID="ToStatusIdTicketStatusDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReason" runat="server" Text="Reason:" AssociatedControlID="dataReason" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReason" Text='<%# Bind("Reason") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


