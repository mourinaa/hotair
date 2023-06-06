<%@ Control Language="C#" ClassName="SystemExtensionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTableId" runat="server" Text="Table Id:" AssociatedControlID="dataTableId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTableId" Text='<%# Bind("TableId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTableId" runat="server" Display="Dynamic" ControlToValidate="dataTableId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTableId" runat="server" Display="Dynamic" ControlToValidate="dataTableId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReferenceValue" runat="server" Text="Reference Value:" AssociatedControlID="dataReferenceValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReferenceValue" Text='<%# Bind("ReferenceValue") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataReferenceValue" runat="server" Display="Dynamic" ControlToValidate="dataReferenceValue" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSystemExtensionLabelId" runat="server" Text="System Extension Label Id:" AssociatedControlID="dataSystemExtensionLabelId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSystemExtensionLabelId" DataSourceID="SystemExtensionLabelIdSystemExtensionLabelDataSource" DataTextField="CustomerId" DataValueField="Id" SelectedValue='<%# Bind("SystemExtensionLabelId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SystemExtensionLabelDataSource ID="SystemExtensionLabelIdSystemExtensionLabelDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


