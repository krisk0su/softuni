function makeCard(face, suit){

    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let validSuits = {
        'S' : '\u2660',
        'H' : '\u2665',
        'D' : '\u2666',
        'C' : '\u2663'
    };


        if(!validFaces.includes(face)){
            throw Error('Invalid state');
        }

        let keys = Object.keys(validSuits);

        if(!keys.includes(suit)){
            throw Error('Invalid state');
        }

        return face+validSuits[suit];

        let card = {
            face:face,
            suit: validSuits[suit],
            toString: function(){
                return this.face+this.suit;
            }
        };

}

printDeckOfCards(['AS', '10D', 'KH', '2C']);