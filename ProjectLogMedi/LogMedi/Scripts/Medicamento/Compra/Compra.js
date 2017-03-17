$('#NavGeneral').addClass('active');
$('#navMedicamentos').addClass('active');
$('#CMedicamentos').addClass('active');
$('#CMedicamento').addClass('active');

$(document).ready(function () {
    $('#tblMovimientos').DataTable({

    });
});

$(".btnDetalles").click(function (eve) {
    $("#modal-content").load("/Medicamento/DetailsMovimiento/" + $(this).data("id"));
})

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Medicamento/EditMovimiento/" + $(this).data("id"));
})