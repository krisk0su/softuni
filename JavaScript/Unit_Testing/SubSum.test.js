const subsum = require('./SubSum');
const assert = require('chai').assert;
console.log(subsum)
describe('myFunc', function(){
    it('should work properly', function(){

        let arr = [4,5,6];

        let result = subsum(arr, 0 , 2);

        assert.equal(result, 15);
    })
});