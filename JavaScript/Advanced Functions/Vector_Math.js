let solve = (function(){

    const add = function([x1,x2],[y1,y2]) {
        return [x1+y1, x2+y2]
    }

    const multiply = function([x1 , x2], multiPlyer){
        return [x1 * multiPlyer, x2 * multiPlyer];
    }

    const length = function([x1, x2]){
        return Math.sqrt(x1*x1 + x2 * x2 );
    }
    const dot = function([x1, x2], [y1, y2]){
        return x1 * y1 + x2 * y2;
    }
    const cross = function([x1 , x2] , [y1 , y2]){
        return x1 * y2 - x2 * y1;
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})()

console.log(solve.add([1,1],[2,2]))
