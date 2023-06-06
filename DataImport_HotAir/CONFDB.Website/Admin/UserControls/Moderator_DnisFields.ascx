<%@ Control Language="C#" ClassName="Moderator_DnisFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDnisid" runat="server" Text="Dnisid:" AssociatedControlID="dataDnisid" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDnisid" DataSourceID="DnisidDnisDataSource" DataTextField="DnisNumber" DataValueField="Id" SelectedValue='<%# Bind("Dnisid") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DnisDataSource ID="DnisidDnisDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataModeratorId" DataSourceID="ModeratorIdModeratorDataSource" DataTextField="WholesalerId" DataValueField="Id" SelectedValue='<%# Bind("ModeratorId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ModeratorDataSource ID="ModeratorIdModeratorDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


