

function getFibonator() {
    let curNum = 0;
    let prevNum = 1;

    function fibonacci() {
        let temp = curNum;
        curNum += prevNum;
        prevNum = temp;
        return curNum;
    }

    return fibonacci
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
