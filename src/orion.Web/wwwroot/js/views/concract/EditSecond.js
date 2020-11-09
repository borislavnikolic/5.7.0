var allTable = [];
var choosenTable = [];

function removeElement(array, element) {
    for (let i = array.length - 1; i >= 0; i--) {
        if (array[i] === element) {
            array.splice(i, 1);
            break;
        }
    }
}

function add(id) {
    let original = document.getElementById(id);
    let row = original.cloneNode(true);

    original.remove();
    row.firstElementChild.innerHTML = "<a class= 'btn btn-danger' onclick='remove(" + id + ")'>-</a>";

    $("#choosenTable tbody").append(row);
}

function remove(id) {
    let original = document.getElementById(id);
    let row = original.cloneNode(true);

    original.remove();
    row.firstElementChild.innerHTML = "<a class='btn btn-info' onclick='add(" + id + ")'>+</a>";

    $("#allTable tbody").append(row);
}
function getIds() {

    let result = [];
    let SearchFieldsTable = $("#choosenTable tbody tr");

    $.each(SearchFieldsTable, function (index, row) {
        let id = $(row).attr("id");
        result.push(id);
    });

    return result;
}
function createConcract() {

    let ids = getIds();
    //alert(ids);

    $.ajax
        ({
            type: "POST",
            url: "/Concract/EditSecond",
            data: { packages: ids },
            traditional: true,
            //contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response.success == 0) {

                    $("#ErrorMessage").text(response.message);
                    $("#ErrorModal").modal({
                        backdrop: 'static'
                    })
                    $("#ErrorModal").modal('show');
                }
                else {
                    location.href = "/Concract/Index";
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
}
