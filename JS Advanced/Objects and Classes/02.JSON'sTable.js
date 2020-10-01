function solve(objs) {
    let employees = [];
    employees = objs.map(el => JSON.parse(el));    
    
    let output = '<table>\n';
    for (let i = 0; i < employees.length; i++) {
        output +='\t<tr>\n';
        Object.values(employees[i]).forEach(prop => output += `\t\t<td>${prop}</td>\n`);
        output +='\t</tr>\n';
        
    }
    output +='</table>';

    console.log(output);
}

solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
)