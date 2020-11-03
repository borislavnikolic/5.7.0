

var idDelete;

function deletePackage(id) {

    idDelete = id;
    //alert(id);
    $("#modal").modal({
        backdrop: 'static'
    })
    $("#modal").modal('show');
}

function confirm() {
    $.ajax({
        type: "DELETE",
        url: "/Concract/Delete/" + idDelete,

        success: function (response) {
            $("#" + idDelete).remove();
            $("#concract-" + idDelete).remove();
            let activeCount = $("#activeCount").text();
            $("#activeCount").text(parseInt(activeCount,10)-1);
            $("#modal").modal('hide');
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}