let isOddOrEven = require('./EvenOrOdd');
let assert = require('chai').assert;
let expect = require('chai').expect;


describe('even or odd', function(){
    it('!string return undefined',function(){
        let result = isOddOrEven(15);

        assert.equal(undefined, result);
    })
    it('return even', function(){
        let result = isOddOrEven("even");

        assert.equal("even", result);
    })
    it('return odd', function(){
        let result = isOddOrEven("odd");

        assert.equal('odd', result);
    })
});