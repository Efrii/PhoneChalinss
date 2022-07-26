// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function() {
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

        // console.log(laki.length); 
        // console.log(cewek.length); 
    });
});

$(document).ready(function() {

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
            // console.log(same.nameSupplier);
            if (same) {
                console.log(key);
                arrayName.push(same);
            }

        });

        const duplicates = dict =>
                Object.keys(dict).filter((a) => dict[a] > 1)

            const count = arraySup =>
                arraySup.reduce((a, b) => ({...a,
                    [b] : (a[b] || 0 ) + 1
                }), {})
                
            var efri = count(arrayName);
            console.log(count(arrayName));
            console.log(arrayName.filter(onlyUnique));
            
            // Bar Chart Example
var ctx = document.getElementById("myBarChart");
var myBarChart = new Chart(ctx, {
  type: 'bar',
  data: {
    labels: arrayName.filter(onlyUnique),
    datasets: [{
      label: "Revenue",
      backgroundColor: "#4e73df",
      hoverBackgroundColor: "#2e59d9",
      borderColor: "#4e73df",
      data: [4215, 5312, 6251, 7841, 9821, 14984],
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
        time: {
          unit: 'month'
        },
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
          max: 15000,
          maxTicksLimit: 5,
          padding: 10,
          // Include a dollar sign in the ticks
          callback: function(value, index, values) {
            return '$' + number_format(value);
          }
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
      titleMarginBottom: 10,
      titleFontColor: '#6e707e',
      titleFontSize: 14,
      backgroundColor: "rgb(255,255,255)",
      bodyFontColor: "#858796",
      borderColor: '#dddfeb',
      borderWidth: 1,
      xPadding: 15,
      yPadding: 15,
      displayColors: false,
      caretPadding: 10,
      callbacks: {
        label: function(tooltipItem, chart) {
          var datasetLabel = chart.datasets[tooltipItem.datasetIndex].label || '';
          return datasetLabel + ': $' + number_format(tooltipItem.yLabel);
        }
      }
    },
  }
});
    });
});

function formatRupiah(money) {
    return new Intl.NumberFormat('id-ID',
      { style: 'currency', currency: 'IDR', minimumFractionDigits: 0 }
    ).format(money);
}

$(document).ready(function () {
    $("#smartphone").DataTable({
        "processing": true,
        "serverside": true,
        "responsive": true,
        "dom": '<"row"B><"row mt-3"lf>t<"row"ip><"clear">',
        "buttons": {
            "buttons": [
                { 
                    extend: 'copyHtml5', 
                    text: '<i class="fas fa-copy"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Copy',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'excelHtml5', 
                    text: '<i class="fas fa-file-excel"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Excel',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'csvHtml5', 
                    text: '<i class="fas fa-file-csv"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Csv',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'pdfHtml5', 
                    text: '<i class="fas fa-file-pdf"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Pdf',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                { 
                    extend: 'print', 
                    text: '<i class="fas fa-print"></i>',
                    className: 'btn btn-primary',
                    titleAttr: 'Print',
                    exportOptions: {
                        columns: ':visible'
                    }
                },
                {
                    extend: 'colvis',
                    text: 'Colvis ',
                    className: 'btn btn-primary dropdown-toggledropdown-toggle',
                    titleAttr: 'Colvis'
                }
            ],
            "dom": {
                "button": {
                    className: 'btn'
                }
            }
        },
        "ajax": {
            "url": "https://localhost:42573/api/Smartphone/Getall",
            "dataType": "json",
            "dataSrc": "data"
        },
        "columns": [
            {
                data: null,
                render: function (data, type, row, meta) {
                 return meta.row + meta.settings._iDisplayStart + 1;
                }  
            },
            {
                data: "nameSmartphone",
            },
            {
                data: "supplierModel.nameSupplier"
            },
            {
                data: null,
                render: function (data, type, row) {
                    return formatRupiah(row['priceSmartphone'])
                }
            },
            {
                data: "stockSmartphoen"
            },
            {
                data: null,
                render: function (data, type, row) {
                    return `<div class="text-center">
                                <a class="btn btn-primary" href="https://localhost:5001/Smartphone/edit/`+ row['idSmartphone'] +`"><i class="fas fa-edit"></i></a>
                                <a class="btn btn-primary" href="https://localhost:5001/Smartphone/delete/`+ row['idSmartphone'] +`"><i class="fas fa-trash-alt"></i></a>
                            </div>`
                }
            }
        ], 
        "columnDefs": [
            {
                "targets": [0,4],
                "className": 'text-center'
            },
            {
                "targets": 5,
                "orderable": false
            }
        ]
    });
    var paginate = document.getElementById("smartphone_paginate");
    paginate.classList.add("col");

    var info = document.getElementById("smartphone_info");
    info.classList.add("col");

    var lenght = document.getElementById("smartphone_length");
    lenght.classList.add("col");

    var filter = document.getElementById("smartphone_filter");
    filter.classList.add("col");
});