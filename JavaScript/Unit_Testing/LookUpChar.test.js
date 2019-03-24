let lookupChar = require('./LookUpChar');
let assert = require('chai').assert;

describe('working', function(){
    it('if non string undefined', function(){
        let result = lookupChar(10, 15);

        assert.equal(undefined, result);
    });

    it('if second param not number', function(){
        let result = lookupChar('i am string', null);

        assert.equal(undefined, result);
    })
    it('index >= string.length', function(){
        let result = lookupChar('kris', 15);
        let output = 'Incorrect index';
        assert.equal(output, result);
    })
    it('index < 0', function(){
        let result = lookupChar('kris', -5);
        let output = 'Incorrect index';
        assert.equal(output, result);
    })
    it('correct output', function(){
        let result = lookupChar('kris', 0);
        let output = "k";
        assert.equal(output, result);
    })

});