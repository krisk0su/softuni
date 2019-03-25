class Stringer{
    constructor(innerString , innerLength){
        this.innerString  = innerString ;
        this.innerLength = innerLength;
        this.keeper = innerString;
    }

    increase(length) {
        this.innerLength += length;
    }
    decrease(length){
        if(this.innerLength - length < 0){
            this.innerLength = 0;
        }
        else{
            this.innerLength -= length;
        }
    }
    toString(){
        if(this.keeper.length > this.innerLength){
            return this.keeper.substring(0, this.innerLength)+'...';
        }
        else{
            return this.keeper;
        }
    }
}

