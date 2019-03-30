function create(sectionArr) {
  // For each string, create a div with a paragraph with the string in it.
  // Each paragraph is initially hidden (display:none).
  // Add a click event listener to each div that displays the hidden paragraph.
  // Finally, you should append all divs to the element with an id “content”.

  sectionArr.forEach(function(element) {
    let $element = $("<div>").append(`<p>${element}</p>`);
    $element.children("p").css("display", "none");

    let $content = $("#content");
    //add event click listener
    $element.click(appendClick);

    $content.append($element);
  });

  function appendClick(event) {
    let $element = $(event.target);
    $element.children("p").css("display", "block");
  }
}
