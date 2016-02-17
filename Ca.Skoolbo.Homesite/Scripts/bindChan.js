
var tableChan;
bindChan('tableChan', 'leaderboardTable');

tableChan.bind("redirect", function (trans, s) {
    document.getElementById('statsSumary').src = window.webDashboard + "/leaderboard/analysis/allwidget?filter=" + s;
});

function bindChan(yourVar, yourId) {
    try {
        window[yourVar] = Channel.build({
            window: document.getElementById(yourId).contentWindow,
            origin: "*",
            scope: "testScope"
        });
    }catch (e) {
        console.log(e);
    }
}
