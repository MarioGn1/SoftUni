function formatCalories(params) {
    let outputString = ''
    for (let index = 0; index < params.length; index += 2) {
        if (index == 0) {
            outputString = outputString + `${params[index]}: ${params[index + 1]}`;
        } else {
            outputString = outputString + `, ${params[index]}: ${params[index + 1]}`;
        }
    }
    console.log(`{ ${outputString} }`);
}

formatCalories(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);
formatCalories(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']);
