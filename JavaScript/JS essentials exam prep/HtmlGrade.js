function solve(points, homeworkCompleted, totalHomework) {
  const maxPoints = 400;
  const examPoints = 100;

  let hasSix = +points === maxPoints ? true : false;

  let result;

  if (hasSix) {
    let rr = "6.00";
    result = rr;
  } else {
    result = calculateGrade();
  }

  function calculateGrade() {
    let homeworkBonus = (homeworkCompleted / totalHomework) * 10;
    let totalPoints = (points / maxPoints) * 90 + homeworkBonus;

    let grade = 3 + (2 * (totalPoints - examPoints / 5)) / (examPoints / 2);
    return grade.toFixed(2);
  }

  if (result > "6.00") {
    result = "6.00";
  }
  if (result < 3) {
    result = "2.00";
  }
  return result;
}

console.log(solve(390, 5, 5));
//grade = 3 + 2 * (totalPoints – maxPoints / 5) / (maxPoints / 2)
