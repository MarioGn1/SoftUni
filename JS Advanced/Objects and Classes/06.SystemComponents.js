function solve(input) {
    let inventory = {}
    input.forEach(line => {
        let [system, component, subcomponent] = line.split(' | ');

        if (!inventory[system]) {
            inventory[system] = {};
        }
        if (!inventory[system][component]) {
            inventory[system][component] = [];
        }

        inventory[system][component].push(subcomponent);
    });

    Object.entries(inventory).sort((a, b) => {
        return Object.entries(b[1]).length - Object.entries(a[1]).length || a[0].localeCompare(b[0]);
    }).forEach(sys => {
        console.log(sys[0]);
        Object.entries(sys[1]).sort((a, b) => {
            return b[1].length - a[1].length;
        }).forEach(comp => {
            console.log(`|||${comp[0]}`);
            comp[1].forEach(sub => {
                console.log(`||||||${sub}`);
            })
        })
    })
}

solve(['SULS | Main Site | Home Page',
    'SULS | Main Site | Login Page',
    'SULS | Main Site | Register Page',
    'SULS | Judge Site | Login Page',
    'SULS | Judge Site | Submittion Page',
    'Lambda | CoreA | A23',
    'SULS | Digital Site | Login Page',
    'Lambda | CoreB | B24',
    'Lambda | CoreA | A24',
    'Lambda | CoreA | A25',
    'Lambda | CoreC | C4',
    'Indice | Session | Default Storage',
    'Indice | Session | Default Security']
)