function solve(){
    
    let res = {

    };

    
    for(let arg of arguments){
       let obj = arg;
        let type = typeof(arg);

        if(res[type]){
            res[type]++;
        }
        else{
            res[type] = 1;
        }

        console.log(type + ': ' + obj)
    }
   
    let sorted = [];

    for(let arg in res){
        sorted.push([arg, res[arg]]);
    }
    sorted.sort(function (a,b){
        return b[1] - a[1]
    });
    for(let i = 0; i < sorted.length; i++){
    
        let type = sorted[i][0];
        let num = sorted[i][1];

        console.log(type + ' = ' + num);
    }
}
solve({ name: 'bob'}, 3.333, 9.999);