// filtered, sorted or modified.
function solve(arr, sortStr) {
  let options = arr[0];

  let args = sortStr.split(" ");
  let command = args[0];

  let result = options.join(" | ");

  if (command === "sort") {
    //TODO: get options
    let property = args[1];
    let sortIndex = getIndex(property);

    let resArr = arr.slice(1, arr.length).sort(function(a, b) {
      if (a[sortIndex] < b[sortIndex]) {
        return -1;
      }
      if (a[sortIndex] > b[sortIndex]) {
        return 1;
      }
      return 0;
    });

    for (const arr of resArr) {
      result += "\n" + arr.join(" | ");
    }

    return result;
  }
  if (command === "filter") {
    let property = args[1];
    let val = args[2];

    let targetIndex = getIndex(property);

    let people = arr.slice(1, arr.length);

    let resArr = people.filter(arr => arr[targetIndex] == val);

    for (const item of resArr) {
      result += "\n" + item.join(" | ");
    }

    return result;
  }
  if (command === "hide") {
    let header = args[1];

    let removeIndex = getIndex(header);

    let res = arr.reduce(function(acc, current, index) {
      current.splice(removeIndex, 1);
      acc.push(current);
      return acc;
    }, []);

    let print = "";

    for (const item of res) {
      print += item.join(" | ") + "\n";
    }

    return print;
  }

  function getIndex(property) {
    for (let index = 0; index < options.length; index++) {
      if (options[index] === property) {
        return index;
      }
    }
  }
}

solve(
  [
    ["firstName", "age", "grade", "course"],
    ["Peter", "25", "5.00", "JS-Core"],
    ["George", "34", "6.00", "Tech"],
    ["Marry", "28", "5.49", "Ruby"]
  ],
  "hide firstName"
);
