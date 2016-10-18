var maxItemShow = 3;

$(document).ready(function () {
    $('.carousel').carousel();
    jQuery('#home-video').acornMediaPlayer({
        theme: 'darkglass',
        volumeSlider: 'vertical'
    });

    getRss(window.urlRss);
});


function RssModel() {
    var self = this;

    self.Title = "";
    self.Link = "";
    self.Image = "";
    self.PubDate = "";
    self.Description = "";

    self.ImageUrl = function () {
        if (self.Image) {
            return $(self.Image).attr("url");
        }
        return "";
    }
}

function getRss(rssUrl) {
    $(document).ready(function () {
        $.get(rssUrl, function (data) {

            var rsssData = [];

            $(data).find("item").each(function () { // or "item" or whatever suits your feed
                var el = $(this);

                var obj = new RssModel();

                obj.Title = el.find("title").text();
                obj.Link = el.find("link").text();
                obj.Image = el.find("enclosure");
                obj.PubDate = el.find("pubDate").text();
                obj.Description = el.find("description").text();
                
                rsssData.push(obj);
            });

            rsssData.sort(function (obj1, obj2) {

                var date1 = new Date(obj1.PubDate);
                var date2 = new Date(obj2.PubDate);

                return date2.getTime() - date1.getTime();
            });
           
            if (rsssData.length > 0) {

                var htmlString = "<div class='col-sm-12 margin-top-10'>";
                htmlString += "<ul class='bxslider margin-bottom-0'>";
                for (var x = 0; x < rsssData.length && x < maxItemShow; x++) {

                    var title = rsssData[x].Title;
                    var link = rsssData[x].Link;
                    var image = rsssData[x].ImageUrl();
                    var summary = rsssData[x].Description;

                    var hasImage = image !== "";

                    htmlString += "<li>";
                    htmlString += "<div class='row'>";

                    if (hasImage) {
                        htmlString += "<div class='col-sm-2 col-md-2 col-lg-1  bxslider-avatar'>";
                        htmlString += "<a href='" + link + "' target='_blank'>";

                        htmlString += "<img src='" + image + "' class='img-responsive' />";

                        htmlString += "</a>";
                        htmlString += "</div>";
                    }

                    htmlString += "<div class='" + (hasImage ? "col-sm-10 col-md-10 col-lg-11" : "col-sm-12") + "'>";

                    htmlString += "<h4 class='color-green text-bold  margin-bottom-5 margin-top-0'>";
                    htmlString += "<a href='" + link + "' target='_blank'>";

                    htmlString += title;

                    htmlString += "</a>";
                    htmlString += "</h4>";

                    if (summary) {
                        htmlString += "<p>";
                        htmlString += summary.replace('<p>', '').replace('</p>', '');
                        htmlString += "</p>";
                    }

                    htmlString += "</div>";

                    htmlString += "</div>";
                    htmlString += "</li>";
                }

                htmlString += "</ul>";
                htmlString += "</div>";

                $('.rss').html(htmlString);

                if (rsssData.length > 1) {
                    $('.bxslider').bxSlider({
                        controls: false,
                        auto: rsssData.length > 1,
                        pager: rsssData.length > 1,
                        speed: 1000,
                        pause: 5000
                    });
                }
            }
        });
    });
}