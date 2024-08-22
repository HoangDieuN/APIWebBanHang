$(function () {

    $('#modal button.close, #modal .nv-modal-close').on('click', function () {
        $.fn.closeMainModal();
    });

    $('#sub-modal button.close, #sub-modal .nv-modal-close').on('click', function () {
        $.fn.closeSubModal();
    });

    $('#modal-file button.close, #modal-file .nv-modal-close').on('click', function () {
        $.fn.closeFileModal();
    });

    $('#modal-pvfile button.close, #modal-pvfile .nv-modal-close').on('click', function () {
        $.fn.closePreviewFileModal();
    });

    $('.modal .reload').on('click', function () {
        $.fn.reloadModal($(this));
    });
})