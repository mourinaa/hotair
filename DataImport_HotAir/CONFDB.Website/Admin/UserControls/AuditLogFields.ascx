<%@ Control Language="C#" ClassName="AuditLogFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataTblName" runat="server" Text="Tbl Name:" AssociatedControlID="dataTblName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTblName" Text='<%# Bind("TblName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTablePkid" runat="server" Text="Table Pkid:" AssociatedControlID="dataTablePkid" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTablePkid" Text='<%# Bind("TablePkid") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTablePkid" runat="server" Display="Dynamic" ControlToValidate="dataTablePkid" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataColumnsUpdated" runat="server" Text="Columns Updated:" AssociatedControlID="dataColumnsUpdated" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataColumnsUpdated" Value='<%# Bind("ColumnsUpdated") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCategory" runat="server" Text="Category:" AssociatedControlID="dataCategory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCategory" Text='<%# Bind("Category") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


