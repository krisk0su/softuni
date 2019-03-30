function toggle() {
  let $button = $(".button");

  if ($("#extra").css("display") && $("#extra").css("display") === "none") {
    $("#extra").css("display", "block");
    $button.text("Less");
  } else {
    $("#extra").css("display", "none");
    $button.text("More");
  }
}
