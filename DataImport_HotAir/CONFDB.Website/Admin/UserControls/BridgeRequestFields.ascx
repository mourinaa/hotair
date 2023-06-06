<%@ Control Language="C#" ClassName="BridgeRequestFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataId" Value='<%# Bind("Id") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataModeratorId" DataSourceID="ModeratorIdModeratorDataSource" DataTextField="WholesalerId" DataValueField="Id" SelectedValue='<%# Bind("ModeratorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ModeratorDataSource ID="ModeratorIdModeratorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransTimeStamp" runat="server" Text="Trans Time Stamp:" AssociatedControlID="dataTransTimeStamp" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransTimeStamp" Text='<%# Bind("TransTimeStamp", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataTransTimeStamp" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataTransTimeStamp" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataTransTimeStamp" id="calext_dataTransTimeStamp" /><asp:RequiredFieldValidator ID="ReqVal_dataTransTimeStamp" runat="server" Display="Dynamic" ControlToValidate="dataTransTimeStamp" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProcessFlag" runat="server" Text="Process Flag:" AssociatedControlID="dataProcessFlag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProcessFlag" Text='<%# Bind("ProcessFlag") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProcessFlag" runat="server" Display="Dynamic" ControlToValidate="dataProcessFlag" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBridgeRequestTypeId" runat="server" Text="Bridge Request Type Id:" AssociatedControlID="dataBridgeRequestTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBridgeRequestTypeId" DataSourceID="BridgeRequestTypeIdBridgeRequestTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("BridgeRequestTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:BridgeRequestTypeDataSource ID="BridgeRequestTypeIdBridgeRequestTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


