<%@ Control Language="C#" ClassName="OmnoviaHostedArchiveFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataOmnoviaCustomerId" runat="server" Text="Omnovia Customer Id:" AssociatedControlID="dataOmnoviaCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOmnoviaCustomerId" Text='<%# Bind("OmnoviaCustomerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataOmnoviaCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataOmnoviaCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieId" runat="server" Text="Movie Id:" AssociatedControlID="dataMovieId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieId" Text='<%# Bind("MovieId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMovieId" runat="server" Display="Dynamic" ControlToValidate="dataMovieId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMovieId" runat="server" Display="Dynamic" ControlToValidate="dataMovieId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRoomName" runat="server" Text="Room Name:" AssociatedControlID="dataRoomName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRoomName" Text='<%# Bind("RoomName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieTitle" runat="server" Text="Movie Title:" AssociatedControlID="dataMovieTitle" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieTitle" Text='<%# Bind("MovieTitle") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieDateAdded" runat="server" Text="Movie Date Added:" AssociatedControlID="dataMovieDateAdded" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieDateAdded" Text='<%# Bind("MovieDateAdded", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataMovieDateAdded" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataMovieDateAdded" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataMovieDateAdded" id="calext_dataMovieDateAdded" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieLength" runat="server" Text="Movie Length:" AssociatedControlID="dataMovieLength" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieLength" Text='<%# Bind("MovieLength") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMovieLength" runat="server" Display="Dynamic" ControlToValidate="dataMovieLength" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieRoomId" runat="server" Text="Movie Room Id:" AssociatedControlID="dataMovieRoomId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieRoomId" Text='<%# Bind("MovieRoomId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMovieRoomId" runat="server" Display="Dynamic" ControlToValidate="dataMovieRoomId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMovieDate" runat="server" Text="Movie Date:" AssociatedControlID="dataMovieDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMovieDate" Text='<%# Bind("MovieDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataMovieDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataMovieDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataMovieDate" id="calext_dataMovieDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyShortLink" runat="server" Text="Company Short Link:" AssociatedControlID="dataCompanyShortLink" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyShortLink" Text='<%# Bind("CompanyShortLink") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreated" runat="server" Text="Created:" AssociatedControlID="dataCreated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreated" Text='<%# Bind("Created", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreated" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreated" id="calext_dataCreated" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkExpiryDate" runat="server" Text="Hosted Link Expiry Date:" AssociatedControlID="dataHostedLinkExpiryDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkExpiryDate" Text='<%# Bind("HostedLinkExpiryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataHostedLinkExpiryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataHostedLinkExpiryDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataHostedLinkExpiryDate" id="calext_dataHostedLinkExpiryDate" /><asp:RequiredFieldValidator ID="ReqVal_dataHostedLinkExpiryDate" runat="server" Display="Dynamic" ControlToValidate="dataHostedLinkExpiryDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkShortened" runat="server" Text="Hosted Link Shortened:" AssociatedControlID="dataHostedLinkShortened" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkShortened" Text='<%# Bind("HostedLinkShortened") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHostedLinkShortened" runat="server" Display="Dynamic" ControlToValidate="dataHostedLinkShortened" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedLinkAlias" runat="server" Text="Hosted Link Alias:" AssociatedControlID="dataHostedLinkAlias" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedLinkAlias" Text='<%# Bind("HostedLinkAlias") %>' MaxLength="50"></asp:TextBox>
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
        <td class="literal"><asp:Label ID="lbldataHostingPeriod" runat="server" Text="Hosting Period:" AssociatedControlID="dataHostingPeriod" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostingPeriod" Text='<%# Bind("HostingPeriod") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataHostingPeriod" runat="server" Display="Dynamic" ControlToValidate="dataHostingPeriod" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostingAutoRenew" runat="server" Text="Hosting Auto Renew:" AssociatedControlID="dataHostingAutoRenew" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostingAutoRenew" Text='<%# Bind("HostingAutoRenew") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataHostingAutoRenew" runat="server" Display="Dynamic" ControlToValidate="dataHostingAutoRenew" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEvent_Id" runat="server" Text="Event Id:" AssociatedControlID="dataEvent_Id" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEvent_Id" Text='<%# Bind("Event_Id") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataEvent_Id" runat="server" Display="Dynamic" ControlToValidate="dataEvent_Id" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


