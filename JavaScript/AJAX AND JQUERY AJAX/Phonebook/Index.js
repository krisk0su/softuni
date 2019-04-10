function attachEvents() {
  $("#btnCreate").on("click", createEntry);
  $("#btnLoad").on("click", loadAllEntries);

  function loadAllEntries() {
    let url = "https://phonebook-8fd7d.firebaseio.com/Phonebook.json";
    $.ajax({
      url,
      success: loadEntries
    });

    function loadEntries(data) {
      $("#phonebook").empty();
      let entries = Object.values(data);

      for (const person of entries) {
        let liItem = `<li>${person.name} ${person.phone} <button id="${
          person.phone
        }">Delete</button></li>`;

        $("#phonebook").append(liItem);
        $(`#${person.phone}`).on("click", deleteEntry);
      }
    }
  }
  function createEntry() {
    let url = "https://phonebook-8fd7d.firebaseio.com/Phonebook.json";
    let name = $("#person").val();
    let phone = $("#phone").val();

    let person = {
      name,
      phone
    };

    $.ajax({
      url,
      method: "POST",
      data: JSON.stringify(person),
      success: addLi(person)
    });
    $("#person").val("");
    $("#phone").val("");

    function addLi(person) {
      let liItem = `<li>${person.name} ${person.phone} <button id="${
        person.phone
      }">Delete</button></li>`;

      $("#phonebook").append(liItem);
      $(`#${person.phone}`).on("click", deleteEntry);
    }
  }

  function deleteEntry() {
    let phone = this.getAttribute("id");
    let url = "https://phonebook-8fd7d.firebaseio.com/Phonebook";

    $.ajax({
      url: url + ".json",
      success: deleteCurrent
    });
    function deleteCurrent(data) {
      let entries = Object.entries(data);
      for (const [key, value] of entries) {
        if (value["phone"] == phone) {
          $.ajax({
            method: "DELETE",
            url: url + `/${key}.json`
          });
        }
      }
    }
    $(`#${phone}`)
      .parent()
      .remove();
  }
}
