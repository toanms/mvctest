$(document).ready(function () {
    var classActive = "active";
    var pathname = window.location.pathname;
    if (pathname === "/") {
        $(".navbar-top ul.navbar-nav li:first").addClass(classActive).find("a").addClass(classActive);
    } else {
        $.each($(".navbar-top ul.navbar-nav li a, footer ul.navbar-nav-footer li a"),
        function (i, e) {
            var $this = $(this);
            if ($this.attr("href").indexOf(pathname) !== -1) {
                $this.addClass(classActive).parent("li").addClass(classActive);
            }
        });
    }
});