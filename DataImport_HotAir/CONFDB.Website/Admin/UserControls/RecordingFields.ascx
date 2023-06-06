<%@ Control Language="C#" ClassName="RecordingFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBridgeId" runat="server" Text="Bridge Id:" AssociatedControlID="dataBridgeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBridgeId" Text='<%# Bind("BridgeId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBridgeId" runat="server" Display="Dynamic" ControlToValidate="dataBridgeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecordingStartTime" runat="server" Text="Recording Start Time:" AssociatedControlID="dataRecordingStartTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRecordingStartTime" Text='<%# Bind("RecordingStartTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRecordingStartTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataRecordingStartTime" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataRecordingStartTime" id="calext_dataRecordingStartTime" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecordingEndTime" runat="server" Text="Recording End Time:" AssociatedControlID="dataRecordingEndTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRecordingEndTime" Text='<%# Bind("RecordingEndTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataRecordingEndTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataRecordingEndTime" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataRecordingEndTime" id="calext_dataRecordingEndTime" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>' MaxLength="16"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassCode" runat="server" Text="Pass Code:" AssociatedControlID="dataPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassCode" Text='<%# Bind("PassCode") %>' MaxLength="16"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecCustomerNumber" Text='<%# Bind("SecCustomerNumber") %>' MaxLength="6"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecordingDirectory" runat="server" Text="Recording Directory:" AssociatedControlID="dataRecordingDirectory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRecordingDirectory" Text='<%# Bind("RecordingDirectory") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueConferenceId" runat="server" Text="Unique Conference Id:" AssociatedControlID="dataUniqueConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUniqueConferenceId" Text='<%# Bind("UniqueConferenceId") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReplayCode" runat="server" Text="Replay Code:" AssociatedControlID="dataReplayCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReplayCode" Text='<%# Bind("ReplayCode") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProcessFlag" runat="server" Text="Process Flag:" AssociatedControlID="dataProcessFlag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProcessFlag" Text='<%# Bind("ProcessFlag") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailSent" runat="server" Text="Email Sent:" AssociatedControlID="dataEmailSent" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEmailSent" SelectedValue='<%# Bind("EmailSent") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRpFileNumber" runat="server" Text="Rp File Number:" AssociatedControlID="dataRpFileNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRpFileNumber" Text='<%# Bind("RpFileNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNotes" runat="server" Text="Notes:" AssociatedControlID="dataNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNotes" Text='<%# Bind("Notes") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMp3Flag" runat="server" Text="Mp3 Flag:" AssociatedControlID="dataMp3Flag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMp3Flag" Text='<%# Bind("Mp3Flag") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMp3SizeInKb" runat="server" Text="Mp3 Size In Kb:" AssociatedControlID="dataMp3SizeInKb" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMp3SizeInKb" Text='<%# Bind("Mp3SizeInKb") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMp3SizeInKb" runat="server" Display="Dynamic" ControlToValidate="dataMp3SizeInKb" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStorageDuration" runat="server" Text="Storage Duration:" AssociatedControlID="dataStorageDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStorageDuration" Text='<%# Bind("StorageDuration") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataStorageDuration" runat="server" Display="Dynamic" ControlToValidate="dataStorageDuration" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingDuration" runat="server" Text="Billing Duration:" AssociatedControlID="dataBillingDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillingDuration" Text='<%# Bind("BillingDuration") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBillingDuration" runat="server" Display="Dynamic" ControlToValidate="dataBillingDuration" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingId" runat="server" Text="Billing Id:" AssociatedControlID="dataBillingId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillingId" Text='<%# Bind("BillingId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDurationSec" runat="server" Text="Duration Sec:" AssociatedControlID="dataDurationSec" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDurationSec" Text='<%# Bind("DurationSec") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDurationSec" runat="server" Display="Dynamic" ControlToValidate="dataDurationSec" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAuxiliaryConferenceId" runat="server" Text="Auxiliary Conference Id:" AssociatedControlID="dataAuxiliaryConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAuxiliaryConferenceId" Text='<%# Bind("AuxiliaryConferenceId") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMediaType" runat="server" Text="Media Type:" AssociatedControlID="dataMediaType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMediaType" Text='<%# Bind("MediaType") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkExpiryDate" runat="server" Text="Hosted Link Expiry Date:" AssociatedControlID="dataHostedLinkExpiryDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkExpiryDate" Text='<%# Bind("HostedLinkExpiryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataHostedLinkExpiryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataHostedLinkExpiryDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataHostedLinkExpiryDate" id="calext_dataHostedLinkExpiryDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkType" runat="server" Text="Hosted Link Type:" AssociatedControlID="dataHostedLinkType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkType" Text='<%# Bind("HostedLinkType") %>' MaxLength="1"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkUrl" runat="server" Text="Hosted Link Url:" AssociatedControlID="dataHostedLinkUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkUrl" Text='<%# Bind("HostedLinkUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExtendRecordingDate" runat="server" Text="Extend Recording Date:" AssociatedControlID="dataExtendRecordingDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExtendRecordingDate" Text='<%# Bind("ExtendRecordingDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataExtendRecordingDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataExtendRecordingDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataExtendRecordingDate" id="calext_dataExtendRecordingDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRecordingGuid" runat="server" Text="Recording Guid:" AssociatedControlID="dataRecordingGuid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRecordingGuid" Text='<%# Bind("RecordingGuid") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


