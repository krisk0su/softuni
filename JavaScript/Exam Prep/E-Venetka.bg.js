function solve(arr) {
  class Town {
    constructor(name, profit, carRegistered) {
      (this.name = name),
        (this.profit = profit),
        (this.carRegistered = carRegistered);
    }
  }
  let result = [];

  class Car {
    constructor(model, price) {
      this.model = model;
      this.count = 0;
      this.price = price;
    }
  }

  let cars = [];

  orderFunc();
  sortArr();

  function orderFunc() {
    for (const entry of arr) {
      let name = entry.town;

      let doesExist = result.some(function(element) {
        return element.name == name;
      });

      let town;

      if (!doesExist) {
        town = new Town(name, 0, 0);
        town.profit += entry.price;
        town.carRegistered++;

        result.push(town);
      } else {
        let townIndex;
        for (const index in result) {
          let dunno = result[index].name;
          if (dunno == name) {
            townIndex = index;
            break;
          }
        }

        town = result[townIndex];
        town.profit += entry.price;
        town.carRegistered++;
        result[townIndex] = town;
      }
    }
  }

  function sortArr() {
    result.sort(function(t1, t2) {
      return (
        t2.profit - t1.profit ||
        t2.carRegistered - t2.carRegistered ||
        t1.name > t2.name
      );
    });
  }

  mostDrivenModel();
  sortCars();
  function mostDrivenModel() {
    let profitableTown = result[0].name;
    let selectedTownArr = arr.reduce(function(acc, curr, index) {
      if (curr.town == profitableTown) {
        acc.push(arr[index]);
      }
      return acc;
    }, []);

    for (const car of selectedTownArr) {
      //check if the cars have this model
      let carIndex;
      let carExists = !cars.some(function(val, index) {
        let areSame = val.model == car.model;
        if (areSame) {
          carIndex = index;
        }

        return areSame;
      });
      let creatingCar;
      if (carExists) {
        creatingCar = new Car(car.model, car.price);
        cars.push(creatingCar);
      }
      carIndex = cars.findIndex(x => x.model === creatingCar.model);
      cars[carIndex].count += 1;
      if (cars[carIndex].price < car.price) {
        cars[carIndex].price = car.price;
      }
    }
  }
  function sortCars() {
    cars.sort(function(t1, t2) {
      return t2.count - t1.count || t2.price - t2.price || t1.model > t2.model;
    });
  }

  let outputResult = "";
  let town = result[0].name;
  let totalProfit = result[0].profit;
  outputResult += `${town} is most profitable - ${totalProfit} BGN` + "\n";
  let drivenModel = cars[0].model;
  outputResult += `Most driven model: ${drivenModel}` + "\n";

  let townsWithThatModel = arr.filter(function(val, index) {
    if (val.model == drivenModel) {
      return val;
    }
  });

  townsWithThatModel.sort(function(t1, t2) {
    return t1.town > t2.town;
  });
  let final = {};
  for (const entry of townsWithThatModel) {
    if (!final[`${entry.town}`]) {
      final[`${entry.town}`] = [];
    }
    final[`${entry.town}`].push(entry.regNumber);
  }
  let entries = Object.entries(final);

  for (const [key, value] of entries) {
    value.sort(function(c1, c2) {
      return c1 > c2;
    });
    outputResult += `${key}: ${value.join(", ")}\n`;
  }

  console.log(outputResult);
}

solve([
  { model: "BMW", regNumber: "B1234SM", town: "Varna", price: 2 },
  { model: "BMW", regNumber: "C5959CZ", town: "Sofia", price: 8 },
  { model: "Tesla", regNumber: "NIKOLA", town: "Burgas", price: 9 },
  { model: "BMW", regNumber: "A3423SM", town: "Varna", price: 3 },
  { model: "Lada", regNumber: "SJSCA", town: "Sofia", price: 3 }
]);
