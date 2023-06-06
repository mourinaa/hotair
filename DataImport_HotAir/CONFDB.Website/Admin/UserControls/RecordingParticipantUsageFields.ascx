<%@ Control Language="C#" ClassName="RecordingParticipantUsageFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecordingId" runat="server" Text="Recording Id:" AssociatedControlID="dataRecordingId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataRecordingId" DataSourceID="RecordingIdRecordingDataSource" DataTextField="WholesalerId" DataValueField="Id" SelectedValue='<%# Bind("RecordingId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:RecordingDataSource ID="RecordingIdRecordingDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataParticipantName" runat="server" Text="Participant Name:" AssociatedControlID="dataParticipantName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataParticipantName" Text='<%# Bind("ParticipantName") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataParticipantName" runat="server" Display="Dynamic" ControlToValidate="dataParticipantName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataParticipantCompanyName" runat="server" Text="Participant Company Name:" AssociatedControlID="dataParticipantCompanyName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataParticipantCompanyName" Text='<%# Bind("ParticipantCompanyName") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataParticipantCompanyName" runat="server" Display="Dynamic" ControlToValidate="dataParticipantCompanyName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataParticipantEmail" runat="server" Text="Participant Email:" AssociatedControlID="dataParticipantEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataParticipantEmail" Text='<%# Bind("ParticipantEmail") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataParticipantEmail" runat="server" Display="Dynamic" ControlToValidate="dataParticipantEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDownloadDate" runat="server" Text="Download Date:" AssociatedControlID="dataDownloadDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDownloadDate" Text='<%# Bind("DownloadDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDownloadDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataDownloadDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataDownloadDate" id="calext_dataDownloadDate" /><asp:RequiredFieldValidator ID="ReqVal_dataDownloadDate" runat="server" Display="Dynamic" ControlToValidate="dataDownloadDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


