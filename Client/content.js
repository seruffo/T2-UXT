var mouse = {
    Id:"",
    X: 0,
    Y: 0,
    Typed: "",
    Time:0
}

var lastX = 0;
var lastY = 0;
var keyboard = {
    Id: "",
    X: 0,
    Y: 0,
    Typed: "",
    Time:0
}
var freeze = 0;
var time = 0;
var lastKeyId = "";

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

function GetScreenCordinates(obj) {
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

function startAgain() {
    chrome.runtime.sendMessage(
        {
            type: "solicita"
        }
    );
}



$(document).mousemove(function (event) {
    mouse.X = event.pageX;
    mouse.Y = event.pageY;
    freeze = 0;
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
    mouse.X = e.pageX;
    mouse.Y = e.pageY;
    freeze = 0;
    if (typing) {
        sendMessage("keyboard");
        keyboard.Typed = "";
        keyboard.Id = e.target.id;
        typing = false;
    }
    sendMessage("click");
});

document.addEventListener("keydown", KeyCheck);
function KeyCheck(event) {
    var KeyID = event.keyCode;
    switch (KeyID) {
        case 8:
            //backspace
            keyboard.Typed = keyboard.Typed.slice(0, -1);
            break;
        case 46:
            //delete
            keyboard.Typed += "-!-";
            break;
        default:
            break;
    }
}
var typing = false;
document.onkeypress = function (e) {
    typing = true;
    var obj = GetScreenCordinates(document.getElementById(e.target.id));
    console.log('Press id ' + e.target.id + " pos "+ obj.x + " | "+obj.y);
    var get = window.event ? event : e;
    var key = get.keyCode ? get.keyCode : get.charCode;
    key = String.fromCharCode(key);
    if (e.target.id != keyboard.Id) {
        sendMessage("keyboard");
        keyboard.Typed = "";
        keyboard.Id = e.target.id;
    } else {
        keyboard.X=obj.x;
        keyboard.Y=obj.y;
    }
    keyboard.Typed += key;
}

function tick() {
    freeze++;
    time++;
    if (freeze == 4) {
        console.log('freeze');
        freeze = 0;
        idClick: mouse.Id,
        sendMessage("freeze");
    }
}
startAgain();
startTimer();

function sendMessage(type)
{
    var data = {};
    if (type == "keyboard") {
        data = keyboard;
        if (data.X == 0 && data.Y == 0)
        {
            data.X = mouse.X;
            data.Y = mouse.Y;
        }
    } else {
        data = mouse;
    }
    data.Time = time;
    chrome.runtime.sendMessage({
        type: type,
        data: data
    });
}