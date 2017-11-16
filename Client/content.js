var posX = 0;
var posY = 0;
var type = " ";
var freeze = 0;
var time = 0;
var keys = "";
var idClick = "";
var idType = "";
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

var cumulativeOffset = function (element) {
    var top = 0, left = 0;
    do {
        top += element.offsetTop || 0;
        left += element.offsetLeft || 0;
        element = element.offsetParent;
    } while (element);

    return {
        top: top,
        left: left
    };
};

function startAgain() {
    chrome.runtime.sendMessage(
        {
            type: "solicita"
        }
    );
}



$(document).mousemove(function (event) {
    posX = event.pageX;
    posY = event.pageY;
});

function startTimer(secs) {
    secTime = parseInt(secs);
    ticker = setInterval("tick()", 1000);
    tick();
}

document.addEventListener("mouseover", function (e) {
    idClick = e.target.id;
});

document.addEventListener("mouseout", function (e) {
    idClick = "";
});

document.addEventListener('click', function (e) {
    idClick = e.target.id;
    console.log("click " + e.pageX + " | " + e.pageY);
    posX = e.pageX;
    posY = e.pageY;
    type = "click";
    sendMessage();
});

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
    idType = e.target.id;
    console.log('id ' + idType);
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
        idClick: idClick,
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
            mouse: {
                id: idClick,
                X: posX,
                Y: posY,
            },
            time: time,
            keyboard: {
                id: idType,
                typed: keys,
                posType: cumulativeOffset(document.getElementById(idType))
            }
        }
    });
    keys = "";
}