$(document).ready(function () {
    $('.user-info-block input').on('keyup', function () {
        let new_pass_exist = $('#new-pass-exist').val().length;
        let repeat_new_pass_exist = $('#repeat-new-pass-exist').val().length;

        let new_pass_exist_val = $('#new-pass-exist').val();
        let repeat_new_pass_exist_val = $('#repeat-new-pass-exist').val();

        let is_error_pass = false;

        if (new_pass_exist_val !== repeat_new_pass_exist_val) {
            $('.wrong-pass-info').css('display', 'block');
            is_error_pass = true;
        }
        else {
            $('.wrong-pass-info').css('display', 'none');
            is_error_pass = false;
        }

        if (new_pass_exist >= 10 && repeat_new_pass_exist >= 10 && !is_error_pass)
            $('.approve-info').attr('disabled', false);
        else
            $('.approve-info').attr('disabled', true);
    });

    $('.modal-body input').on('keyup', function () {
        let new_user = $('#new-user-name').val().length;
        let new_pass = $('#new-pass').val().length;
        let repeat_new_pass = $('#repeat-new-pass').val().length;

        let new_pass_val = $('#new-pass').val();
        let repeat_new_pass_val = $('#repeat-new-pass').val();

        let is_error_pass = false;

        if (new_pass_val !== repeat_new_pass_val) {
            $('.wrong-pass').css('display', 'block');
            is_error_pass = true;
        }
        else {
            $('.wrong-pass').css('display', 'none');
            is_error_pass = false;
        }

        if (new_user > 0 && new_pass >= 10 && repeat_new_pass >= 10 && !is_error_pass)
            $('.approve').attr('disabled', false);
        else $('.approve').attr('disabled', true);
    });

    $('#user-info-modal').on('hidden.bs.modal', function () {
        $('#old-pass-exist').val('');
        $('#new-pass-exist').val('');
        $('#repeat-new-pass-exist').val('');
        $('.wrong-pass-info').css('display', 'none');
        $('.approve-info').attr('disabled', true);
    });

    $('#new-user-modal').on('hidden.bs.modal', function () {
        $('#new-user-name').val('');
        $('#new-pass').val('');
        $('#repeat-new-pass').val('');
        $('.wrong-pass').css('display', 'none');
        $('.approve').attr('disabled', true);
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

function readUser(username) {
    $.ajax({
        type: "GET",
        url: "/Users/ReadUser",
        data: { name: username },
        success: function (data) {
            const obj = JSON.parse(data);

            console.log(obj.Name);
            console.log(obj.Role);
        },
        error: function (data) {
            alert("An error occured while processing the request. Please, try again later.");
        }
    });
}

function updateUser(username, user_role) {
    let old_pass_val = $('#old-pass-exist').val();
    let new_pass_val = $('#new-pass-exist').val();
    $.ajax({
        type: "PUT",
        url: "/Users/UpdateUser",
        data: {
            name: username,
            old_pass: old_pass_val,
            new_pass: new_pass_val,
            role: user_role
        },
        success: function (data) {
        },
        error: function (data) {
            alert("An error occured while processing the request. Please, try again later.");
        }
    });
}

function deleteUser(username) {
    $.ajax({
        type: "DELETE",
        url: "/Users/DeleteUser",
        data: { name: username },
        success: function (data) {
        },
        error: function (data) {
            alert("An error occured while processing the request. Please, try again later.");
        }
    });
}