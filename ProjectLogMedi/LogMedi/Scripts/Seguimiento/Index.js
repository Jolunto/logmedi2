$('#NavSeguimiento').addClass('active');
$('#liAtencion').addClass('active');


$(document).ready(function () {
    $('#tblCitas').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Seguimiento/Prioritaria");
});
