var myOptions = {
	"nativeControlsForTouch": false,
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

 $(document).on("click", ".show-video", function (e) {
    $("#myVideo").modal("show");

  $('#myVideo').on('shown.bs.modal', function (e) {
        myPlayer.play();
    });
    $('#myVideo').on('hidden.bs.modal', function (e) {
        myPlayer.pause();
    });
});
