﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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