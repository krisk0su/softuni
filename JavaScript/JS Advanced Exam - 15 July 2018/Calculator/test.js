let Calculator = require("./Calculator");
let assert = require("chai").assert;

describe("calculator", function() {
  let calc;

  beforeEach(function() {
    calc = new Calculator();
  });

  it("Contains a property expenses that is initialized to an empty array.", function() {
    assert.isArray(calc.expenses);
    assert.isEmpty(calc.expenses);
  });

  it("add primitive types", function() {
    calc.add(1);
    calc.add("text");
    calc.add(true);
    calc.add(5.5);

    assert.deepEqual(calc.expenses, [1, "text", true, 5.5]);
  });

  it("devide nums work", function() {
    calc.add(100);
    calc.add(2);
    calc.add(5);

    assert.equal(calc.divideNums(), 10);
  });

  it("devide nums throws error", function() {
    assert.throw(() => calc.divideNums(), "There are no numbers in the array!");
  });
});
