const assert = require('chai').assert;
const obj = require('../04. Math Enforcer/MathEnforcer');

describe('04. Math Enforcer', function () {
    let error = 'Function did not return the correct value!';

    describe('Test method addFive', function () {
        it('Shoud return undefined when wrong parameter is passed.', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.addFive('test');
            let result2 = curObj.addFive(true);
            //we can check like above for each type of parameter passed to the function

            assert.equal(result1, undefined, error);
            assert.equal(result2, undefined, error);
        })
        it('Shoud return corect value after add 5', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.addFive(5);
            let result2 = curObj.addFive(5.5);
            let result3 = curObj.addFive(-5);

            assert.equal(result1, 10, error);
            assert.equal(result2, 10.5, error);
            assert.equal(result3, 0, error);
        })
    })
    describe('Test method subtractTen', function () {
        it('Shoud return undefined when wrong parameter is passed.', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.subtractTen('test');
            let result2 = curObj.subtractTen(true);
            //we can check like above for each type of parameter passed to the function

            assert.equal(result1, undefined, error);
            assert.equal(result2, undefined, error);
        })
        it('Shoud return corect value after subtract 10', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.subtractTen(10);
            let result2 = curObj.subtractTen(10.5);
            let result3 = curObj.subtractTen(5);

            assert.equal(result1, 0, error);
            assert.equal(result2, 0.5, error);
            assert.equal(result3, -5, error);
        })
    })
    describe('Test method sum', function () {
        it('Shoud return undefined when any of the passed parameters is incorrect', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.sum('test', 2);
            let result2 = curObj.sum(2, 'test');
            //we can check like above for each type of parameter passed to the function            

            assert.equal(result1, undefined, error);
            assert.equal(result2, undefined, error);
        })
        it('Shoud return corect value after the sum is done', () => {
            let curObj = obj.mathEnforcer;
            let result1 = curObj.sum(10, 5);
            let result2 = curObj.sum(-10, 5);
            let result3 = curObj.sum(-3, 5);
            let result4 = curObj.sum(-3.3, 5);

            assert.equal(result1, 15, error);
            assert.equal(result2, -5, error);
            assert.equal(result3, 2, error);            
            assert.closeTo(result4, 1.7, 0.01, error); 
        })
    })
})