$(document).on("click", ".add_btn", function (e) {
    var data = [];
    data[0] = $("#add_color_name").val();
    data[1] = $("#add_hex_code").val();
    data[2] = $("#add_available").is(':checked');
    console.log(data);

    $.ajax({
        url: "api/addcolor",
        type: "POST",
        data: { "Name": data[0], "HexCode": data[1], "IsAvailable": data[2] },
        success: function () {
            $("#add_color_name").text() = "";
            $("#add_hex_code").text() = "";
            $("#add_available").attr('checked') = false;

        }
    })

})