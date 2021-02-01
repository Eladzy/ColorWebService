const colors = [];

$(document).ready(() => {
    $colorsTable = $("#colorsTable")
    $.ajax({
        url: "/api/inventory"
    })
        .then((result) => {
            $.each(result, (i, color) => {
                const aColor = new Color(color.Id, color.Name, color.HexCode, color.IsAvailable)
                $("#id_select").append(color.Id)
                colors.push(aColor)
                $colorsTable.append(
                    "<tr>" +
                    "<td>" + aColor.id + "</td>"
                    + "<td>" + aColor.name + "</td>"
                    + "<td>" + aColor.hexcode + "</td>"
                    + "<td>" + aColor.availability + "</td>"
                    + "<td>" + `<button type="button" class="delete_btn">Delete</button><button type="button" class="edit_btn">Edit</button>` + "</tr>"
                )
            })
        }).catch((err) => { console.log(err) })

})

$(document).on('click', 'edit_btn', function () {

})
$(document).on('click', '.delete_btn', function () {
    alert("deleting record...");
    var $row = $(this).closest("tr");
    $tds = $row.find("td:first").text();
    console.log($tds)

    $.ajax({
        url: "/api/delete/" + $tds,
        type: 'DELETE',

    }).then((result) => {

        $row.remove();
    })
})