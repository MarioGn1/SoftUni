
const oddEven = require('../02. Even or Odd/EvenOrOdd.js');
const assert = require('chai').assert;

describe('02. IsOddOrEven', function(){
    it('Shoud return undefined', () => {
        let resultEmptyParam = oddEven.isOddOrEven();
        let resultDigit = oddEven.isOddOrEven(12);
        let resultBool = oddEven.isOddOrEven(true);
        let resultObj = oddEven.isOddOrEven({});
        let resultArr = oddEven.isOddOrEven([]);
        let resultNull = oddEven.isOddOrEven([]);
        let resultFunc = oddEven.isOddOrEven(function name() {});

        assert.equal(resultEmptyParam, undefined);
        assert.equal(resultDigit, undefined);
        assert.equal(resultBool, undefined);
        assert.equal(resultObj, undefined);
        assert.equal(resultArr, undefined);
        assert.equal(resultNull, undefined);
        assert.equal(resultFunc, undefined);
    })
    it('Shoud return even', () => {
        let result = oddEven.isOddOrEven('test');

        assert.equal(result, 'even');
    })
    it('Shoud return odd', () => {
        let result = oddEven.isOddOrEven('tes');

        assert.equal(result, 'odd');
    })
})