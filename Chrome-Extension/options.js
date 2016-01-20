function loadOptions() {
  // Set default options as p
  chrome.storage.sync.get({
    element: 'p',
    paragraph: 3
  }, function(items) {
    document.getElementById('element').value = items.element;
    document.getElementById('paragraph').value = items.paragraph;
    document.getElementById('range').innerHTML = items.paragraph;
    console.log('Load element options : ' + items.element);
    console.log('Load paragraph options : ' + items.paragraph);
  });
}

function saveOptions(e) {
  var element = document.getElementById('element').value;
  var paragraph = document.getElementById('paragraph').value;
  chrome.storage.sync.set({
    element: element,
    paragraph: paragraph
  }, function() {
    // Update status to let user know options were saved.
    console.log('Set element options as ' + element);
    console.log('Set paragraph options as ' + paragraph);
    var status = document.getElementById('status');
    status.style.opacity = 1;
    status.style.display = 'block';
    status.textContent = 'Options saved.';
    setTimeout(function() {
      fade(status);
    }, 300);
  });
}

function clearOptions() {
  chrome.storage.sync.clear();
  location.reload();
}

function showRangeValue() {
  var newValue = document.getElementById('paragraph').value;
  document.getElementById('range').innerHTML = newValue;
}

function fade(element) {
  var op = 1; // initial opacity
  var timer = setInterval(function() {
    if (op <= 0.1) {
      clearInterval(timer);
      element.style.display = 'none';
    }
    element.style.opacity = op;
    element.style.filter = 'alpha(opacity=' + op * 100 + ")";
    op -= op * 0.1;
  }, 35);
}

document.addEventListener('DOMContentLoaded', function() {
  loadOptions();
  document.getElementById('save').addEventListener('click', saveOptions);
  document.getElementById('clear').addEventListener('click', clearOptions);
  document.getElementById('paragraph').addEventListener('input', showRangeValue);
});
