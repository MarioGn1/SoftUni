function solve(products) {
    let catalog = {};
    products.sort((a, b) => (a.toUpperCase()).localeCompare(b.toUpperCase()))
        .forEach(el => {            
            if (!catalog[el[0]]) {
                catalog[el[0]] = [];
            }
            catalog[el[0]].push(el);

        });

    Object.keys(catalog).forEach(letter => {
        console.log(`${letter}`);
        catalog[letter].forEach(el => {
            let [productName, qty] = el.split(' : ');
            console.log(`  ${productName}: ${qty}`)
        });
    });
}

solve(['Banana : 2',
    "Rubic's Cube : 5",
    'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']

)