function attachEvents() {
  $("#btnLoadTowns").click(function() {
    let towns = $("#towns")
      .val()
      .split(", ");

    let templete = $("#towns-template").html();

    let compiled = Handlebars.compile(templete);

    let context = {
      towns
    };

    $("#root").html(compiled(context));
  });
}
