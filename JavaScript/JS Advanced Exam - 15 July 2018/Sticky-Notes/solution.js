function addSticker() {
  let $title = $(".title");

  let $content = $(".content");

  if ($title.val().length > 0 && $content.val().length > 0) {
    let $stickerList = $("#sticker-list");

    let $li = $("<li></li>");
    $li.addClass("note-content");

    let $button = $("<a>");
    $button.addClass("button");
    $button.text("x");
    $($button).click(function del(event) {
      let $current = $(event.target);
      console.log($current.parent().remove());
    });

    let $h2 = $("<h2>");
    $h2.text($title.val());

    let $hr = $("<hr>");

    let content = $("<p>");
    content.text($content.val());

    $li.append($button);
    $li.append($h2);
    $li.append($hr);
    $li.append(content);

    $stickerList.append($li);

    $title.val("");

    $content.val("");
  }
}
