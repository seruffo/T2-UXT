var mouse = {
    id:"",
    class:"",
    x: 0,
    y: 0,
    typed: "",
    time:0
};

var lastPosition = {
    x:0,
    y:0
};

var freeze = 0;

document.addEventListener("mouseover",function (e){
    overId = e.target.id;
    overClass = e.target.className;
});

document.addEventListener('click', function (e) {
    mouse.Id = e.target.id;
    mouse.Class = e.target.className;
    //console.log("click " + e.pageX + " | " + e.pageY);
    mouse.X = e.pageX;
    mouse.Y = e.pageY;
    freeze = 0;
    save_mouse("click");
});

document.addEventListener("mousemove", function (e) {
    mouse.id = e.target.id;
    mouse.class = e.target.className;
    mouse.X = e.pageX;
    mouse.Y = e.pageY;
	freeze = 0;
	save_mouse("move");
});

document.addEventListener("mouseout", function (e) {
    mouse.id = "";
    mouse.Class = "";
});

document.addEventListener("wheel", function (e) {
    mouse.id = e.target.id;
    mouse.class = e.target.className;
    mouse.x = e.pageX;
    mouse.y = e.pageY;
    freeze = 0;
    save_mouse("wheel");
});

function save_mouse(type){
    let data = mouse;
    data.type=type;
    save_trace(data);
}

(function startTimer_mouse() {
    setInterval(() => {
        freeze+=0.5;
        if (freeze == 1) {
            save_mouse("freeze");
            freeze=0;
        }
    }, TICK_INTERVAL);
})();

