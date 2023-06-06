<%@ Control Language="C#" ClassName="TempReplayIdsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataReplayId" runat="server" Text="Replay Id:" AssociatedControlID="dataReplayId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReplayId" Text='<%# Bind("ReplayId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReplayId" runat="server" Display="Dynamic" ControlToValidate="dataReplayId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataReplayId" runat="server" Display="Dynamic" ControlToValidate="dataReplayId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAuxiliaryCid" runat="server" Text="Auxiliary Cid:" AssociatedControlID="dataAuxiliaryCid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAuxiliaryCid" Text='<%# Bind("AuxiliaryCid") %>' MaxLength="7"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingDuration" runat="server" Text="Billing Duration:" AssociatedControlID="dataBillingDuration" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillingDuration" Text='<%# Bind("BillingDuration") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBillingDuration" runat="server" Display="Dynamic" ControlToValidate="dataBillingDuration" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNotes" runat="server" Text="Notes:" AssociatedControlID="dataNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNotes" Text='<%# Bind("Notes") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModifiedDate" runat="server" Text="Last Modified Date:" AssociatedControlID="dataLastModifiedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastModifiedDate" Text='<%# Bind("LastModifiedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataLastModifiedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataLastModifiedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataLastModifiedDate" id="calext_dataLastModifiedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataLastModifiedDate" runat="server" Display="Dynamic" ControlToValidate="dataLastModifiedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
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


