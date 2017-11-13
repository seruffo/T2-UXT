$(".drag").draggable();
$(".drag").droppable();
var takeScreenShot = function () {
    var canvas = document.getElementById('canvas'),
        context = canvas.getContext('2d');
    canvas.width = 500;
    canvas.height = 600;

    // Grab the iframe 
    var inner = document.getElementById('container');

    // Get the image 
    iframe2image(inner, function (err, img) {
        // If there is an error, log it 
        if (err) { return console.error(err); }

        // Otherwise, add the image to the canvas 
        context.drawImage(img, 0, 0);
    });
}