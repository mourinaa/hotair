<%@ Control Language="C#" ClassName="ModeratorFieldsEdit" %>

<%--************************ NOTE: Use this control for Editing ******************************--%>
<asp:FormView ID="ModFormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"></td>
        <td>
					<%-- <asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
					<asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>'/>
				</td>
			</tr>
			<tr>
                <td class="literal">
                    <asp:HyperLink ID="lnkCustomerId" runat="server" Text="Customer:" NavigateUrl='<%# string.Format("~/Admin/CustomerEdit.aspx?Id={0}", Eval("CustomerId")) %>' />
                <td>
	                <data:EntityDropDownList runat="server" ReadOnly="true" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
	                <data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetByWholesalerId">
	                    <Parameters>
	                        <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID" Type="string">
	                        </data:SqlParameter>
	                    </Parameters>
	                </data:CustomerDataSource>
                </td>
			</tr>
			
        <%--	
        	<tr>
                <td class="literal"><asp:Label Visible="false" ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
                <td>
                    <asp:HiddenField runat="server" ID="dataCustomerId" Value='<%# Eval("CustomerId") %>'/>
                </td>
			</tr>
			<tr>
		--%>
            <tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox ReadOnly="true" runat="server" ID="dataPriCustomerNumber" Text='<%# Eval("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPriCustomerNumber" runat="server" Display="Dynamic" ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
            </tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox ReadOnly="true" runat="server" ID="dataSecCustomerNumber" Text='<%# Eval("SecCustomerNumber") %>' MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSecCustomerNumber" runat="server" Display="Dynamic" ControlToValidate="dataSecCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExternalModeratorNumber" runat="server" Text="External Moderator Number:" AssociatedControlID="dataExternalModeratorNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExternalModeratorNumber" Text='<%# Bind("ExternalModeratorNumber") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>' MaxLength="16"></asp:TextBox><asp:Label ID="lblModCodeReminder" Visible="false" runat="server" Text="*Reminder*: Press 'Update' to save your changes." CssClass="note" />
					<asp:RequiredFieldValidator ID="ReqVal_dataModeratorCode" runat="server" Display="Dynamic" ControlToValidate="dataModeratorCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
					<asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="dataModeratorCode" ControlToCompare="dataPassCode" Operator="NotEqual" Type="String" ErrorMessage="Moderator Code can not be equal to the Pass Code."></asp:CompareValidator>
					
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassCode" runat="server" Text="Pass Code:" AssociatedControlID="dataPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassCode" Text='<%# Bind("PassCode") %>' MaxLength="16"></asp:TextBox> <asp:Label ID="lblPassCodeReminder" Visible="false" runat="server" Text="*Reminder*: Press 'Update' to save your changes." CssClass="note" />
					<asp:RequiredFieldValidator ID="ReqVal_dataPassCode" runat="server" Display="Dynamic" ControlToValidate="dataPassCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
					<asp:CompareValidator ID="CompareValidator2" runat="server" Display="Dynamic" ControlToValidate="dataPassCode" ControlToCompare="dataModeratorCode" Operator="NotEqual" Type="String" ErrorMessage="Pass Code can not be equal to the Moderator Code."></asp:CompareValidator>

				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPhoneNumber" runat="server" Text="Phone Number:" AssociatedControlID="dataPhoneNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPhoneNumber" Text='<%# Bind("PhoneNumber") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDepartmentId" runat="server" Text="Department Id:" AssociatedControlID="dataDepartmentId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataDepartmentId" DataSourceID="DepartmentIdDepartmentDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentId") %>' AppendNullItem="false" Required="true" NullItemText="No Department" ErrorText="Required" />
					<%--<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetAll"  />--%>
					<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetByCustomerIdCustom">
					    <Parameters>
					        <asp:ControlParameter Name="CustomerId" ControlID="dataCustomerId" PropertyName="SelectedValue" Type="Int32" />
					    </Parameters>
					</data:DepartmentDataSource>
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
        <td class="literal"><asp:Label ID="lbldataSecContactName" runat="server" Text="Sec Contact Name:" AssociatedControlID="dataSecContactName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecContactName" Text='<%# Bind("SecContactName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecContactPhoneNumber" runat="server" Text="Sec Contact Phone Number:" AssociatedControlID="dataSecContactPhoneNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecContactPhoneNumber" Text='<%# Bind("SecContactPhoneNumber") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecContactEmailAddress" runat="server" Text="Sec Contact Email Address:" AssociatedControlID="dataSecContactEmailAddress" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecContactEmailAddress" Text='<%# Bind("SecContactEmailAddress") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox ReadOnly="true" runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:Label runat="server" ID="dataCreatedDate" Text='<%# Eval("CreatedDate", "{0:d}") %>'/>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
        <td>
					<asp:Label runat="server" ID="dataLastModified" Text='<%# Eval("LastModified", "{0:d}") %>' />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
<%--			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueModeratorId" runat="server" Text="Unique Moderator Id:" AssociatedControlID="dataUniqueModeratorId" /></td>
        <td>
					<asp:Label runat="server" id="dataUniqueModeratorId" Text='<%# Eval("UniqueModeratorId") %>'/>
				</td>
			</tr>	--%>		
		</table>

	</ItemTemplate>
</asp:FormView>


