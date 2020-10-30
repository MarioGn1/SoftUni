function solve(rows, cols) {
    let matrix = [...Array(rows)].map(e => Array(cols))

    let topLimit = 0;
    let bottomLimit = rows;
    let leftLimit = 0;
    let rightLimit = cols;

    let counter = 1;
    while (counter <= rows * cols) {
        for (let i = leftLimit; i < rightLimit; i++) {
            matrix[topLimit][i] = counter;
            counter++;
        }
        topLimit++;

        for (let i = topLimit; i < bottomLimit; i++) {
            matrix[i][rightLimit - 1] = counter;
            counter++;
        }
        rightLimit--;

        for (let i = rightLimit - 1; i >= leftLimit; i--) {
            matrix[bottomLimit - 1][i] = counter;
            counter++;
        }
        bottomLimit--;

        for (let i = bottomLimit - 1; i >= topLimit; i--) {
            matrix[i][leftLimit] = counter;
            counter++;
        }
        leftLimit++;
    }

    matrix.forEach(row => console.log(row.join(' ')));
}
solve(3, 3)
solve(5, 5)
solve(5, 4)