function subtract() {
  let $first = +$("#firstNumber").val();
  let $second = +$("#secondNumber").val();

  let res = $first - $second;

  $("#result").text(res);
}
