function solve(inputArr) {
    let juices = {};
    let orderOfBottles = {};
    inputArr.forEach(el => {               
        let [name, qty] = el.split(' => ');
        qty = Number(qty);        

        if (!juices[name]) {
            juices[name] = qty;            
        }else{            
            juices[name] += qty;                 
        }
        if (juices[name] >= 1000) {
            orderOfBottles[name] = 0;
        }
    });

    Object.keys(orderOfBottles).forEach(element => {        
            console.log(`${element} => ${Math.floor(juices[element]/ 1000)}`)                
    });
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

)