function attachEvents() {
  const baseUrl = "https://baas.kinvey.com/";
  const appKey = "kid_S1X0wjoOV";
  const endPoint = "biggestCatches";
  const userName = "krisk0su";
  const password = "krizk0tak3n";
  const headers = {
    Authorization: `Basic ${btoa(userName + ":" + password)}`,
    "Content-Type": "application/json"
  };

  $("#addFish").on("click", addCatch);
  $("#loadCatches").on("click", loadCatches);
  function loadCatches() {
    $("#catches").empty();

    renderAllCatches();
  }

  async function renderAllCatches() {
    let response = await fetch(baseUrl + "appdata/" + appKey + "/" + endPoint, {
      method: "GET",
      headers: headers
    });

    let catches = await response.json();

    for (let ulov of catches) {
      $("#catches").append(
        `<div class="catch" data-id="${ulov._id}">
          <label>Angler</label>
          <input type="text" class="angler" value="${ulov.angler}">
          <label>Weight</label>
          <input type="number" class="weight" value="636">
          <label>Species</label>
          <input type="text" class="species" value="${ulov.species}">
          <label>Location</label>
          <input type="text" class="location" value="${ulov.location}">
          <label>Bait</label>
          <input type="text" class="bait" value="${ulov.bait}">
          <label>Capture Time</label>
          <input type="number" class="captureTime" value="${ulov.captureTime}">
          <button class="update">Update</button>
          <button class="delete">Delete</button>
        </div>`
      );

      let deleteBtn = $(`[data-id="${ulov._id}"] button.delete`);
      deleteBtn.click({ id: ulov._id }, deleteCatch);

      let updateBtn = $(`[data-id="${ulov._id}"] button.update`);
      updateBtn.click({ id: ulov._id }, updateCatch);
    }
  }

  async function updateCatch(event) {
    let id = event.data.id;

    let angler = $(`[data-id="${id}"] input.angler`).val();
    let weight = $(`[data-id="${id}"] input.weight`).val();
    let species = $(`[data-id="${id}"] input.species`).val();
    let location = $(`[data-id="${id}"] input.location`).val();
    let bait = $(`[data-id="${id}"] input.bait`).val();
    let captureTime = $(`[data-id="${id}"] input.captureTime`).val();

    let obj = {
      angler,
      weight,
      species,
      location,
      bait,
      captureTime
    };

    let request = await fetch(
      baseUrl + "appdata/" + appKey + "/" + endPoint + "/" + id,
      {
        method: "PUT",
        headers,
        body: JSON.stringify(obj)
      }
    );

    let requestObj = await request.json();
    console.log(requestObj);
  }
  async function deleteCatch(event) {
    let catchId = event.data.id;
    try {
      let response = await fetch(
        baseUrl + "appdata/" + appKey + "/" + endPoint + "/" + catchId,
        {
          method: "Delete",
          headers
        }
      );

      $(`[data-id="${catchId}"]`).remove();
    } catch (error) {
      console.log(error.message);
    }
  }

  function addCatch() {
    let $angler = $("#angler").val();
    let $weight = $("#weight").val();
    let $species = $("#species").val();
    let $location = $("#location").val();
    let $bait = $("#bait").val();
    let $captureTime = $("#captureTime").val();

    createNewCatch($angler, $weight, $species, $location, $bait, $captureTime);
  }

  async function createNewCatch(
    angler,
    weight,
    species,
    location,
    bait,
    captureTime
  ) {
    let catchObj = {
      angler,
      weight,
      species,
      location,
      bait,
      captureTime
    };
    let response = await fetch(baseUrl + "appdata/" + appKey + "/" + endPoint, {
      method: "POST",
      headers: headers,
      body: JSON.stringify(catchObj)
    });

    let responseObj = await response.json();

    $("#catches").append(
      `<div class="catch" data-id="${responseObj._id}">
    <label>Angler</label>
    <input type="text" class="angler" value="${responseObj.angler}">
    <label>Weight</label>
    <input type="number" class="weight" value="636">
    <label>Species</label>
    <input type="text" class="species" value="${responseObj.species}">
    <label>Location</label>
    <input type="text" class="location" value="${responseObj.location}">
    <label>Bait</label>
    <input type="text" class="bait" value="${responseObj.bait}">
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${responseObj.captureTime}">
    <button class="update">Update</button>
    <button class="delete">Delete</button>
  </div>`
    );
  }
}
