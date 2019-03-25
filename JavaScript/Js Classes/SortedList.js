class result{
    constructor(arr){
        this.arr = arr;
    }
    add(elemenent){
        this.arr.push(element);
    } 
    remove(index){
        this.arr.splice(index,1);
    }
    get(index){
        return this.arr[index];
    }
}