$(document).ready(function () {
    $("#btn_submit").click(function (e) {
        e.preventDefault();
        var data = [];
        data[0] = $("#add_color_name").val();
        data[1] = $("#add_hex_code").val();
        data[2] = $("#add_available").is(':checked');
        console.log(data);
        $.post({
            url: "api/addcolor",
            type: "POST",
            // dataType: "application/json",
            data: { "Name": data[0], "HexCode": data[1], "IsAvailable": data[2] = false },
            success: onSuccess(),
            error: function (res, status) {
                console.log("error");
            }

        })
    })
})
function onSuccess(res) {
    location.reload();
}
// $(document).on("click", ".add_btn", function (e) {

//     var data = [];
//     data[0] = $("#add_color_name").val();
//     data[1] = $("#add_hex_code").val();
//     data[2] = $("#add_available").is(':checked');
//     console.log(data);
//     //  submit({ "Name": data[0], "HexCode": data[1], "IsAvailable": data[2] = false });
//     $.ajax({
//         url: "api/addcolor",
//         type: "POST",
//         dataType: "application/json",
//         data: { "Name": data[0], "HexCode": data[1], "IsAvailable": data[2] = false },
//         success: function () {
//             $("#add_color_name").text() = "";
//             $("#add_hex_code").text() = "";
//             $("#add_available").attr('checked') = false;

//         }
//     })

// })

// function submit(data) {
//     // $.ajax({
//     //     type: "POST",
//     //     url: "https://localhost:44385/api/AddColor",
//     //     data: JSON.stringify(data),
//     //     contentType: 'application/json; charset=utf-8'


//     //});
//     var settings = {
//         "url": "https://localhost:44385/api/addcolor",
//         "method": "POST",
//         "timeout": 0,
//         "headers": {
//             "Content-Type": "application/json"
//         },
//         "data": JSON.stringify({ "Name": "sads", "HexCode": "dsad", "IsAvailable": false }),
//     };

//     $.ajax(settings).done(function (response) {
//         console.log(response);
//     });
// }
// function addNewColor(e) {

//     var data = [];
//     data[0] = $("#add_color_name").val();
//     data[1] = $("#add_hex_code").val();
//     data[2] = $("#add_available").is(':checked');
//     console.log(data);
//     submit({ "Name": data[0], "HexCode": data[1], "IsAvailable": data[2] = false });
// }
