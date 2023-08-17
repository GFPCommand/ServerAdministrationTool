$.ajax({
    url: "/StateWatcher/CheckState",
}).done(function (data) {
    $("#smth").text(data);
});