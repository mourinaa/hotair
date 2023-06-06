<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserGridCustom.ascx.cs" Inherits="UserGridCustom" %>

<%--NOTE: This is a custom control used to display the User setting for the CustomerEdit and ModeratorEdit pages.--%>

<asp:UpdatePanel ID="UpdatePanelUserGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelUserGrid" DynamicLayout="false" DisplayAfter="1">
            <ProgressTemplate>
                <div class="">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                    Please Wait...
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>       
        <asp:Label ID="lblErrorMessage" Visible="false" runat="server" CssClass="ErrorMessage" Text="User name invalid as it is not unique. Please select a different user name and try again."></asp:Label>
        <%--Hidden control used to pass value to NetTiers Typed DataSource control or between page postbacks.--%>
        <asp:Label Visible="false" ID="lblUserID" runat="server" />
        <data:EntityGridView ID="GridViewUser" SkinID="CustomGrid" runat="server" AutoGenerateColumns="False"
            DataSourceID="UserDataSource" DataKeyNames="UserId" AllowMultiColumnSorting="false"
            DefaultSortColumnName="" DefaultSortDirection="Ascending" ExcelExportFileName="Export_User.xls"
            AllowPaging="False" AllowSorting="false" OnRowUpdating="GridViewUser_RowUpdating"
            >
            <Columns>
                <asp:CommandField ShowSelectButton="False" ShowEditButton="True" />
                <asp:TemplateField HeaderText="AMP Login">
                   <itemtemplate>
                       <a target="_blank" href="<%# String.Format("http://amp.redbackconferencing.com.au/signon.aspx?a={0}&b={1}", DataBinder.Eval(Container.DataItem, "Username"), DataBinder.Eval(Container.DataItem, "Password")) %>">AMP Login</a>
                   </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="User Name">
                <itemtemplate>
                    <asp:Label ID="lblUsername" runat="server" Text='<%# Eval("Username") %>'  />
                </itemtemplate>
                <edititemtemplate>
                    <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>
                    <%--In case JS turned off. Server side check done.--%>
                    <asp:Label ID="lblInvalidUserName" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: User name is not unique. Please select a new one and try your request again." />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtUsername" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </edititemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Password">
                <itemtemplate>
                    <asp:Label ID="lblPassword" runat="server" Text='<%# Eval("Password") %>'  />
                </itemtemplate>
                <edititemtemplate>
                    <asp:TextBox ID="txtPassword" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                     <%--In case JS turned off. Server side check done.--%>
                        <asp:Label ID="lblInvalidPassword" runat="server" CssClass="ErrorMessage" Visible="false" Text="Error: Password is invalid. It must be a minimum of length of 8. Please select a new one and try your request again." />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Required"></asp:RequiredFieldValidator>
<%--REMOVE min. 8 char check for Customer: Requested By JD Aug/2010
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" 
                    ValidationExpression=".{8}.*" ErrorMessage="Password must be a minimum length of 8." Display="Dynamic"></asp:RegularExpressionValidator>
--%>                </edititemtemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DisplayName" HeaderText="Display Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Telephone" HeaderText="Telephone" />
                <data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" ItemStyle-HorizontalAlign="Center" />
                <data:BoundRadioButtonField DataField="MustChangePassword" HeaderText="Must Change Password" ItemStyle-HorizontalAlign="Center" />
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

