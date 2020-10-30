function build(myArray) {
    let finalArr = [];
    let fillCounter = 1;
    myArray.forEach(element => {
        if (element === 'add') {
            finalArr.push(fillCounter);
        }
        if (element === 'remove') {
            finalArr.pop();
        }
        fillCounter++;
    });
    finalArr.length ? finalArr.forEach(el => console.log(el)):console.log('Empty');
}

build(['add', 
'add', 
'remove', 
'add', 
'add']
)

build(['remove', 
'remove', 
'remove']
)