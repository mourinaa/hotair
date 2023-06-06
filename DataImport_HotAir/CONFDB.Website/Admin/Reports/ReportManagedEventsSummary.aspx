<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="ReportManagedEventsSummary.aspx.cs" Inherits="Admin_Reports_ReportManagedEventsSummary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
Managed Events Summary
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<link href="//cdn.datatables.net/1.10.4/css/jquery.dataTables.css" rel="stylesheet" type="text/css" />
<link href="//cdn.datatables.net/tabletools/2.2.3/css/dataTables.tableTools.css" rel="stylesheet" type="text/css" />
<link href="../../scripts/plugins/jquery-date-range-picker/daterangepicker.css" rel="stylesheet" type="text/css" />
<link href="../../css/customDataTables.css" rel="stylesheet" type="text/css" />
    
<div class="box">
    <div class="box header">
        <label for="managedEventsReportDateRange">Report Date Range</label>
        <input id = "managedEventsReportDateRange" class="daterange"></input>
    </div>
    
    <div class="box body"> 
        <div id="wait" style="display:none;">fetching data...</div>
        <table id="ManagedEventsTable" class="display" cellspacing="0" width="100%">
        </table>
    </div>
</div>
<script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js" type="text/javascript"></script>
<script src="../../scripts/plugins/jquery-date-range-picker/jquery.daterangepicker.js" type="text/javascript"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/underscore.js/1.7.0/underscore-min.js" type="text/javascript"></script>
<script src="//cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js" type="text/javascript"></script>
<script src="//cdn.datatables.net/tabletools/2.2.3/js/dataTables.tableTools.min.js" type="text/javascript"></script>
<script src="../../scripts/ManagedEventsSummaryReport.js" type="text/javascript"></script>

</asp:Content>

