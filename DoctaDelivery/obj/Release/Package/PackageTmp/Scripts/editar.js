$(document).ready(function () {

    $('#btn_editar').click(function () {
        var nombre = $('#nombre');
        var apellido = $('#apellido');
        var documento = $('#documento');
        var fecha = $('#fecha_nac');
        var email = $('#e_mail');
        var telefono = $('#telefono');
        var zona = $('#zona');
        var barrio = $('#id_barrio');
        var calle = $('#calle_numero');
        var foto = $('#avatardiv');
        var btnEditar = $('#btn_editar');
        var btnGuardar = $('#btn_guardar');
        var divBtn = $('#divbtnEdit');
        nombre.removeAttr('disabled');
        apellido.removeAttr('disabled');
        documento.removeAttr('disabled');
        fecha.removeAttr('disabled');
        email.removeAttr('disabled');
        telefono.removeAttr('disabled');
        zona.removeAttr('disabled');
        barrio.removeAttr('disabled');
        calle.removeAttr('disabled');
        foto.removeAttr('hidden');
        btnGuardar.removeAttr('disabled');
        btnEditar.attr('disabled', 'true');
        divBtn.removeAttr('hidden');
        $('#btn_cancelar').click(function () {
            nombre.attr('disabled','true');
            apellido.attr('disabled','true');
            documento.attr('disabled','true');
            fecha.attr('disabled','true');
            email.attr('disabled','true');
            telefono.attr('disabled','true');
            zona.attr('disabled','true');
            barrio.attr('disabled','true');
            calle.attr('disabled', 'true');
            foto.attr('hidden','hidden');
            btnGuardar.attr('disabled','true');
            btnEditar.removeAttr('disabled');
            divBtn.attr('hidden','hidden');
 
        });
        
    });
});