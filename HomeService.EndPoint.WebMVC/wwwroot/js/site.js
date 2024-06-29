// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


// فایل جاوااسکریپت برای اعمال کدهای مربوط به صفحات
document.addEventListener('DOMContentLoaded', function () {
    // کدهای جاوااسکریپت مورد نیاز را اینجا اضافه کنید

    // مثال: تایید حذف کامنت
    const deleteButtons = document.querySelectorAll('.btn-danger');
    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            if (!confirm('آیا مطمئن هستید که می‌خواهید این مورد را حذف کنید؟')) {
                event.preventDefault();
            }
        });
    });

    // تغییر وضعیت درخواست
    const statusButtons = document.querySelectorAll('.status-change');
    statusButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const requestId = button.getAttribute('data-request-id');
            const newStatusId = button.getAttribute('data-new-status-id');
            const url = `/Admin/ChangeRequestStatus?id=${requestId}&newStatusId=${newStatusId}`;
            window.location.href = url;
        });
    });
});