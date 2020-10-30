function solve(inputArr) {
    let heroes = [];
    for (let i = 0; i < inputArr.length; i++) {
        let curElement = inputArr[i].split(' / ');
        let curHero = {};
        curHero.name = curElement[0];
        curHero.level = Number(curElement[1]);
        curHero.items = curElement[2] ? curElement[2].split(', ') : [];
        heroes.push(curHero);
    }

    let convertedHeroes = JSON.stringify(heroes);
    console.log(convertedHeroes);
}

solve(['Isacc / 25',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)