$(document).ready(function () {
    var c = 0;
    $('#1').click(function () {
        var a = $('img[name=1]').attr('src');
        var b = a.split('/');
        var fs = $('input[name=fotosSacar]').val('-' + b[2]);
        $('#1').attr('disabled', 'disabled');
        $('span[name=1]').removeClass('hidden');
        $('a[name=1]').removeClass('hidden');
        $('a[name=1]').click(function () {
            $('a[name=1]').addClass('hidden');
            $('span[name=1]').addClass('hidden');
            $('#1').removeAttr('disabled');
            var fs = $('input[name=fotosSacar]').removeAttr('value', '-' + b[2]);
        });

    });

    $('#2').click(function () {
        var a = $('img[name=2]').attr('src');
        var b = a.split('/');
        var fs = $('input[name=fotosSacar]').val('-' + b[2]);
        $('#2').attr('disabled', 'disabled');
        $('span[name=2]').removeClass('hidden');
        $('a[name=2]').removeClass('hidden');
        $('a[name=2]').click(function () {
            $('a[name=2]').addClass('hidden');
            $('span[name=2]').addClass('hidden');
            $('#2').removeAttr('disabled');
            var fs = $('input[name=fotosSacar]').removeAttr('value', '-' + b[2]);
        });

    });

    $('#3').click(function () {
        var a = $('img[name=3]').attr('src');
        var b = a.split('/');
        var fs = $('input[name=fotosSacar]').val('-' + b[2]);
        $('#3').attr('disabled', 'disabled');
        $('span[name=3]').removeClass('hidden');
        $('a[name=3]').removeClass('hidden');
        $('a[name=3]').click(function () {
            $('a[name=3]').addClass('hidden');
            $('span[name=3]').addClass('hidden');
            $('#3').removeAttr('disabled');
            var fs = $('input[name=fotosSacar]').removeAttr('value', '-' + b[2]);
        });
    });

    $('#AgregarFoto').click(function () {
        c++;
        $('#SacarFoto').removeClass('hidden');
        if (c < 3) {
            var b = $('div[name=fotoedit]').clone(true);
            b.attr('name', 'fotoedit'+c);
            b.insertAfter('div[name=fotoedit]');
        }
        else {
            $('#AgregarFoto').attr('disabled', 'disabled'); 
        }
        $('#SacarFoto').click(function () {
            c--;
            $('div[name=fotoedit'+c']').remove();
        });
    });
});