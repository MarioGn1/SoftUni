const assert = require('chai').assert;
const charLookup = require('../03. Char Lookup/CharLookup');

describe('03. LookupChar', function(){
    it('Should return undefined when accept incorect parameters', () =>{ 
        function test() {};
        let error = 'The function did not return the correct result'; 

        let checkFirst = charLookup.lookupChar(2, 2);
        let checkSecond = charLookup.lookupChar('test', 'test');
        let floatFirst = charLookup.lookupChar(3.5, 2);
        let floatSecond = charLookup.lookupChar('test', 3.5);
        let missingParams = charLookup.lookupChar();
        let missingSecond = charLookup.lookupChar('test');
        let boolCheckFirst = charLookup.lookupChar(true);
        let boolCheckSecond = charLookup.lookupChar('test', true);
        let arrCheckFirst = charLookup.lookupChar([]);
        let arrCheckSecond = charLookup.lookupChar('test', []);
        let objCheckFirst = charLookup.lookupChar({});
        let objCheckSecond = charLookup.lookupChar('test', {});
        let funcCheckFirst = charLookup.lookupChar(test());
        let funcCheckSecond = charLookup.lookupChar('test', test());
        let nullCheckFirst= charLookup.lookupChar(null);
        let nullCheckSecond = charLookup.lookupChar('test', null);

        assert.equal(checkFirst, undefined, error);
        assert.equal(checkSecond, undefined, error);
        assert.equal(floatFirst, undefined, error);
        assert.equal(floatSecond, undefined, error);
        assert.equal(missingParams, undefined, error);
        assert.equal(missingSecond, undefined, error);
        assert.equal(boolCheckFirst, undefined, error);
        assert.equal(boolCheckSecond, undefined, error);
        assert.equal(arrCheckFirst, undefined, error);
        assert.equal(arrCheckSecond, undefined, error);
        assert.equal(objCheckFirst, undefined, error);
        assert.equal(objCheckSecond, undefined, error);
        assert.equal(funcCheckFirst, undefined, error);
        assert.equal(funcCheckSecond, undefined, error);
        assert.equal(nullCheckFirst, undefined, error);
        assert.equal(nullCheckSecond, undefined, error);
    })
    it("Should return 'Incorrect index'", () => {
        let error = 'The function did not return the correct result'; 

        let negativeIndex = charLookup.lookupChar('test', -1);
        let bigerThanLength = charLookup.lookupChar('test', 5);
        let equalToLength = charLookup.lookupChar('test', 4);

        assert.equal(negativeIndex, 'Incorrect index', error);
        assert.equal(bigerThanLength, 'Incorrect index', error);
        assert.equal(equalToLength, 'Incorrect index', error);
    })
    it("Should return corect result", () => {
        let error = 'The function did not return the correct result'; 

        let result1 = charLookup.lookupChar('test', 0);
        let result2 = charLookup.lookupChar('test', 2);        

        assert.equal(result1, 't', error);
        assert.equal(result2, 's', error);        
    })
})