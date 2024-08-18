$.fn.showAlert = (message, type) => {
    let alertDiv = document.createElement('div');
    alertDiv.role = 'alert';
    alertDiv.className = `alert alert-${type} bg-${type} text-light border-0 alert-dismissible fade show`;
    alertDiv.style.position = 'fixed';
    alertDiv.style.top = '70px';
    alertDiv.style.right = '-300px'; // Bắt đầu từ ngoài màn hình
    alertDiv.style.zIndex = '1050';
    alertDiv.style.width = 'auto';
    alertDiv.style.maxWidth = '300px';
    alertDiv.style.opacity = '0.6';
    alertDiv.style.transition = 'right 0.5s ease-in-out'; // Thêm hiệu ứng chuyển động

    switch (type) {
        case 'success':
            alertDiv.innerHTML = `
                ${message}
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
            `;
            break;
        case 'danger':
            alertDiv.innerHTML = `
                ${message}
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="alert" aria-label="Close"></button>
            `;
            break;
        case 'warning':
            alertDiv.innerHTML = `
                ${message}
                <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            `;
            break;
        default:
            console.error('Unknown alert type');
            return;
    }

    document.body.appendChild(alertDiv);

    // Di chuyển thông báo vào trong màn hình
    setTimeout(() => {
        alertDiv.style.right = '10px';
    }, 10); // Thời gian ngắn để đảm bảo hiệu ứng chuyển động

    // Tự động ẩn alert sau 2.5 giây
    setTimeout(() => {
        alertDiv.style.right = '-300px'; // Di chuyển ra ngoài màn hình
        setTimeout(() => {
            alertDiv.remove();
        }, 500); // Thời gian để hoàn thành hiệu ứng chuyển động
    }, 2500);
};
