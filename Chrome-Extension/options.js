function loadOptions() {
  // Set default options as p
  chrome.storage.sync.get({
    element: 'p',
    paragraph: 3
  }, function(items) {
    $('element').value = items.element;
    $('paragraph').value = items.paragraph;
    $('range').innerHTML = items.paragraph;
    console.log('Load element options : ' + items.element);
    console.log('Load paragraph options : ' + items.paragraph);
  });
}

function saveOptions(e) {
  $('save').addClass('onClick', 250, validate);
  var element = $('element').value;
  var paragraph = $('paragraph').value;
  chrome.storage.sync.set({
    element: element,
    paragraph: paragraph
  }, function() {
    // Update status to let user know options were saved.
    console.log('Set element options as ' + element);
    console.log('Set paragraph options as ' + paragraph);
    var status = $('status');
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
  var newValue = $('paragraph').value;
  $('range').innerHTML = newValue;
}

function fade(element) {
  var op = 1; // initial opacity
  var timer = setInterval(function() {
    if (op <= 0.1) {
      clearInterval(timer);
      element.style.display = 'none';
    }
    element.style.opacity = op;
    element.style.filter = 'alpha(opacity=' + op * 100 + ')';
    op -= op * 0.1;
  }, 35);
}

document.addEventListener('DOMContentLoaded', function() {
  loadOptions();
  $('save').addEventListener('click', saveOptions);
  $('clear').addEventListener('click', clearOptions);
  $('paragraph').addEventListener('input', showRangeValue);
});

function validate() {
  setTimeout(function() {
    $('#save').removeClass('onClick');
    $('#save').addClass('validate', 450, callback);
  }, 500);
}

function callback() {
  setTimeout(function() {
    $('#save').removeClass('validate');
  }, 1000);
}
