function mySort(myArr) {
    function orderByNameLength(a, b) {
        if (a.length !== b.length) {
            return a.length - b.length;
        } else {
            return a.toLowerCase().localeCompare(b.toLowerCase());
        }

    }
    
    myArr.sort(orderByNameLength)
        .forEach(el => console.log(el));
}

// mySort(['alpha',
//     'beta',
//     'gamma']
// )

// mySort(['Isacc', 
// 'Theodor', 
// 'Jack', 
// 'Harrison', 
// 'George']
// )

mySort(['test', 
'Deny', 
'omen', 
'Default']
)