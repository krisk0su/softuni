function notify(str) {
  let $element = $("#notification");
  $element.css("display", "block");
  $element.append(`<p>${str}</p>`);

  setTimeout(function() {
    $element.css("display", "none");
  }, 2000);
}
