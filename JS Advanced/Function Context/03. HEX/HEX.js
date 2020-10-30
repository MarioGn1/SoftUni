class Hex{
    constructor(value){
        this.value = value;
    }
    valueOf(){
        return this.value;
    }

    toString(){
        return '0x' + this.value.toString(16).toUpperCase();
    }

    plus(number){
        if (Number.isInteger(number)) {            
            return new Hex(this.value + number)
        }else{
            return new Hex(this.value + number.value)
        }
    }
    minus(number){
        if (Number.isInteger(number)) {            
            return new Hex(this.value - number)
        }else{
            return new Hex(this.value - number.value)
        }
    }

    parse(string){
        let hexNum = string.substring(2).toLowerCase()
        return parseInt(string,16)
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('f'))

// 0xFF
// 0xF
// true
