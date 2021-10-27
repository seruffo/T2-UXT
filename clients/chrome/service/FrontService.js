var TICK_INTERVAL = 200;
var pageHeight = Math.max(document.body.scrollHeight, document.body.offsetHeight);
var overId = "";
var overClass = "";
var webtracer_time = 0;

function getScreenCordinates(obj) {
    var p = {};
    if (obj == null || (typeof obj == 'undefined')) {
        p.x = 0;
        p.y = 0;
        return p;
    }
    p.x = obj.offsetLeft;
    p.y = obj.offsetTop;
    while (obj.offsetParent) {
        p.x = p.x + obj.offsetParent.offsetLeft;
        p.y = p.y + obj.offsetParent.offsetTop;
        if (obj == document.getElementsByTagName("body")[0]) {
            break;
        }
        else {
            obj = obj.offsetParent;
        }
    }
    return p;
}

// $(window).on("navigate", function (event, data) {
//     var direction = data.state.direction;
//     sendMessage(direction);
//     //back, forward
// });

(function startTimer() {
    setInterval(() => {
        webtracer_time += 0.2;
    }, TICK_INTERVAL);
})();

(function recoverSession() {
    chrome.runtime.sendMessage(
        {
            type: "solicita"
        }
    );
})();

function save_trace(data) {

    data.time = webtracer_time;
    data.imageName = "";
    data.pageHeight = Math.round(pageHeight);
    data.pageScroll = Math.round(document.documentElement.scrollTop);
    data.url = document.URL;
    data.mouseId = overId;
    data.mouseClass = overClass;
    //console.log("message send "+type);
    chrome.runtime.sendMessage(data);

}