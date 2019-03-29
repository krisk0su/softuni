function attachEvents() {
  $("#submit").on("click", getWeather);

  const weatherString = {
    Sunny: "&#x2600;", // ☀
    "Partly sunny": "&#x26C5;", // ⛅
    Overcast: "&#x2601;", // ☁
    Rain: "&#x2614;", // ☂
    Degrees: "&#176;" // °
  };

  function getWeather() {
    let $location = $("#location").val();

    let url = " https://judgetests.firebaseio.com/locations.json";
    fetch(url) // Call the fetch function passing the url of the API as a parameter
      .then(function(promise) {
        return promise.json();
      })
      .then(function(data) {
        let values = Object.values(data);

        for (const obj of values) {
          if (obj["name"] === $location) {
            return obj["code"];
          }
        }

        throw new Error("No such city or value is null");
      })
      .then(function(code) {
        let finalUrl = `https://judgetests.firebaseio.com/forecast/today/${code}.json`;

        fetch(finalUrl)
          .then(function(js) {
            return js.json();
          })
          .then(function(obj) {
            displayCurrentConditions(obj);
          });

        let weatherUrl = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;

        fetch(weatherUrl)
          .then(function(jsonObj) {
            return jsonObj.json();
          })
          .then(function(data) {
            displayThreeDayForecast(data);
          });
      })
      .catch(function(error) {
        console.log(error.message);
      });

    function displayCurrentConditions(data) {
      $("#forecast").css("display", "");

      let condition = data.forecast["condition"];
      let $current = $("#current");

      $current.append(
        `<span class="condition symbol">${weatherString[condition]}</span>`
      );

      $current.append(`<span class="forecast-data">${data.name}</span>`);

      $current.append(
        `<span class="forecast-data">${data.forecast["low"]}&#176;/${
          data.forecast["high"]
        }&#176;</span>`
      );

      $current.append(`<span class="forecast-data">${condition}</span>`);
    }

    function displayThreeDayForecast(data) {
      let values = Object.values(data.forecast);

      for (const day of values) {
        let $parent = $(`<span class="upcoming"></span>`);

        $parent.append(
          `<span class="symbol">${weatherString[day.condition]}</span>`
        );
        $parent.append(
          `<span class="forecast-data">${day.low}&#176;/${
            day.high
          }&#176;</span>`
        );
        $parent.append(`<span class="forecast-data">${day.condition}</span>`);

        $("#upcoming").append($parent);
      }
    }
  }
}
