function addItem() {
  let $text = $("#newItemText").val();
  let $value = $("#newItemValue").val();

  let $menu = $("#menu");

  let $element = $("<option>")
    .attr("value", $value)
    .text($text);
  $menu.append($element);

  $("#newItemText").val("");
  $("#newItemValue").val("");
}
