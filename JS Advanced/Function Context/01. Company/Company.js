class Company {
    constructor() {
        this.departments = [];
    }

    validate(arg) {
        if (!arg || arg < 0) {
            throw new Error('Invalid input!');
        }
    }
    
    addEmployee(username, salary, position, department) {
        for (let arg of [username, salary, position, department]) {
            this.validate(arg);
        }
        if (!this.departments[department]) {
            this.departments[department] = [];
        }
        this.departments[department].push({
            username,
            salary,
            position,
        })
        return `New employee is hired. Name: ${username}. Position: ${position}`;
    }

    bestDepartment() {
        let bestDepartment = '';
        let maxAvrSalary = 0;
        let employes = null;
        Object.keys(this.departments).forEach(depart => {
            let totalSalary = 0;
            this.departments[depart].forEach(employee => totalSalary += employee.salary);
            if (totalSalary / this.departments[depart].length > maxAvrSalary) {
                bestDepartment = depart;
                maxAvrSalary = totalSalary / this.departments[depart].length;
                employes = this.departments[depart];
                employes.sort(compare);
            }
        });

        function compare(a, b) {
            if (b.salary - a.salary !== 0) {
                return b.salary - a.salary;
            } else {
                return a.username.localeCompare(b.username)
            }
        }

        let result = `Best Department is: ${bestDepartment}\n` + `Average salary: ${maxAvrSalary.toFixed(2)}\n`;
        employes.forEach(emp => result += `${emp.username} ${emp.salary} ${emp.position}\n`);

        return result.trim();
    }
}

let c = new Company();
// c.addEmployee("Stanimir", 2000, "engineer", "Construction");
// c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
// c.addEmployee("Slavi", 500, "dyer", "Construction");
// c.addEmployee("Stan", 2000, "architect", "Construction");
// c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
// c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
// c.addEmployee("Gosho", 1350, "HR", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());

