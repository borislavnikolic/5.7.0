var idDelete;

function deletePackage(id) {

    idDelete = id;

    $("#modal").modal({
        backdrop: 'static'
    })
    $("#modal").modal('show');
}

function confirm() {
    $.ajax({
        type: "DELETE",
        url: "/Package/Delete/" + idDelete,
       
        success: function (response) {
            if (response.success === 1) {
                $("#" + idDelete).remove();
                $("#modal").modal('hide');
            }
            else {
                $("#modal").modal('hide');
                $("#errorModal").modal({
                    backdrop: 'static'
                })
                $("#errorModal").modal('show');
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
/*(function ($) {

  

})(jQuery);*/