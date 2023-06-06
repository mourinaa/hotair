<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master"
    AutoEventWireup="true" CodeFile="ModeratorEdit.aspx.cs" Inherits="ModeratorEdit"
    Title="Moderator Edit" %>

<%@ Register Src="CustomControls/UserGridModerator.ascx" TagName="UserGridModerator"
    TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Moderator - Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--Should never add a Moderator with this page. Use the Conference pages as they enforce the correct biz rules--%>
    <%--			
            <InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ModeratorUserFields.ascx" />
			</InsertItemTemplatePaths>
        <EditItemTemplatePaths>
            <data:TemplatePath Path="~/Admin/UserControls/ModeratorUserFields.ascx" />
        </EditItemTemplatePaths>

    --%>
    <%-- Moved out of FormView as the DataSource rebinding was losing the BindData Information --%>
    <table border="0" cellpadding="3" cellspacing="1">
        <tr>
            <td class="literal">
                <asp:HyperLink ID="lnkCustomerId" runat="server" Text="Customer Admin:" NavigateUrl="" />
            </td>
            <td>
                <asp:Label ID="lblDDLDescription" CssClass="Normal" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <data:MultiFormView ID="FormView1" DataKeyNames="UserId" runat="server" DataSourceID="UserDataSource">
        <EditItemTemplate>
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal" colspan="2">
                        <asp:Label ID="Label5" CssClass="NormalBold13" runat="server" Text="CONTACT INFORMATION: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataDisplayName" runat="server" Text="Moderator Name:" AssociatedControlID="dataDisplayName" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>'
                            MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDisplayName"
                                runat="server" Display="Dynamic" ControlToValidate="dataDisplayName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid characters. Please use only alphanumerics, hyphens, or periods."
                            Display="Dynamic" ControlToValidate="dataDisplayName" ValidationExpression="([a-zA-Z0-9\.-]*\s?)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataUsername" runat="server" Text="Web Login Name:" AssociatedControlID="dataUsername" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataUsername" Text='<%# Bind("Username") %>'
                            MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ReqVal_dataUsername" runat="server" Display="Dynamic"
                            ControlToValidate="dataUsername" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPassword" runat="server" Text="Web Login Password:" AssociatedControlID="dataPassword" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPassword" Text='<%# Bind("Password") %>'
                            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassword"
                                runat="server" Display="Dynamic" ControlToValidate="dataPassword" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ReadOnly="true" ID="dataEmail" Text='<%# Bind("Email") %>'
                            MaxLength="100"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataTelephone" runat="server" Text="Telephone:" AssociatedControlID="dataTelephone" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataTelephone" Text='<%# Bind("Telephone") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        <asp:Label ID="Label1" CssClass="NormalBold13" runat="server" Text="SHIP TO INFORMATION: "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataAddress1" runat="server" Text="Address1:" AssociatedControlID="dataAddress1" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataAddress1" Text='<%# Bind("Address1") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataAddress2" runat="server" Text="Address2:" AssociatedControlID="dataAddress2" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataAddress2" Text='<%# Bind("Address2") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCity" runat="server" Text="City:" AssociatedControlID="dataCity" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataCity" Text='<%# Bind("City") %>'
                            MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCountry" runat="server" Text="Country:" AssociatedControlID="dataCountry" />
                    </td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataCountry" DataSourceID="CountryCountryDataSource"
                            DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("Country") %>'
                            AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                        <data:CountryDataSource ID="CountryCountryDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataRegion" runat="server" Text="Region:" AssociatedControlID="dataRegion" />
                    </td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataRegion" DataSourceID="RegionStateDataSource"
                            DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("Region") %>'
                            AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                        <data:StateDataSource ID="RegionStateDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataPostalCode" runat="server" Text="Postal Code:" AssociatedControlID="dataPostalCode" />
                    </td>
                    <td>
                        <asp:TextBox Width="300px" runat="server" ID="dataPostalCode" Text='<%# Bind("PostalCode") %>'
                            MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="literal" colspan="2">
                        <asp:Label ID="Label2" CssClass="NormalBold13" runat="server" Text="INTERNAL ADMINISTRATIVE INFORMATION: "></asp:Label>
                    </td>
                </tr>
                <%--            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCompanyId" runat="server" Text="Company Id:" AssociatedControlID="dataCompanyId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCompanyId" DataSourceID="CompanyIdCompanyDataSource"
                        DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CompanyId") %>'
                        AppendNullItem="true" Required="false" NullItemText="None" />
                    <data:CompanyDataSource ID="CompanyIdCompanyDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                        DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>'
                        AppendNullItem="true" Required="false" NullItemText="None" />
                    <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
--%>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataRoleId" runat="server" Text="Role:" AssociatedControlID="dataRoleId" />
                    </td>
                    <td>
                        <data:EntityDropDownList ReadOnly="true" runat="server" ID="dataRoleId" DataSourceID="RoleIdRoleDataSource"
                            DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("RoleId") %>'
                            AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                        <data:RoleDataSource ID="RoleIdRoleDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCharityId" runat="server" Text="Charity:" AssociatedControlID="dataCharityId" />
                    </td>
                    <td>
                        <data:EntityDropDownList Width="305px" runat="server" ID="dataCharityId" DataSourceID="CharityIdCharityDataSource"
                            DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CharityId") %>'
                            AppendNullItem="false" Required="false" NullItemText="< Please Choose ...>" />
                        <data:CharityDataSource ID="CharityIdCharityDataSource" runat="server" SelectMethod="GetAll" />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataMustChangePassword" runat="server" Text="Must Change Password:"
                            AssociatedControlID="dataMustChangePassword" />
                    </td>
                    <td>
                        <asp:RadioButtonList runat="server" ID="dataMustChangePassword" SelectedValue='<%# Bind("MustChangePassword") %>'
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="False" Text="No"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <%--            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWebMemberId" runat="server" Text="Web Member Id:" AssociatedControlID="dataWebMemberId" /></td>
                <td>
                    <asp:TextBox width="300px" runat="server" ID="dataWebMemberId" Text='<%# Bind("WebMemberId") %>'
                        MaxLength="50"></asp:TextBox>
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
            </table>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <b>User not found!</b>
        </EmptyDataTemplate>
        <FooterTemplate>
            <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                Text="Insert" />
            <asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update"
                Text="Submit" />
            <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                Text="Cancel" />
        </FooterTemplate>
    </data:MultiFormView>
    <data:UserDataSource ID="UserDataSource" runat="server" SelectMethod="GetByUserId"
        OnAfterUpdated="UserDataSource_AfterUpdated">
        <Parameters>
            <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
        </Parameters>
    </data:UserDataSource>
    &nbsp;<%--Just used to get at User/Moderator functionality.--%>
    <br />
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
        <data:EntityGridView ID="GridViewConference" runat="server" AutoGenerateColumns="False"
            OnSelectedIndexChanged="GridViewConference_SelectedIndexChanged" DataSourceID="ConferenceDataSource"
            DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="[CompanyName]"
            DefaultSortDirection="Ascending" ExcelExportFileName="Export_Conference.xls"
            Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
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
            EnablePaging="False" EnableSorting="False">
            <Parameters>
                <data:SqlParameter Name="Parameters">
                    <Filters>
                        <data:Vw_ConferenceListFilter Column="UserId" QueryStringField="UserId" />
                    </Filters>
                </data:SqlParameter>
                <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
            </Parameters>
        </data:Vw_ConferenceListDataSource>
        <br />
    </asp:Panel>
    <asp:Panel ID="MarketingServicePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="MarketingServiceImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Marketing Services</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="MarketingServiceLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="MarketingServicePanel1" runat="server" CssClass="collapsePanel" Height="0">
        <asp:UpdatePanel ID="UpdatePanelMarketingService" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="padding: 5px;">
                    <asp:Label ID="lbldataMarketingServiceId" runat="server" Text="Marketing Service:"
                        AssociatedControlID="dataMarketingServiceId" />
                    <data:EntityDropDownList runat="server" ID="dataMarketingServiceId" DataSourceID="MarketingServiceIdMarketingServiceDataSource"
                        DataTextField="Name" DataValueField="Id" AppendNullItem="false" Required="true"
                        NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:MarketingServiceDataSource ID="MarketingServiceIdMarketingServiceDataSource"
                        runat="server" SelectMethod="GetByWholesalerId">
                        <Parameters>
                            <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="WholesalerId"
                                Type="String" />
                        </Parameters>
                    </data:MarketingServiceDataSource>
                    &nbsp;&nbsp;
                    <asp:LinkButton runat="server" ID="btnAddMarketingService" OnClick="btnAddMarketingService_Click">Add New</asp:LinkButton>
                </div>
                <data:EntityGridView ID="GridViewMarketingService" runat="server" AutoGenerateColumns="False"
                    DataSourceID="MarketingServiceDataSource" DataKeyNames="MarketingServiceId, UserId"
                    AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending"
                    ExcelExportFileName="Export_MarketingService.xls" AllowSorting="True" AllowPaging="false"
                    PageSize="100">
                    <Columns>
                        <asp:CommandField ShowSelectButton="False" ShowEditButton="True" ShowDeleteButton="true" />
                        <data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}"
                            DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username"
                            Visible="false" />
                        <data:HyperLinkField HeaderText="Marketing Service" DataNavigateUrlFormatString=""
                            DataNavigateUrlFields="" DataContainer="MarketingServiceIdSource" DataTextField="Name" />
                        <asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Created Date" ReadOnly="true" />
                        <asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Last Modified" ReadOnly="true" />
                        <asp:BoundField DataField="LastModifiedBy" HeaderText="Last Modified By" ReadOnly="true" />
                        <asp:TemplateField HeaderText="Last Contact Date">
                            <ItemTemplate>
                                <asp:Label ID="lblLastContactDate" runat="server" Text='<%# Bind("LastContactDate","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtLastContactDate" Width="72px" Text='<%# Bind("LastContactDate","{0:d}") %>' />
                                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="Click to show calendar" />
                                <ajaxToolkit:CalendarExtender ID="calLastContactDate" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtLastContactDate" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                                &nbsp;&nbsp;
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Next Contact Date">
                            <ItemTemplate>
                                <asp:Label ID="lblNextContactDate" runat="server" Text='<%# Bind("NextContactDate","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox runat="server" ID="txtNextContactDate" Width="72px" Text='<%# Bind("NextContactDate","{0:d}") %>' />
                                <asp:ImageButton runat="Server" ID="Image2" ImageUrl="~/images/Calendar_scheduleHS.png"
                                    AlternateText="Click to show calendar" />
                                <ajaxToolkit:CalendarExtender ID="calNextContactDate" runat="server" CssClass="MyCalendar"
                                    TargetControlID="txtNextContactDate" PopupButtonID="Image2" Format="dd/MM/yyyy" />
                                &nbsp;&nbsp;
                            </EditItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <b>No MarketingService Found!</b>
                    </EmptyDataTemplate>
                </data:EntityGridView>
                <data:User_MarketingServiceDataSource ID="MarketingServiceDataSource" runat="server"
                    SelectMethod="GetByUserId" EnablePaging="False" EnableSorting="False" EnableDeepLoad="True"
                    UpdateDateTimeNames="LastModified" UpdateUserNames="LastModifiedBy">
                    <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                        <Types>
                            <data:User_MarketingServiceProperty Name="MarketingService" />
                            <data:User_MarketingServiceProperty Name="User" />
                        </Types>
                    </DeepLoadProperties>
                    <Parameters>
                        <asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />
                    </Parameters>
                </data:User_MarketingServiceDataSource>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeModerator" runat="Server" TargetControlID="ConferencePanel1"
        ExpandControlID="ConferencePanel2" CollapseControlID="ConferencePanel2" Collapsed="True"
        TextLabelID="ConferenceLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
        ImageControlID="ConferenceImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeMarketingService" runat="Server" TargetControlID="MarketingServicePanel1"
        ExpandControlID="MarketingServicePanel2" CollapseControlID="MarketingServicePanel2"
        Collapsed="True" TextLabelID="MarketingServiceLabel" ExpandedText="(Hide Details...)"
        CollapsedText="(Show Details...)" ImageControlID="MarketingServiceImage" ExpandedImage="~/images/collapse_blue.jpg"
        CollapsedImage="~/images/expand_blue.jpg" SuppressPostBack="true" />
</asp:Content>
