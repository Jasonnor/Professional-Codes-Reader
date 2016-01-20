function loadOptions() {
  chrome.storage.sync.get({
    element: 'p'
  }, function(items) {
    document.getElementById('element').value = items.element;
    console.log('Load element options : ' + items.element);
  });
}

function saveOptions(e) {
    var element = document.getElementById('element').value;
    chrome.storage.sync.set({
      element: element
    }, function() {
      // Update status to let user know options were saved.
      console.log('Set element options as ' + element);
      var status = document.getElementById('status');
      status.textContent = 'Options saved.';
      setTimeout(function() {
        status.textContent = '';
      }, 750);
    });
}

function clearOptions() {
  chrome.storage.sync.clear();
  location.reload();
}

document.addEventListener('DOMContentLoaded', function() {
  loadOptions();
  document.getElementById('save').addEventListener('click', saveOptions);
  document.getElementById('clear').addEventListener('click', clearOptions);
});
