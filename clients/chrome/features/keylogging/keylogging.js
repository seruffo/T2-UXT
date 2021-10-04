const TICK_INTERVAL_KEYBOARD=750;
var keyboard = {
    type:"keyboard",
    id: "",
    class:"",
    x: 0,
    y: 0,
    typed: "",
    time:0
};
var typing = false;
var lastKeyId = "";

document.addEventListener("keydown", (e) => {
    var KeyID = e.keyCode;
    switch (KeyID) {
        case 8:
            //backspace
            keyboard.typed = keyboard.typed.slice(0, -1);
            break;
        case 46:
            //delete
            keyboard.typed += "-!-";
            break;
        case 13:
            save_keyboard();
            keyboard.typed = "";
            keyboard.id = e.target.id;
            keyboard.class = e.target.className;
            break;
        default:
            typing = true;
            var obj = getScreenCordinates(document.getElementById(e.target.id));
            console.log('Press id ' + e.target.id + " pos "+ obj.x + " | "+obj.y);
            var get = window.event ? event : e;
            var key = get.keyCode ? get.keyCode : get.charCode;
            key = String.fromCharCode(key);
            if (mouse.id != keyboard.Id) {
                save_keyboard();
                keyboard.typed = "";

                keyboard.id = mouse.id;
                keyboard.class = mouse.class;
            } else {
                keyboard.x=Math.round(obj.x);
                keyboard.y=Math.round(obj.y);
            }
            keyboard.typed += key;
            keyboard.typed.replace(/(?:\r\n|\r|\n)/g," - ");
            console.log(keyboard.typed);
            break;
    }

});

function save_keyboard(){
    let data = keyboard;
    if (data.x == 0 && data.y == 0)
    {
        data.x = Math.round(mouse.x);
        data.y = Math.round(mouse.y);
    }
    data.typed = data.typed.replace(/(?:\r\n|\r|\n)/g, " - ");
    save_trace(data);
}

(function startTimer_keyboard() {
    setInterval(() => {
        if (typing) {
            save_keyboard();
            keyboard.typed = "";
            keyboard.id = mouse.id;
            keyboard.class = mouse.class;
            typing=false;
        }
    }, TICK_INTERVAL_KEYBOARD);
})();