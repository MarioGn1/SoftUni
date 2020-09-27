function rotate(myArr) {
    let rotationCount = Number(myArr.pop());
    for (let i = 0; i < rotationCount % myArr.length; i++) {
        let curLast = myArr.pop(); 
        myArr.unshift(curLast);     
    }
    console.log(myArr.join(' '));
}

// rotate(['1', 
// '2', 
// '3', 
// '4', 
// '2']
// )

rotate(['Banana', 
'Orange', 
'Coconut', 
'Apple', 
'15']
)
