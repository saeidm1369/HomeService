$(document).ready(function () {
    // Smooth scrolling for anchor links
    $("a[href^='#']").on('click', function (event) {
        event.preventDefault();

        $('html, body').animate({
            scrollTop: $($.attr(this, 'href')).offset().top
        }, 500);
    });

    // Add other custom scripts here
});
