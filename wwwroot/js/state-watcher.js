function update() {
	$.ajax({
		type: "GET",
		url: "/StateWatcher/CheckState",
		success: function (data) {
			$("h2").text(data);
		},
		error: function (data) {
			console.error(data);
		}
	});
}

let func = setInterval(update, 500);