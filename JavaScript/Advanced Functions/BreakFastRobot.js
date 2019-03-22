let manager = (function (){

    let ingredients  = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let recipesObj = {
        'apple':{
            carbohydrate: 1, 
            flavour: 2
        },
        'coke':{
            carbohydrate: 10, 
            flavour: 20
        },
        'burger':{
            carbohydrate: 5,
            fat: 7, 
            flavour: 3
        },
        'omelet':{
            protein: 5,
            fat: 1, 
            flavour: 1
        },
        'cheverme':{
            protein: 10,
            carbohydrate: 10,
            fat: 10, 
            flavour: 10
        },
    }
    function prepare(meal, quantity){
        
        let product = recipesObj[meal];

        for(let ingr in product){
            let currentIngredientValue = product[ingr];
            let storedValue =  ingredients[ingr];
            if(storedValue >= currentIngredientValue * quantity){
                storedValue -= currentIngredientValue * quantity;
                continue;
            }
            else{
               
                return `Error: not enough ${ingr} in stock`
            }
        }

        return "Success";
    }
    function report(){
        let result;

        for(let ingr in ingredients){
            result+= ingr + ' = ' + ingredients[ingr] + ' '
        }

        return result;
    }
    return function(input){
        let tokens = input.split(' ');
        let command = tokens[0];

        if(command ==='restock'){
            let ingredient = tokens[1];
            let quantity = Number(tokens[2]);
            ingredients[ingredient] += (quantity);
            console.log('Success');

        }
        else if(command === 'prepare'){
            let meal = tokens[1];
            let quantity = tokens[2];

            console.log(prepare(meal, quantity));
        }
        else if(command === 'report'){
            console.log(report());
        }
    }
})();

manager("restock flavour 50"); 
manager("prepare coke 4");    
manager("restock carbohydrate 10");  
manager("restock flavour 10"); 
manager("prepare apple 1"); 
manager("restock fat 10"); 
manager("prepare burger 1"); 
manager("report"); 
