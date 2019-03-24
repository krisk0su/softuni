let isSymmetric = require('./CheckSymmetry');
let assert = require('chai').assert;

describe('works fine', function(){

    it('takes arr as argument', function(){
        let arr = [1, 2, 3];

        assert.equal(true, Array.isArray(arr));
    });

    it('returns false if its not array', function(){
        let result = isSymmetric(15);

        assert.equal(false, result);
    })
    it('is symmetric', function(){

        let result = isSymmetric([1, 2, 2, 1]);

        assert.equal(true, result);
    })
    it('is non symmetric', function(){
        let result = isSymmetric([1, 2, 3, 4]);

        assert.equal(false, result);
    })
})
