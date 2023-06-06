<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserGridModerator.ascx.cs"
    Inherits="UserGridModerator" %>
<%--NOTE: This is a custom control used to display the User setting for the ConferenceEdit pages only in EDIT MODE.
    It differs in that the Moderator must use their email address as their login username and when add a new
    user they must enter in their address information.
--%>
<asp:UpdatePanel ID="UpdatePanelUserGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelUserGrid"
            DynamicLayout="true" DisplayAfter="1">
            <ProgressTemplate>
                <div class="">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                    Please Wait...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Label ID="lblErrorMessage" Visible="false" runat="server" CssClass="ErrorMessage"
            Text="User name invalid as it is not unique. Please select a different user name and try again."></asp:Label>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.--%>
        <asp:Label Visible="false" ID="lblUserID" runat="server" />
        <data:EntityGridView ID="GridViewUser" SkinID="CustomGrid" runat="server" AutoGenerateColumns="False"
            DataSourceID="UserDataSource" DataKeyNames="UserId" AllowMultiColumnSorting="False"
            DefaultSortDirection="Ascending" ExcelExportFileName="Export_User.xls" OnRowUpdating="GridViewUser_RowUpdating"
            AllowExportToExcel="True" ExportToExcelText="Excel" PageSelectorPageSizeInterval="10"
            RecordsCount="0" OnRowUpdated="GridViewUser_RowUpdated">
            <Columns>
                <asp:CommandField ShowSelectButton="False" ShowEditButton="True" />
                <asp:TemplateField HeaderText="AMP Login">
                   <itemtemplate>                       
                       <a target="_blank" href="<%# String.Format("http://amp.redbackconferencing.com.au/signon.aspx?a={0}&b={1}", DataBinder.Eval(Container.DataItem, "Username"), DataBinder.Eval(Container.DataItem, "Password")) %>">AMP Login</a>
                   </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Web Login Name">
                    <edititemtemplate>
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>
                    <%--In case JS turned off. Server side check done.--%>
                    <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: User name is not unique. Please select a new one and try your request again." />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
					<asp:RegularExpressionValidator id="Regularexpressionvalidator2" runat="server" CssClass="ErrorMessage" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="Email address is not valid." ValidationExpression="^(?:[a-zA-Z0-9_'^&amp;amp;/+-])+(?:\.(?:[a-zA-Z0-9_'^&amp;amp;/+-])+)*@(?:(?:\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\]?)|(?:[a-zA-Z0-9-]+\.)+(?:[a-zA-Z]){2,}\.?)$"></asp:RegularExpressionValidator>
                </edititemtemplate>
                    <itemtemplate>
                        <asp:Label id="lblUsername" runat="server" Text='<%# Eval("Username") %>'></asp:Label> 
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Web Login Password">
                    <edititemtemplate>
                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                     <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidPassword" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: Password is invalid. It must be a minimum of length of 8. Please select a new one and try your request again." />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtPassword" 
                    ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8." Display="Dynamic"></asp:RegularExpressionValidator>
                </edititemtemplate>
                    <itemtemplate>
                    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'  />
                </itemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DisplayName" HeaderText="Moderator Name" />
                <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
                <asp:TemplateField HeaderText="Address1">
                    <edititemtemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Address1") %>' id="TextBox1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </edititemtemplate>
                    <itemtemplate>
                    <asp:Label runat="server" Text='<%# Bind("Address1") %>' id="Label1"></asp:Label>
                </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address2">
                    <edititemtemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("Address2") %>' id="TextBox2"></asp:TextBox>
                </edititemtemplate>
                    <itemtemplate>
                <asp:Label runat="server" Text='<%# Bind("Address2") %>' id="Label2"></asp:Label>
                </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="City">
                    <edititemtemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("City") %>' id="TextBox3"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </edititemtemplate>
                    <itemtemplate>
                    <asp:Label runat="server" Text='<%# Bind("City") %>' id="Label3"></asp:Label>
                </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Country">
                    <itemtemplate>
					    <data:EntityDropDownList ReadOnly="true" runat="server" ID="dataCountry" DataSourceID="CountryCountryDataSource" DataTextField="Description" 
					    DataValueField="Id" SelectedValue='<%# Bind("Country") %>' AppendNullItem="False" Required="true" 
					    NullItemText="< Please Choose ...>"  RequiredErrorMessage="Required" />
					    <data:CountryDataSource ID="CountryCountryDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
					    </data:CountryDataSource>
                    </itemtemplate>
                    <edititemtemplate>
					    <data:EntityDropDownList runat="server" ID="dataCountry" DataSourceID="CountryCountryDataSource" DataTextField="Description" 
					    DataValueField="Id" SelectedValue='<%# Bind("Country") %>' AppendNullItem="False" Required="true" 
					    NullItemText="< Please Choose ...>"  RequiredErrorMessage="Required" />
					    <data:CountryDataSource ID="CountryCountryDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder,Description" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
					    </data:CountryDataSource>
                    </edititemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Region">
                    <itemtemplate>
					    <data:EntityDropDownList ReadOnly="true" runat="server" ID="dataRegion" DataSourceID="RegionStateDataSource" DataTextField="LongName" 
					    DataValueField="Id" SelectedValue='<%# Bind("Region") %>' AppendNullItem="true" Required="false" 
					    NullItemText="< Please Choose ...>" />
					    <data:StateDataSource ID="RegionStateDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
					    </data:StateDataSource>
                    </itemtemplate>
                    <edititemtemplate>
					    <data:EntityDropDownList runat="server" ID="dataRegion" DataSourceID="RegionStateDataSource" DataTextField="LongName" 
					    DataValueField="Id" SelectedValue='<%# Bind("Region") %>' AppendNullItem="true" Required="false" 
					    NullItemText="< Please Choose ...>" />
					    <data:StateDataSource ID="RegionStateDataSource" runat="server" 
                            SelectMethod="GetPaged">
                            <Parameters>
                                <data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />                        
                            </Parameters>
					    </data:StateDataSource>
                    </edititemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PostalCode">
                    <edititemtemplate>
                    <asp:TextBox runat="server" Text='<%# Bind("PostalCode") %>' id="TextBox4"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </edititemtemplate>
                    <itemtemplate>
                    <asp:Label runat="server" Text='<%# Bind("PostalCode") %>' id="Label4"></asp:Label>
                </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Charity">
                    <itemtemplate>
					    <data:EntityDropDownList readonly="true" runat="server" ID="dataCharityId" DataSourceID="CharityIdCharityDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CharityId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					    <data:CharityDataSource ID="CharityIdCharityDataSource" runat="server" SelectMethod="GetAll"  />
                    </itemtemplate>
                    <edititemtemplate>
					    <data:EntityDropDownList runat="server" ID="dataCharityId" DataSourceID="CharityIdCharityDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CharityId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					    <data:CharityDataSource ID="CharityIdCharityDataSource" runat="server" SelectMethod="GetAll"  />
                    </edititemtemplate>
                </asp:TemplateField>
                <asp:CheckBoxField DataField="Enabled" HeaderText="Enabled">
                    <itemstyle horizontalalign="Center" />
                </asp:CheckBoxField>
                <asp:CheckBoxField DataField="MustChangePassword" HeaderText="Must Change Password">
                    <itemstyle horizontalalign="Center" />
                </asp:CheckBoxField>
                <data:HyperLinkField HeaderText="Role" DataContainer="RoleIdSource" DataTextField="Name" />
            </Columns>
            <EmptyDataTemplate>
                <b>No User Found!</b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:UserDataSource ID="UserDataSource" runat="server" SelectMethod="GetByUserId"
            EnablePaging="False" EnableSorting="False" EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:UserProperty Name="Role" />
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <asp:ControlParameter ControlID="lblUserID" Name="UserId" PropertyName="Text" Type="Int32" />
            </Parameters>
        </data:UserDataSource>
    </ContentTemplate>
</asp:UpdatePanel>
