
var timeInternal = 0;
var userId = "";
var domain = "";
var lastTime = 0;
var fixtime = 0;
var shot = 5;
var id = 0;

chrome.runtime.onMessage.addListener(function (request, sender) {
    if (request.type == "solicita") {
        handshake();
    }
    else {
        save_trace(request);
    }
    //sendResponse({ farewell: "goodbye" });
});

chrome.browserAction.onClicked.addListener(function (tab) {
    chrome.storage.sync.remove(["userid"], function (Items) {
        loadedId == null;
    });
    alert('Data Cleaned.');
});

chrome.tabs.onUpdated.addListener(function (tabId, changeInfo, tab) {
    //alert("reloaded");
    //chrome.tabs.executeScript(tabId, { file: "content.js" });
});

function handshake() {
    chrome.storage.sync.get(["userid"], function (items) {
        var loadedId = items.userid;
        function useToken(userid) {
            userId = userid;
            chrome.tabs.getSelected(null, function (tab) {
                var url = new URL(tab.url);
                domain = url.hostname;
                post("handshake.php", { userId: userid, domain: domain })
                    .then(
                        (data) => {
                            timeInternal = parseInt(data);
                        });
            });
        }
        if (loadedId !== null && loadedId !== "" && typeof loadedId !== 'undefined') {
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

function save_trace(data) {
    chrome.windows.getCurrent(function (win) {
        chrome.tabs.getSelected(null, function (tab) {
            var url = new URL(tab.url);
            domain = url.hostname;
            //if(lastTime == (Math.ceil(data.time) + timeInternal)&& ((type=="move" || type=="freeze") && //Math.ceil(data.time) % 3 == 1)){
            //    data.imageData = "";
            //}
            if (data.type == "eye") {
                data.imageData = "NO";
                //data.time-=0.2;
            }
            else if (data.type == "voice") {
                data.imageData = "NO";
                //data.time-=0.2;
            }
            else {
                if ((data.type == "move" || data.type == "freeze") && shot < 7) {
                    data.imageData = "NO";
                    shot++;
                }
                else {
                    shot = 0;
                    lastTime = data.time + timeInternal;
                    chrome.tabs.captureVisibleTab(win.id, { format: "jpeg", quality: 25 }, function (screenshotUrl) {
                        data.imageData = screenshotUrl;
                    });

                }
            }
            transfer(data);
        });
    });
}

function transfer(data) {
    data.imageName = lastTime + ".jpg";
    if (fixtime < data.time + timeInternal) {
        fixtime = data.time + timeInternal;
    }
    post("trace.php",
        {
            metadata: {
                sample: domain,
                userId: userId,
                time: fixtime,
                scroll: data.pageScroll,
                height: data.pageHeight,
                url: data.url
            },
            data: data
        }
    ).then(function (data) {
        console.log(data.type + " " + data);
    })
    .catch(function (data) {
        console.log(data.type + " " + data);
    });
}