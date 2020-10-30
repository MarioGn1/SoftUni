(() => {

    String.prototype.ensureStart = function (str) {
        if (this.startsWith(str)) {
            return this.toString();
        }
        return str + this.toString();
    }
    String.prototype.ensureEnd = function (str) {
        if (this.endsWith(str)) {
            return this.toString();
        }
        return this.toString() + str;
    }
    String.prototype.isEmpty = function () {
        return this.length === 0;
    }
    String.prototype.truncate = function (n) {
        if (n < 4) {
            return '.'.repeat(n)
        }
        if (this.length <= n) {
            return this.toString();
        }
        if (this.length > n) {
            let splitedStr = this.toString().substring(0,n).trim().split(' ')
            if (splitedStr.length > 1) {  
               // while (splitedStr.length + 3 > n) {
                    splitedStr.pop();  
               // }                             
                return splitedStr.join(' ') + '...';
            }else{
                return this.toString().substring(0, n-3)+'...'
            }
            
        }
    }
    String.format = function (str, ...replacements) {
        replacements.forEach((key, index) => {
            str = str.replace(`{${index}}`, key)
        });
        return str;
    }
})();

let str = 'the quick brown fox jumps over the lazy dog';
// str = str.ensureStart('my');
// console.log(str)
// str = str.ensureStart('hello ');
// console.log(str)
// str = str.truncate(10);
// console.log(str)
// str = str.truncate(25);
// console.log(str)
str = str.truncate(43);
console.log(str)
str = str.truncate(45);
console.log(str)
// str = str.truncate(2);
// console.log(str)
// str = String.format('The {0} {1} fox',
// 'quick', 'brown');
// console.log(str)
// str = String.format('jumps {0} {1}',
// 'dog');
// console.log(str)
