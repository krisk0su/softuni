function subSum(arr, startIndex, endIndex){
    if(!Array.isArray(arr)){
        return NaN;
    }

    if(arr.length === 0 ){
        return 0;
    }

    if(startIndex<0){
        startIndex = 0;
    }

    if(endIndex > arr.length - 1){
        endIndex = arr.length - 1
    }
    

    let subArray = arr.slice(startIndex, endIndex+1);

    if(!subArray.every(Number)){
        return NaN;
    }
    let result = subArray.reduce((a,b) => a+b);

    return result;
}


module.exports = subSum;