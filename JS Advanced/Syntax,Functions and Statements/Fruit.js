function calcFruitPrice(fruit, weight, price){
    let realWeight = weight/1000;
    console.log(`I need $${((weight/1000) * price).toFixed(2)} to buy ${realWeight.toFixed(2)} kilograms ${fruit}.`);
}

calcFruitPrice('orange', 2500, 1.80);
calcFruitPrice('apple', 1563, 2.35);