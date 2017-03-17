$('#NavGeneral').addClass('active');
$('#navMedicamentos').addClass('active');
$('#Medicamentos').addClass('active');
$('#Medicamento').addClass('active');

$(document).ready(function () {
    $('#tblMedicamentos').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/Medicamento/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/Medicamento/Edit/" + $(this).data("id"));
})

