
$(function() {
    var daterangeOptions = { shortcuts: { 'prev-days': '',
        'next-days': '',
        'prev': ['week', 'month'],
        'next': ''
    }
    };

    $("#managedEventsReportDateRange").dateRangePicker(daterangeOptions)
                            .bind('datepicker-change', function(event, obj) {
                                //console.log(obj);
                                // obj will be something like this:
                                // {
                                //      date1: (Date object of the earlier date),
                                //      date2: (Date object of the later date),
                                //      value: "2013-06-05 to 2013-06-07"
                                // }
                            })
                            .bind('datepicker-apply', function(event, obj) {
                                showReport(obj.date1.format("yyyy-MM-dd"), obj.date2.format("yyyy-MM-dd"));
                            })
                            .bind('datepicker-close', function() {
                            });

    $('#wait').ajaxStart(function() {
        $(this).show();
    }).ajaxComplete(function() {
        $(this).hide();
    });

    function showReport(startDate, endDate) {

        $.ajax({
            url: "../ReportHandler.ashx",
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: "json",
            data: { 'reportType': 'ManagedEventsSummaryAdmin', 'startDate': startDate, 'endDate': endDate },
            responseType: "json",
            success: function(d) {
                if (d.err) {
                    //session timeout
                    if (d.err.errcode === "-1") {
                        window.location.href = "../signOn.aspx";
                        return;
                    }
                }

                if (!d.Table) {
                    $('#ManagedEventsTable').html('No data in this date range');
                    return;
                }

                var dataSet = _.map(d.Table, function(x) { return [x.CustomerNumber, x.Company, x.Event_Title, moment(x.Event_StartDate).format('DD-MM-YYYY hh:mm'), x.Event_CustomId, x.Att_TotalLiveParticipants, x.Reg_TotalRegistrant, x.Att_TotalDuration, x.Att_Average_Duration] });

                if ($.fn.dataTable.isDataTable('#ManagedEventsTable')) {
                    table = $('#ManagedEventsTable').DataTable();

                    table.destroy();
                }
                $('#ManagedEventsTable').dataTable({
                    "data": dataSet,
                    "columns": [
                    { "title": "Customer #" },
                    { "title": "Company" },
                                    { "title": "Event Title" },
                                    { "title": "Start Date" },
                                    { "title": "Event ID" },
                                    { "title": "Total Live Participants" },
                                    { "title": "Total Registrants" },
                                    { "title": "Total Duration (minutes)" },
                                    { "title": "Average Duration" }
                                ],
                    "dom": 'T<"clear">lfrtip',
                    "oTableTools": {
                        "sSwfPath": "../../scripts/plugins/swf/copy_csv_xls_pdf.swf",
                         "aButtons": [
                                        {
                                            "sExtends": "csv",
                                            "sTitle": "Managed Events Summary Report",
                                            "sButtonText": "Export CSV",
                                        }
                                     ]
                    },
                    deferRender: true
                });
            },
            error: function(xhr, ajaxOptions, thrownError) {
                $('#ManagedEventsTable').html('Error occured: <br>' + xhr.status + '<br>' + thrownError);
            }
        });
    }
});
