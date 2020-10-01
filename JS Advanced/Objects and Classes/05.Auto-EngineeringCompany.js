function solve(cars) {
    let inventory = {};
    cars.forEach(line => {
        let [brand, model, qty] = line.split(' | ');
        qty = Number(qty);

        if (!inventory[brand]) {
            inventory[brand] = [];
        }
        if (!inventory[brand][model]) {
            inventory[brand][model] = qty;
        } else {
            inventory[brand][model] += qty;
        }
    });
    Object.keys(inventory).forEach(carBrand => {
        console.log(carBrand);
        Object.keys(inventory[carBrand]).forEach(carModel => console.log(`###${carModel} -> ${inventory[carBrand][carModel]}`))
    })
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Niva | 1',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
)