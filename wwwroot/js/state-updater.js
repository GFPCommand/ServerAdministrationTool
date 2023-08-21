function update() {
    $.ajax({
        type: "GET",
        url: "/StateWatcher/CheckState",
        success: function (data) {
            console.log(data);
        },
        error: function (data) {
            console.error(data);
        }
    });
}

var func = setInterval(update, 1);