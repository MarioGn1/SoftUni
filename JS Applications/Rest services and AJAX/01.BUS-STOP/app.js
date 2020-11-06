function getInfo() {    
    let id = document.getElementById('stopId').value;
    let resultStop = document.getElementById('stopName');
    let resultBuses = document.getElementById('buses');

    let url = `https://judgetests.firebaseio.com/businfo/${id}.json `;
    const httpRequest = new XMLHttpRequest();    

    httpRequest.addEventListener('loadend', loadInfo);

    function loadInfo(e) {
        resultBuses.innerHTML = '';
        if (httpRequest.status === 200) {
            let obj = JSON.parse(httpRequest.responseText);
            resultStop.innerText = obj.name;
            Object.entries(obj.buses).forEach(bus => {
                let liElement = document.createElement('li');
                liElement.innerText = `Bus ${bus[0]} arrives in ${bus[1]}`;
                resultBuses.appendChild(liElement);
            })  
        } else {
            resultStop.innerText = 'Error';
        }
    }

    httpRequest.open('GET', url);
    httpRequest.send();
}