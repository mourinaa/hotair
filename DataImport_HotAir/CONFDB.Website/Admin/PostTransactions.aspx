<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeFile="PostTransactions.aspx.cs" Inherits="PostTransactions" Title="Untitled Page" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Post Transactions
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanelPostTransactions" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" />
            <table border="0" cellpadding="3" cellspacing="1">
                <tr>
                    <td class="literal">
                        <asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Admin:" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerListDataSource1"
                            DataTextField="DDLDescription" DataValueField="Id" AppendNullItem="true" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" OnSelectedIndexChanged="dataCustomerId_SelectedIndexChanged"
                            AutoPostBack="true" CssClass="Normal" ToolTip="Select a Customer Admin." />
                        <data:Vw_CustomerListDataSource ID="CustomerListDataSource1" runat="server" SelectMethod="Get">
                            <Parameters>
                                <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID"
                                    Type="string">
                                </data:SqlParameter>
                                <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                            </Parameters>
                        </data:Vw_CustomerListDataSource>
                        <ew:MultiTextDropDownList ID="dataCustomerId2" runat="server" Visible="false" DataValueField="Id"
                            DataTextFormatString="{0} - {1} - {2}" DataTextFields="PriCustomerNumber, CompanyName, PrimaryContactName"
                            AutoPostBack="True" CssClass="Normal" ToolTip="Select a Customer Admin." OnSelectedIndexChanged="dataCustomerId2_SelectedIndexChanged">
                        </ew:MultiTextDropDownList>
                    </td>
                    <td style="width: 200px">
                        <asp:CheckBox ID="chkDisplayByPrimaryNumber" CssClass="Normal" runat="server" AutoPostBack="true"
                            Text="Display By Primary Number" OnCheckedChanged="chkDisplayByPrimaryNumber_CheckedChanged" />
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="lblCurrentBalance" runat="server" CssClass="LargeBoldLabelWithHelp"
                            ToolTip="Customer Admin's current balance."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label1" runat="server" Text="Moderator Name/Conference Name:" />
                    </td>
                    <td colspan="3">
                        <asp:DropDownList runat="server" ID="dataConferenceList" Enabled="false" AutoPostBack="false"
                            Width="300px" CssClass="Normal" ToolTip="OPTIONAL: Select a moderator/conference to associate the transaction to. Usually done for miscellaneous charges." />
                        <asp:Label ID="Label2" runat="server" CssClass="Normal" Text="OPTIONAL"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label10" runat="server" Text="Transaction Date:" />
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtTransactionDate" Width="72px" />
                        <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                            AlternateText="Click to show calendar" CausesValidation="false" />
                        <ajaxToolkit:CalendarExtender ID="calTransactionDate" runat="server" CssClass="MyCalendar"
                            TargetControlID="txtTransactionDate" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTransactionDate"
                            ErrorMessage="Required" Enabled="true" Display="dynamic"></asp:RequiredFieldValidator>
                        <asp:Label ID="Label11" runat="server" CssClass="ToolTipWithHelpBold" Text="If entering a item for the current billing period, 
                            set the transaction date to last day of month so the item will be processed."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label3" runat="server" Text="Transaction Type:" />
                    </td>
                    <td>
                        <data:EntityDropDownList runat="server" ID="dataCustomerTransactionType" DataSourceID="CustomerTransactionTypeDataSource"
                            DataTextField="DisplayName" DataValueField="Id" AppendNullItem="false" Required="true"
                            NullItemText="< Please Choose ...>" ErrorText="Required" Width="300px" CssClass="Normal"
                            ToolTip="List of transactions types are provided below." />
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label4" runat="server" Text="Retail Amount ($.00):" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtRetailAmount" runat="server" CssClass="Normal" Width="300px"
                            ToolTip="Retail amount of the item ($.00)."></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtRetailAmount"
                            FilterType="Custom, Numbers" ValidChars="." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                            ControlToValidate="txtRetailAmount" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ValueToCompare="0.00" ControlToValidate="txtRetailAmount"
                            ErrorMessage="Must enter positive number" Operator="GreaterThan" Type="Currency" Display="Dynamic"></asp:CompareValidator>
                        <asp:Label ID="Label5" runat="server" CssClass="Normal" Text="Only positive numbers allowed."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label6" runat="server" Text="Wholesale Amount ($.00):" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtWSAmount" runat="server" CssClass="Normal" Width="300px" ToolTip="Wholesale cost amount of the item ($.00)."></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                            TargetControlID="txtWSAmount" FilterType="Custom, Numbers" ValidChars="." />
                        <asp:Label ID="Label7" runat="server" CssClass="Normal" Text="OPTIONAL: Only positive numbers allowed."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="literal">
                        <asp:Label ID="Label8" runat="server" Text="Description:" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="Normal" Width="300px" ToolTip="OPTIONAL: Additional information about the item."></asp:TextBox>
                        <asp:Label ID="Label9" runat="server" CssClass="Normal" Text="OPTIONAL: Additional information about the item."></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert"
                            Text="Submit" OnClick="InsertButton_Click" />
                        <asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="Cancel" OnClick="CancelButton_Click" />
                    </td>
                    <td>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelPostTransactions"
                            DynamicLayout="false" DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/progress.gif" />
                                    Please Wait...
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <asp:Panel ID="CustomerTransactionPanel2" runat="server" CssClass="collapsePanelHeader">
                <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
                    <div style="float: left; vertical-align: middle;">
                        <asp:Image ID="CustomerTransactionImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
                    <div style="float: left; padding-left: 5px; font-weight: bold;">
                        Customer Transactions - Quick View - (Newest to Oldest)</div>
                    <div style="float: left; margin-left: 20px;">
                        <asp:Label ID="CustomerTransactionLabel" runat="server" /></div>
                </div>
            </asp:Panel>
            <asp:Panel ID="CustomerTransactionPanel1" runat="server" CssClass="collapsePanel"
                Height="0">
                <data:EntityGridView ID="gvCustomerTransactions" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="ID"
                    DefaultSortDirection="Descending" ExcelExportFileName="Export_CustomerTransaction.xls"
                    AllowSorting="false" PageSize="30" OnPageIndexChanging="gvCustomerTransactions_PageIndexChanging"
                    OnPageSizeChanged="gvCustomerTransactions_PageSizeChanged">
                    <RowStyle HorizontalAlign="center" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="false" ShowEditButton="false" />
                        <asp:BoundField DataField="ID" HeaderText="Transaction ID" SortExpression="" />
                        <asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Transaction Date" SortExpression="" />
                        <asp:BoundField DataField="TransactionAmount" DataFormatString="{0:c}" HeaderText="Retail Amount"
                            SortExpression="" />
                        <asp:BoundField DataField="LocalTaxAmount" DataFormatString="{0:c}" HeaderText="Local Tax"
                            SortExpression="" />
                        <asp:BoundField DataField="TransactionTotal" DataFormatString="{0:c}" HeaderText="Transaction Total"
                            SortExpression="" />
                        <asp:BoundField DataField="CustomerBalance" DataFormatString="{0:c}" HeaderText="Customer Balance"
                            SortExpression="" />
                        <asp:BoundField DataField="WsTransactionAmount" DataFormatString="{0:c}" HeaderText="Wholesale Amount"
                            SortExpression="" />
                        <asp:BoundField DataField="TransactionDescription" HeaderText="Transaction Description"
                            SortExpression="" />
                        <asp:BoundField DataField="ModeratorConferenceName" HeaderText="Moderator/Conference Name"
                            SortExpression="" />
                        <asp:BoundField DataField="CustomerTransactionTypeDisplayName" HeaderText="Transaction Type"
                            SortExpression="" />
                        <asp:BoundField DataField="PostedDate" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Posted Date" SortExpression="" />
                        <asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="" />
                        <asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Created Date" SortExpression="" />
                        <asp:BoundField DataField="PostedToInvoiceDate" DataFormatString="{0:d}" HtmlEncode="False"
                            HeaderText="Invoice Date" SortExpression="" />
                    </Columns>
                    <EmptyDataTemplate>
                        <b>No Transaction Found!</b>
                    </EmptyDataTemplate>
                </data:EntityGridView>
            </asp:Panel>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerTransaction" runat="Server"
                TargetControlID="CustomerTransactionPanel1" ExpandControlID="CustomerTransactionPanel2"
                CollapseControlID="CustomerTransactionPanel2" Collapsed="True" TextLabelID="CustomerTransactionLabel"
                ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="CustomerTransactionImage"
                ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
                SuppressPostBack="true" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="CustomerTransactionTypePanel2" runat="server" CssClass="collapsePanelHeader">
        <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
            <div style="float: left; vertical-align: middle;">
                <asp:Image ID="CustomerTransactionTypeImage" runat="server" ImageUrl="~/images/expand_blue.jpg" /></div>
            <div style="float: left; padding-left: 5px; font-weight: bold;">
                Transaction Type Help Infromation</div>
            <div style="float: left; margin-left: 20px;">
                <asp:Label ID="CustomerTransactionTypeLabel" runat="server" /></div>
        </div>
    </asp:Panel>
    <asp:Panel ID="CustomerTransactionTypePanel1" runat="server" CssClass="collapsePanel"
        Height="0">
        <data:EntityGridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="CustomerTransactionTypeDataSource"
            DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="[DisplayOrder]"
            DefaultSortDirection="Ascending" ExcelExportFileName="Export_CustomerTransactionType.xls"
            AllowPaging="false" PageSize="50">
            <Columns>
                <asp:CommandField ShowSelectButton="False" ShowEditButton="False" />
                <asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="" />
                <data:HyperLinkField HeaderText="GL Posting Type" DataContainer="GlPostingTypeIdSource"
                    DataTextField="Name" />
                <asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />
            </Columns>
            <EmptyDataTemplate>
                <b>No CustomerTransactionType Found!</b>
            </EmptyDataTemplate>
        </data:EntityGridView>
        <data:CustomerTransactionTypeDataSource ID="CustomerTransactionTypeDataSource" runat="server"
            SelectMethod="GetPaged" EnablePaging="True" EnableSorting="True" EnableDeepLoad="True">
            <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                <Types>
                    <data:CustomerTransactionTypeProperty Name="GlPostingType" />
                    <%--<data:CustomerTransactionTypeProperty Name="CustomerTransactionCollection" />--%>
                </Types>
            </DeepLoadProperties>
            <Parameters>
                <data:CustomParameter Name="WhereClause" Value="Visible=1" ConvertEmptyStringToNull="false" />
                <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                <asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex"
                    Type="Int32" />
                <asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize"
                    Type="Int32" />
                <data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
            </Parameters>
        </data:CustomerTransactionTypeDataSource>
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerTransactionType" runat="Server"
        TargetControlID="CustomerTransactionTypePanel1" ExpandControlID="CustomerTransactionTypePanel2"
        CollapseControlID="CustomerTransactionTypePanel2" Collapsed="True" TextLabelID="CustomerTransactionTypeLabel"
        ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)" ImageControlID="CustomerTransactionTypeImage"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true" />
</asp:Content>
