<%@ Control Language="C#" ClassName="CompanyInfoFields" %>

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
        <td class="literal"><asp:Label ID="lbldataLeadId" runat="server" Text="Lead Id:" AssociatedControlID="dataLeadId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLeadId" Text='<%# Bind("LeadId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLeadId" runat="server" Display="Dynamic" ControlToValidate="dataLeadId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLeadId" runat="server" Display="Dynamic" ControlToValidate="dataLeadId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyId" runat="server" Text="Company Id:" AssociatedControlID="dataCompanyId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompanyId" Text='<%# Bind("CompanyId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCompanyId" runat="server" Display="Dynamic" ControlToValidate="dataCompanyId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCompanyId" runat="server" Display="Dynamic" ControlToValidate="dataCompanyId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSlaEndDate" runat="server" Text="Sla End Date:" AssociatedControlID="dataSlaEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSlaEndDate" Text='<%# Bind("SlaEndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataSlaEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataSlaEndDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataSlaEndDate" id="calext_dataSlaEndDate" /><asp:RequiredFieldValidator ID="ReqVal_dataSlaEndDate" runat="server" Display="Dynamic" ControlToValidate="dataSlaEndDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress" runat="server" Text="Address:" AssociatedControlID="dataAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress" Text='<%# Bind("Address") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryId" runat="server" Text="Country Id:" AssociatedControlID="dataCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryId" DataSourceID="CountryIdCountryDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CountryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountryDataSource ID="CountryIdCountryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostal" runat="server" Text="Postal:" AssociatedControlID="dataPostal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostal" Text='<%# Bind("Postal") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


