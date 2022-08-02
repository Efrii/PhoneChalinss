$(document).ready(function() {
    // Set new default font family and font color to mimic Bootstrap's default styling
    Chart.defaults.global.defaultFontFamily = 'Quicksand, sans-serif';
    Chart.defaults.global.defaultFontColor = '#858796';

    $.ajax({
        'url': "/employee/get",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (result) {
        
        let laki = [];
        let cewek = [];
        
        for(let i = 0; i < result.length; i++){
            let data = result[i].genderEmployee == "L";
            if(data == true){
                laki.push(result[i])
            } else{
                cewek.push(result[i])
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
        'url': "/smartphone/getall",
        'method': "GET",
        'contentType': 'application/json'
    }).done(function (result) {

        let nameSmartphone = [];
        let stockSmartphone = [];
        let arrayName = [];
        let arraySum = [];
        let arrayColor = [];
        let data = result;
        
        $(data).each(function(key,val){
            let same = val.supplierModel.nameSupplier;
            let colorRandom = Math.floor(Math.random() * 999) + 100;

            nameSmartphone.push(val.nameSmartphone);
            stockSmartphone.push(val.stockSmartphoen);
            arrayName.push(same);
            arrayColor.push('#4'+colorRandom+'df');
        }); 

        let d = arrayName.filter(onlyUnique);
        for(let i = 0; i < d.length; i++){
            let filterCat = arrayName.filter(x => x == d[i]);
            arraySum.push(filterCat.length);
        }

        console.log(arrayColor);

        // add chart bar vertical
        var ctx = document.getElementById("myAreaChart");
        var myBarChart = new Chart(ctx, {
        type: 'bar',
        data: {
            labels: arrayName.filter(onlyUnique),
            datasets: [{
            label: "Smartphone ",
            backgroundColor: arrayColor,
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
       
        // Add chart horizontal
        var ctx = document.getElementById("stockSmartphone");
        var myPieChart = new Chart(ctx, {
        type: 'horizontalBar',
        data: {
            labels: nameSmartphone,
            datasets: [{
              label: "Stock Smartphone ",
              data: stockSmartphone,
              backgroundColor: arrayColor,
              hoverBackgroundColor: arrayColor,
              hoverBorderColor: arrayColor,
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
              }
            }],
            yAxes: [{
              ticks: {
                min: 0,
                padding: 10,
              },
              gridLines: {
                color: "rgb(234, 236, 244)",
                zeroLineColor: "rgb(234, 236, 244)",
                drawBorder: false
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
          responsive: true,
          plugins: {
            legend: {
              position: 'right',
            },
            title: {
              display: true,
              text: 'Chart.js Horizontal Bar Chart'
            }
          }
        }
        });
        
    });

});