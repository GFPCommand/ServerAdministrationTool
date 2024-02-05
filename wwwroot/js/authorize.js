function auth() {
    $.ajax({
        type: "POST",
        url: "/Auth/Authorization",
        data: {},
        error: function (data) {

        }
    });
}