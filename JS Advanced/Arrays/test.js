let a = 2;
console.log('I want ${a}')

let defField = [[],
    [],
    []];

    console.log(checkFreeSpaces())

    function checkFreeSpaces(){
        return defField.some(arr => arr.some(el => el === false))
    }