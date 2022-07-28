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
                  type: "POST",
                  url: "https://localhost:42573/api/Account/Login",
                  data: payLoad,
                  dataType: "json",
                  success: function(result) {
                      localStorage.setItem('Token', result.token);
                      sessionStorage.setItem('key', result.token);
                      console.log(localStorage.getItem('Token'));
                      console.log(sessionStorage.getItem('key'));
                      window.location = "https://localhost:5001/Smartphone/Index";
                    },
                  error: function(errormessage) {
                    console.log(errormessage)

                    let message = errormessage.responseJSON.message;

                    $("#messageError").html(message);
                  }
              });
            }
            form.classList.add('was-validated');
        }, false);
    });
})