$(document).on("click", ".edit_btn", function (e) {

    var data = [];
    data[0] = $("#id_select").val();
    data[1] = $("#edit_color_name").val();
    data[2] = $("#edit_hex_code").val();
    data[3] = $("#edit_available").is(':checked');
    console.log(data);
    setTimeout(23232)

    $.ajax({
        url: "api/updatecolor",
        type: "PUT",
        data: { "Id": data[0], "Name": data[1], "HexCode": data[2], "IsAvailable": data[3] },
        success: function () {
            $("#edit_color_name").text() = "";
            $("#edit_hex_code").text() = "";
            $("#edit_available").attr('checked') = false;

        }
    })

})