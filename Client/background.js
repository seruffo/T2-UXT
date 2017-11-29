var timeInternal = 0;
var userId = "";
var domain = "";

chrome.runtime.onMessage.addListener(function (request, sender) {
    if (request.type == "solicita")
    {
        prepareSample();
    }
    else
    {
        capture(request.type, request.data);
    }
    //sendResponse({ farewell: "goodbye" });
});

function capture(type, data)
{
    chrome.windows.getCurrent(function (win) {   
        chrome.tabs.getSelected(null, function (tab) {
            var url = new URL(tab.url);
            domain = url.hostname;
        chrome.tabs.captureVisibleTab(win.id, { format: "jpeg", quality: 75 }, function (screenshotUrl)
        {

            $.post("http://localhost/WebTracer/receiver.php",
                {
                    metadata: JSON.stringify({
                            imageData: screenshotUrl,
                            sample: domain,
                            userId: userId,
                            type: type,
                            time: data.Time + timeInternal,
                    }),
                    data: JSON.stringify(data)

            }
            ).done(function (data) {
                alert(type+" "+data);
                }
            );
            });
        });
    });
}



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

function prepareSample() {
    chrome.storage.sync.get(["userid"], function (items) {
        var loadedId = items.userid;
        function useToken(userid) {
            userId = userid;
            chrome.tabs.getSelected(null, function (tab) {
                var url = new URL(tab.url);
                domain = url.hostname;
                $.post("http://localhost/WebTracer/SampleChecker.php", { userId: userid, domain: domain }).done(function (data) {
                    timeInternal = parseInt(data);});
            });
        }
        if (loadedId !== null && loadedId !== "" && typeof loadedId  !== 'undefined') {
            useToken(loadedId);
        }
        else {
            loadedId = getRandomToken();
            chrome.storage.sync.set({ 'userid': loadedId }, function () {
                // Notify that we saved.
                useToken(loadedId);
            });
        }
    });
}


var id = 0;
function init() {
    //alert("Mouse pos "+posX+" "+posY);
}

chrome.browserAction.onClicked.addListener(function (tab) {
    alert('O WebTracer client is running!');
    capture("forced", "0", "0", "0", "waves");
});

chrome.tabs.onUpdated.addListener(function (tabId, changeInfo, tab) {
    //alert("reloaded");
    //chrome.tabs.executeScript(tabId, { file: "content.js" });
});

alert('O WebTracer client is running!');
