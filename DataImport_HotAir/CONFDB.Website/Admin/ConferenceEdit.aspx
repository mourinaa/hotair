<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeFile="ConferenceEdit.aspx.cs" Inherits="ConferenceEdit"
    Title="Conference Edit" %>

<%@ Register Src="~/Admin/CustomControls/DNISModerator.ascx" TagName="DNISModerator"
    TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/FeaturesModerator.ascx" TagName="FeaturesModerator"
    TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/UserGridModerator.ascx" TagName="UserGridModerator"
    TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/EmailsModerator.ascx" TagName="EmailsModerator"
    TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/WalletCardRequestModerator.ascx" TagName="WalletCardRequestModerator"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Conference - Add/Edit
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--	<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueModeratorId" runat="server" Text="Unique Moderator Id:" AssociatedControlID="dataUniqueModeratorId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataUniqueModeratorId" Value='<%# Bind("UniqueModeratorId") %>'></asp:HiddenField>
				</td>
			</tr>	
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataWebMeetingId" runat="server" Text="Web Meeting Id:" AssociatedControlID="dataWebMeetingId" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="dataWebMeetingId" Text='<%# Bind("WebMeetingId") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
        --%>
    <data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ModeratorDataSource">
        <InsertItemTemplate>
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal">
                    </td>
                    <td>
                        <%-- <asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                        <asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Admin:" AssociatedControlID="dataCustomerId" />
                        <td>
                            <data:EntityDropDownList ID="dataCustomerId" runat="server" 
                                AppendNullItem="true" AutoPostBack="true" 
                                DataSourceID="CustomerListDataSource1" DataTextField="DDLDescription" 
                                DataValueField="Id" ErrorText="Required" 
                                NullItemText="&lt; Please Choose ...&gt;" 
                                OnSelectedIndexChanged="dataCustomerId_SelectedIndexChanged" Required="true" 
                                SelectedValue='<%# Bind("CustomerId") %>' />
                            <data:Vw_CustomerListDataSource ID="CustomerListDataSource1" runat="server" 
                                SelectMethod="Get">
                                <Parameters>
                                    <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" 
                                        Name="WholesalerID" Type="string">
                                    </data:SqlParameter>
                                    <data:CustomParameter ConvertEmptyStringToNull="false" Name="OrderBy" 
                                        Value="CompanyName,PriCustomerNumber" />
                                </Parameters>
                            </data:Vw_CustomerListDataSource>
                        </td>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataDescription" runat="server" Text="Conference Name:" AssociatedControlID="dataDescription" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                            Width="260px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid characters. Please use only alphanumerics, hyphens, or periods."
                            Display="Dynamic" ControlToValidate="dataDescription" ValidationExpression="([a-zA-Z0-9\.-]*\s?)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="true" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>'
                            MaxLength="16"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender3" runat="server"
                            TargetControlID="dataModeratorCode" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPassCode" runat="server" Text="Participant Code:" AssociatedControlID="dataPassCode" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ReadOnly="true" ID="dataPassCode" Text='<%# Bind("PassCode") %>'
                            MaxLength="16"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender4" runat="server"
                            TargetControlID="dataPassCode" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        <asp:Label ID="Label5" CssClass="NormalBold13" runat="server" Text="INTERNAL ADMINISTRATIVE INFO: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataDepartmentId" runat="server" Text="Department:" 
                            AssociatedControlID="dataDepartmentId" ><label id="ctl00_lbldataDepartmentId">Department:</label></asp:Label>
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataDepartmentId" DataSourceID="DepartmentIdDepartmentDataSource"
                            DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentId") %>'
                            AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                        <%--<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetAll"  />--%>
                        <%--When added, force to No Department, they can change it in Edit mode. There is a bug when linking controls in FormView in insert mode--%>
                        <data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetByName">
                            <Parameters>
                                <data:SqlParameter Name="Name" DefaultValue="No Department" Type="String" />
                            </Parameters>
                        </data:DepartmentDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:"
                            AssociatedControlID="dataPriCustomerNumber" />
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="true" runat="server" ID="dataPriCustomerNumber" Text='<%# Eval("PriCustomerNumber") %>'
                            MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server"
                            TargetControlID="dataPriCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:"
                            AssociatedControlID="dataSecCustomerNumber" />
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="true" runat="server" ID="dataSecCustomerNumber" Text='<%# Eval("SecCustomerNumber") %>'
                            MaxLength="6"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server"
                            TargetControlID="dataSecCustomerNumber" WatermarkCssClass="watermarked" WatermarkText="<auto generated>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataExternalModeratorNumber" runat="server" Text="External Conference Number:"
                            AssociatedControlID="dataExternalModeratorNumber" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataExternalModeratorNumber" Text='<%# Bind("ExternalModeratorNumber") %>'
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <%--                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
                    <td>
                        <asp:Label runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
                    <td>
                        <asp:Label runat="server" ID="dataCreatedDate" Text='<%# Eval("CreatedDate", "{0:d}") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" /></td>
                    <td>
                        <asp:Label runat="server" ID="dataLastModified" Text='<%# Eval("LastModified", "{0:d}") %>' />
                    </td>
                </tr>
--%>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" />
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="False" Text="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <%--	<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueModeratorId" runat="server" Text="Unique Moderator Id:" AssociatedControlID="dataUniqueModeratorId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataUniqueModeratorId" Value='<%# Bind("UniqueModeratorId") %>'></asp:HiddenField>
				</td>
			</tr>	
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataWebMeetingId" runat="server" Text="Web Meeting Id:" AssociatedControlID="dataWebMeetingId" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="dataWebMeetingId" Text='<%# Bind("WebMeetingId") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
        --%>
                <tr>
                    <td class="literal" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr valign="baseline">
                    <td class="literal" colspan="2">
                        <asp:Label ID="lbldataUserId" runat="server" CssClass="NormalBold13" Text="USER LOGIN: ">
                        </asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="*Select an existing user from the list or create a new user. When creating a new user, press the Check User button to validate the information. <br/> The user name (email address) must be unique to create a user."
                            CssClass="ToolTipWithHelpBold" ToolTip="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Existing User:" CssClass="ToolTipWithHelpBold"
                            ToolTip="Select an existing User to associate with this Conference." AssociatedControlID="" />
                    </td>
                    <td>
                        <%-- 
                            If a user is selected then enabled the Insert button, if not then the User must press "Check Users"
                            to validate the information.
                        --%>
                        <data:EntityDropDownList runat="server" ID="ddlUsers" DataTextField="Email" DataValueField="UserId"
                            AppendNullItem="true" Required="false" NullItemText="Existing Users" ErrorText="Required"
                            Enabled="false" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" AutoPostBack="true" />
                    </td>
                </tr>
            </table>
            <br />
            <table id="TblNewUser" runat="server">
                <tr>
                    <td valign="top" colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="New User:" CssClass="ToolTipWithHelpBold"
                            ToolTip="Create a new User to associate with this Conference." AssociatedControlID="" />
                    </td>
                </tr>
                <tr>
                    <td class="literal" style="width: 218px">
                        <asp:Label ID="Label6" runat="server" Text="User Name:" AssociatedControlID="txtUserName" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" Width="300px"></asp:TextBox>
                        <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false"
                            Text="Error: Email Address is not unique. Please select a new one and try your request again." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUserName"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" CssClass="ErrorMessage"
                            Display="Dynamic" ControlToValidate="txtUserName" ErrorMessage="Email address is not valid."
                            ValidationExpression="^(?:[a-zA-Z0-9_'^&/+-])+(?:\.(?:[a-zA-Z0-9_'^&/+-])+)*@(?:(?:\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\]?)|(?:[a-zA-Z0-9-]+\.)+(?:[a-zA-Z]){2,}\.?)$"></asp:RegularExpressionValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender5" runat="server"
                            TargetControlID="txtUserName" WatermarkCssClass="watermarked" WatermarkText="<Email Address>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label7" runat="server" Text="Password:" AssociatedControlID="txtPassword" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" Width="300px"></asp:TextBox>
                        <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidPassword" runat="server" CssClass="ErrorMessage" Visible="false"
                            Text="Error: Password is invalid. It must be a minimum of length of 8. Please select a new one and try your request again." />
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender6" runat="server"
                            TargetControlID="txtPassword" WatermarkCssClass="watermarked" WatermarkText="<Password>" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassword"
                            Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPassword"
                            ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8."
                            Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label8" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataDisplayName" Text='' MaxLength="100" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_dataDisplayName" runat="server" Display="Dynamic"
                            ControlToValidate="dataDisplayName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender7" runat="server"
                            TargetControlID="dataDisplayName" WatermarkCssClass="watermarked" WatermarkText="<Display Name>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label9" runat="server" Text="Telephone:" AssociatedControlID="dataTelephone" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataTelephone" Text='' MaxLength="50" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="dataTelephone" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender8" runat="server"
                            TargetControlID="dataTelephone" WatermarkCssClass="watermarked" WatermarkText="<Telephone>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label10" runat="server" Text="Address1:" AssociatedControlID="dataAddress1" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataAddress1" Text='' MaxLength="50" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                            ControlToValidate="dataAddress1" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender9" runat="server"
                            TargetControlID="dataAddress1" WatermarkCssClass="watermarked" WatermarkText="<Address1>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label11" runat="server" Text="Address2:" AssociatedControlID="dataAddress2" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataAddress2" Text='' MaxLength="50" Width="300px"></asp:TextBox>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender10" runat="server"
                            TargetControlID="dataAddress2" WatermarkCssClass="watermarked" WatermarkText="<Address2>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label12" runat="server" Text="City:" AssociatedControlID="dataCity" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataCity" Text='' MaxLength="50" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                            ControlToValidate="dataCity" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender11" runat="server"
                            TargetControlID="dataCity" WatermarkCssClass="watermarked" WatermarkText="<City>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label13" runat="server" Text="Country:" AssociatedControlID="dataCountry" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataCountry" DataSourceID="CountryCountryDataSource"
                            DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("Country") %>'
                            AppendNullItem="true" Required="true" NullItemText="< Country ...>" RequiredErrorMessage="Required"
                            Width="305px" />
                        <data:CountryDataSource ID="CountryCountryDataSource" runat="server" SelectMethod="GetAll">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
                            </Parameters>
                        </data:CountryDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label14" runat="server" Text="Region:" AssociatedControlID="dataRegion" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataRegion" DataSourceID="RegionStateDataSource"
                            DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("Region") %>'
                            AppendNullItem="false" Required="false" NullItemText="< Region ...>" RequiredErrorMessage="Required"
                            Width="305px" />
                        <data:StateDataSource ID="RegionStateDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label15" runat="server" Text="Postal Code:" AssociatedControlID="dataPostalCode" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataPostalCode" Text='<%# Bind("PostalCode") %>'
                            MaxLength="20" Width="300px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                            ControlToValidate="dataPostalCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <ajaxToolkit:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender12" runat="server"
                            TargetControlID="dataPostalCode" WatermarkCssClass="watermarked" WatermarkText="<Postal Code>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label16" runat="server" Text="Charity:" AssociatedControlID="dataCharityId" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataCharityId" DataSourceID="CharityIdCharityDataSource"
                            DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CharityId") %>'
                            AppendNullItem="false" Required="false" NullItemText="< Charity ...>" Width="305px" />
                        <data:CharityDataSource ID="CharityIdCharityDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp
                    </td>
                    <td>
                        <%--
                                NOTE: User will need to click the 'Check User' button to check that the User settings 
                                are valid before they can insert a new record.
                            --%>
                        <asp:Button ID="btnCheckUser" runat="server" Text="Check User" OnClick="btnCheckUser_Click"
                            Enabled="false" ToolTip="When creating a new user, press the Check User button to validate the information. The user name (email address) must be unique to create a user." />
                        &nbsp
                        <asp:Label ID="CheckUserMsg" Visible="false" runat="server" Text="New user is valid."
                            CssClass="NormalGreen" />
                    </td>
                </tr>
            </table>
        </InsertItemTemplate>
        <EditItemTemplate>
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal">
                    </td>
                    <td>
                        <%-- <asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>--%>
                        <asp:HiddenField runat="server" ID="dataWholesalerId" Value='<%$ AppSettings:WholesalerID %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:HyperLink ID="lnkCustomerId" runat="server" Text="Customer Admin:" NavigateUrl='<%# string.Format("~/Admin/CustomerEdit.aspx?Id={0}", Eval("CustomerId")) %>' />
                        <td>
                            <data:EntityDropDownList runat="server" ReadOnly="true" ID="dataCustomerId" DataSourceID="CustomerDataSource1"
                                DataTextField="DDLDescription" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>'
                                AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                            <data:Vw_CustomerListDataSource ID="CustomerDataSource1" runat="server" SelectMethod="Get">
                                <Parameters>
                                    <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID"
                                        Type="string">
                                    </data:SqlParameter>
                                    <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                                </Parameters>
                            </data:Vw_CustomerListDataSource>
                        </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataDescription" runat="server" Text="Conference Name:" AssociatedControlID="dataDescription" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                            Width="260px" MaxLength="100"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid characters. Please use only alphanumerics, hyphens, or periods."
                            Display="Dynamic" ControlToValidate="dataDescription" ValidationExpression="([a-zA-Z0-9\.-]*\s?)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>'
                            MaxLength="16"></asp:TextBox>
                        <asp:Label ID="lblModCodeReminder" Visible="false" runat="server" Text="*Reminder*: Press 'Submit' to save your changes."
                            CssClass="note" />
                        <asp:RequiredFieldValidator ID="ReqVal_dataModeratorCode" runat="server" Display="Dynamic"
                            ControlToValidate="dataModeratorCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ControlToValidate="dataModeratorCode"
                            ControlToCompare="dataPassCode" Operator="NotEqual" Type="String" ErrorMessage="Moderator Code can not be equal to the Participant Code."></asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="dynamic"
                            ControlToValidate="dataModeratorCode" ValidationExpression="^\d{4}\d*$" ErrorMessage="Must have a minimum of 4 digits and only numbers are allowed."></asp:RegularExpressionValidator>
                        <%--Code added to select new Moderator and Participant Code.--%>
                        <asp:Button ID="btnGenModCode" runat="server" CausesValidation="false" CommandName="GenModCode"
                            Width="220px" CommandArgument="GenModCode" OnCommand="btnGenCode_Click" Text="Generate Moderator Code"
                            ToolTip="Generates a new moderator code. You must save the information for the code to work."
                            Visible="<%# (FormView1.CurrentMode == FormViewMode.Edit) ? true : false %>" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPassCode" runat="server" Text="Participant Code:" 
                            AssociatedControlID="dataPassCode" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataPassCode" Text='<%# Bind("PassCode") %>' Enabled="false"
                            MaxLength="16"></asp:TextBox>
                        <asp:Label ID="lblPassCodeReminder" Visible="False" runat="server" Text="*Reminder*: Press 'Submit' to save your changes."
                            CssClass="note" />
                        <asp:RequiredFieldValidator ID="ReqVal_dataPassCode" runat="server" Display="Dynamic"
                            ControlToValidate="dataPassCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" runat="server" Display="Dynamic" ControlToValidate="dataPassCode"
                            ControlToCompare="dataModeratorCode" Operator="NotEqual" Type="String" 
                            ErrorMessage="Participant Code can not be equal to the Moderator Code."></asp:CompareValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="dynamic"
                            ControlToValidate="dataPassCode" ValidationExpression="^\d{4}\d*$" 
                            ErrorMessage="Must have a minimum of 4 digits and only numbers are allowed."></asp:RegularExpressionValidator>
                        <%--Code added to select new Moderator and Participant Code.--%>
                        <asp:Button ID="btnGenPassCode" runat="server" CausesValidation="false" CommandName="GenPassCode"
                            Width="220px" CommandArgument="GenPassCode" OnCommand="btnGenCode_Click" Text="Generate Participant Code"
                            ToolTip="Generates a new Participant Code. You must save the information for the code to work."
                            Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        <asp:Label ID="Label5" CssClass="NormalBold13" runat="server" Text="INTERNAL ADMINISTRATIVE INFO: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataDepartmentId" runat="server" Text="Department:" AssociatedControlID="dataDepartmentId" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataDepartmentId" DataSourceID="DepartmentIdDepartmentDataSource"
                            DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DepartmentId") %>'
                            AppendNullItem="false" Required="true" NullItemText="No Department" ErrorText="Required" />
                        <%--<data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetAll"  />--%>
                        <data:DepartmentDataSource ID="DepartmentIdDepartmentDataSource" runat="server" SelectMethod="GetByCustomerIdCustom">
                            <Parameters>
                                <asp:ControlParameter Name="CustomerId" ControlID="dataCustomerId" PropertyName="SelectedValue"
                                    Type="Int32" />
                            </Parameters>
                        </data:DepartmentDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:"
                            AssociatedControlID="dataPriCustomerNumber" />
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="true" runat="server" ID="dataPriCustomerNumber" Text='<%# Eval("PriCustomerNumber") %>'
                            MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPriCustomerNumber"
                                runat="server" Display="Dynamic" ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:"
                            AssociatedControlID="dataSecCustomerNumber" />
                    </td>
                    <td>
                        <asp:TextBox ReadOnly="true" runat="server" ID="dataSecCustomerNumber" Text='<%# Eval("SecCustomerNumber") %>'
                            MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSecCustomerNumber"
                                runat="server" Display="Dynamic" ControlToValidate="dataSecCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataExternalModeratorNumber" runat="server" Text="External Conference Number:"
                            AssociatedControlID="dataExternalModeratorNumber" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="dataExternalModeratorNumber" Text='<%# Bind("ExternalModeratorNumber") %>'
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="dataCreatedDate" Text='<%# Eval("CreatedDate", "{0:d}") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataLastModified" runat="server" Text="Last Modified:" AssociatedControlID="dataLastModified" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="dataLastModified" Text='<%# Eval("LastModified", "{0:d}") %>' />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" />
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="False" Text="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <%--			
                    <tr>
                    <td class="literal"><asp:Label ID="lbldataUniqueModeratorId" runat="server" Text="Unique Moderator Id:" AssociatedControlID="dataUniqueModeratorId" /></td>
                    <td>
					            <asp:Label runat="server" id="dataUniqueModeratorId" Text='<%# Eval("UniqueModeratorId") %>'/>
				            </td>
			            </tr>	
	                --%>
                <%--            
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataWebMeetingId" runat="server" Text="Web Meeting Id:" AssociatedControlID="dataWebMeetingId" /></td>
                    <td>
                        <asp:TextBox runat="server" ID="dataWebMeetingId" Text='<%# Bind("WebMeetingId") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                --%>
<%--
JS: Added this items here for Topo so he can see the values from the database, just to make sure things are working. Next would be to add
a User Control that houses the logic and workflow you want. Look below to the "PANEL" items and you'll see examples of custom user controls examples.

                <td class="literal">
                    <asp:Label ID="lbldataSeevogh_Meeting_Url" runat="server" Text="Seevogh Meeting Url:"
                        AssociatedControlID="dataSeevogh_Meeting_Url" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataSeevogh_Meeting_Url" Text='<%# Bind("Seevogh_Meeting_Url") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
                </tr>
--%>                
                <tr>
                    <td class="literal" valign="top">
                        <%--NOTE: Had to add width here as the HTML would get on messed up when the User Login Grid went into Edit Mode--%>
                        <asp:Label ID="Label1" runat="server" CssClass="NormalBold13" Text="USER LOGIN:"
                            Width="200px" />
                    </td>
                    <td>
                        <%--NOTE: Need to go thru a different UI and Workflow to change associated User Login as they could want to change 
                            more settings thus the Grid custom usercontrol.
                        --%>
                        <uc1:UserGridModerator ID="ucUserGridCustom" runat="server" UserID='<%# Eval("UserId") %>'>
                        </uc1:UserGridModerator>
                    </td>
                </tr>
            </table>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <b>Conference not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" Enabled="false" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Submit" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
            <asp:Button runat="server" ID="btnAddNew" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'
                OnClick="btnAddNew_Click" Text="Add New"></asp:Button>
        </FooterTemplate>
    </data:MultiFormView>
    <data:ModeratorDataSource ID="ModeratorDataSource" runat="server" SelectMethod="GetById"
        OnAfterInserted="ModeratorDataSource_AfterInserted" InsertDateTimeNames="CreatedDate,LastModified"
        UpdateDateTimeNames="LastModified" OnInserting="ModeratorDataSource_Inserting">
        <Parameters>
            <asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />
        </Parameters>
    </data:ModeratorDataSource>
    <br />
                    <asp:Button ID="cmdCreatePexip" runat="server" CssClass="Normal" 
                        Text="Create Pexip" OnClick="cmdSendEmail_Click" />
    <br />
    <br />
    <asp:Panel ID="ModeratorDnisPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="ModeratorDnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                DNIS Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="ModeratorDnisLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ModeratorDnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
        <uc1:DNISModerator ID="ucDNISModerator" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
        </uc1:DNISModerator>
        <br />
    </asp:Panel>
    <asp:Panel ID="Moderator_FeaturePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="Moderator_FeatureImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Feature Details</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="Moderator_FeatureLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Moderator_FeaturePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <uc1:FeaturesModerator ID="ucFeaturesModerator" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    <asp:Panel ID="ModeratorEmailTemplatePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="ModeratorEmailTemplateImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Email Notifications</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="ModeratorEmailTemplateLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="ModeratorEmailTemplatePanel1" runat="server" CssClass="collapsePanel"
        Height="0">
        <uc1:EmailsModerator ID="ucEmailsModerator" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    <asp:Panel ID="WalletCardRequestModeratorPanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="WalletCardRequestModeratorImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Wallet Card Request</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="WalletCardRequestModeratorLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="WalletCardRequestModeratorPanel1" runat="server" CssClass="collapsePanel"
        Height="0">
        <uc1:WalletCardRequestModerator ID="ucWalletCardRequestModerator" runat="server"
            Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
        <br />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeModeratorDnis" runat="Server" TargetControlID="ModeratorDnisPanel1"
        ExpandControlID="ModeratorDnisPanel2" CollapseControlID="ModeratorDnisPanel2"
        Collapsed="True" TextLabelID="ModeratorDnisLabel" ExpandedText="(Hide Details...)"
        CollapsedText="(Show Details...)" ImageControlID="ModeratorDnisImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeModerator_Feature" runat="Server" TargetControlID="Moderator_FeaturePanel1"
        ExpandControlID="Moderator_FeaturePanel2" CollapseControlID="Moderator_FeaturePanel2"
        Collapsed="True" TextLabelID="Moderator_FeatureLabel" ExpandedText="(Hide Details...)"
        CollapsedText="(Show Details...)" ImageControlID="Moderator_FeatureImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeModerator_EmailTemplate" runat="Server"
        TargetControlID="ModeratorEmailTemplatePanel1" ExpandControlID="ModeratorEmailTemplatePanel2"
        CollapseControlID="ModeratorEmailTemplatePanel2" Collapsed="True" TextLabelID="ModeratorEmailTemplateLabel"
        ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="ModeratorEmailTemplateImage"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
        TargetControlID="WalletCardRequestModeratorPanel1" ExpandControlID="WalletCardRequestModeratorPanel2"
        CollapseControlID="WalletCardRequestModeratorPanel2" Collapsed="True" TextLabelID="WalletCardRequestModeratorLabel"
        ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="WalletCardRequestModeratorImage"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
</asp:Content>
