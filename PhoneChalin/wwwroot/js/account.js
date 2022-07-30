$(document).ready(function () {

    var forms = document.getElementsByClassName('needs-validation');
    var validation = Array.prototype.filter.call(forms, function(form) {
        form.addEventListener('submit', function(event) {
            if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            } else{

                event.preventDefault();

                let payLoad = JSON.stringify({
                username: $("#username").val(),
                password: $("#password").val()
                });

                console.log(payLoad)

                $.ajax({
                    headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                    },
                    url: "/Account/Auth",
                    type: "POST",
                    data: payLoad,
                    dataType: "json",
                    beforeSend: function (request) {
                        request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                    },
                    // beforeSend: function(){
                    //   let loading = `
                    //     <div class="spinner-border" role="status">
                    //       <span class="sr-only">Loading...</span>
                    //     </div>
                    //   `;
                    //   $("#messageError").html(loading);
                    // },
                }).done((result) => {
                    console.log(result);
                    if(result.status == 200){
                        Swal.fire({
                            icon: 'success',
                            title: 'login success',
                            showConfirmButton: false,
                            timer: 1000
                        }).then(function () {
                            window.location = "/smartphone";
                        });
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Login Gagal',
                            text: 'Username or Password is invalid',
                        })
                    }
                });
            }
            form.classList.add('was-validated');
        }, false);
    });
    
});