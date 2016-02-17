var totalAnwserCore = $("#total-answer-score");

if (totalAnwserCore.length > 0) {
    var numAnim;

    window.getTotalAnwserCore(function (data) {
        numAnim = startCoutUp(data.Start, data.End, data.Duration);
        if (!window.isEndEvent) {
            numAnim.start();
        }
        setTimeoutForTotalAnwser(numAnim, data.Duration);
    });
}

var endScore = 0;
function getTotalAnwserCore(callBack) {
    $.get(window.urlTotalAnswer + "?location=" + totalAnwserCore.data("location") + "&startfix=" + endScore, function (data) {
        if (data != null) {
            callBack(data);
        }
    });
}

function startCoutUp(start, end, duration) {
    var options = {
        useEasing: false,
        useGrouping: true,
        separator: ',',
        decimal: '.',
        prefix: '',
        suffix: '',
        showvalue: function (currentNumber) {
            //if ((currentNumber + 5) === endScore) {
            //    updateTotalAnwser(window.numAnim);
            //}
        }
    };

    endScore = end;

    return new CountUp("total-answer-score", start, end, 0, duration, options);
}

function updateTotalAnwser(numAnim) {
    getTotalAnwserCore(function (data) {
        if (numAnim == null || numAnim == undefined) {
            numAnim = startCoutUp(data.Start, data.End, data.Duration);
            numAnim.start();
            setTimeoutForTotalAnwser(numAnim, data.Duration);

        } else {
            if (endScore < data.End) {
                numAnim = startCoutUp(endScore, data.End, data.Duration);
                numAnim.start();
            }
            setTimeoutForTotalAnwser(numAnim, data.Duration);
        }
    });
}

var myVar;
var retry = 1;
function setTimeoutForTotalAnwser(numAnim, duration) {
    if (myVar != null)
        clearTimeout(myVar);

    if (parseInt(duration) <= 0) {
        duration = retry;
        retry++;
    }

    if (retry === 3) {
        duration = 1 * 60;
        retry = 1;
    }

    myVar = setTimeout(function () {
        updateTotalAnwser(numAnim);
    }, 1000 * Math.round(duration));
}
