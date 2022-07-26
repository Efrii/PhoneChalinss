$(document).ready(function() {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = 'Quicksand, sans-serif';
    Chart.defaults.global.defaultFontColor = '#858796';

    $.ajax({
        'url': "https://localhost:42573/api/Employee",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (result) {
        
        let laki = [];
        let cewek = [];
        
        for(let i = 0; i < result.data.length; i++){
            let data = result.data[i].genderEmployee == "L";
            if(data == true){
                laki.push(result.data[i])
            } else{
                cewek.push(result.data[i])
            }
        }

        // Pie Chart Example
        var ctx = document.getElementById("myPieChart");
        var myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ["Laki-Laki", "Perempuan"],
            datasets: [{
            data: [laki.length, cewek.length],
            backgroundColor: ['#4e73df', '#1cc88a'],
            hoverBackgroundColor: ['#2e59d9', '#17a673'],
            hoverBorderColor: "rgba(234, 236, 244, 1)",
            }],
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
            },
            legend: {
            display: false
            }
        },
        });
    });

    // ----------------------- //

    function onlyUnique(value, index, self) {
        return self.indexOf(value) === index;
    }

    $.ajax({
        'url': "https://localhost:42573/api/Smartphone/Getall",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (result) {
        
        let arrayName = [];
        let arraySum = [];
        let data = result.data;

        $(data).each(function(key,val){
            let same = val.supplierModel.nameSupplier;
            arrayName.push(same);
        }); 

        let d = arrayName.filter(onlyUnique);
        for(let i = 0; i < d.length; i++){
            let filterCat = arrayName.filter(x => x == d[i])
            arraySum.push(filterCat.length);
        }

        console.log(arrayName.filter(onlyUnique));
        console.log(arraySum);

        var ctx = document.getElementById("myAreaChart");
        var myBarChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayName.filter(onlyUnique),
            datasets: [{
            label: "Smartphone ",
            backgroundColor: "#4e73df",
            hoverBackgroundColor: "#2e59d9",
            borderColor: "#4e73df",
            data: arraySum,
            }],
        },
        options: {
            maintainAspectRatio: false,
            layout: {
              padding: {
                left: 10,
                right: 25,
                top: 25,
                bottom: 0
              }
            },
            scales: {
              xAxes: [{
                gridLines: {
                  display: false,
                  drawBorder: false
                },
                ticks: {
                  maxTicksLimit: 6
                },
                maxBarThickness: 25,
              }],
              yAxes: [{
                ticks: {
                  min: 0,
                  maxTicksLimit: 10,
                  padding: 10,
                },
                gridLines: {
                  color: "rgb(234, 236, 244)",
                  zeroLineColor: "rgb(234, 236, 244)",
                  drawBorder: false,
                  borderDash: [2],
                  zeroLineBorderDash: [2]
                }
              }],
            },
            legend: {
              display: false
            },
            tooltips: {
              titleMarginBottom: 12,
              titleFontColor: '#6e707e',
              titleFontSize: 14,
              backgroundColor: "rgb(255,255,255)",
              bodyFontColor: "#858796",
              borderColor: '#dddfeb',
              borderWidth: 1,
              xPadding: 15,
              yPadding: 15,
              displayColors: false,
              caretPadding: 10
            },
          }
        });                         
    });

    
});