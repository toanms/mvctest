
var $elementTable = null;
function callTableScroll(para) {
    var scrollValue = {
        cursorcolor: "#006ab2",
        boxzoom: false,
        autohidemode: false,
        cursorwidth: "15px",
        cursorminheight: 100,
        cursorborderradius: "0",
        elementtable: ".table-scroll"
    };

    para = $.extend(scrollValue, para);

    var $elementTable = $(para.elementtable);

    if ($elementTable.length > 0) {
      

        $elementTable.niceScroll(para);
        var niceScroll = $elementTable.getNiceScroll()[0];
       

        niceScroll.onscrollend = function (data) {
            $('.lazy').lazy({
                bind: "event",
                onFinishedAll: function () { }
            });
        };
    }
}

function countDownFunc(element) {
    var $element = $(element);
    if ($element.length > 0) {
       
        $element.countdown(new Date($element.attr("data-endTime") + " UTC"), function (event) {

            var offset = event.offset;

            var stringFormat = "";

            if (offset.years > 0) {
                stringFormat = '<span> %-Y</span>year%!Y';
            }

            if (offset.daysToWeek > 0) {
                stringFormat = '<span> %-w</span>week%!w';
            }

            if (offset.daysToMonth > 0) {
                stringFormat = '<span> %-m</span>month%!m';
            }

            if (offset.totalDays > 0) {
                stringFormat = '<span> %-D</span>day%!D';
            }

            var $this = $(this).html(event.strftime(stringFormat
                                               + '<span> %H</span>h'
                                               + '<span> %M</span>m '
                                               + '<span> %S</span>s'));

        }).on('finish.countdown', function (event) {
            window.isEndEvent = true;
            $(this).html(eventSetting.eventEventText);
        });;
    }
}

function getLeaderboard() {

    var href = $("#table-leaderboard .active a").data("href");
    href += "?location=" + $("#tabFilter .active a").data("location");

    var $tableContent = $("#table-content");

    $tableContent.block(blockUIConfig);

    $.get(href, function (data) {

        $tableContent.html(data);

        $('.lazy').lazy({
            bind: "event",
            onFinishedAll: function () { }
        });

        callTableScroll();


    }).always(function () {

        $tableContent.unblock();
    });
}


$(document).ready(function () {
 
    var $leaderboard = $("#leaderboard");
    var $tableaderboard = $("#table-leaderboard");

    //$leaderboard.block(blockUIConfig);

    if ($tableaderboard.length > 0) {
        var tabActive = $tableaderboard.find("li.active");
        if (tabActive.length > 0) {
            getLeaderboard();
            //var tagA = tabActive.find("a[role='tab']").data("href");
            //$.get(tagA, function (data) {

            //    $("#table-content").html(data);
            //    $('.lazy').lazy({
            //        bind: "event",
            //        onFinishedAll: function () { }
            //    });
            //    callTableScroll();

            //}).always(function () {
                //$leaderboard.unblock();
            //});
        }
    }


    $(document).on('shown.bs.tab', 'a[data-toggle="tab"]', function (e) {
        getLeaderboard();

        //var href = $(e.target).data("href");

        //var $tableContent = $("#table-content");

        //$tableContent.block(blockUIConfig);

        //$.get(href, function (data) {

        //    $tableContent.html(data);

        //    $('.lazy').lazy({
        //        bind: "event",
        //        onFinishedAll: function () { }
        //    });

        //    callTableScroll();
        //}).always(function () {

        //    $tableContent.unblock();
            
        //});

    });
  
    countDownFunc(".count-down");
});