document.addEventListener('DOMContentLoaded', function () {
    var year = document.getElementById('footerYear');
    if (year) {
        year.textContent = new Date().getFullYear();
    }
});
