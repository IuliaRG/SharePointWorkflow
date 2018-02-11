function callStatusDev() {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataStatus?listTitle=Development team&data",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
               
                createStatusDevChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callStatusMarketing() {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataStatus?listTitle=Marketing team&data",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {

                createStatusDevChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callPriorityDev()
{
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataPriority?listTitle=Development team",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {

                createPriorityChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callPriorityMarketing() {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataPriority?listTitle=Marketing team",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {

                createPriorityChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callDataWithHighPriorityDev()
{
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataInProgressWithHighPriority?listTitle=Development team",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                console.log(response);
                createInprogressChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callDataWithHighPriorityMarketing() {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetDataInProgressWithHighPriority?listTitle=Marketing team",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                console.log(response);
                createInprogressChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function callCurrentMonthStatusDev() {
  $(document).ready(function () {
       $.ajax({
           type: "GET",
           url: "api/reportsApi/GetStatisticsOfStatusCurrentMonth?listTitle=Development team",
           contentType: "application/json; charset=utf-8",
           dataType: "json",
           async: false,
           success: function (response) {
               createCurrentMonthChart(response);
           },
           error: function (response, text) {
               alert(text);
           }
       });
  });
}

function callCurrentMonthStatusMarketing() {
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetStatisticsOfStatusCurrentMonth?listTitle=Development team",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                createCurrentMonthChart(response);
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
}

function GetDataInProgressDev() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Development team&state=In progress",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
                
                for (var i = 0; i <= response.length - 1; i++) {
                    "<pre>"
                    res = res +"<div>"+ " Item:" + i + "</div>" + "<div>"+"Title:" + response[i].Title + "</div>" +"<div>" +"Error: " + response[i].Error + "</div>" + "<div>"+" Priority:" + response[i].Priority + "</div>";
                    "</pre>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });   
    return res;
}

function GetDataSolvedDev() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Development team&state=Solved",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
               
                for (var i = 0; i <= response.length - 1; i++) {
                    "<br>"
                    res = res + " Item:" + i + ' ' + "Title:" + response[i].Title + ' ' + "Error:" + response[i].Error + ' ' + " Priority:" + response[i].Priority+"<br>" ;
                    "</br>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
    return res;
}

function GetDataNewDev() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Development team&state=New",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
             
                for (var i = 0; i <= response.length - 1; i++) {
                    "<br>"
                    res = res + " Item:" + i + "<br/>" + "Title:" + response[i].Title + "<br/>" + "Error " + response[i].Error + "<br/>" + " Priority" + response[i].Priority ;
                    "</br>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
    return res;
}

function GetDataInProgressMarketing() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Marketing team&state=In progress",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
              
                for (var i = 0; i <= response.length - 1; i++) {
                    "<br>"
                    res = res + "<div>" + " Item:" + i + "</div>" + "<div>" + "Title:" + response[i].Title + "</div>" + "<div>" + "Request:" + response[i].Request + "</div>" + "<div>" + " Priority:" + response[i].Priority + "</div>";
                    "</br>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
    return res;
}

function GetDataSolvedMarketing() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Marketing team&state=Solved",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
            
                for (var i = 0; i <= response.length - 1; i++) {
                    "<br>"
                    res = res + "<div>" + " Item:" + i + "</div>" + "<div>" + "Title:" + response[i].Title + "</div>" + "<div>" + "Request:" + response[i].Request + "</div>" + "<div>" + " Priority:" + response[i].Priority + "</div>";
                    "</br>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
    return res;
}

function GetDataNewMarketing() {
    var res = "";
    $(document).ready(function () {
        $.ajax({
            type: "GET",
            url: "api/reportsApi/GetData?listTitle=Marketing team&state=New",
            //data: ,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (response) {
               
                for (var i = 0; i <= response.length - 1; i++) {
                    "<div>"
                    res = res + " Item:" + i + "<br>" + "Title:" + response[i].Title + "<br>" + "Request " + response[i].Request + " " + " Priority" + response[i].Priority+"<br>";
                    "</div>"
                    "<br>"
                }
            },
            error: function (response, text) {
                alert(text);
            }
        });
    });
    return res;
}

function createStatusDevChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawStatusChart);
    function drawStatusChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addColumn({ 'type': 'string', 'role': 'tooltip', 'p': { 'html': true } });
        data.addRows([
          ['New', response.New, GetDataNewDev()],
          ['In progress', response.InProgress, GetDataInProgressDev()],
          ['Solved', response.Solved, GetDataSolvedDev()]
        ]);
        var options = {
         tooltip: { isHtml: true },
            'title': 'Status',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('Status_chart_div'));
        chart.draw(data, options);
    }
}

function createStatusMarketingChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawStatusChart);
    function drawStatusChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addColumn({ 'type': 'string', 'role': 'tooltip', 'p': { 'html': true } });
        data.addRows([
          ['New', response.New, GetDataNewMarketing()],
          ['In progress', response.InProgress, GetDataInProgressMarketing()],
          ['Solved', response.Solved, GetDataSolvedMarketing()]
        ]);
        var options = {
            tooltip: { isHtml: true },
            'title': 'Status',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('Status_chart_div'));
        chart.draw(data, options);
    }
}

function createPriorityChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawPriorityChart);
    function drawPriorityChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addRows([
          ['Low', response.Low],
          ['Mid', response.Mid],
          ['High', response.High]
        ]);
        var options = {
            'title': 'Priority',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('Priority_chart_div'));
        chart.draw(data, options);
    }
}

function createPriorityChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawPriorityChart);
    function drawPriorityChart() {

        // Create the data table.
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addRows([
          ['Low', response.Low],
          ['Mid', response.Mid],
          ['High', response.High]
        ]);
        var options = {
            'title': 'Priority',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('Priority_chart_div'));
        chart.draw(data, options);
    }
}

function createInprogressChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawInProgressChart);
    function drawInProgressChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addRows([
          ['Total Number', response.TotalNumber],
          ['Number With High Priority', response.NumberWithSpecificProperty]
        ]);
        var options = {
            'title': 'Items In Progress With High Priority ',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('InProgress_chart_div'));
        chart.draw(data, options);
    }
}

function createCurrentMonthChart(response) {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(drawCurrentMonthChart);
    function drawCurrentMonthChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Type');
        data.addColumn('number', 'Number');
        data.addRows([
          ['New', response.New],
          ['In Progress', response.InProgress],
           ['Solved', response.Solved]
        ]);

        var options = {
            'title': 'Current Month Status ',
            'width': 800,
            'height': 500
        };
        var chart = new google.visualization.PieChart(document.getElementById('CurrentMonth_chart_div'));
        chart.draw(data, options);
    }
}