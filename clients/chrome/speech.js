// new instance of speech recognition
var recognition = new webkitSpeechRecognition();
// set params
recognition.continuous = true;
recognition.interimResults = false;
recognition.lang = 'pt-BR';
recognition.start();
recognition.onresult = function (event) {

  // delve into words detected results & get the latest
  // total results detected
  var resultsLength = event.results.length - 1;
  // get length of latest results
  var ArrayLength = event.results[resultsLength].length - 1;
  // get last word detected
  var saidWord = event.results[resultsLength][ArrayLength].transcript;
  if (voice.Typed != saidWord) {
    voice.Typed = saidWord;
    console.log(saidWord);
    sendMessage("voice");
  }
}

// speech error handling
recognition.onerror = function (event) {
  console.log('error?');
  console.log(event);
}
