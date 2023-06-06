<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeFile="BillingRun.aspx.cs" Inherits="BillingRun" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Billing Run
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Normal">
        <strong>Step 1: </strong>Enter in all payments, charges, credits, etc before starting
        the billing run. Make sure to date the transaction date to the last day of your
        billing period or earlier.
        <br />
        NOTE: ONCE YOU START THE BILLING RUN, NO CHARGES OR PAYMENTS SHOULD BE ADDED TO
        THE SYSTEM AS DOING A ROLLBACK WILL ERASE THESE ACTIONS.
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                DynamicLayout="true" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                        Please Wait...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="Normal">
                <strong>Step 2: </strong>If the LAST BILLING RUN was successful then mark the CDRS
                so they won't be processed again. This is done to make getting at the current BILLING
                RUN CDRs faster.
                <br />
                <strong>NOTE 1: DON'T RUN THIS STEP AGIAN IF YOU DID A ROLLBACK. GO TO STEP #3</strong>
                <br />
                NOTE 2: THIS CAN ONLY BE RUN ONCE PER BILLING RUN SO MAKE SURE YOUR LAST BILLING
                RUN WAS COMPLETED CORRECTLY.
                <br />
                <asp:Button ID="btnMarkLastBillingRunComplete" runat="server" CssClass="NormalBold"
                    Text="Mark Last Billing Run Complete" OnClick="btnMarkLastBillingRunComplete_Click" />
                <asp:Label ID="lblMarkLastBillingRunComplete" runat="server" CssClass="NormalGreen"
                    Visible="false">Done.</asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                DynamicLayout="true" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/progress.gif" />
                        Please Wait...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="Normal">
                <strong>Step 3: </strong>Backup all of the tables used for Invoicing.
                <br />
                NOTE: ONLY DO THIS ONCE BEFORE THE BILLING RUN UNLESS THERE WAS AN ISSUE AND YOU
                ROLLBACKED THE CURRENT BILLING RUN AND ADDED NEW TRANSACTIONS TO THE SYSTEM.
                <br />
                <asp:Button ID="btnBackupInvoiceTables" runat="server" CssClass="NormalBold" Text="Backup Invoice Tables"
                    OnClick="btnBackupInvoiceTables_Click" />
                <asp:Label ID="lblBackupInvoiceTables" runat="server" CssClass="NormalGreen" Visible="false">Done.</asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <div>
        <strong>Step 4: </strong>Execute the Billing Run. The start date (DD/MM/YYYY) should
        be the first day of the billing period and the end date should be the first day
        of the next month. e.g Jan 1 2009, Feb 1 2009, would be the dates for the January
        billing run.<br />
        <table cellpadding="1" cellspacing="2">
            <tr>
                <td valign="top" align="right">
                    Start Date:
                </td>
                <td valign="top">
                    <asp:TextBox runat="server" ID="txtStartDate" Width="72px" />
                    <asp:ImageButton runat="Server" ID="Image4" ImageUrl="~/Images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" CausesValidation="false" />
                    <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" CssClass="MyCalendar"
                        TargetControlID="txtStartDate" PopupButtonID="Image4" Format="dd/MM/yyyy" />
                </td>
                <td valign="top" align="right">
                    End Date:
                </td>
                <td valign="top">
                    <asp:TextBox runat="server" ID="txtEndDate" Width="72px" />
                    <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" CausesValidation="false" />
                    <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" CssClass="MyCalendar"
                        TargetControlID="txtEndDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy" />
                </td>
                <td valign="top" align="right">
                    Billing Period Cut-Off:
                </td>
                <td valign="top">
                    <asp:TextBox runat="server" ID="txtBillingCutoff" ReadOnly="true" Width="72px">31</asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="UpdatePanel3"
                DynamicLayout="true" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/progress.gif" />
                        Please Wait...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="Normal">
                <asp:Button ID="btnExecuteBillingRun" runat="server" CssClass="NormalBold" Text="Execute Billing Run"
                    OnClick="btnExecuteBillingRun_Click" />
                <asp:Label ID="lblExecuteBillingRun" runat="server" CssClass="NormalGreen" Visible="false">Done.</asp:Label>
                <asp:Label ID="lblErrorMessage" runat="server" CssClass="ErrorMessage" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="UpdatePanel5"
                DynamicLayout="true" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="">
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/progress.gif" />
                        Please Wait...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="Normal">
                <strong>Step 4.1: </strong>After checking the invoices to see if they are ok, 
                submit the request to generate the conference summary report emails and send 
                them to customers.
                <br />
                <asp:Button ID="btnEmailInvoices" runat="server" CssClass="NormalBold" 
                    Text="Email Conference Summaries" onclick="btnEmailInvoices_Click"
                    />
                <asp:Label ID="Label1" runat="server" CssClass="NormalGreen" Visible="false">Done.</asp:Label>
                <asp:Label ID="lblMessage" runat="server" CssClass="ErrorMessage" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel4"
                DynamicLayout="true" DisplayAfter="1">
                <ProgressTemplate>
                    <div class="">
                        <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/progress.gif" />
                        Please Wait...
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="Normal">
                <strong>Step 5: </strong>IF ANYTHING GOES WRONG OR THERE ARE ANY MISTAKES, ROLLBACK!
                <br />
                <asp:Button ID="btnRollback" runat="server" CssClass="NormalBold" Text="Rollback Billing Run"
                    OnClick="btnRollback_Click" />
                <asp:Label ID="lblRollback" runat="server" CssClass="NormalGreen" Visible="false">Done.</asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
