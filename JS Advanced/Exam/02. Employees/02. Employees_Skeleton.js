function solveClasses() {
    class Developer{
        constructor(firstName, lastName){
            this.firstName = firstName;
            this.lastName = lastName;
            this.baseSalary = 1000;
            this.tasks = [];
            this.experience = 0;
        }
        addTask(id, taskName, priority){
            let curTask = { id, taskName, priority}
            if(priority === 'high'){
                this.tasks.unshift(curTask);
            } else {
                this.tasks.push(curTask);
            }
            return `Task id ${id}, with ${priority} priority, has been added.`
        }
        doTask(){
            if (this.tasks.length === 0) {
                return `${this.firstName}, you have finished all your tasks. You can rest now.`;
            }
                let taskName = this.tasks.shift().taskName;
                return taskName;            
        }
        getSalary(){
            return `${this.firstName} ${this.lastName} has a salary of: ${this.baseSalary}`;
        }
        reviewTasks(){
            let result = 'Tasks, that need to be completed:';
            this.tasks.forEach(el => result += `\n${el.id}: ${el.taskName} - ${el.priority}`);
            return result;
        }
    }

    class Junior extends Developer{
        constructor(firstName, lastName, bonus, experience){
            super(firstName, lastName);
            this.baseSalary += bonus;
            this.tasks = [];
            this.experience = experience;
        }
        learn(years){
            this.experience += years;
        }
    }

    class Senior extends Developer{
        constructor(firstName,lastName, bonus, experience){
            super(firstName,lastName);
            this.baseSalary += bonus;
            this.tasks = [];
            this.experience = experience + 5;
        }

        changeTaskPriority(taskId){
            let curTask = this.tasks.find(el => el.id === taskId);
            let index = this.tasks.indexOf(curTask);
            this.tasks.splice(index, 1);
            if (curTask.priority === 'high') {
                curTask.priority === 'low';                              
                this.tasks.push(curTask);
            }else if (curTask.priority === 'low') {
                curTask.priority = 'high';                              
                this.tasks.unshift(curTask);
            }
            return curTask;
        }
    }

    return {
        Developer,
        Junior,
        Senior
    }
}

let classes = solveClasses();
// const developer = new classes.Developer("George", "Joestar");
// console.log(developer.addTask(1, "Inspect bug", "low"));
// console.log(developer.addTask(2, "Inspect Me", "high"));
// console.log(developer.doTask());

// console.log(developer.getSalary());
// console.log(developer.reviewTasks());

// const developer = new classes.Junior("Jonathan", "Joestar", 200, 2);
// console.log(developer.addTask(1, "Inspect bug", "low"));
// console.log(developer.addTask(2, "Inspect Me", "high"));
// console.log(developer.doTask());
// developer.learn(2);
// console.log(developer.getSalary());
// console.log(developer.reviewTasks());
// console.log(developer.experience);

const developer = new classes.Senior("Jonathan", "Joestar", 200, 2);
console.log(developer.addTask(1, "Inspect bug", "low"));
console.log(developer.addTask(2, "Inspect Me", "high"));
console.log(developer.doTask());
console.log(developer.getSalary());
console.log(developer.reviewTasks());



// const junior = new classes.Junior("Jonathan", "Joestar", 200, 2);
// console.log(junior.getSalary());

// const senior = new classes.Senior("Joseph", "Joestar", 200, 2);
// senior.addTask(1, "Create functionality", "low");
// senior.addTask(2, "Update functionality", "high");
// console.log(senior.changeTaskPriority(1)["priority"]);
// console.log(senior.experience);



