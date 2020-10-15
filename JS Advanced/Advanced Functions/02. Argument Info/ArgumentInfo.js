function solve(...args) {
    let counts = [];
    for (let i = 0; i < args.length; i++) {
        console.log(`${typeof args[i]}: ${args[i]}`)
        if (!counts[typeof args[i]]) {
            counts[typeof args[i]] = 0;
        }
        counts[typeof args[i]]++;
    }
    
    Object.keys(counts)
        .map(el => [el, counts[el]])
        .sort(sortArgs).forEach(el => {
            console.log(`${el[0]} = ${el[1]}`);
        });

    function sortArgs(a, b) {
        result = b[1] - a[1];
        return result;
    }
}

solve('mario', 22, function name(params) { },function name(params) { },function name(params) { }, true, false,false)