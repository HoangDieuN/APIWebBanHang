const modalButton = {
    save: `<button type="button" class="btn btn-sm btn-outline-success waves-effect waves-light btn-save"><i class="ri-save-line align-bottom"></i> <span class="title-btn">Lưu</span></button>`
}

const showModal = ({elm, title, content, button, size}) => {
    let strHtml = `<div class="nv-modal-content">
        <div class="nv-modal-header">
            <h5 class="nv-modal-title">${title ?? "TIÊU ĐỀ"}</h5>
            <span class="nv-modal-close">
                <i class="ri-close-line"></i>
            </span>
        </div>
        <div class="nv-modal-body">
            ${content ?? ""}
        </div>
        <div class="nv-modal-footer">
            ${button ?? ""}
            <button type="button" class="btn btn-sm btn-outline-danger waves-effect waves-light close"><i class="ri-close-circle-line align-bottom"></i> Đóng</button>
        </div>
    </div>`;
    $(elm).html(strHtml);
    $(elm).prop("class", "nv-modal");
    if(size) {
        $(elm).addClass(size);
    }
    $(elm).fadeIn();
    //close event
    $(`${elm} button.close, ${elm} .nv-modal-close`).on('click', function () {
        closeModal(elm);
    });
}

const closeModal = (elm) => {
    $(elm).html("");
    $(elm).fadeOut();
}