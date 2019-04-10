$(() => {
  // TODO
  loadMonkeys();

  async function loadMonkeys() {
    let monkeysHtml = await $.ajax({
      url: "./monkeysList.html"
    });

    let monkeyHtml = await $.ajax({
      url: "./monkey.html"
    });

    let allMonkeysTemplete = Handlebars.compile(monkeysHtml);

    let monkeyTemplete = Handlebars.compile(monkeyHtml);

    let context = {
      monkeys
    };
    Handlebars.registerPartial("monkey", monkeyTemplete);
    $("div.monkeys").html(allMonkeysTemplete(context));

    let $buttons = $(".monkey button");
  }
});

function toggleInfo(id) {
  $(`#${id}`).toggle();
}
