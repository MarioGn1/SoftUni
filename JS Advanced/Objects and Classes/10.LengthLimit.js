class Stringer{
    #innerString; 
    #innerLength;   
    constructor(singleString, length){
        this.#innerString = singleString;
        this.#innerLength = length;
    }

    get innerString(){return this.#innerString};
    get innerLength(){return this.#innerLength};
    set innerLength(value){        
        if (value < 0) {
            this.#innerLength = 0;
        }else{
            this.#innerLength = value;
        }
    }

    increase(length){
        this.innerLength += length;
    }

    decrease(length){
        this.innerLength -= length;
    }

    toString(){
        let output = '';
        if (this.#innerString.length > this.#innerLength) {
            if (this.#innerLength === 0) {
                output = '...';
            }else{
            output = this.#innerString.slice(0, this.#innerLength) + '...';
            }
        }else{
            output = this.#innerString;
        }
        return output;
    }
}

let test = new Stringer("Test", 5);
console.log(test.toString()); // Test

test.decrease(3);
console.log(test.toString()); // Te...

test.decrease(5);
console.log(test.toString()); // ...

test.increase(4); 
console.log(test.toString()); // Test


