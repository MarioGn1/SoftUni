function solve(myArr) {
    let sortedArr = myArr.map(row => row.split(' ').map(el => Number(el)));
    let mainSum = 0, secondarySum = 0;
    for (let row = 0; row < sortedArr.length; row++) {
        mainSum += sortedArr[row][row];
        secondarySum += sortedArr[row][sortedArr.length - row - 1];
    }
    if (mainSum === secondarySum) {
        for (let row = 0; row < sortedArr.length; row++) {
            for (let col = 0; col < sortedArr.length; col++) {
                if (row + col !== row + row && row + col !== row + (sortedArr.length - row - 1)) {
                    sortedArr[row][col] = mainSum;
                }                
            }            
        }
    }
    sortedArr.forEach(row => console.log(row.join(' ')));
}


// solve(['1 1 1',
// '1 1 1',
// '1 1 0']
// )

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
)