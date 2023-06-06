<%@ Control Language="C#" ClassName="ForExFields" %>

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
        <td class="literal"><asp:Label ID="lbldataFromCcy" runat="server" Text="From Ccy:" AssociatedControlID="dataFromCcy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFromCcy" Text='<%# Bind("FromCcy") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataFromCcy" runat="server" Display="Dynamic" ControlToValidate="dataFromCcy" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataToCcy" runat="server" Text="To Ccy:" AssociatedControlID="dataToCcy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataToCcy" Text='<%# Bind("ToCcy") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataToCcy" runat="server" Display="Dynamic" ControlToValidate="dataToCcy" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRate" runat="server" Text="Rate:" AssociatedControlID="dataRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRate" Text='<%# Bind("Rate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRate" runat="server" Display="Dynamic" ControlToValidate="dataRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRate" runat="server" Display="Dynamic" ControlToValidate="dataRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurveId" runat="server" Text="Curve Id:" AssociatedControlID="dataCurveId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCurveId" DataSourceID="CurveIdCurveDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CurveId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurveDataSource ID="CurveIdCurveDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEffectiveDate" runat="server" Text="Effective Date:" AssociatedControlID="dataEffectiveDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEffectiveDate" Text='<%# Bind("EffectiveDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEffectiveDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataEffectiveDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataEffectiveDate" id="calext_dataEffectiveDate" /><asp:RequiredFieldValidator ID="ReqVal_dataEffectiveDate" runat="server" Display="Dynamic" ControlToValidate="dataEffectiveDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


