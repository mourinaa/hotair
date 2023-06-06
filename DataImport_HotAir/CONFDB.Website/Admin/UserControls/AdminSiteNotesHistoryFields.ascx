<%@ Control Language="C#" ClassName="AdminSiteNotesHistoryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdminSiteNotesId" runat="server" Text="Admin Site Notes Id:" AssociatedControlID="dataAdminSiteNotesId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataAdminSiteNotesId" DataSourceID="AdminSiteNotesIdAdminSiteNotesDataSource" DataTextField="CustomerId" DataValueField="Id" SelectedValue='<%# Bind("AdminSiteNotesId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:AdminSiteNotesDataSource ID="AdminSiteNotesIdAdminSiteNotesDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNotes" runat="server" Text="Notes:" AssociatedControlID="dataNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNotes" Text='<%# Bind("Notes") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


