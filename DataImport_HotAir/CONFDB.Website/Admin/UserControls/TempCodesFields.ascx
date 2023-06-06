<%@ Control Language="C#" ClassName="TempCodesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCodes" runat="server" Text="Codes:" AssociatedControlID="dataCodes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCodes" Text='<%# Bind("Codes") %>' MaxLength="8"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewCode" runat="server" Text="New Code:" AssociatedControlID="dataNewCode" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataNewCode" SelectedValue='<%# Bind("NewCode") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecCustomerNumber" Text='<%# Bind("SecCustomerNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocation" runat="server" Text="Location:" AssociatedControlID="dataLocation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocation" Text='<%# Bind("Location") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


