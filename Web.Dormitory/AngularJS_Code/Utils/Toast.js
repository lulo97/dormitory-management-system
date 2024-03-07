var Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 1000
});

function showToast(icon, title, text) {
    Toast.fire({
        icon: icon,
        title: title,
        text: text
    })
}
