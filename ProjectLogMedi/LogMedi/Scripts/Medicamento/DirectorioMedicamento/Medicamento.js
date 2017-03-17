$('#NavGeneral').addClass('active');
$('#navMedicamentos').addClass('active');
$('#DMedicamentos').addClass('active');
$('#DMedicamento').addClass('active');

$(document).ready(function () {
    $('#tblDirectorioMedicamentos').DataTable({

    });
});

$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/DirectorioMedicamentos/Create");
});

$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/DirectorioMedicamentos/Edit/" + $(this).data("id"));
})
