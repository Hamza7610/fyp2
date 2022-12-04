window.onload = function () {
    CheckIfNoInput();
    CheckIfRegNoInput();
    checkPasswordMatch()
    CheckForgotIfNoInput();

    $('#id_card_number').val('');
    $('#txt_psw').val('');
    $('.login-show').addClass('show-log-panel');

    $('.forgetP').on('click', function () {

        if ($(this).attr('data-on') == 1) {
            $('#login').fadeIn();
            $('#register').fadeOut();
            $('#forgot').fadeOut();
        } else if ($(this).attr('data-on') == 2) {
            $('#register').fadeIn();
            $('#forgot').fadeOut();
            $('#login').fadeOut();
        } else if ($(this).attr('data-on') == 3) {
            $('#forgot').fadeIn();
            $('#register').fadeOut();
            $('#login').fadeOut();
        }
    });
    $("#txt_psw").on('keyup', RegisterPasswordValidation);

    $("#txt_psw").focusout(function () {

        $('.password_tooltip,.tooltip_text ').css("visibility", "hidden");
        $('.password_tooltip,.tooltip_text ').css("opacity", "0");
    });

    $.get('/api/plans/get').done(function (response) {
        $.each(response, function (index, plans) {

            $('.plans-select').append('<option value='+plans.id+' >'+plans.plans+'</option>');
        });
    });

}

function RegisterPasswordValidation() {
    $('.password_tooltip,.tooltip_text ').css("visibility", "visible");
    $('.password_tooltip,.tooltip_text ').css("opacity", "1");
    /*Array of rules and the information target*/
    var rules = [{
            Pattern: "[A-Z]",
            Target: "UpperCase"
        },
        {
            Pattern: "[a-z]",
            Target: "LowerCase"
        },
        {
            Pattern: "[0-9]",
            Target: "Numbers"
        },
        {
            Pattern: "[!@@#$%^&*]",
            Target: "Symbols"
        }
    ];

    //Just grab the password once
    var password = $(this).val();

    /*Length Check, add and remove class could be chained*/
    /*I've left them seperate here so you can see what is going on */
    /*Note the Ternary operators ? : to select the classes*/
    $("#Length").removeClass(password.length > 6 ? "glyphicon-remove" : "glyphicon-ok");
    $("#Length").addClass(password.length > 6 ? "glyphicon-ok" : "glyphicon-remove");

    /*Iterate our remaining rules. The logic is the same as for Length*/
    for (var i = 0; i < rules.length; i++) {

        $("#" + rules[i].Target).removeClass(new RegExp(rules[i].Pattern).test(password) ? "glyphicon-remove" : "glyphicon-ok");
        $("#" + rules[i].Target).addClass(new RegExp(rules[i].Pattern).test(password) ? "glyphicon-ok" : "glyphicon-remove");
    }

}

function checkPasswordMatch() {

    $('#newP, #rnewP').keyup(function () {


        if ($('#rnewP').val() != $('#newP').val()) {

            $('#btn_forget').attr('disabled', 'disabled');
            $('#rnewP').css("border", "1px solid #700");
        } else {
            $('#btn_forget').attr('disabled', false);
            $('#rnewP').css("border", "1px solid #32CD32");

        }
    });
}

function check() {
    if (!validateEmail($("#txt_email").val())) {
        // alert("email should be in correct format");
        return false;
    }
    // if ($("#txt_psw").val() != $("#txt_psw-repeat").val()) {
    //     alert("password should be same");
    //     return false;
    // }
    return true;
}

function validateEmail($email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    return emailReg.test($email);
}

function CheckIfNoInput() {

    $('#login-form').submit(function (e) {

        if ($('#idad_email').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Email',
            });
            return false;
        }
        if (!validateEmail($("#idad_email").val())) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter Valid Email',
            });
            return false;
        }
        if ($('#idad_password ').val().trim() == '') {
            e.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Password',
            });
            //message here future if any
            return false;
        }
        if ($('#idad_password ').val().trim().length < 5) {
            e.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Minimum 5 character password requird',
            });
            //message here future if any
            return false;
        }

        if ($('#idad_password ').val().trim().length > 10) {
            e.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Max 10 character password allowed',
            });
            //message here future if any
            return false;
        }
        return true;
    });
}

function CheckForgotIfNoInput() {

    $('#forgot-password-form').submit(function (e) {

        if ($('#idad_femail').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Account Email',
            });
            return false;
        }

        if (!validateEmail($("#idad_femail").val())) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter Valid Email',
            });
            return false;
        }
        return true;
    });

}

function CheckIfRegNoInput() {
    $('#register-form').submit(function (e) {
        var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
        if ($('#name ').val().trim() == '') {
            e.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Name',
            });
            //message here future if any
            return false;
        }
        if ($('#txt_email').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Email',
            });
            return false;
        }

        if (!($('#txt_email').val().trim()).match(reg)) {
            // e.preventDefault();
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please Enter Correct Email Format',
            });
            //message here future if any
            return false;
        }

        if ($('#id_card_number').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your 13 Digits CNIC no#',
            });
            return false;
        }

        if ($('#id_card_number').val().trim().length < 13 || isNaN($('#id_card_number').val().trim())) {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'CNIC Must be 13 Digits ',
            });
            return false;
        }
        if ($('#id_card_number').val().trim().length > 13 || isNaN($('#id_card_number').val().trim())) {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'CNIC no longer than 13 Digits ',
            });
            return false;
        }
        if ($('#txt_psw').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Password',
            });
            return false;
        }


        if ($('#psw-repeat').val().trim() == '') {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please enter your Password',
            });
            return false;
        }
        if ($('#psw-repeat').val() != $('#txt_psw').val()) {
            e.preventDefault();

            //message here future if any
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Password and Reapeat password should be same',
            });
            return false;
        }
        return true;
    });

}

//Check password match or not
function checkPasswordMatch() {

    $('#txt_psw, #psw-repeat').keyup(function () {

        if ($('#psw-repeat').val() != $('#txt_psw').val()) {

            $('#register-button').attr('disabled', 'disabled');
            $('#psw-repeat').css("border", "1px solid #700");
        } else {
            $('#register-button').attr('disabled', false);
            $('#psw-repeat').css("border", "1px solid #32CD32");

        }
    });
}

// IS number event
function isNumber(e) {
    e = e || window.event;
    var charCode = e.which ? e.which : e.keyCode;
    return /\d/.test(String.fromCharCode(charCode));
}
