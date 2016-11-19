$(document).ready(function () {

    $('#btn_editarNegocio').click(function () {
        var nombre = $('#nombre');
        var horarioAper = $('#horario_apertura');
        var horarioCier = $('#horario_cierre');
        var telefono = $('#telefono');
        var zona = $('#zona');
        var barrio = $('#id_barrio');
        var tipo = $('#id_tipo_negocio');
        var calle = $('#calle_numero');
        var foto = $('#avatardivNegocio');
        var btnEditar = $('#btn_editarNegocio');
        var btnGuardar = $('#btn_guardarNegocio');
        var divBtn = $('#divbtnEditNegocio');
        nombre.removeAttr('disabled');
        horarioAper.removeAttr('disabled');
        horarioCier.removeAttr('disabled');
        telefono.removeAttr('disabled');
        zona.removeAttr('disabled');
        barrio.removeAttr('disabled');
        tipo.removeAttr('disabled');
        calle.removeAttr('disabled');
        foto.removeAttr('hidden');
        btnGuardar.removeAttr('disabled');
        btnEditar.attr('disabled', 'true');
        divBtn.removeAttr('hidden');
        $('#btn_cancelarNegocio').click(function () {
            nombre.attr('disabled', 'true');
            horarioAper.attr('disabled', 'true');
            horarioCier.attr('disabled', 'true');
            telefono.attr('disabled', 'true');
            zona.attr('disabled', 'true');
            barrio.attr('disabled', 'true');
            tipo.attr('disabled', 'true');
            calle.attr('disabled', 'true');
            foto.attr('hidden', 'hidden');
            btnGuardar.attr('disabled', 'true');
            btnEditar.removeAttr('disabled');
            divBtn.attr('hidden', 'hidden');

        });

    });
});