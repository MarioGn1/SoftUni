function solve(requirements) {
    let storage = {
        engines: [{ power: 90, volume: 1800 }, { power: 120, volume: 2400 }, { power: 200, volume: 3500 }],
        hatchback: { type: 'hatchback', color: "" },
        coupe: { type: 'coupe', color: "" }
    }
    let car = {}

    let { model, power, color, carriage, wheelsize } = requirements;
    car.model = model;
    car.engine = storage.engines.find(el => el.power >= power);
    car.carriage = carriage == 'hatchback' ? storage.hatchback : storage.coupe;
    car.carriage.color = color;
    car.wheels = (wheelsize % 2 === 0 ? new Array(4).fill(wheelsize -= 1) : new Array(4).fill(wheelsize));

    return car;
}

// console.log(solve({
//     model: 'VW Golf II',
//     power: 90,
//     color: 'blue',
//     carriage: 'hatchback',
//     wheelsize: 14
// }))

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}))