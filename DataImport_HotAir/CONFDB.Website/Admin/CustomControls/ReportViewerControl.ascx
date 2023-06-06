<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReportViewerControl.ascx.cs" Inherits="ReportViewerControl" %>
<%@ Register Assembly="DevExpress.XtraReports.v8.1.Web, Version=8.1.2.0, Culture=neutral, PublicKeyToken=9b171c9fd64da1d1"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dxxr" %>
<%@ Register Assembly="DevExpress.XtraReports.v8.1.Web" Namespace="DevExpress.XtraReports.Web" TagPrefix="dxwc"%>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<table cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td></td>
        <td style="padding-left:6px; padding-right:6px;">
            &nbsp;<dxxr:ReportToolbar ID="ReportToolbar1" runat="server" ShowDefaultButtons="False" ReportViewer="<%# ReportViewer1 %>"><Items><dxxr:ReportToolbarButton ItemKind='Search' ToolTip='Display the search window' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='PrintReport' ToolTip='Print the report' /><dxxr:ReportToolbarButton ItemKind='PrintPage' ToolTip='Print the current page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip='First Page' /><dxxr:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip='Previous Page' /><dxxr:ReportToolbarLabel Text='Page' /><dxxr:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dxxr:ReportToolbarComboBox><dxxr:ReportToolbarLabel Text='of' /><dxxr:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' /><dxxr:ReportToolbarButton ItemKind='NextPage' ToolTip='Next Page' /><dxxr:ReportToolbarButton ItemKind='LastPage' ToolTip='Last Page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='SaveToDisk' ToolTip='Export a report and save it to the disk' /><dxxr:ReportToolbarButton ItemKind='SaveToWindow' ToolTip='Export a report and show it in a new window' /><dxxr:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'><Elements><dxxr:ListElement Text='Pdf' Value='pdf' /><dxxr:ListElement Text='Xls' Value='xls' /><dxxr:ListElement Text='Rtf' Value='rtf' /><dxxr:ListElement Text='Mht' Value='mht' /><dxxr:ListElement Text='Text' Value='txt' /><dxxr:ListElement Text='Csv' Value='csv' /><dxxr:ListElement Text='Image' Value='png' /></Elements></dxxr:ReportToolbarComboBox></Items><Styles><LabelStyle><Margins MarginLeft='3px' MarginRight='3px' /></LabelStyle></Styles></dxxr:ReportToolbar>
        </td>
    </tr>
    <tr><td style="height:8px"></td></tr>
    <tr>
        <td>
            <asp:Panel ID="Panel1" runat="server" EnableTheming="False" Visible="false">
                <table cellspacing="0" cellpadding="0" border="0">
                    <tr>
	                    <td class="PageBorder_tlc" style="width:10px;height:10px;"><div style="width:10px;height:10px;font-size:1px"></div></td>
	                    <td class="PageBorder_t"></td>
	                    <td class="PageBorder_trc" style="width:10px;height:10px;"><div style="width:10px;height:10px;font-size:1px"></div></td>
                    </tr>
                    <tr>
	                    <td class="PageBorder_l"></td>
	                    <td style="background-color:white;">
                            <asp:PlaceHolder ID="DocumentMapPlaceHolder" runat="server"></asp:PlaceHolder>
                        </td>
	                    <td class="PageBorder_r"></td>
                    </tr>
                    <tr>
	                    <td class="PageBorder_blc" style="width:10px;height:10px;"></td>
	                    <td class="PageBorder_b"></td>
	                    <td class="PageBorder_brc" style="width:10px;height:10px;"></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
        <td style="height: 241px; width: 417px;" align="center">
           <table cellspacing="0" cellpadding="0" border="0">
                <tr>
	                <td class="PageBorder_tlc" style="width:11px;height:10px;"><div style="width:10px;height:10px;font-size:1px"></div></td>
	                <td class="PageBorder_t"></td>
	                <td class="PageBorder_trc" style="width:10px;height:10px;"><div style="width:10px;height:10px;font-size:1px"></div></td>
                </tr>
                <tr>
	                <td class="PageBorder_l" style="width: 11px"></td>
	                <td style="background-color:white; border:thin double rgb(128,128,128)" >
                        <dxxr:ReportViewer ID="ReportViewer1" runat="server" OnUnload="Page_Unload">
                        </dxxr:ReportViewer>
                        &nbsp;</td>
	                <td class="PageBorder_r"></td>
                </tr>
                <tr>
	                <td class="PageBorder_blc" style="width:11px;height:19px;"></td>
	                <td class="PageBorder_b" style="height: 19px"></td>
	                <td class="PageBorder_brc" style="width:10px;height:19px;"></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr><td style="height:8px"></td></tr>
    <tr>
        <td></td>
        <td valign="top" style="padding-left:6px; padding-right:6px;">
            &nbsp;<dxxr:ReportToolbar ID="ReportToolbar2" runat="server" ShowDefaultButtons="False" ReportViewer="<%# ReportViewer1 %>"><Items><dxxr:ReportToolbarButton ItemKind='Search' ToolTip='Display the search window' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='PrintReport' ToolTip='Print the report' /><dxxr:ReportToolbarButton ItemKind='PrintPage' ToolTip='Print the current page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton Enabled='False' ItemKind='FirstPage' ToolTip='First Page' /><dxxr:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' ToolTip='Previous Page' /><dxxr:ReportToolbarLabel Text='Page' /><dxxr:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'></dxxr:ReportToolbarComboBox><dxxr:ReportToolbarLabel Text='of' /><dxxr:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' /><dxxr:ReportToolbarButton ItemKind='NextPage' ToolTip='Next Page' /><dxxr:ReportToolbarButton ItemKind='LastPage' ToolTip='Last Page' /><dxxr:ReportToolbarSeparator /><dxxr:ReportToolbarButton ItemKind='SaveToDisk' ToolTip='Export a report and save it to the disk' /><dxxr:ReportToolbarButton ItemKind='SaveToWindow' ToolTip='Export a report and show it in a new window' /><dxxr:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'><Elements><dxxr:ListElement Text='Pdf' Value='pdf' /><dxxr:ListElement Text='Xls' Value='xls' /><dxxr:ListElement Text='Rtf' Value='rtf' /><dxxr:ListElement Text='Mht' Value='mht' /><dxxr:ListElement Text='Text' Value='txt' /><dxxr:ListElement Text='Csv' Value='csv' /><dxxr:ListElement Text='Image' Value='png' /></Elements></dxxr:ReportToolbarComboBox></Items><Styles><LabelStyle><Margins MarginLeft='3px' MarginRight='3px' /></LabelStyle></Styles></dxxr:ReportToolbar>
        </td>
    </tr>
</table>
