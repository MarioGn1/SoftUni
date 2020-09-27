function print(array) {
    let step = Number(array.pop());
    array.filter((el, i) => i % step === 0)
        .forEach(element => console.log(element));
}

print(['1', 
'2',
'3', 
'4', 
'5', 
'6']

)

print(['dsa',
'asd', 
'test', 
'tset', 
'2']
)