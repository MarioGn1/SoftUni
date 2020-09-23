function sameDigits(x){
    let isAllDigitsEqual = true;
    let sum = 0;
    let digitString = x.toString();
    for (let index = 0; index < digitString.length; index++) {
        sum += Number(digitString[index]);        
    }
    let firstDigit = digitString[0];
    for (let index = 1; index < digitString.length; index++) {
        if (firstDigit != digitString[index]) {
            isAllDigitsEqual = false;
        }        
    }
    console.log(isAllDigitsEqual);
    console.log(sum);
}

//sameDigits(2222222)
sameDigits(1234)