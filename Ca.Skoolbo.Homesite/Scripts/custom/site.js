$(document).ready(function () {
    var navbarTop = $(".navbar-top");
    if (navbarTop.length > 0) {
        var classActive = "active";
        var pathname = window.location.pathname;
        var navbarItem = $(".navbar-top").find("li");
        var countNavbarItem = navbarItem.length;
        if (countNavbarItem > 0) {

            navbarItem.removeClass(classActive);
            for (var i = 0; i < countNavbarItem; i++) {
                var item = $(navbarItem[i]);
                if (item.length > 0) {
                    var tagA = item.find("a");
                    if (tagA.length > 0) {
                        var href = tagA.attr("href");
                        if (href === pathname) {
                            item.addClass(classActive);
                            break;
                        }
                    }
                }
            }
        }
    }
});