const TICK_INTERVAL_EYE = 400;
var eye = {
	type: "eye",
	x: 512,
	y: 256
};

function sendEye(x, y) {
	eye.x = Math.round(x);
	eye.y = Math.round(y);
}

function save_eye() {
	let data = eye;
	save_trace(data);
}

(function startTimer_eye() {
	setInterval(() => {
		save_eye();
	}, TICK_INTERVAL_EYE);
})();


