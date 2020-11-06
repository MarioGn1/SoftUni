const assert = require('chai').assert;
const paymentPack = require('../06. Payment Package/PaymentPackage');

describe('06. Payment Package', function(){
    let PPackage = paymentPack.PaymentPackage;
    describe('Test constructor', function(){
        it('Should initialize correctly an object', () =>{
            let curPackage = new PPackage('test', 10);
            let name = curPackage.name;
            let value = curPackage.value;
            let VAT = curPackage.VAT;
            let active = curPackage.active;

            assert.equal(name, 'test')
            assert.equal(value, 10)
            assert.equal(VAT, 20)
            assert.equal(active, true)
        })
        it('Should throw error when fist param is not a string', () =>{           
            assert.throws(() => {new PPackage(20, 10)});
            assert.throws(() => {new PPackage([], 10)});
            //can be chacked for each type of the given first parameter
        })
        it('Should throw error when fist param is empty string', () =>{           
            assert.throws(() => {new PPackage('', 10)});           
        })
        it('Should throw error when second param is not of type number', () =>{           
            assert.throws(() => {new PPackage('test', 'test')});           
            assert.throws(() => {new PPackage('test', null)});
            //can be chacked for each type of the given first parameter           
        })
        it('Should throw error when second param is negative number', () =>{           
            assert.throws(() => {new PPackage('test', -1)});                             
        })
    })
    describe("Test setter 'name'", function(){
        it('Should throw error when given param is not a string', () =>{
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.name = 20});
            assert.throws(() => {curPackage.name = null});
            //can be chacked for each type of the given parameter
        })
        it('Should throw error when given param is empty string', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.name = ''});          
        })
        it('Should set property with corect value', () => {
            let curPackage =  new PPackage('test', 10);
            curPackage.name = 'correct';
            let result = curPackage.name;
            assert.equal(result, 'correct');
        })
    })
    describe("Test setter 'value'", function(){
        it('Should throw error when given param is not of type number', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.value = {}});
            assert.throws(() => {curPackage.value = 'string'});
            //can be chacked for each type of the given parameter         
        })
        it('Should throw error when given param is negative number', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.value = -1});                              
        })
        it('Should set property with corect value', () => {
            let curPackage =  new PPackage('test', 10);
            curPackage.value = 15;
            let result = curPackage.value;
            assert.equal(result, 15);
        })
    })
    describe("Test setter 'VAT'", function(){
        it('Should throw error when given param is not of type number', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.VAT = {}});
            assert.throws(() => {curPackage.VAT = 'string'});
            //can be chacked for each type of the given parameter         
        })
        it('Should throw error when given param is negative number', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.VAT = -10});                              
        })
        it('Should set property with corect value', () => {
            let curPackage =  new PPackage('test', 10);
            curPackage.VAT = 15;
            let result = curPackage.VAT;
            assert.equal(result, 15);
        })
    })
    describe("Test setter 'active'", function(){
        it('Should throw error when given param is not of type boolean', () =>{           
            let curPackage =  new PPackage('test', 10);         
            assert.throws(() => {curPackage.active = [false]});
            assert.throws(() => {curPackage.active = 'true'});
            //can be chacked for each type of the given parameter         
        })
        it('Should set property with corect value', () => {
            let curPackage =  new PPackage('test', 10);
            curPackage.active = false;
            let result = curPackage.active;
            assert.equal(result, false);
        })
    })
    describe("Test method toString", function(){
        it('Should return correct string when active is false', () => {
            let curPackage =  new PPackage('Test', 10);
            curPackage.active = false;
            let actual = [
                `Package: Test` + ' (inactive)',
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): ${10 * (1 + 20 / 100)}`
              ];
              actual = actual.join('\n');
            let real = curPackage.toString()
            assert.equal(real, actual);
        })
        it('Should return correct string when active is true', () => {
            let curPackage =  new PPackage('Test', 10);            
            let actual = [
                `Package: Test`,
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): ${10 * (1 + 20 / 100)}`
              ];
              actual = actual.join('\n');
            let real = curPackage.toString()
            assert.equal(real, actual);
        })
    })
})