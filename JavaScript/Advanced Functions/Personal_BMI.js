function solve(name, age, weight, height){

   function getBMI(){
    let heightInCm = height/100;
    let result = Math.round(weight / (heightInCm*heightInCm));
    return result;
   }

   let bim = getBMI();
   let status;

   if(bim < 18.5){
        status = "underweight";
   }
   else if(bim >= 18.5 && bim <25 ){
       status = "normal";
   }
   else if(bim >=25 && bim <30){
        status = "overweight";
   }
   else if(bim >= 30){
       status = "obese";
   }

   let patient = {
        name: name,
        personalInfo:{
            age: age,
            weight: weight,
            height: height
        },
        BMI: bim,
        status: status
   }

   if(status==="obese"){
       patient['recommendation'] = 'admission required' ;
   }

   return patient;
}

solve('Peter', 29, 75, 182);