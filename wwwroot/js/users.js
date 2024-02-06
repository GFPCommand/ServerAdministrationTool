$(document).ready(function () {
    $('.modal-body input').on('keyup', function () {
        let new_user = $('#new-user-name').val().length;
        let new_pass = $('#new-pass').val().length;
        let repeat_new_pass = $('#repeat-new-pass').val().length;

        let new_pass_val = $('#new-pass').val();
        let repeat_new_pass_val = $('#repeat-new-pass').val();

        let is_error_pass = false;

        if (new_pass_val !== repeat_new_pass_val) {
            $('#wrong-pass').css('display', 'block');
            is_error_pass = true;
        }
        else {
            $('#wrong-pass').css('display', 'none');
            is_error_pass = false;
        }

        if (new_user > 0 && new_pass >= 10 && repeat_new_pass >= 10 && !is_error_pass)
            $('#approve').attr('disabled', false);
        else $('#approve').attr('disabled', true);
    });

    $('#new-user-modal').on('hidden.bs.modal', function () {
        $('#new-user-name').val('');
        $('#new-pass').val('');
        $('#repeat-new-pass').val('');
        $('#wrong-pass').css('display', 'none');
        $('#approve').attr('disabled', true);
    });
});

function createUser() {
    let new_user_val = $('#new-user-name').val();
    let new_pass_val = $('#new-pass').val();
    let roles_list_val = $('#roles-list').val();

    $.ajax({
        type: "POST",
        url: "/Users/CreateUser",
        data: {
            new_user: new_user_val,
            new_pass: new_pass_val,
            role: roles_list_val
        },
        success: function (data) {
        },
        error: function (data) {
            alert("An error occured while processing the request. Please, try again later.");
        }
    });
}

function readUser() {
    $.ajax({
        type: "GET",
        url: "",
        data: {},
        success: function (data) {
            alert("Пользователь найден");
        },
        error: function (data) {
            alert("Во время обработки запроса произошла ошибка. Попробуйте повторить позже.");
            console.log(data);
        }
    });
}

function updateUser() {
    $.ajax({
        type: "UPDATE",
        url: "",
        data: {},
        success: function (data) {
            alert("Изменения были успешно внесены");
        },
        error: function (data) {
            alert("Во время обработки запроса произошла ошибка. Попробуйте повторить позже.");
            console.log(data);
        }
    });
}

function deleteUser() {
    $.ajax({
        type: "DELETE",
        url: "",
        data: {},
        success: function (data) {
            alert("Пользователь удален");
        },
        error: function (data) {
            alert("Во время обработки запроса произошла ошибка. Попробуйте повторить позже.");
            console.log(data);
        }
    });
}