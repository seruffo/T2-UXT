    var x = [];
    var y = [];
    var time = [];
    

    window.onload = function() {
        webgazer.setRegression('ridge') /* currently must set regression and tracker */
        .setTracker('clmtrackr')
        .setGazeListener(function(data, clock) {
           if(data!=null) {
            console.log(data.x,data.y);
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
        

        .showPredictionPoints(false); /* shows a square every 100 milliseconds where current prediction is */
		document.onkeyup=function(e){
if(e.which == 27){
    webgazer.showPredictionPoints(true);
}
} 
        
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
                setTimeout(checkIfReady, 100);
            }
        }
        
        setTimeout(checkIfReady,100);


        
        


        window.onbeforeunload = function() {
            webgazer.end();
        };
    };





