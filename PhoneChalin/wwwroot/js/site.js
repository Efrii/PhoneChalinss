// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function formatRupiah(money) {
    return new Intl.NumberFormat('id-ID',
      { style: 'currency', currency: 'IDR', minimumFractionDigits: 0 }
    ).format(money);
}

function deleteSmartphone(idSmartphone) {
    
    // GET DETAIL SMARTPHONE
    $.ajax({
        url: "https://localhost:42573/api/Smartphone/"+idSmartphone,
        method: "GET",
    }).done((result) => {
        let val = result.data;
        let text = '<h4>Apakah anda yakin ingin menghapus data <strong>'+val.nameSmartphone+'</strong></h4>';
        
        $("#textDelete").html(text);

        console.log(result);
    })

    // DELETE DATA SMARTPHONE
    $("#deleteSmartphone").on("click", function(e){
        e.preventDefault();
        $.ajax({
            headers: { 
                'Accept': 'application/json',
                'Content-Type': 'application/json' 
            },
            url: "https://localhost:42573/api/Smartphone/"+idSmartphone,
            type: "DELETE",
            dataType: "json",
            success: function(){
                $("#smartphone").DataTable().ajax.reload();
                $('#deleteSmartphone').modal('hide');
                Swal.fire({
                    icon: 'success',
                    text: 'Data has been saved'
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
        e.stopPropagation();
    });

}

function editSmartphone(idSmartphone){

    let arraySup;

    $.ajax({
        url: "https://localhost:42573/api/Smartphone/"+idSmartphone,
        method: "GET",
    }).done((result) => {
        let val = result.data;
        arraySup = val.idSupplier;
        let text = `
            <input type="text" class="form-control" id="idSmartphone" name="idSmartphone" placeholder="Name Smartphone" value="${val.idSmartphone}" required>
            <div class="form-group">
                <div class="col mb-3">
                        <label for="idSupplier">Select Supplier</label>
                        <select class="form-control" id="idSuppliers" required>
                        </select>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col mb-3">
                        <label for="nameSmartphone">Name Smartphone</label>
                        <input type="text" class="form-control" id="nameSmartphones" name="nameSmartphone" placeholder="Name Smartphone" value="${val.nameSmartphone}" required>
                    <div class="valid-feedback">
                        Looks good!
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="row p-2">
                    <div class="col-6 mb-3">
                        <label for="priceSmartphone">Price Smartphone</label>
                        <input type="text" class="form-control" id="priceSmartphones" name="priceSmartphone" placeholder="Price Smartphone" value="${val.priceSmartphone}" required>
                        <div class="invalid-feedback">
                            Please provide a valid city.
                        </div>
                    </div>
                        <div class="col-6 mb-3">
                            <label for="stockSmartphoen">Stock Smartphone</label>
                            <input type="text" class="form-control" id="stockSmartphoens" name="stockSmartphoen" placeholder="Stock Smartphone" value="${val.stockSmartphoen}" required>
                        <div class="invalid-feedback">
                            Please provide a valid state.
                        </div>
                    </div>
                </div>
            </div>
        `;

        $("#textEdit").html(text);

        // GET SUPPLIER
        $.ajax({
            url: "https://localhost:42573/api/Supplier",
            method: "GET",
        }).done((result) => {
            let text = '';
            $.each(result.data, function (key, isi){
                text += '<option value="'+isi.idSupplier+'">'+isi.nameSupplier+'</option>'
            });

            $("#idSuppliers").html(text);

            //ADD SELECTED
            for (var option of document.getElementById("idSuppliers").options)
            {
                if (option.value == arraySup)
                {
                    option.selected = true;
                    return;
                }
            }
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
                obj.idSmartphone = $("#idSmartphone").val();
                obj.idSupplier = $("#idSuppliers").val();
                obj.nameSmartphone = $("#nameSmartphones").val();
                obj.priceSmartphone = $("#priceSmartphones").val();
                obj.stockSmartphoen = $("#stockSmartphoens").val();

                console.log(obj);

                // EDIT DATA
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "https://localhost:42573/api/Smartphone",
                    type: "PUT",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    success: function(data){
                        $("#smartphone").DataTable().ajax.reload();
                        $('#editSmartphone').modal('hide');
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

    // GET SUPPLIER
    $.ajax({
        url: "https://localhost:42573/api/Supplier",
        method: "GET",
    }).done((result) => {
        let text = '';
        $.each(result.data, function (key, val){
            text += '<option value="'+val.idSupplier+'">'+val.nameSupplier+'</option>'
        });
        $("#idSupplier").html(text);
    });

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
                obj.idSupplier = $("#idSupplier").val();
                obj.nameSmartphone = $("#nameSmartphone").val();
                obj.priceSmartphone = $("#priceSmartphone").val();
                obj.stockSmartphoen = $("#stockSmartphoen").val();

                console.log(obj);

                // ADD DATA SMARTPHONE
                $.ajax({
                    headers: { 
                        'Accept': 'application/json',
                        'Content-Type': 'application/json' 
                    },
                    url: "https://localhost:42573/api/Smartphone",
                    type: "POST",
                    dataType: "json",
                    data: JSON.stringify(obj),
                    success: function(data){
                        $("#smartphone").DataTable().ajax.reload();
                        $('#addSmartphone').modal('hide');
                        Swal.fire({
                            icon: 'success',
                            text: 'Data has been saved'
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
                                <a onClick="editSmartphone('${row['idSmartphone']}')" href="" class="btn btn-primary" data-toggle="modal" data-target="#editSmartphone"><i class="fas fa-edit"></i></a>
                                <a onClick="deleteSmartphone('${row['idSmartphone']}')" href="" class="btn btn-primary" data-toggle="modal" data-target="#deleteSmartphone"><i class="fas fa-trash-alt"></i></a>
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