// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function formatRupiah(money) {
    return new Intl.NumberFormat('id-ID',
      { style: 'currency', currency: 'IDR', minimumFractionDigits: 0 }
    ).format(money);
}

// Function for Delete Smartphone
function deleteSmartphone(idSmartphone) {
    // GET DETAIL SMARTPHONE
    $.ajax({
        url: "/smartphone/get/"+idSmartphone,
        method: "GET",
    }).done((result) => {
        // Using Swal for delete
        Swal.fire({
            title: 'Are you sure?',
            text: "You want to delete the data " + result.nameSmartphone,
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
          }).then((result) => {
            if (result.isConfirmed) {
                // action delete
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "/smartphone/delete/"+idSmartphone,
                    type: "DELETE",
                    dataType: "json",
                    success: function(){
                        $("#smartphone").DataTable().ajax.reload();
                        Swal.fire(
                            'Deleted!',
                            'Your data has been deleted.',
                            'success'
                          )
                    },
                    error: function (errormessage) {
                        console.log(errormessage)
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Error Code '+errormessage.responseJSON.status +' With '+ errormessage.responseJSON.title
                        })    
                    }
                });
            }
        });
    }).fail(() => {
        Swal.fire({
            title : '401',
            text : 'Unauthorized',
            icon : 'error'
        })
    });
}

// Function for Edit Smartphone
function editSmartphone(idSmartphone){

    let arraySup;

    $.ajax({
        url: "/Smartphone/get/"+idSmartphone,
        method: "GET",
    }).done((result) => {
        let val = result;
        console.log(result);
        arraySup = val.idSupplier;
        let text = `
            <input type="text" class="form-control" id="idSmartphone" name="idSmartphone" placeholder="Name Smartphone" value="${val.idSmartphone}" required hidden disabled>
            <div class="form-group">
                <div class="col mb-3">
                        <label for="idSupplier">Select Supplier</label>
                        <select class="form-control" id="idSuppliers" required>
                        
                        </select>
                    <div class="invalid-feedback">
                        Supplier is required
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col mb-3">
                        <label for="nameSmartphone">Name Smartphone</label>
                        <input type="text" class="form-control" id="nameSmartphones" name="nameSmartphone" placeholder="Name Smartphone" value="${val.nameSmartphone}" required>
                    <div class="invalid-feedback">
                        Name smartphone is required
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row p-2">
                    <div class="col-6 mb-3">
                        <label for="priceSmartphone">Price Smartphone</label>
                        <input type="text" class="form-control" id="priceSmartphones" name="priceSmartphone" placeholder="Price Smartphone" value="${val.priceSmartphone}" pattern="[0-9]+" required>
                        <div class="invalid-feedback">
                                Price smartphone contain numbers
                                <br>
                                Price smartphone is required
                        </div>
                    </div>
                        <div class="col-6 mb-3">
                            <label for="stockSmartphoen">Stock Smartphone</label>
                            <input type="text" class="form-control" id="stockSmartphoens" name="stockSmartphoen" placeholder="Stock Smartphone" value="${val.stockSmartphoen}" pattern="[0-9]+" required>
                        <div class="invalid-feedback">
                            Stock smartphone must contain numbers
                            <br>
                            Stock smartphone is rquired
                        </div>
                    </div>
                </div>
            </div>
        `;

        $("#textEdit").html(text);

        // GET SUPPLIER
        $.ajax({
            url: "/supplier/get",
            method: "GET",
        }).done((result) => {
            let text = '<option value="">Pilih Supplier</option>';
            $.each(result, function (key, isi){
                text += '<option value="'+isi.idSupplier+'">'+isi.nameSupplier+'</option>'
            });

            $("#idSuppliers").html(text);

            //ADD SELECTED ON SELECT OPTION
            for (var option of document.getElementById("idSuppliers").options)
            {
                if (option.value == arraySup)
                {
                    option.selected = true;
                    return;
                }
            }
        });
    }).fail(() => {
        Swal.fire({
            title : '401',
            text : 'Unauthorized',
            icon : 'error'
        }).then(() => {
            $('#modaleditSmartphone').modal('hide');
        });
    });
    
}

$(document).ready(function () {

    // VALIDATE EDIT DATA
    var forms = document.getElementsByClassName('needs-validation-edit');
    var validation = Array.prototype.filter.call(forms, function(form) {
        form.addEventListener('submit', function(event) {
            if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            } else{

                event.preventDefault();
                
                let obj = {};
                obj.idSmartphone = parseInt($("#idSmartphone").val());
                obj.idSupplier = parseInt($("#idSuppliers").val());
                obj.nameSmartphone = $("#nameSmartphones").val();
                obj.priceSmartphone = parseInt($("#priceSmartphones").val());
                obj.stockSmartphoen = parseInt($("#stockSmartphoens").val());

                console.log(obj);

                // EDIT DATA
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "/Smartphone/edit",
                    type: "PUT",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    success: function(data){
                        $("#smartphone").DataTable().ajax.reload();
                        $('#modaleditSmartphone').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been edit'
                        })
                    },
                    error: function (errormessage) {
                        console.log(errormessage)
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'Error Code '+errormessage.responseJSON.status +' With '+ errormessage.responseJSON.title
                        })
                    }
                });
            }
            form.classList.add('was-validated');
        }, false);
    });

    // Add validation error 401
    $("#addSmartphones").on('click', () => {

        $("#addSmartphone").modal('show');

        // GET SUPPLIER
        $.ajax({
            url: "/Supplier/get",
            method: "GET",
        }).done((result) => {
            let text = '<option value="">Pilih Supplier</option>';
            $.each(result, function (key, val){
                text += '<option value="'+val.idSupplier+'">'+val.nameSupplier+'</option>'
            });
            
            $("#idSupplier").html(text);

            // VALIDATE ADD SMARTPHONE 
            var forms = document.getElementsByClassName('needs-validation');
            var validation = Array.prototype.filter.call(forms, function(form) {
                form.addEventListener('submit', function(event) {
                    if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                    } else{

                        event.preventDefault();

                        let obj = {};
                        obj.idSupplier = parseInt($("#idSupplier").val());
                        obj.nameSmartphone = $("#nameSmartphone").val();
                        obj.priceSmartphone = parseInt($("#priceSmartphone").val());
                        obj.stockSmartphoen = parseInt($("#stockSmartphoen").val());

                        console.log(obj);

                        // ADD DATA SMARTPHONE
                        $.ajax({
                            headers: { 
                                'Accept': 'application/json',
                                'Content-Type': 'application/json' 
                            },
                            url: "/Smartphone/add",
                            type: "POST",
                            dataType: "json",
                            data: JSON.stringify(obj),
                            beforeSend: function (data) {
                                data.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                            },
                            success: function(data){
                                $("#smartphone").DataTable().ajax.reload();
                                $('#addSmartphone').modal('hide');
                                Swal.fire({
                                    icon: 'success',
                                    text: 'Data has been saved'
                                }).then((result) => {
                                    if (result.isConfirmed) {
                                        $("#idSupplier").val('');
                                        $("#nameSmartphone").val('');
                                        $("#priceSmartphone").val('');
                                        $("#stockSmartphoen").val('');
                                    }
                                });
                            },
                            error: function (errormessage) {
                                console.log(errormessage)
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Oops...',
                                    text: 'Error Code '+errormessage.responseJSON.status +' With '+ errormessage.responseJSON.title
                                })
                                
                            }
                        });
                    }
                    form.classList.add('was-validated');
                }, false);
            });

        }).fail(() => {
            Swal.fire({
                title : '401',
                text : 'Unauthorized',
                icon : 'error'
            }).then(() => {
                $('#addSmartphone').modal('hide');
            });
        });
    });

    // DATATABLE SMARTPHONE
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
            "url": "/smartphone/getall",
            "dataType": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                data: null,
                render: function (data, type, row, meta) {
                    return meta.row + 1;
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
                                <a onClick="editSmartphone('${row['idSmartphone']}')" href="#" class="btn btn-primary" data-toggle="modal" data-target="#modaleditSmartphone"><i class="fas fa-edit"></i></a>
                                <a onClick="deleteSmartphone('${row['idSmartphone']}')" href="#" class="btn btn-primary"><i class="fas fa-trash-alt"></i></a>
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