<%@ Control Language="C#" ClassName="ActionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateTimeStamp" runat="server" Text="Date Time Stamp:" AssociatedControlID="dataDateTimeStamp" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateTimeStamp" Text='<%# Bind("DateTimeStamp", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateTimeStamp" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataDateTimeStamp" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataDateTimeStamp" id="calext_dataDateTimeStamp" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActionTypeId" runat="server" Text="Action Type Id:" AssociatedControlID="dataActionTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataActionTypeId" DataSourceID="ActionTypeIdActionTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ActionTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ActionTypeDataSource ID="ActionTypeIdActionTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataActionFrom" runat="server" Text="Action From:" AssociatedControlID="dataActionFrom" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataActionFrom" Text='<%# Bind("ActionFrom") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataActionFrom" runat="server" Display="Dynamic" ControlToValidate="dataActionFrom" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExtraInfo" runat="server" Text="Extra Info:" AssociatedControlID="dataExtraInfo" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExtraInfo" Text='<%# Bind("ExtraInfo") %>' MaxLength="200"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProcessedFlag" runat="server" Text="Processed Flag:" AssociatedControlID="dataProcessedFlag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProcessedFlag" Text='<%# Bind("ProcessedFlag") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProcessedFlag" runat="server" Display="Dynamic" ControlToValidate="dataProcessedFlag" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


