<%@ Control Language="C#" ClassName="CustomerDocumentFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocumentDate" runat="server" Text="Document Date:" AssociatedControlID="dataDocumentDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDocumentDate" Text='<%# Bind("DocumentDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDocumentDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataDocumentDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataDocumentDate" id="calext_dataDocumentDate" /><asp:RequiredFieldValidator ID="ReqVal_dataDocumentDate" runat="server" Display="Dynamic" ControlToValidate="dataDocumentDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocumentTypeId" runat="server" Text="Document Type Id:" AssociatedControlID="dataDocumentTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDocumentTypeId" DataSourceID="DocumentTypeIdDocumentTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DocumentTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:DocumentTypeDataSource ID="DocumentTypeIdDocumentTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataKbSize" runat="server" Text="Kb Size:" AssociatedControlID="dataKbSize" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataKbSize" Text='<%# Bind("KbSize") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataKbSize" runat="server" Display="Dynamic" ControlToValidate="dataKbSize" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataKbSize" runat="server" Display="Dynamic" ControlToValidate="dataKbSize" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDocumentDirectory" runat="server" Text="Document Directory:" AssociatedControlID="dataDocumentDirectory" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDocumentDirectory" Text='<%# Bind("DocumentDirectory") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataCreatedDate" runat="server" Display="Dynamic" ControlToValidate="dataCreatedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNotes" runat="server" Text="Notes:" AssociatedControlID="dataNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNotes" Text='<%# Bind("Notes") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLanguageId" runat="server" Text="Language Id:" AssociatedControlID="dataLanguageId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataLanguageId" DataSourceID="LanguageIdLanguageDataSource" DataTextField="DisplayName" DataValueField="Id" SelectedValue='<%# Bind("LanguageId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:LanguageDataSource ID="LanguageIdLanguageDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


