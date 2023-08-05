
$(document).ready(function () {


    
    GetMonthlyPieChartData()
    
    GetAnnualPieChartData()

    GetExpensesLineChart(0)


    $("#optionselect").change(function () {
        var Testid = parseInt($("#optionselect option:selected").val());

        console.log(Testid)
       

        GetExpensesLineChart(Testid)
           

        });
        



    function DisplayLineChart(result)
    {
        var ExpenseDom = document.getElementById('container');
        var myChart = echarts.init(ExpenseDom, null, {
            renderer: 'canvas',
            useDirtyRect: false
        });
        var app = {};

        var option;

        option = {
            xAxis: {
                type: 'category',
                data: result.month
            },
            yAxis: {
                type: 'value'
            },
            series: [
                {
                    data: result.expenseValue,
                    type: 'line',
                    smooth: true
                }
            ]
        };

        if (option && typeof option === 'object') {
            myChart.setOption(option);
        }

        window.addEventListener('resize', myChart.resize);
    }


    function GetExpensesLineChart(CategoryId)
    {
        $.ajax({
            type: 'GET',
            url: "/api/DashBoardApi/ExpensesChart",
            data: { id: CategoryId }
        }).done(function (result) {

            DisplayLineChart(result)

        });
    }


    function GetMonthlyPieChartData()
    {
        $.ajax({
            type: 'GET',
            url: "/api/DashBoardApi/MonthlyPieChart?Type=monthly",
            
        }).done(function (result) {

            DisplayPieChart(result,'Monthly-chart-container')
            console.log(result)
        });
    }

    function GetAnnualPieChartData() {
        $.ajax({
            type: 'GET',
            url: "/api/DashBoardApi/MonthlyPieChart?Type=Annual",

        }).done(function (result) {

            DisplayPieChart(result, 'Annual-chart-container')
            console.log(result)
        });
    }
    function DisplayPieChart(result,containerName)
    {
        var MonthlyByCategory = document.getElementById(containerName);
        var myChart = echarts.init(MonthlyByCategory, null, {
            renderer: 'canvas',
            useDirtyRect: false
        });
        var app = {};

        var option;

        option = {
            tooltip: {
                trigger: 'item'
            },
            legend: {
                top: '5%',
                left: 'center'
            },
            series: [
                {
                    name: 'Access From',
                    type: 'pie',
                    radius: ['40%', '70%'],
                    avoidLabelOverlap: false,
                    itemStyle: {
                        borderRadius: 10,
                        borderColor: '#fff',
                        borderWidth: 2
                    },
                    label: {
                        show: false,
                        position: 'center'
                    },
                    emphasis: {
                        label: {
                            show: true,
                            fontSize: 16,
                            fontWeight: 'bold'
                        }
                    },
                    labelLine: {
                        show: false
                    },
                    data: result
                        
                    
                }
            ]
        };


        if (option && typeof option === 'object') {
            myChart.setOption(option);
        }

        window.addEventListener('resize', myChart.resize);
    }
});
