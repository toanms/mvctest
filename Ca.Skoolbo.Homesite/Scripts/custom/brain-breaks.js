
var get_params = function (search_string) {

    var parse = function (params, pairs) {
        var pair = pairs[0];
        var parts = pair.split('=');
        var key = decodeURIComponent(parts[0]);
        var value = decodeURIComponent(parts.slice(1).join('='));

        // Handle multiple parameters of the same name
        if (typeof params[key] === "undefined") {
            params[key] = value;
        } else {
            params[key] = [].concat(params[key], value);
        }

        return pairs.length == 1 ? params : parse(params, pairs.slice(1))
    }

    // Get rid of leading ?
    return search_string.length == 0 ? {} : parse({}, search_string.substr(1).split('&'));
}

var myOptions = {
    "nativeControlsForTouch": false,
    techOrder: ["azureHtml5JS", "html5", "flashSS", "html5FairPlayHLS", "silverlightSS"],
    controls: true,
    autoplay: false,
    width: "100%",
    height: "345",
    hotKeys: {
        enableFullscreen: false
    }
}

var myPlayer = amp("azuremediaplayer", myOptions);
myPlayer.src([
        {
            "src": "//pspmedia.streaming.mediaservices.windows.net/a7224d33-0045-4c63-bb96-0ed5c4f84514/BrainBreaksMedleyVIDEO.ism/manifest",
            "type": "application/vnd.ms-sstr+xml"
        }
]);

$(document).ready(function () {

    var params = get_params(location.search);
    var autoPlay = params['autoplay'];

    if (autoPlay != null && autoPlay != undefined) {
        $("#myVideo").modal("show");
        myPlayer.ready(function () {
            this.play();
        });
    }


    $('#myVideo').on('shown.bs.modal', function (e) {
        myPlayer.play();
    });
    $('#myVideo').on('hidden.bs.modal', function (e) {
        myPlayer.pause();
    });

    $(document).on("click", ".show-video", function (e) {
        $("#myVideo").modal("show");
    });
});


