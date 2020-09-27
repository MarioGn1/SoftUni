function solve(coords) {
    rowLength = coords[0];
    colLength = coords[1];
    coordRow = coords[2];
    coordCol = coords[3];

    let matrix = [...Array(rowLength)].map(e => Array(colLength))
    matrix[coordRow][coordCol] = 1;

    for (let i = 0; i < rowLength; i++) {
        for (let j = 0; j < colLength; j++) {
            if (i - coordRow !== 0 || j - coordCol !== 0) {
                let rowStep = Math.abs(i - coordRow)
                let colStep = Math.abs(j - coordCol)
                let criteria = Math.max(rowStep,colStep)
                matrix[i][j] = criteria + 1;
            }
        }
    }
    matrix.forEach(row => console.log(row.join(' ')));
}

solve([4, 4, 0, 0])
solve([5, 5, 2, 2])
solve([3, 3, 2, 2])