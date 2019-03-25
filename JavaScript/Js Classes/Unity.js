class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(otherRat){
        if(otherRat instanceof Rat){
            this.unitedRats.push(otherRat)
        }
    }

    getRats(){
        return this.unitedRats;
    }

    toString(){
        let result = this.name;
        while(this.unitedRats.length > 0){
            let rr = this.unitedRats.shift();
            result+='\n' + `##${rr.name}`
        }
        return result;
    }
}
