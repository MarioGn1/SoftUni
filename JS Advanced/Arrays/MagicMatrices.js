function checkMagic(myArr) {
    let sumBase = sum(myArr[0])
    let isEqual = true;

    function sum(arr) {
        return arr.reduce(function (a, b) {
            return a + b;
        }, 0);
    }        

    for (let i = 0; i < myArr.length; i++) {
        let curRowSum = sum(myArr[i]);
        isEqual = sumBase === curRowSum;
        if (!isEqual) {
            break;
        }

        let columnSum = 0;
        for (let j = 0; j < myArr.length; j++) {
            columnSum += myArr[i][j];

        }
        isEqual = sumBase === columnSum;
        if (!isEqual) {
            break;
        }
    }
    console.log(isEqual)
}

checkMagic([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]
)

checkMagic([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]
)

checkMagic([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
)