$(document).ready(function () {

    // Validate Login
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
                }).done((result) => {
                    console.log(result);
                    if(result.status == 200){
                        Swal.fire({
                            icon: 'success',
                            title: 'login success',
                            showConfirmButton: false,
                            timer: 1000
                        }).then(function () {
                            // do success
                            // window.location = "/smartphone";
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

    //Validate Register
    var forms = document.getElementsByClassName('needs-validation-register');
    var validation = Array.prototype.filter.call(forms, function(form) {
        form.addEventListener('submit', function(event) {
            if (form.checkValidity() === false) {
            event.preventDefault();
            event.stopPropagation();
            } else{

                event.preventDefault();

                let obj = {}
                obj.nipEmployee = parseInt($("#nipEmployee").val());
                obj.nameEmployee = $("#nameEmployee").val();
                obj.genderEmployee = $("#genderEmployee").val();
                obj.ageEmployee = parseInt($("#ageEmployee").val());
                obj.statusEmployee = $("#statusEmployee").val();
                obj.email = $("#email").val();
                obj.username = $("#usernames").val();
                obj.password = $("#passwords").val();
                

                console.log(obj)

                $.ajax({
                    headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                    },
                    url: "/Account/Register",
                    type: "POST",
                    data: JSON.stringify(obj),
                    dataType: "json",
                    beforeSend: function (request) {
                        request.setRequestHeader("RequestVerificationToken", $("[name='__RequestVerificationToken']").val());
                    },
                }).done((result) => {
                    console.log(result);
                    if(result == 200){
                        Swal.fire({
                            icon: 'success',
                            title: 'Register success',
                            showConfirmButton: false,
                            timer: 1000
                        }).then(() => {
                            $("#registerModal").modal('hide');
                        })
                    }else if(result == 409){
                        Swal.fire({
                            icon: 'error',
                            title: 'Email is already registered !!',
                            text: 'Please use another email that is not registered in the system',
                        })
                    } else {
                        Swal.fire({
                            icon: 'error',
                            title: 'Register Invalid',
                            text: 'Plis check your input type and length',
                        })
                    }
                });

            }
            form.classList.add('was-validated');
        }, false);
    });
    
});