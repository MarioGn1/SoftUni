function solve(worker) {
    const { weight, experience, dizziness } = worker;
    if (dizziness) {
        worker.levelOfHydrated += weight * 0.1 * experience;
        worker.dizziness = false;
    }
    return worker;
}

console.log(solve({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));