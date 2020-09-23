function checkValidDistance(params) {
    let x1 = params[0];
    let y1 = params[1];
    let x2 = params[2];
    let y2 = params[3];

    let firstPointCheck = Number.isInteger(Math.sqrt(x1 * x1 + y1 * y1));
    let secondPointCheck = Number.isInteger(Math.sqrt(x2 * x2 + y2 * y2));

    let x3 = Math.abs(x1 - x2);
    let y3 = Math.abs(y1 - y2);
    let firstToSecondCheck = Number.isInteger(Math.sqrt(x3 * x3 + y3 * y3));

    console.log(`{${x1}, ${y1}} to {0, 0} ${firstPointCheck ? 'is valid' : 'is invalid'}`)
    console.log(`{${x2}, ${y2}} to {0, 0} ${secondPointCheck ? 'is valid' : 'is invalid'}`)
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} ${firstToSecondCheck ? 'is valid' : 'is invalid'}`)
}

checkValidDistance([3, 0, 0, 4])
console.log('----------')
checkValidDistance([2, 1, 1, 1])