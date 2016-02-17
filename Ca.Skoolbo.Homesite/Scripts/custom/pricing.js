$(document).ready(function () {


    $(".goto").click(function (e) {
        // Prevent a page reload when a link is pressed
        e.preventDefault();
        // Call the scroll function
        goToByScroll($(this).attr("id"));
    });
    expandableAndCollapsible();
});
function expandableAndCollapsible() {
    $(".table-licence").addClass("hidden");
    $("[class*=-icon-action]").click(function () {
        var plus = $(this).hasClass("plus-icon");
        var minus = $(this).hasClass("minus-icon");

        if (plus) {
            $(this).removeClass("plus-icon");
            $(this).addClass("minus-icon");
            $(this).closest(".row").find(".table-licence").removeClass("hidden").addClass("show");
        }

        if (minus) {
            $(this).removeClass("minus-icon");
            $(this).addClass("plus-icon");
            $(this).closest(".row").find(".table-licence").removeClass("show").addClass("hidden");
        }
    });
}
function myTrim(x) {
    return x.replace(/^\s+|\s+$/gm, '');
}
function goToByScroll(id) {
    console.info(id);
    id = id.replace("link", "");
    console.info(id);
    // Scroll
    $('html,body').animate({
        scrollTop: $("#" + id).offset().top
    }, 'slow');
}