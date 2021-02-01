const colors = [];

$(document).ready(() => {
    $colorsTable = $("#colorsTable")//fetch inventory data
    $.ajax({
        url: "/api/inventory"
    })
        .then((result) => {
            $.each(result, (i, color) => {
                const aColor = new Color(color.Id, color.Name, color.HexCode, color.IsAvailable)
                $("#id_select").append(new Option(color.Id, color.Id));//pupolates the edit select box with ids
                colors.push(aColor)
                $colorsTable.append(//populates table
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


$(document).on('click', '.delete_btn', function () {
    alert("deleting record...");
    var $row = $(this).closest("tr");//locates the row that delete button was called from
    $tds = $row.find("td:first").text();//locates the first table data from row
    console.log($tds)

    $.ajax({
        url: "/api/delete/" + $tds,//sends color id for delete method in tje controller
        type: 'DELETE',

    }).then((result) => {

        $row.remove();//removes the row if success
    }).catch((err) => { console.log(err) })
})