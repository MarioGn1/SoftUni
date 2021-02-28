const assert = require('chai').assert;
const sb = require('../05. String Builder/StringBuilder');

describe("05. String Builder class", function () {
    let  SB = sb.StringBuilder;
    describe('Test Constuctor', function () {        
        it('Should initialize empty array when parameter is undefined', () => {            
            let curSb = new SB();
            let result = curSb.toString();
            assert.equal(result, '', 'Constructor did not init empty array');
        })
        it('Should initialize new arr with first element the passed string', () => {            
            let curSb = new SB('test');
            let result = curSb.toString();
            assert.equal(result, 'test', 'Constructor did not init corect array');
        })
        it('Should throw error if passed parameter type is not a string', () => {                        
            assert.throws(()=>{new SB(true)});
            assert.throws(()=>{new SB(20)});
            assert.throws(()=>{new SB({})});
            //could be checked like this for all parameter types
        })
    })
    describe('Test method append', function(){
        it('Should throw error if passed parameter type is not a string', () => {                        
            let curSb = new SB('test')
            assert.throws(()=>{curSb.append(null)});
            assert.throws(()=>{curSb.append([])});
            assert.throws(()=>{curSb.append(function(){})});            
            //could be checked like this for all parameter types
        })
        it('Should append the string correctly', () => {                        
            let curSb = new SB('test')
            curSb.append(' append');
            let result = curSb.toString();
            assert.equal(result, 'test append');
        })
    })
    describe('Test method prepend', function(){
        it('Should throw error if passed parameter type is not a string', () => {                        
            let curSb = new SB('test')
            assert.throws(()=>{curSb.append(null)});
            assert.throws(()=>{curSb.append([])});
            assert.throws(()=>{curSb.append(function(){})});            
            //could be checked like this for all parameter types
        })
        it('Should prepend the string correctly', () => {                        
            let curSb = new SB(' test')
            curSb.prepend('prepend');
            let result = curSb.toString();
            assert.equal(result, 'prepend test');
        })

    })
    describe('Test method insertAt', function(){
        it('Should throw error if first passed parameter type is not a string', () => {                        
            let curSb = new SB('test')
            assert.throws(()=>{curSb.append(null)});
            assert.throws(()=>{curSb.append([])});
            assert.throws(()=>{curSb.append(function(){})});            
            //could be checked like this for all parameter types
        })
        it('Should insert correctly the string at the given index', () => {                        
            let curSb = new SB('test at index')
            curSb.insertAt(' insert', 4);
            let result = curSb.toString();
            assert.equal(result, 'test insert at index');
        })

    })
    describe('Test method remove', function(){
        it('Should remove correct amount of text', () => {                        
            let curSb = new SB('test text remove')
            curSb.remove(4, 5);
            let result = curSb.toString();
            assert.equal(result, 'test remove');
        })

    })
    describe('Test method toString', function(){
        it('Should return correct string', () => {                        
            let curSb = new SB('test')
            curSb.append(' toString!');
            curSb.prepend('Lets ');
            let result = curSb.toString();
            assert.equal(result, 'Lets test toString!');
        })
    })
})