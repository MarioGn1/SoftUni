function extractSequence(myArr) {
    let minNumber = Number.MIN_SAFE_INTEGER
    myArr.forEach(el => {
        if (minNumber < Number(el)) {
            console.log(el)
            minNumber = el
        }
    })
}

extractSequence([20, 
    3, 
    2, 
    15,
    6, 
    1]
    
)