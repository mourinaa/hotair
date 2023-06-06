<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="CustomerEdit.aspx.cs" Inherits="CustomerEdit" Title="Customer Edit" %>
<%@ Register Src="~/Admin/CustomControls/DNISCustomer.ascx" TagName="DNISCustomer" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/ProductRatesCustomer.ascx" TagName="ProductRatesCustomer" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/FeaturesCustomer.ascx" TagName="FeaturesCustomer" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/UserGridCustom.ascx" TagName="UserGridCustom" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/EmailsCustomer.ascx" TagName="EmailsCustomer" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/CompanyUC.ascx" TagName="CompanyUC" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/UserControls/EventManagerFields.ascx" TagName="EventManagerFields" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">Customer - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:FormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CustomerDataSource">
        <%--	Moved the code into here to be able to access the controls. Must be some bug with this control from NetTiers.
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerFields.ascx" />
			</InsertItemTemplatePaths>

			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CustomerFieldsEdit.ascx" />
			</EditItemTemplatePaths>
--%>
        <InsertItemTemplate>
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal">
                        <%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" />--%>
                    </td>
                    <td>
                        <data:EntityDropDownList Width="305px" Visible="false" runat="server" ID="dataWholesalerId"
                            DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id"
                            SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="false" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                            <Parameters>
                                <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                            </Parameters>
                        </data:WholesalerDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label9" CssClass="NormalBold13" runat="server" Text="CUSTOMER ADMIN ASSIGNMENT:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCompanyId" runat="server" Text="Company" AssociatedControlID="ucCompanyId" /></td>
                    <td>
                        <uc1:CompanyUC ID="ucCompanyId" runat="server" SelectedValue='<%# Bind("CompanyId") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataVerticalId" runat="server" Text="Vertical" AssociatedControlID="dataVerticalId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataVerticalId" DataSourceID="VerticalIdVerticalDataSource"
                            DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("VerticalId") %>'
                            AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:VerticalDataSource ID="VerticalIdVerticalDataSource" runat="server" SelectMethod="GetByWholesalerId">
                            <Parameters>
                                <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="WholesalerId" Type="String" />
                            </Parameters>
                        </data:VerticalDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person" AssociatedControlID="dataSalesPersonId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                            DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                            SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataAccountManagerId" runat="server" Text="Account Manager" AssociatedControlID="dataAccountManagerId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataAccountManagerId" DataSourceID="AccountManagerIdAccountManagerDataSource"
                            DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("AccountManagerId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:AccountManagerDataSource ID="AccountManagerIdAccountManagerDataSource" runat="server"
                            SelectMethod="GetAll" />
                    </td>
                </tr>                
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label10" CssClass="NormalBold13" runat="server" Text="CUSTOMER ADMIN INFO:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactName" runat="server" Text="Customer Admin Name:"
                            AssociatedControlID="dataPrimaryContactName" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactName" Text='<%# Bind("PrimaryContactName") %>'
                            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactName"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactPhoneNumber" runat="server" Text="Customer Admin Phone Number:"
                            AssociatedControlID="dataPrimaryContactPhoneNumber" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactPhoneNumber" Text='<%# Bind("PrimaryContactPhoneNumber") %>'
                            MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactPhoneNumber"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactPhoneNumber"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactEmailAddress" runat="server" Text="Customer Admin Email Address:"
                            AssociatedControlID="dataPrimaryContactEmailAddress" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactEmailAddress" Text='<%# Bind("PrimaryContactEmailAddress") %>'
                            MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactEmailAddress"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactEmailAddress"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactEmailAddress" ErrorMessage="Email address is not valid."
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactAddress1" runat="server" Text="Customer Admin Address1:"
                            AssociatedControlID="dataPrimaryContactAddress1" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactAddress1" Text='<%# Bind("PrimaryContactAddress1") %>'
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactAddress1" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactAddress2" runat="server" Text="Customer Admin Address2:"
                            AssociatedControlID="dataPrimaryContactAddress2" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactAddress2" Text='<%# Bind("PrimaryContactAddress2") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactCity" runat="server" Text="Customer Admin City:"
                            AssociatedControlID="dataPrimaryContactCity" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactCity" Text='<%# Bind("PrimaryContactCity") %>'
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactCity" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactCountry" runat="server" Text="Customer Admin Country:"
                            AssociatedControlID="dataPrimaryContactCountry" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataPrimaryContactCountry"
                            DataSourceID="PrimaryContactCountryCountryDataSource" DataTextField="Description"
                            DataValueField="Id" SelectedValue='<%# Bind("PrimaryContactCountry") %>' AppendNullItem="true"
                            Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:CountryDataSource ID="PrimaryContactCountryCountryDataSource" runat="server"
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
                        </data:CountryDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactRegion" runat="server" Text="Customer Admin Region:"
                            AssociatedControlID="dataPrimaryContactRegion" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataPrimaryContactRegion"
                            DataSourceID="PrimaryContactRegionStateDataSource" DataTextField="LongName" DataValueField="Id"
                            SelectedValue='<%# Bind("PrimaryContactRegion") %>' AppendNullItem="true" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:StateDataSource ID="PrimaryContactRegionStateDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
                            </Parameters>
                        </data:StateDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactPostalCode" runat="server" Text="Customer Admin Postal Code:"
                            AssociatedControlID="dataPrimaryContactPostalCode" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactPostalCode" Text='<%# Bind("PrimaryContactPostalCode") %>'
                            MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactPostalCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactFaxNumber" runat="server" Text="Customer Admin Fax Number:"
                            AssociatedControlID="dataPrimaryContactFaxNumber" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactFaxNumber" Text='<%# Bind("PrimaryContactFaxNumber") %>'
                            MaxLength="30"></asp:TextBox>
                    </td>
                </tr>
                <%--
        NOTE: User will need to click the 'Check User' button to check that the User settings are valid before they can insert a new record.
    --%>
                <tr valign="baseline">
                    <td class="literal">
                        <asp:Label ID="lbldataUserId" runat="server" Text="New User:" CssClass="ToolTipWithHelpBold"
                            ToolTip="Enter a unique user name and password to create a web login." AssociatedControlID="txtUserName" />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="When creating a new user, press the Check User button to validate the information. <br/> The user name must be unique to create a user."
                            CssClass="ToolTipWithHelpBold" ToolTip="" />
                    </td>
                </tr>
                <tr id="trNewUser" runat="server">
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="User Name:" CssClass="ToolTipWithHelp"
                            ToolTip="Create a new User to associate with this Customer." AssociatedControlID="" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" ID="txtUserName" runat="server"></asp:TextBox>
                        <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false"
                            Text="Error: User name is not unique. Please select a new one and try your request again." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                            TargetControlID="txtUserName" WatermarkCssClass="watermarked" WatermarkText="<Enter User Name>" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Password:" CssClass="ToolTipWithHelp"
                            ToolTip="Create a new User to associate with this Customer." AssociatedControlID="" />
                    </td>
                    <td valign="top">
                        <asp:TextBox Width="300px" ID="txtPassword" runat="server"></asp:TextBox>
                        <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidPassword" runat="server" CssClass="ErrorMessage" Visible="false"
                            Text="Error: Password is invalid. It must be a minimum of length of 8. Please select a new one and try your request again." />
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                            TargetControlID="txtPassword" WatermarkCssClass="watermarked" WatermarkText="<Enter Password>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword"
                            ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8."
                            Display="Dynamic"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnCheckUser" runat="server" Text="Check User" OnClick="btnCheckUser_Click"
                            ToolTip="When creating a new user, press the Check User button to validate the information. The user name must be unique to create a user." />
                            &nbsp
                            <asp:Label ID="CheckUserMsg" Visible="false" runat="server" Text="New user is valid." CssClass="NormalGreen"/>                                
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="BillingInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="BillingInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label11" CssClass="NormalBold13" runat="server" Text="BILLING INFO: "></asp:Label>
                        <asp:Label ID="Label12" runat="server" CssClass="literalbold" Text="(NOTE: Blank Billing Contact information will be set to the Customer Admin information listed above.)"></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="BillingInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="BillingInfoPanel1" runat="server" CssClass="collapsePanel" Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactName" runat="server" Text="Billing Contact Name:"
                                AssociatedControlID="dataBillingContactName" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactName" Text='<%# Bind("BillingContactName") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactPhoneNumber" runat="server" Text="Billing Contact Phone Number:"
                                AssociatedControlID="dataBillingContactPhoneNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactPhoneNumber" Text='<%# Bind("BillingContactPhoneNumber") %>'
                                MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactEmailAddress" runat="server" Text="Billing Contact Email Address:"
                                AssociatedControlID="dataBillingContactEmailAddress" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactEmailAddress" Text='<%# Bind("BillingContactEmailAddress") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactAddress1" runat="server" Text="Billing Contact Address1:"
                                AssociatedControlID="dataBillingContactAddress1" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactAddress1" Text='<%# Bind("BillingContactAddress1") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactAddress2" runat="server" Text="Billing Contact Address2:"
                                AssociatedControlID="dataBillingContactAddress2" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactAddress2" Text='<%# Bind("BillingContactAddress2") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactCity" runat="server" Text="Billing Contact City:"
                                AssociatedControlID="dataBillingContactCity" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactCity" Text='<%# Bind("BillingContactCity") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactCountry" runat="server" Text="Billing Contact Country:"
                                AssociatedControlID="dataBillingContactCountry" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataBillingContactCountry"
                                DataSourceID="BillingContactCountryCountryDataSource" DataTextField="Description"
                                DataValueField="Id" SelectedValue='<%# Bind("BillingContactCountry") %>' AppendNullItem="true"
                                Required="false" NullItemText="< Please Choose ...>" />
                            <data:CountryDataSource ID="BillingContactCountryCountryDataSource" runat="server"
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
                            </data:CountryDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactRegion" runat="server" Text="Billing Contact Region:"
                                AssociatedControlID="dataBillingContactRegion" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataBillingContactRegion"
                                DataSourceID="BillingContactRegionStateDataSource" DataTextField="LongName" DataValueField="Id"
                                SelectedValue='<%# Bind("BillingContactRegion") %>' AppendNullItem="true" Required="false"
                                NullItemText="< Please Choose ...>" />
                            <data:StateDataSource ID="BillingContactRegionStateDataSource" runat="server" 
                                SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
                            </Parameters>
                            </data:StateDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactPostalCode" runat="server" Text="Billing Contact Postal Code:"
                                AssociatedControlID="dataBillingContactPostalCode" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactPostalCode" Text='<%# Bind("BillingContactPostalCode") %>'
                                MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactFaxNumber" runat="server" Text="Billing Contact Fax Number:"
                                AssociatedControlID="dataBillingContactFaxNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactFaxNumber" Text='<%# Bind("BillingContactFaxNumber") %>'
                                MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeBillingInfo" runat="Server" TargetControlID="BillingInfoPanel1"
                ExpandControlID="BillingInfoPanel2" CollapseControlID="BillingInfoPanel2" Collapsed="True"
                TextLabelID="BillingInfoLabel1" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
                ImageControlID="BillingInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
            <asp:Panel ID="CreditCardInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="CreditCardInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label13" CssClass="NormalBold13" runat="server" Text="CREDIT CARD INFO: "></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="CreditCardInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="CreditCardInfoPanel1" runat="server" CssClass="collapsePanel" Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardNameOnCard" runat="server" Text="Credit Card Name On Card:"
                                AssociatedControlID="dataCreditCardNameOnCard" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardNameOnCard" Text='<%# Bind("CreditCardNameOnCard") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardNumber" runat="server" Text="Credit Card Number:"
                                AssociatedControlID="dataCreditCardNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardNumber" Text='<%# Bind("CreditCardNumber") %>'
                                MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardExp" runat="server" Text="Credit Card Exp:" AssociatedControlID="dataCreditCardExp" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardExp" Text='<%# Bind("CreditCardExp") %>'
                                MaxLength="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardVerCode" runat="server" Text="Credit Card Ver Code:"
                                AssociatedControlID="dataCreditCardVerCode" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardVerCode" Text='<%# Bind("CreditCardVerCode") %>'
                                MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardTypeName" runat="server" Text="Credit Card Type Name:"
                                AssociatedControlID="dataCreditCardTypeName" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardTypeName" Text='<%# Bind("CreditCardTypeName") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeCreditCardInfo" runat="Server" TargetControlID="CreditCardInfoPanel1"
                ExpandControlID="CreditCardInfoPanel2" CollapseControlID="CreditCardInfoPanel2"
                Collapsed="True" TextLabelID="CreditCardInfoLabel1" ExpandedText="(Hide Details...)"
                CollapsedText="(Show Details...)" ImageControlID="CreditCardInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
            <asp:Panel ID="AdministrativeInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="AdministrativeInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label14" CssClass="NormalBold13" runat="server" Text="ADMINISTRATIVE DATA:"></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="AdministrativeInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="AdministrativeInfoPanel1" runat="server" CssClass="collapsePanel"
                Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
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
                            <asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency" AssociatedControlID="dataCurrencyId" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataCurrencyId" DataSourceID="CurrencyIdCurrencyDataSource"
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
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingPeriodCutoff" Text='<%# Bind("BillingPeriodCutoff") %>'></asp:TextBox><asp:RangeValidator
                                ID="RangeVal_dataBillingPeriodCutoff" runat="server" Display="Dynamic" ControlToValidate="dataBillingPeriodCutoff"
                                ErrorMessage="Invalid value" MaximumValue="31" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataTaxableId" runat="server" Text="Taxable" AssociatedControlID="dataTaxableId" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataTaxableId" DataSourceID="TaxableIdTaxableDataSource"
                                DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TaxableId") %>'
                                AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                            <data:TaxableDataSource ID="TaxableIdTaxableDataSource" runat="server" SelectMethod="GetAll" />
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataWebsiteUrl" runat="server" Text="Web Conferencing Url:" AssociatedControlID="dataWebsiteUrl" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataWebsiteUrl" Text='<%# Bind("WebsiteUrl") %>'
                                MaxLength="100"></asp:TextBox><strong>If blank, then www.redbackconferencing.com.au will be used.</strong>
                            <%--Hidden: to be used to set the Web URL default without a recompile--%>
                            <asp:Label ID="lblResellerDefaultWebURL" runat="server" Visible="false" Text="www.redbackconferencing.com.au"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Primary Customer Number:"
                                AssociatedControlID="dataPriCustomerNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" ReadOnly="true" runat="server" ID="dataPriCustomerNumber"
                                Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="ReqVal_dataPriCustomerNumber" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                TargetControlID="dataPriCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataExternalCustomerNumber" runat="server" Text="External Customer Number:"
                                AssociatedControlID="dataExternalCustomerNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataExternalCustomerNumber" Text='<%# Bind("ExternalCustomerNumber") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <%--             
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
           <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUniqueCustomerId" runat="server" Text="Unique Customer Id:"
                        AssociatedControlID="dataUniqueCustomerId" /></td>
                <td>
                    <asp:Label runat="server" ID="dataUniqueCustomerId" Text='<%# Eval("UniqueCustomerId") %>' />
                </td>
            </tr>

			<tr>
        <td class="literal"><asp:Label ID="lbldataWebGroupId" runat="server" Text="Web Group Id:" AssociatedControlID="dataWebGroupId" /></td>
        <td>
					<asp:TextBox width="300px" runat="server" ID="dataWebGroupId" Text='<%# Bind("WebGroupId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
--%>
                </table>
            </asp:Panel>
            <br />
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeAdministrativeInfo" runat="Server" TargetControlID="AdministrativeInfoPanel1"
                ExpandControlID="AdministrativeInfoPanel2" CollapseControlID="AdministrativeInfoPanel2"
                Collapsed="True" TextLabelID="AdministrativeInfoLabel1" ExpandedText="(Hide Details...)"
                CollapsedText="(Show Details...)" ImageControlID="AdministrativeInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
        </InsertItemTemplate>
        <EditItemTemplate>
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal">
                        <%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" />--%>
                    </td>
                    <td>
                        <%--<asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>' />--%>
                        <data:EntityDropDownList Visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource"
                            DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                            <Parameters>
                                <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                            </Parameters>
                        </data:WholesalerDataSource>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label9" CssClass="NormalBold13" runat="server" Text="CUSTOMER ADMIN ASSIGNMENT:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCompanyId" runat="server" Text="Company" AssociatedControlID="ucCompanyId" /></td>
                    <td>
                        <uc1:CompanyUC ID="ucCompanyId" runat="server" SelectedValue='<%# Bind("CompanyId") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataVerticalId" runat="server" Text="Vertical" AssociatedControlID="dataVerticalId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataVerticalId" DataSourceID="VerticalIdVerticalDataSource"
                            DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("VerticalId") %>'
                            AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:VerticalDataSource ID="VerticalIdVerticalDataSource" runat="server" SelectMethod="GetByWholesalerId">
                            <Parameters>
                                <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="WholesalerId" Type="String" />
                            </Parameters>
                        </data:VerticalDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person" AssociatedControlID="dataSalesPersonId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                            DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                            SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataAccountManagerId" runat="server" Text="Account Manager" AssociatedControlID="dataAccountManagerId" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataAccountManagerId" DataSourceID="AccountManagerIdAccountManagerDataSource"
                            DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("AccountManagerId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:AccountManagerDataSource ID="AccountManagerIdAccountManagerDataSource" runat="server"
                            SelectMethod="GetAll" />
                    </td>
                </tr>                
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label10" CssClass="NormalBold13" runat="server" Text="CUSTOMER ADMIN INFO:"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactName" runat="server" Text="Customer Admin Name:"
                            AssociatedControlID="dataPrimaryContactName" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactName" Text='<%# Bind("PrimaryContactName") %>'
                            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactName"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactPhoneNumber" runat="server" Text="Customer Admin Phone Number:"
                            AssociatedControlID="dataPrimaryContactPhoneNumber" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactPhoneNumber" Text='<%# Bind("PrimaryContactPhoneNumber") %>'
                            MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactPhoneNumber"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactPhoneNumber"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactEmailAddress" runat="server" Text="Customer Admin Email Address:"
                            AssociatedControlID="dataPrimaryContactEmailAddress" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactEmailAddress" Text='<%# Bind("PrimaryContactEmailAddress") %>'
                            MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPrimaryContactEmailAddress"
                                runat="server" Display="Dynamic" ControlToValidate="dataPrimaryContactEmailAddress"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactEmailAddress" ErrorMessage="Email address is not valid."
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactAddress1" runat="server" Text="Customer Admin Address1:"
                            AssociatedControlID="dataPrimaryContactAddress1" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactAddress1" Text='<%# Bind("PrimaryContactAddress1") %>'
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactAddress1" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactAddress2" runat="server" Text="Customer Admin Address2:"
                            AssociatedControlID="dataPrimaryContactAddress2" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactAddress2" Text='<%# Bind("PrimaryContactAddress2") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactCity" runat="server" Text="Customer Admin City:"
                            AssociatedControlID="dataPrimaryContactCity" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactCity" Text='<%# Bind("PrimaryContactCity") %>'
                            MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactCity" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactCountry" runat="server" Text="Customer Admin Country:"
                            AssociatedControlID="dataPrimaryContactCountry" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataPrimaryContactCountry"
                            DataSourceID="PrimaryContactCountryCountryDataSource" DataTextField="Description"
                            DataValueField="Id" SelectedValue='<%# Bind("PrimaryContactCountry") %>' AppendNullItem="true"
                            Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:CountryDataSource ID="PrimaryContactCountryCountryDataSource" runat="server"
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
                        </data:CountryDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactRegion" runat="server" Text="Customer Admin Region:"
                            AssociatedControlID="dataPrimaryContactRegion" /></td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataPrimaryContactRegion"
                            DataSourceID="PrimaryContactRegionStateDataSource" DataTextField="LongName" DataValueField="Id"
                            SelectedValue='<%# Bind("PrimaryContactRegion") %>' AppendNullItem="true" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <data:StateDataSource ID="PrimaryContactRegionStateDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
                            </Parameters>
                        </data:StateDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactPostalCode" runat="server" Text="Customer Admin Postal Code:"
                            AssociatedControlID="dataPrimaryContactPostalCode" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactPostalCode" Text='<%# Bind("PrimaryContactPostalCode") %>'
                            MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="dataPrimaryContactPostalCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPrimaryContactFaxNumber" runat="server" Text="Customer Admin Fax Number:"
                            AssociatedControlID="dataPrimaryContactFaxNumber" /></td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPrimaryContactFaxNumber" Text='<%# Bind("PrimaryContactFaxNumber") %>'
                            MaxLength="30"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <%--NOTE: Had to add width here as the HTML would get on messed up when the User Login Grid went into Edit Mode--%>
                        <asp:Label ID="Label1" runat="server" Text="User Login:" Width="200px" />
                    </td>
                    <td>
                        <%--NOTE: Need to go thru a different UI and Workflow to change associated User Login as they could want to change 
                    more settings thus the Grid custom usercontrol.
                --%>
                        <uc1:UserGridCustom ID="ucUserGridCustom" runat="server" UserID='<%# Eval("UserId") %>'>
                        </uc1:UserGridCustom>
                    </td>
                </tr>
            </table>
            <br />
            <asp:Panel ID="BillingInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="BillingInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label11" CssClass="NormalBold13" runat="server" Text="BILLING INFO: "></asp:Label>
                        <asp:Label ID="Label12" runat="server" CssClass="literalbold" Text="(NOTE: Blank Billing Contact information will be set to the Customer Admin information listed above.)"></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="BillingInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="BillingInfoPanel1" runat="server" CssClass="collapsePanel" Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactName" runat="server" Text="Billing Contact Name:"
                                AssociatedControlID="dataBillingContactName" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactName" Text='<%# Bind("BillingContactName") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactPhoneNumber" runat="server" Text="Billing Contact Phone Number:"
                                AssociatedControlID="dataBillingContactPhoneNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactPhoneNumber" Text='<%# Bind("BillingContactPhoneNumber") %>'
                                MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactEmailAddress" runat="server" Text="Billing Contact Email Address:"
                                AssociatedControlID="dataBillingContactEmailAddress" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactEmailAddress" Text='<%# Bind("BillingContactEmailAddress") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactAddress1" runat="server" Text="Billing Contact Address1:"
                                AssociatedControlID="dataBillingContactAddress1" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactAddress1" Text='<%# Bind("BillingContactAddress1") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactAddress2" runat="server" Text="Billing Contact Address2:"
                                AssociatedControlID="dataBillingContactAddress2" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactAddress2" Text='<%# Bind("BillingContactAddress2") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactCity" runat="server" Text="Billing Contact City:"
                                AssociatedControlID="dataBillingContactCity" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactCity" Text='<%# Bind("BillingContactCity") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactCountry" runat="server" Text="Billing Contact Country:"
                                AssociatedControlID="dataBillingContactCountry" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataBillingContactCountry"
                                DataSourceID="BillingContactCountryCountryDataSource" DataTextField="Description"
                                DataValueField="Id" SelectedValue='<%# Bind("BillingContactCountry") %>' AppendNullItem="true"
                                Required="false" NullItemText="< Please Choose ...>" />
                            <data:CountryDataSource ID="BillingContactCountryCountryDataSource" runat="server"
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
                            </data:CountryDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactRegion" runat="server" Text="Billing Contact Region:"
                                AssociatedControlID="dataBillingContactRegion" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataBillingContactRegion"
                                DataSourceID="BillingContactRegionStateDataSource" DataTextField="LongName" DataValueField="Id"
                                SelectedValue='<%# Bind("BillingContactRegion") %>' AppendNullItem="true" Required="false"
                                NullItemText="< Please Choose ...>" />
                            <data:StateDataSource ID="BillingContactRegionStateDataSource" runat="server" 
                                SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
                            </Parameters>
                            </data:StateDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactPostalCode" runat="server" Text="Billing Contact Postal Code:"
                                AssociatedControlID="dataBillingContactPostalCode" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactPostalCode" Text='<%# Bind("BillingContactPostalCode") %>'
                                MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataBillingContactFaxNumber" runat="server" Text="Billing Contact Fax Number:"
                                AssociatedControlID="dataBillingContactFaxNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingContactFaxNumber" Text='<%# Bind("BillingContactFaxNumber") %>'
                                MaxLength="30"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeBillingInfo" runat="Server" TargetControlID="BillingInfoPanel1"
                ExpandControlID="BillingInfoPanel2" CollapseControlID="BillingInfoPanel2" Collapsed="True"
                TextLabelID="BillingInfoLabel1" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
                ImageControlID="BillingInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
            <asp:Panel ID="CreditCardInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="CreditCardInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label13" CssClass="NormalBold13" runat="server" Text="CREDIT CARD INFO: "></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="CreditCardInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="CreditCardInfoPanel1" runat="server" CssClass="collapsePanel" Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardNameOnCard" runat="server" Text="Credit Card Name On Card:"
                                AssociatedControlID="dataCreditCardNameOnCard" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardNameOnCard" Text='<%# Bind("CreditCardNameOnCard") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardNumber" runat="server" Text="Credit Card Number:"
                                AssociatedControlID="dataCreditCardNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardNumber" Text='<%# Bind("CreditCardNumber") %>'
                                MaxLength="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardExp" runat="server" Text="Credit Card Exp:" AssociatedControlID="dataCreditCardExp" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardExp" Text='<%# Bind("CreditCardExp") %>'
                                MaxLength="4"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardVerCode" runat="server" Text="Credit Card Ver Code:"
                                AssociatedControlID="dataCreditCardVerCode" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardVerCode" Text='<%# Bind("CreditCardVerCode") %>'
                                MaxLength="6"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataCreditCardTypeName" runat="server" Text="Credit Card Type Name:"
                                AssociatedControlID="dataCreditCardTypeName" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataCreditCardTypeName" Text='<%# Bind("CreditCardTypeName") %>'
                                MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeCreditCardInfo" runat="Server" TargetControlID="CreditCardInfoPanel1"
                ExpandControlID="CreditCardInfoPanel2" CollapseControlID="CreditCardInfoPanel2"
                Collapsed="True" TextLabelID="CreditCardInfoLabel1" ExpandedText="(Hide Details...)"
                CollapsedText="(Show Details...)" ImageControlID="CreditCardInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
            <asp:Panel ID="AdministrativeInfoPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="AdministrativeInfoImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        <asp:Label ID="Label14" CssClass="NormalBold13" runat="server" Text="ADMINISTRATIVE DATA:"></asp:Label>
                    </div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="AdministrativeInfoLabel1" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="AdministrativeInfoPanel1" runat="server" CssClass="collapsePanel"
                Height="0">
                <table border="0" cellpadding="3" cellspacing="1">
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
                            <asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency" AssociatedControlID="dataCurrencyId" /></td>
                        <td>
                        <%--In edit mode, we need to disable the changing of currency as New Zealand was added and this has to match
                        rates defaulted to Customer and QuickBook.
                        --%>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataCurrencyId" DataSourceID="CurrencyIdCurrencyDataSource"
                                DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("CurrencyId") %>'
                                AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" ReadOnly="true" />
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
                            <asp:TextBox Width="300px" runat="server" ID="dataBillingPeriodCutoff" Text='<%# Bind("BillingPeriodCutoff") %>'></asp:TextBox><asp:RangeValidator
                                ID="RangeVal_dataBillingPeriodCutoff" runat="server" Display="Dynamic" ControlToValidate="dataBillingPeriodCutoff"
                                ErrorMessage="Invalid value" MaximumValue="31" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataTaxableId" runat="server" Text="Taxable" AssociatedControlID="dataTaxableId" /></td>
                        <td>
                            <data:EntityDropDownList Width="305px" runat="server" ID="dataTaxableId" DataSourceID="TaxableIdTaxableDataSource"
                                DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TaxableId") %>'
                                AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                            <data:TaxableDataSource ID="TaxableIdTaxableDataSource" runat="server" SelectMethod="GetAll" />
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataWebsiteUrl" runat="server" Text="Web Conferencing Url:" AssociatedControlID="dataWebsiteUrl" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataWebsiteUrl" Text='<%# Bind("WebsiteUrl") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Primary Customer Number:"
                                AssociatedControlID="dataPriCustomerNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" ReadOnly="true" runat="server" ID="dataPriCustomerNumber"
                                Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator
                                    ID="ReqVal_dataPriCustomerNumber" Enabled="false" runat="server" Display="Dynamic"
                                    ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                            <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                                TargetControlID="dataPriCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                                MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="literal">
                            <asp:Label ID="lbldataExternalCustomerNumber" runat="server" Text="External Customer Number:"
                                AssociatedControlID="dataExternalCustomerNumber" /></td>
                        <td>
                            <asp:TextBox Width="300px" runat="server" ID="dataExternalCustomerNumber" Text='<%# Bind("ExternalCustomerNumber") %>'
                                MaxLength="100"></asp:TextBox>
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
                    <%--             
           <tr>
                <td class="literal">
                    <asp:Label ID="lbldataUniqueCustomerId" runat="server" Text="Unique Customer Id:"
                        AssociatedControlID="dataUniqueCustomerId" /></td>
                <td>
                    <asp:Label runat="server" ID="dataUniqueCustomerId" Text='<%# Eval("UniqueCustomerId") %>' />
                </td>
            </tr>

			<tr>
        <td class="literal"><asp:Label ID="lbldataWebGroupId" runat="server" Text="Web Group Id:" AssociatedControlID="dataWebGroupId" /></td>
        <td>
					<asp:TextBox width="300px" runat="server" ID="dataWebGroupId" Text='<%# Bind("WebGroupId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
--%>
                </table>
            </asp:Panel>
            <br />
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeAdministrativeInfo" runat="Server" TargetControlID="AdministrativeInfoPanel1"
                ExpandControlID="AdministrativeInfoPanel2" CollapseControlID="AdministrativeInfoPanel2"
                Collapsed="True" TextLabelID="AdministrativeInfoLabel1" ExpandedText="(Hide Details...)"
                CollapsedText="(Show Details...)" ImageControlID="AdministrativeInfoImage" ExpandedImage="~/images/collapse_blue.jpg"
                CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
        </EditItemTemplate>
        <EmptyDataTemplate>
            <b>Customer not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" Enabled="false" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Submit" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
            <asp:Button runat="server" ID="btnAddNew" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'
                OnClientClick="javascript:location.href='CustomerEdit.aspx'; return false;" Text="Add New">
            </asp:Button>
        </FooterTemplate>
    </asp:FormView>
    <data:CustomerDataSource ID="CustomerDataSource" runat="server" SelectMethod="GetById"
        OnAfterInserted="CustomerDataSource_AfterInserted" InsertDateTimeNames="CreatedDate,LastModified"
        UpdateDateTimeNames="LastModified" OnInserting="CustomerDataSource_Inserting">
        <Parameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
        </Parameters>
    </data:CustomerDataSource>
    <br />
    <%--CustomerID hidden control. Used to allow other items ie. datasource control, user controls, etc. 
    to bind to it--%>
    <asp:Label ID="lblCustomerID" runat="server" Visible="false"></asp:Label>
    <asp:Panel ID="CustomerDnisPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="CustomerDnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                DNIS Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="CustomerDnisLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="CustomerDnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
        <uc1:DNISCustomer ID="ucDNISCustomer" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
    </asp:Panel>
    <asp:Panel ID="ProductRateValuePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="ProductRateValueImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Product Rate Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="ProductRateValueLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ProductRateValuePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <uc1:ProductRatesCustomer ID="ucProductRatesCustomer" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    <asp:Panel ID="Customer_FeaturePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="Customer_FeatureImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Feature Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="Customer_FeatureLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Customer_FeaturePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <uc1:FeaturesCustomer ID="ucFeaturesCustomer" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    <asp:Panel ID="DepartmentPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="DepartmentImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Department Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="DepartmentLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="DepartmentPanel1" runat="server" CssClass="collapsePanel" Height="0">
        <asp:UpdatePanel ID="UpdatePanelDept" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Department Name: "></asp:Label></td>
                        <td>
                            <asp:TextBox Width="200px" ID="txtDeptment" runat="server"></asp:TextBox></td>
                        <td>
                            <asp:LinkButton runat="server" ID="btnDepartment" OnClick="btnDepartment_Click">Add New</asp:LinkButton>
                        </td>
                    </tr>
                </table>
                <data:EntityGridView ID="GridViewDepartment" runat="server" AutoGenerateColumns="False"
                    OnSelectedIndexChanged="GridViewDepartment_SelectedIndexChanged" DataSourceID="DepartmentDataSource8"
                    DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending"
                    ExcelExportFileName="Export_Department.xls" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="Name" HeaderText="Department Name" SortExpression="" />
                    </Columns>
                    <EmptyDataTemplate>
                        <b>No Department Found! </b>
                    </EmptyDataTemplate>
                </data:EntityGridView>
                <data:DepartmentDataSource ID="DepartmentDataSource8" runat="server" SelectMethod="Find"
                    EnableDeepLoad="False">
                    <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                        <Types>
                            <%--<data:DepartmentProperty Name="Wholesaler"/> --%>
                            <%--<data:DepartmentProperty Name="Customer"/> --%>
                            <%--<data:DepartmentProperty Name="ModeratorCollection" />--%>
                            <%--<data:DepartmentProperty Name="MonthlyDepartmentSummaryCollection" />--%>
                        </Types>
                    </DeepLoadProperties>
                    <Parameters>
                        <data:SqlParameter Name="Parameters">
                            <Filters>
                                <data:DepartmentFilter Column="CustomerId" QueryStringField="Id" />
                            </Filters>
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderBy" Value="Name" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:DepartmentDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </asp:Panel>
    <asp:Panel ID="ConferencePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="ConferenceImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Conference Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="ConferenceLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ConferencePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <asp:LinkButton runat="server" ID="hypConference" OnClick="hypConference_Click">Add New</asp:LinkButton>
        <data:EntityGridView ID="GridViewConference" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GridViewConference_SelectedIndexChanged" DataSourceID="ConferenceDataSource"
            DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending" PageSize="1000"
            ExcelExportFileName="Export_Conference.xls" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
                <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />
                <asp:BoundField DataField="AdminName" HeaderText="Admin Name" SortExpression="[AdminName]" />
                <asp:BoundField DataField="ModeratorName" HeaderText="Moderator Name" SortExpression="[ModeratorName]" />
                <asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" />
                <asp:BoundField DataField="PassCode" HeaderText="Pass Code" />
                <asp:BoundField DataField="Enabled" HeaderText="Enabled" />
                <asp:BoundField DataField="LastWalletCardSentdate" HeaderText="Last Wallet Card Sent" />
            </Columns>
            <EmptyDataTemplate>
                <b>No Conference Found!</b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:Vw_ConferenceListDataSource ID="ConferenceDataSource" runat="server" SelectMethod="Find"
            EnablePaging="True" EnableSorting="True">
            <Parameters>
                <data:SqlParameter Name="Parameters">
                    <Filters>
                        <data:Vw_ConferenceListFilter Column="CustomerId" QueryStringField="Id" />
                    </Filters>
                </data:SqlParameter>
                <%--<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />--%>
                <data:CustomParameter Name="OrderBy" Value="CompanyName,AdminName,ModeratorName"
                    ConvertEmptyStringToNull="false" />
                <asp:ControlParameter Name="PageIndex" ControlID="GridViewConference" PropertyName="PageIndex"
                    Type="Int32" />
                <asp:ControlParameter Name="PageSize" ControlID="GridViewConference" PropertyName="PageSize"
                    Type="Int32" />
                <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
            </Parameters>
        </data:Vw_ConferenceListDataSource>
        <br />
    </asp:Panel>
    <asp:Panel ID="CustomerEmailTemplatePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="CustomerEmailTemplateImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Email Notifications</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="CustomerEmailTemplateLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="CustomerEmailTemplatePanel1" runat="server" CssClass="collapsePanel"
        Height="0">
        <uc1:EmailsCustomer ID="ucEmailsCustomer" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    
    <asp:Panel ID="CustomerEventManagerPanel" runat="server" CssClass="collapsePanel"
        Height="0">
                <uc1:EventManagerFields ID="EventMangerFields1" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />

               <br />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerDnis" runat="Server" TargetControlID="CustomerDnisPanel1"
        ExpandControlID="CustomerDnisPanel2" CollapseControlID="CustomerDnisPanel2" Collapsed="True"
        TextLabelID="CustomerDnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="CustomerDnisImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRateValue" runat="Server" TargetControlID="ProductRateValuePanel1"
        ExpandControlID="ProductRateValuePanel2" CollapseControlID="ProductRateValuePanel2"
        Collapsed="True" TextLabelID="ProductRateValueLabel" ExpandedText="(Hide Details...)"
        CollapsedText="(Show Details...)" ImageControlID="ProductRateValueImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer_Feature" runat="Server" TargetControlID="Customer_FeaturePanel1"
        ExpandControlID="Customer_FeaturePanel2" CollapseControlID="Customer_FeaturePanel2"
        Collapsed="True" TextLabelID="Customer_FeatureLabel" ExpandedText="(Hide Details...)"
        CollapsedText="(Show Details...)" ImageControlID="Customer_FeatureImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDepartment" runat="Server" TargetControlID="DepartmentPanel1"
        ExpandControlID="DepartmentPanel2" CollapseControlID="DepartmentPanel2" Collapsed="True"
        TextLabelID="DepartmentLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="DepartmentImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeConference" runat="Server" TargetControlID="ConferencePanel1"
        ExpandControlID="ConferencePanel2" CollapseControlID="ConferencePanel2" Collapsed="True"
        TextLabelID="ConferenceLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="ConferenceImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer_EmailTemplate" runat="Server"
        TargetControlID="CustomerEmailTemplatePanel1" ExpandControlID="CustomerEmailTemplatePanel2"
        CollapseControlID="CustomerEmailTemplatePanel2" Collapsed="True" TextLabelID="CustomerEmailTemplateLabel"
        ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="CustomerEmailTemplateImage"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
</asp:Content>
