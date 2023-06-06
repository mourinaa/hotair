<%@ Control Language="C#" ClassName="CustomerFields" %>
<%--NOTE: This control is used in Insert/Add mode.--%>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" />--%>
                </td>
                <td>
                    <%--<asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>' />--%>
                    <data:EntityDropDownList Visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                        <Parameters>
                            <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                        </Parameters>
                    </data:WholesalerDataSource>
                    
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:"
                        AssociatedControlID="dataPriCustomerNumber" /></td>
                <td>
                    <asp:TextBox ReadOnly="true" runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>'
                        MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPriCustomerNumber" Enabled="false"
                            runat="server" Display="Dynamic" ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="dataPriCustomerNumber" 
                        WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataExternalCustomerNumber" runat="server" Text="External Customer Number:"
                        AssociatedControlID="dataExternalCustomerNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataExternalCustomerNumber" Text='<%# Bind("ExternalCustomerNumber") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactName" runat="server" Text="Primary Contact Name:"
                        AssociatedControlID="dataPrimaryContactName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactName" Text='<%# Bind("PrimaryContactName") %>'
                        MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactName"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactPhoneNumber" runat="server" Text="Primary Contact Phone Number:"
                        AssociatedControlID="dataPrimaryContactPhoneNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactPhoneNumber" Text='<%# Bind("PrimaryContactPhoneNumber") %>'
                        MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactPhoneNumber"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactPhoneNumber"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactEmailAddress" runat="server" Text="Primary Contact Email Address:"
                        AssociatedControlID="dataPrimaryContactEmailAddress" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactEmailAddress" Text='<%# Bind("PrimaryContactEmailAddress") %>'
                        MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactEmailAddress"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactEmailAddress"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
						    <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" Display="Dynamic"
							    ControlToValidate="dataPrimaryContactEmailAddress" ErrorMessage="Email address is not valid." ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                           
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactAddress1" runat="server" Text="Primary Contact Address1:"
                        AssociatedControlID="dataPrimaryContactAddress1" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactAddress1" Text='<%# Bind("PrimaryContactAddress1") %>'
                        MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactAddress1"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactAddress2" runat="server" Text="Primary Contact Address2:"
                        AssociatedControlID="dataPrimaryContactAddress2" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactAddress2" Text='<%# Bind("PrimaryContactAddress2") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactCity" runat="server" Text="Primary Contact City:"
                        AssociatedControlID="dataPrimaryContactCity" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactCity" Text='<%# Bind("PrimaryContactCity") %>'
                        MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactCity"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactCountry" runat="server" Text="Primary Contact Country:"
                        AssociatedControlID="dataPrimaryContactCountry" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataPrimaryContactCountry" DataSourceID="PrimaryContactCountryCountryDataSource"
                        DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("PrimaryContactCountry") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required"/>
                    <data:CountryDataSource ID="PrimaryContactCountryCountryDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactRegion" runat="server" Text="Primary Contact Region:"
                        AssociatedControlID="dataPrimaryContactRegion" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataPrimaryContactRegion" DataSourceID="PrimaryContactRegionStateDataSource"
                        DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("PrimaryContactRegion") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required"/>
                    <data:StateDataSource ID="PrimaryContactRegionStateDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactPostalCode" runat="server" Text="Primary Contact Postal Code:"
                        AssociatedControlID="dataPrimaryContactPostalCode" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactPostalCode" Text='<%# Bind("PrimaryContactPostalCode") %>'
                        MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactPostalCode"
                            ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPrimaryContactFaxNumber" runat="server" Text="Primary Contact Fax Number:"
                        AssociatedControlID="dataPrimaryContactFaxNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataPrimaryContactFaxNumber" Text='<%# Bind("PrimaryContactFaxNumber") %>'
                        MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2"><p class="literalbold">NOTE: Blank Billing Contact information will be set to the Primary Contact information listed above.</p>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactName" runat="server" Text="Billing Contact Name:"
                        AssociatedControlID="dataBillingContactName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactName" Text='<%# Bind("BillingContactName") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactPhoneNumber" runat="server" Text="Billing Contact Phone Number:"
                        AssociatedControlID="dataBillingContactPhoneNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactPhoneNumber" Text='<%# Bind("BillingContactPhoneNumber") %>'
                        MaxLength="30"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactEmailAddress" runat="server" Text="Billing Contact Email Address:"
                        AssociatedControlID="dataBillingContactEmailAddress" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactEmailAddress" Text='<%# Bind("BillingContactEmailAddress") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactAddress1" runat="server" Text="Billing Contact Address1:"
                        AssociatedControlID="dataBillingContactAddress1" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactAddress1" Text='<%# Bind("BillingContactAddress1") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactAddress2" runat="server" Text="Billing Contact Address2:"
                        AssociatedControlID="dataBillingContactAddress2" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactAddress2" Text='<%# Bind("BillingContactAddress2") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactCity" runat="server" Text="Billing Contact City:"
                        AssociatedControlID="dataBillingContactCity" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactCity" Text='<%# Bind("BillingContactCity") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactCountry" runat="server" Text="Billing Contact Country:"
                        AssociatedControlID="dataBillingContactCountry" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataBillingContactCountry" DataSourceID="BillingContactCountryCountryDataSource"
                        DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("BillingContactCountry") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                    <data:CountryDataSource ID="BillingContactCountryCountryDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactRegion" runat="server" Text="Billing Contact Region:"
                        AssociatedControlID="dataBillingContactRegion" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataBillingContactRegion" DataSourceID="BillingContactRegionStateDataSource"
                        DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("BillingContactRegion") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                    <data:StateDataSource ID="BillingContactRegionStateDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingContactPostalCode" runat="server" Text="Billing Contact Postal Code:"
                        AssociatedControlID="dataBillingContactPostalCode" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingContactPostalCode" Text='<%# Bind("BillingContactPostalCode") %>'
                        MaxLength="20"></asp:TextBox>
                </td>
            </tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingContactFaxNumber" runat="server" Text="Billing Contact Fax Number:" AssociatedControlID="dataBillingContactFaxNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillingContactFaxNumber" Text='<%# Bind("BillingContactFaxNumber") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWebsiteUrl" runat="server" Text="Website Url:" AssociatedControlID="dataWebsiteUrl" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataWebsiteUrl" Text='<%# Bind("WebsiteUrl") %>'
                        MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person" AssociatedControlID="dataSalesPersonId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                        DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataVerticalId" runat="server" Text="Vertical" AssociatedControlID="dataVerticalId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataVerticalId" DataSourceID="VerticalIdVerticalDataSource"
                        DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("VerticalId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:VerticalDataSource ID="VerticalIdVerticalDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCompanyId" runat="server" Text="Company" AssociatedControlID="dataCompanyId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCompanyId" DataSourceID="CompanyIdCompanyDataSource"
                        DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CompanyId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:CompanyDataSource ID="CompanyIdCompanyDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency" AssociatedControlID="dataCurrencyId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCurrencyId" DataSourceID="CurrencyIdCurrencyDataSource"
                        DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("CurrencyId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:CurrencyDataSource ID="CurrencyIdCurrencyDataSource" runat="server" SelectMethod="GetPaged">
                        <Parameters>
                            <data:CustomParameter Name="WhereClause" Value="Enabled=1" Type="String" />
                        </Parameters>
                    </data:CurrencyDataSource>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillingPeriodCutoff" runat="server" Text="Billing Period Cutoff:"
                        AssociatedControlID="dataBillingPeriodCutoff" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataBillingPeriodCutoff" Text='<%# Bind("BillingPeriodCutoff") %>'></asp:TextBox><asp:RangeValidator
                        ID="RangeVal_dataBillingPeriodCutoff" runat="server" Display="Dynamic" ControlToValidate="dataBillingPeriodCutoff"
                        ErrorMessage="Invalid value" MaximumValue="31" MinimumValue="1"
                        Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataTaxableId" runat="server" Text="Taxable" AssociatedControlID="dataTaxableId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataTaxableId" DataSourceID="TaxableIdTaxableDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TaxableId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:TaxableDataSource ID="TaxableIdTaxableDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreditCardNameOnCard" runat="server" Text="Credit Card Name On Card:"
                        AssociatedControlID="dataCreditCardNameOnCard" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataCreditCardNameOnCard" Text='<%# Bind("CreditCardNameOnCard") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreditCardNumber" runat="server" Text="Credit Card Number:"
                        AssociatedControlID="dataCreditCardNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataCreditCardNumber" Text='<%# Bind("CreditCardNumber") %>'
                        MaxLength="20"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreditCardExp" runat="server" Text="Credit Card Exp:" AssociatedControlID="dataCreditCardExp" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataCreditCardExp" Text='<%# Bind("CreditCardExp") %>'
                        MaxLength="4"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreditCardVerCode" runat="server" Text="Credit Card Ver Code:"
                        AssociatedControlID="dataCreditCardVerCode" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataCreditCardVerCode" Text='<%# Bind("CreditCardVerCode") %>'
                        MaxLength="6"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreditCardTypeName" runat="server" Text="Credit Card Type Name:"
                        AssociatedControlID="dataCreditCardTypeName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataCreditCardTypeName" Text='<%# Bind("CreditCardTypeName") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
                <td>
                    <asp:Label runat="server" ID="dataCreatedDate" Text='<%# Eval("CreatedDate", "{0:d}") %>'></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
                <td>
                    <asp:Label runat="server" ID="dataLastModified" Text='<%# Eval("LastModified", "{0:d}") %>'></asp:Label>
                </td>
            </tr>
<%--            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUniqueCustomerId" runat="server" Text="Unique Customer Id:"
                        AssociatedControlID="dataUniqueCustomerId" /></td>
                <td>
                    <asp:Label runat="server" ID="dataUniqueCustomerId" Text='<%# Eval("UniqueCustomerId") %>' />
                </td>
            </tr>
--%>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebGroupId" runat="server" Text="Web Group Id:" AssociatedControlID="dataWebGroupId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWebGroupId" Text='<%# Bind("WebGroupId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUserId" runat="server" Text="User Login:" CssClass="ToolTipWithHelp"
                        ToolTip="Enter a unique user name and password to create a web login." AssociatedControlID="txtUserName" /></td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" Text=''></asp:TextBox>
                    <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false" Text="User name is not unique. Please select a new one and try your request again." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtUserName" 
                            WatermarkCssClass="watermarked" WatermarkText="<Enter User Name>" />

                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server" TargetControlID="txtPassword" 
                            WatermarkCssClass="watermarked" WatermarkText="<Enter Password>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword" 
                            ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8." Display="Dynamic"></asp:RegularExpressionValidator>
                        <ajaxToolkit:PasswordStrength ID="PS" runat="server" TargetControlID="txtPassword" DisplayPosition="AboveRight"
                            StrengthIndicatorType="Text" PreferredPasswordLength="8" PrefixText="Password Strength:"
                            TextCssClass="TextIndicator_TextBox1" MinimumNumericCharacters="0" MinimumSymbolCharacters="0"
                            RequiresUpperAndLowerCaseCharacters="false" TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
                            StrengthStyles="cssClass1;cssClass2;cssClass3;cssClass4;cssClass5"
                            CalculationWeightings="50;15;15;20" />
                        
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
