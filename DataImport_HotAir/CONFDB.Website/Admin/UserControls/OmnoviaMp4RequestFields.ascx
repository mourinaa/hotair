<%@ Control Language="C#" ClassName="OmnoviaMp4RequestFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedId" runat="server" Text="Hosted Id:" AssociatedControlID="dataHostedId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedId" Text='<%# Bind("HostedId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHostedId" runat="server" Display="Dynamic" ControlToValidate="dataHostedId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataHostedId" runat="server" Display="Dynamic" ControlToValidate="dataHostedId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRequestedBy" runat="server" Text="Requested By:" AssociatedControlID="dataRequestedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRequestedBy" Text='<%# Bind("RequestedBy") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEstimatedTime" runat="server" Text="Estimated Time:" AssociatedControlID="dataEstimatedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEstimatedTime" Text='<%# Bind("EstimatedTime") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExtraInfo" runat="server" Text="Extra Info:" AssociatedControlID="dataExtraInfo" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExtraInfo" Text='<%# Bind("ExtraInfo") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOmnoviaHostedUrl" runat="server" Text="Omnovia Hosted Url:" AssociatedControlID="dataOmnoviaHostedUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOmnoviaHostedUrl" Text='<%# Bind("OmnoviaHostedUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRedbackHostedUrl" runat="server" Text="Redback Hosted Url:" AssociatedControlID="dataRedbackHostedUrl" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRedbackHostedUrl" Text='<%# Bind("RedbackHostedUrl") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOmnoviaHostedUrlExpiryDate" runat="server" Text="Omnovia Hosted Url Expiry Date:" AssociatedControlID="dataOmnoviaHostedUrlExpiryDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOmnoviaHostedUrlExpiryDate" Text='<%# Bind("OmnoviaHostedUrlExpiryDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataOmnoviaHostedUrlExpiryDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataOmnoviaHostedUrlExpiryDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataOmnoviaHostedUrlExpiryDate" id="calext_dataOmnoviaHostedUrlExpiryDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreated" runat="server" Text="Created:" AssociatedControlID="dataCreated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreated" Text='<%# Bind("Created", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreated" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreated" id="calext_dataCreated" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


