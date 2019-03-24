function printDeckOfCards(arr){

   try{
    let result = arr.reduce(function(acc, current, index){

        let face;
        let suit;
        if(current.includes('10')){
            face = current[0]+current[1];
            suit = current[2];
        }else{
            face = current[0];
            suit = current[1];
        }
        
        let res = makeCard(face, suit);
        acc[index] = res;
        return acc;
    }, []);
    console.log(result.join(' '));
   }catch(error){
       throw Error(error)
   }
   

    
    function makeCard(face, suit){

        let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    
        let validSuits = {
            'S' : '\u2660',
            'H' : '\u2665',
            'D' : '\u2666',
            'C' : '\u2663'
        };
    
    
            if(!validFaces.includes(face)){
                throw Error(`Invalid card: ${face}${suit}`);
            }
    
            let keys = Object.keys(validSuits);
    
            if(!keys.includes(suit)){
                throw Error(`Invalid card: ${face}${suit}`);
            }
    
            
    
            let card = {
                face:face,
                suit: validSuits[suit],
                toString: function(){
                    return this.face+this.suit;
                }
            };

            let dunno = card.face+card.suit;
            return dunno;
    
    }
}
printDeckOfCards(['AS', '10D', 'KH', '2C']);