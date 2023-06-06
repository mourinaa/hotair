<%@ Control Language="C#" ClassName="BridgeQueueFields" %>

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
        <td class="literal"><asp:Label ID="lbldataBridgeId" runat="server" Text="Bridge Id:" AssociatedControlID="dataBridgeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBridgeId" DataSourceID="BridgeIdBridgeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("BridgeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:BridgeDataSource ID="BridgeIdBridgeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProcessFlag" runat="server" Text="Process Flag:" AssociatedControlID="dataProcessFlag" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProcessFlag" Text='<%# Bind("ProcessFlag") %>' MaxLength="1"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProcessFlag" runat="server" Display="Dynamic" ControlToValidate="dataProcessFlag" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


