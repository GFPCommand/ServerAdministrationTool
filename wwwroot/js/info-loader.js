function loadData(appName) {
    $.ajax({
        type: "GET",
        url: "/AppInformation/AppInfo",
        data: { objName: appName },
        success: function (data) {
            const obj = JSON.parse(data);

            $("#name").text(obj.Name);
            $("#path").text(obj.Path);
            $("#size").text(obj.Size);
            $("#version").text(obj.Version);
            $("#upload-date").text(obj.UploadDate);
            $("#last-update").text(obj.LastUpdate);
            $("#description").text(obj.Description);
            $("#link").text(obj.Link);
            $("#link").attr("href", obj.Link);
        },
        error: function (data) {
            console.error(data);
        }
    });
}