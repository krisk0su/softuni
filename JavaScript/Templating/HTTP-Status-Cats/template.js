$(() => {
  renderCatTemplate();

  async function renderCatTemplate() {
    // TODO: Render cat template and attach events
    let catsTemplete = await $.ajax({
      url: "./catsTemplate.html"
    });
    let compiledTemplete = Handlebars.compile(catsTemplete);

    let context = {
      cats: window.cats
    };

    $("#allCats").html(compiledTemplete(context));
  }
});

function showInfo(id) {
  $(`#${id}`).toggle();
}
