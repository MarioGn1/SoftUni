vectorObj = {
    add: (v1, v2) => [v1[0] + v2[0], v1[1] + v2[1]] ,
    multiply: (v1, s) => [v1[0] * s, v1[1] * s],
    length: (v1) => Math.sqrt((v1[0] * v1[0]) + (v1[1] * v1[1])),
    dot: (v1, v2) => (v1[0] * v2[0]) + (v1[1] * v2[1]),
    cross: (v1, v2) => (v1[0] * v2[1]) - (v1[1] * v2[0])
}

console.log(vectorObj.add([1, 1], [1, 0]));
console.log(vectorObj.multiply([3.5, -2], 2));
console.log(vectorObj.length([3, -4]));
console.log(vectorObj.dot([1, 0], [0, -1]));
console.log(vectorObj.cross([3, 7], [1, 0]));