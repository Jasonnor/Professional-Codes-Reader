chrome.browserAction.onClicked.addListener(function(tab) {
  chrome.tabs.executeScript(null, {file: 'js/pretender.js'});
});
var url;
chrome.tabs.onUpdated.addListener(function(tabId, changeInfo, tab) {
    if (typeof changeInfo.url !== 'undefined' && url != changeInfo.url) {
      url = changeInfo.url;
      var autoRun = [];
      for (var i = 0; i < autoRun.length; i++)
        if (url.indexOf(autoRun[i]) > -1) {
          chrome.tabs.executeScript(tabId, {file: 'js/pretender.js'});
          break;
        }
    }
});
