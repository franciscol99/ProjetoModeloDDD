function Modal(opt = {}) {
    var idRandom = "Modal" + random(3);
    console.log("Modal criado - " + idRandom)

    $('#modalIndex').attr("data-id", idRandom)

    var $modal = $(".modal[data-id='" + idRandom + "']");

    if (opt.titulo)
        $('.modal-title').html(opt.titulo)

    if (!opt.footer)
        $('.modal-footer').hide()
    else
        $('.modal-footer').show()

    if (opt.data)
        $('.modal-body').html(opt.data);

    if (opt.options)
        $modal.modal(opt.options);

    $modal.show()

    $modal.on('hidden.bs.modal', function (e) {
        if (opt.hidden) {
            opt.hidden()
        }
        $('#modalIndex').removeAttr("data-id")
        $('.modal-title').html("")
        $('.modal-title').html("")
        $('.modal-body').html("")
    });
}

function EmailAleatorio() {
    var strValues = "abcdefghijklmnopqrstuvwxyz123456789";
    var strEmail = "";
    var strTmp;
    for (var i = 0; i < 10; i++) {
        strTmp = strValues.charAt(Math.round(strValues.length * Math.random()));
        strEmail = strEmail + strTmp;
    }
    strTmp = "";
    strEmail = strEmail + "@";
    for (var j = 0; j < 8; j++) {
        strTmp = strValues.charAt(Math.round(strValues.length * Math.random()));
        strEmail = strEmail + strTmp;
    }
    strEmail = strEmail + ".com"
    return strEmail;
}

function random(len, options = {}) {
    var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    var result = "",
        rand;
    for (var i = 0; i < len; i++) {
        rand = Math.floor(Math.random() * chars.length);
        result += chars.charAt(rand);
    }
    if (options.different && (options.different == result ||
        options.different.indexOf(result) !== -1))
        random(len, options)
    else if (options.different)
        result += '_' + options.add
    return result;
}

$(".fecharModal").click(function () {
    $('#modalIndex').modal('hide');
    $('.modal-body').html('');
});

$(document).on("keydown keyup", '.LimiteNumerico', function (e) {
    var max = $(this).attr("max");
    var min = $(this).attr("min");
    var valor = $(this).val();

    if (parseFloat(valor) >= parseFloat(max)) {
        $(this).val(max);
    }
    //if (parseFloat(valor) <= parseFloat(min)) {
    //    $(this).val(min);
    //}
  
}).on("keydown keyup", '.apenasNumbero', function (e) {
    var reg = /[a-z]/i;
    var val = String.fromCharCode(e.which) || e.key;
    if (reg.test(val)) {
        e.preventDefault();
        return false;
    }
})
