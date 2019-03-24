let sum = require('./sumOfNumbers');
const assert = require('chai').assert;

describe('sum', function(){

    it('sum is a function', function(){

        let type = typeof(sum);

        assert.equal("function", type);
    })
    it('the argument is array', function(){

        let arr = [1,2,3];

        let res = sum(arr);

        assert.equal(true, Array.isArray(arr));
    })
    it('the returned value is the sum of the array', function(){

        let arr = [1,2,3];

        let res = sum(arr);

        assert.equal(6, res);
    })
})