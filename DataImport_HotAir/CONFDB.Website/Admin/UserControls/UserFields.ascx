<%@ Control Language="C#" ClassName="UserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUsername" runat="server" Text="Username:" AssociatedControlID="dataUsername" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUsername" Text='<%# Bind("Username") %>' MaxLength="100"></asp:TextBox>
					<asp:RequiredFieldValidator ID="ReqVal_dataUsername" runat="server" Display="Dynamic" ControlToValidate="dataUsername" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassword" runat="server" Text="Password:" AssociatedControlID="dataPassword" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassword" Text='<%# Bind("Password") %>' MaxLength="50">
					</asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassword" runat="server" Display="Dynamic" ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>' MaxLength="100"></asp:TextBox>
					<asp:RequiredFieldValidator ID="ReqVal_dataDisplayName" runat="server" Display="Dynamic" ControlToValidate="dataDisplayName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="dataEmail" ErrorMessage="Required"></asp:RequiredFieldValidator>					
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTelephone" runat="server" Text="Telephone:" AssociatedControlID="dataTelephone" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTelephone" Text='<%# Bind("Telephone") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyId" runat="server" Text="Company" AssociatedControlID="dataCompanyId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCompanyId" DataSourceID="CompanyIdCompanyDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CompanyId") %>' AppendNullItem="true" Required="false" NullItemText="None" />
					<data:CompanyDataSource ID="CompanyIdCompanyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource" DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>' AppendNullItem="true" Required="false" NullItemText="None" />
					<data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRoleId" runat="server" Text="Role" AssociatedControlID="dataRoleId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataRoleId" DataSourceID="RoleIdRoleDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("RoleId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:RoleDataSource ID="RoleIdRoleDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMustChangePassword" runat="server" Text="Must Change Password:" AssociatedControlID="dataMustChangePassword" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataMustChangePassword" SelectedValue='<%# Bind("MustChangePassword") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress1" runat="server" Text="Address1:" AssociatedControlID="dataAddress1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress1" Text='<%# Bind("Address1") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAddress2" runat="server" Text="Address2:" AssociatedControlID="dataAddress2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAddress2" Text='<%# Bind("Address2") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCity" Text='<%# Bind("City") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountry" runat="server" Text="Country:" AssociatedControlID="dataCountry" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountry" DataSourceID="CountryCountryDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("Country") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CountryDataSource ID="CountryCountryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRegion" runat="server" Text="Region:" AssociatedControlID="dataRegion" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataRegion" DataSourceID="RegionStateDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("Region") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:StateDataSource ID="RegionStateDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostalCode" runat="server" Text="Postal Code:" AssociatedControlID="dataPostalCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostalCode" Text='<%# Bind("PostalCode") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCharityId" runat="server" Text="Charity" AssociatedControlID="dataCharityId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCharityId" DataSourceID="CharityIdCharityDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CharityId") %>' AppendNullItem="false" Required="false" NullItemText="< Please Choose ...>" />
					<data:CharityDataSource ID="CharityIdCharityDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
<%--			<tr>
        <td class="literal"><asp:Label ID="lbldataWebMemberId" runat="server" Text="Web Member" AssociatedControlID="dataWebMemberId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebMemberId" Text='<%# Bind("WebMemberId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
--%>			
		</table>

	</ItemTemplate>
</asp:FormView>


