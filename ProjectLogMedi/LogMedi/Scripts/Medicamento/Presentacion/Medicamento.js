$('#NavGeneral').addClass('active');
$('#navMedicamentos').addClass('active');
$('#PMedicamentos').addClass('active');
$('#PMedicamento').addClass('active');

$(document).ready(function () {
    $('#tblPresentacion').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Presentacion/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Presentacion/Edit/" + $(this).data("id"));
})