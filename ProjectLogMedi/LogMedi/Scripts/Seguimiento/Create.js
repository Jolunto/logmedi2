$('#NavSeguimiento').addClass('active');
$('#liAtencion').addClass('active');


$("#btnEnfermedad").click(function (eve) {
    $("#modal-content").load("/Seguimiento/CreateEnfermedad/" + $(this).data("id"));
})
