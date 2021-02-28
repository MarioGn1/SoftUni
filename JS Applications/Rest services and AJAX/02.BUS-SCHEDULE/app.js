function solve() {
    let nextId = 'depot';
    let stopName = '';
    let infoElement = document.getElementsByClassName('info')[0];
    let departBtn = document.getElementById('depart');
    let arriveBtn = document.getElementById('arrive');

    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${nextId}.json`)
            .then(res => res.json())
            .then(data => {
                if (data !== null && data.hasOwnProperty('name') && data.hasOwnProperty('next')) {
                    console.log(data)
                    stopName = data.name;
                    nextId = data.next;
                    infoElement.innerText = `Next stop ${stopName}`;
                    departBtn.disabled = true;
                    arriveBtn.disabled = false;
                } else {
                    infoElement.innerText = `Error`;
                    departBtn.disabled = true;
                    arriveBtn.disabled = true;
                }
            })
    }

    function arrive() {
        infoElement.innerText = `Arriving at ${stopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();