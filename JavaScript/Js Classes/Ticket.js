function solve(arr, sortStr){

    class Ticket{
        constructor(destination, price, status){
            this.destination = destination,
            this.price = Math.round(price*100)/100,
            this.status = status
        }
    
    }

    let resArr = [];
    
    for(let index of arr){
        
        let tokens = index.split('|');

        let destination = tokens[0];
        let price = tokens[1];
        let status = tokens[2];

        let ticket = new Ticket(destination, price, status);

        resArr.push(ticket);
    }

    if(sortStr==="destination"){
        return resArr.sort(function (t1, t2){
            var nameA = t1.destination.toUpperCase(); // ignore upper and lowercase
            var nameB = t2.destination.toUpperCase(); // ignore upper and lowercase
            if (nameA < nameB) {
              return -1;
            }
            if (nameA > nameB) {
              return 1;
            }
          
            // names must be equal
            return 0;
        });
    }else if(sortStr==="price"){
        return resArr.sort(function(t1, t2){
            return t1.price - t2.price;
        });
    }else if(sortStr==="status"){
        return resArr.sort(function (t1, t2){
            var nameA = t1.status.toUpperCase(); // ignore upper and lowercase
            var nameB = t2.status.toUpperCase(); // ignore upper and lowercase
            if (nameA < nameB) {
              return -1;
            }
            if (nameA > nameB) {
              return 1;
            }
          
            // names must be equal
            return 0;
        });
    }
}

