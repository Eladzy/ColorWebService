$(document).ready(function () {
    $("#btn_edit").click(function (e) {
        e.preventDefault();
        var data = [];
        data[0] = $("#id_select").val();
        data[1] = $("#edit_color_name").val();
        data[2] = $("#edit_hex_code").val();
        data[3] = $("#edit_available").is(':checked');

        $.ajax({
            url: "api/updatecolor",
            type: "PUT",
            data: { "Id": data[0], "Name": data[1], "HexCode": data[2], "IsAvailable": data[3] },
            success: function () {
                location.reload();

            }
        })

    })

})