    var x = [];
    var y = [];
    var time = [];

        webgazer.setRegression('ridge') /* currently must set regression and tracker */
        .setTracker('clmtrackr')
        .setGazeListener(function(data, clock) {
           if(data!=null) {
            //console.log(data.x,data.y);
            //console.log(findDomElementGoogle(data.x,data.y));
            x = data.x; //these x coordinates are relative to the viewport
            y = data.y; //these y coordinates are relative to the viewport
            time = clock;
            
            sendEye(x,y);
            
            //Posx.push(data.x);
            //Posy.push(data.y);
            //time.push(clock);

           }

         //   console.log(data); /* data is an object containing an x and y key which are the x and y prediction coordinates (no bounds limiting) */
         //   console.log(clock); /* elapsed time in milliseconds since webgazer.begin() was called */
        })
        .begin()
        

        .showPredictionPoints(true); /* shows a square every 100 milliseconds where current prediction is */
        
        var width = 320;
        var height = 240;
        var topDist = '0px';
        var leftDist = '0px';
        
        var setup = function() {
            var video = document.getElementById('webgazerVideoFeed');
            video.style.display = 'hidden';
            video.style.position = 'absolute';
            video.style.top = topDist;
            video.style.left = leftDist;
            video.width = width;
            video.height = height;
            video.style.margin = '0px';
   
            webgazer.params.imgWidth = width;
            webgazer.params.imgHeight = height;

         
        };

        function checkIfReady() {
            if (webgazer.isReady()) {
                setup();
            } else {
                setTimeout(checkIfReady, 200);
            }
        }
        
        setTimeout(checkIfReady,200);


        
        


        window.onbeforeunload = function() {
            webgazer.end();
        };
        

    //console save salvar os array's de predições
    console.save = function(data, filename){

if(!data) {
    console.error('Console.save: No data')
    return;
}

if(!filename) filename = 'console.json'

if(typeof data === "object"){
    data = JSON.stringify(data, undefined, 4)
}

var blob = new Blob([data], {type: 'text/json'}),
    e    = document.createEvent('MouseEvents'),
    a    = document.createElement('a')

a.download = filename
a.href = window.URL.createObjectURL(blob)
a.dataset.downloadurl =  ['text/json', a.download, a.href].join(':')
e.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null)
a.dispatchEvent(e)
}

document.onkeyup=function(e){
if(e.which == 27){
    //Pressionou ESC, aqui vai a função para esta tecla.
    console.save(Posx,"PosX.txt");
    console.save(Posy,"PosY.txt");
    console.save(time,"timestamps.txt"); //elapsed time in milliseconds since webgazer.begin() was called
}
}


