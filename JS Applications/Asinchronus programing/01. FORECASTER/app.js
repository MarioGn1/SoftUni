function attachEvents() {
    let urlLocations = 'https://judgetests.firebaseio.com/locations.json'
    let locationEl = document.getElementById('location');
    let submitBtnEl = document.getElementById('submit');
    let forecastDivEl = document.getElementById('forecast');
    let divCurConditionEl = document.getElementById('current');
    let divUpcomingEl = document.getElementById('upcoming');
    let symbols = {
        sunny: '&#x2600;',
        partlySunny: '&#x26C5;',
        overcast: '&#x2601;',
        rain: '&#x2614;',
        degrees: '&#176;'
    }


    submitBtnEl.addEventListener('click', submitLocation);

    async function submitLocation(e) {
        try {            
            let resLocations = await fetch(urlLocations);
            let dataLocations = await resLocations.json();

            let code = locationEl.value;
            if (Object.values(dataLocations).find(el => el.name === code)) {
                checkForExistingInfo();
                let curDestination = Object.values(dataLocations).find(el => el.name === code)
                code = curDestination.code;

                let urlCurCondition = `https://judgetests.firebaseio.com/forecast/today/${code}.json `;
                let urlUpcomingDays = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;

                let curCondition = await fetch(urlCurCondition);
                let upcomingDays = await fetch(urlUpcomingDays);
                
                let dataCurCondition = await curCondition.json();
                let dataUpcomingDays = await upcomingDays.json();
                
                createCurConditionVizualization(dataCurCondition);
                createUpcomingVisualization(dataUpcomingDays)

                forecastDivEl.style.display = 'block';
                locationEl.value = '';
            } else {
                throw new Error('Invalide code!')
            }
        } catch (error) {
            checkForExistingInfo();
            let error1 = document.createElement('div')
            let error2 = document.createElement('div')
            error1.innerHTML = 'Error';
            error2.innerHTML = 'Error';
            error1.classList.add('forecasts');
            error2.classList.add('forecast-info');
            divCurConditionEl.appendChild(error1);
            divUpcomingEl.appendChild(error2);
            forecastDivEl.style.display = 'block';
        }
        e.preventDefault();
    }
    function createCurConditionVizualization(data) {        
        let divForecastsEl = document.createElement('div');
        let symbolSpanEl = document.createElement('span');
        let dataSpanEl = document.createElement('span');
        let townSpanEl = document.createElement('span');
        let degreesSpanEl = document.createElement('span');
        let conditionSpanEl = document.createElement('span');

        divForecastsEl.classList.add('forecasts');
        symbolSpanEl.classList.add(...['condition', 'symbol']);
        dataSpanEl.classList.add('condition');
        townSpanEl.classList.add('forecast-data');
        degreesSpanEl.classList.add('forecast-data');
        conditionSpanEl.classList.add('forecast-data');

        symbolSpanEl.innerHTML = chooseWeatherSymbol(data.forecast.condition);
        townSpanEl.innerHTML = data.name;
        degreesSpanEl.innerHTML = `${data.forecast.low}${symbols.degrees}/${data.forecast.high}${symbols.degrees}`;
        conditionSpanEl.innerHTML = data.forecast.condition;

        dataSpanEl.appendChild(townSpanEl);
        dataSpanEl.appendChild(degreesSpanEl);
        dataSpanEl.appendChild(conditionSpanEl);
        divForecastsEl.appendChild(symbolSpanEl);
        divForecastsEl.appendChild(dataSpanEl);
        divCurConditionEl.appendChild(divForecastsEl);
    }
    function createUpcomingVisualization(data) {        
        let divUpcomingInfoEl = document.createElement('div');
        divUpcomingInfoEl.classList.add('forecast-info');

        data.forecast.forEach(day => {
            let spanDailyEl = document.createElement('span')
            let symbolEl = document.createElement('span')
            let degreesEl = document.createElement('span')
            let conditionEl = document.createElement('span')

            symbolEl.innerHTML = chooseWeatherSymbol(day.condition);
            degreesEl.innerHTML = `${day.low}${symbols.degrees}/${day.high}${symbols.degrees}`;
            conditionEl.innerHTML = day.condition;

            spanDailyEl.classList.add('upcoming');
            symbolEl.classList.add('symbol');
            degreesEl.classList.add('forecast-data');
            conditionEl.classList.add('forecast-data');

            spanDailyEl.appendChild(symbolEl);
            spanDailyEl.appendChild(degreesEl);
            spanDailyEl.appendChild(conditionEl);
            divUpcomingInfoEl.appendChild(spanDailyEl);
        })

        divUpcomingEl.appendChild(divUpcomingInfoEl);
    }
    function chooseWeatherSymbol(condition) {
        let result = '';
        switch (condition) {
            case 'Sunny':
                result = symbols.sunny;
                break;
            case 'Partly sunny':
                result = symbols.partlySunny;
                break;
            case 'Overcast':
                result = symbols.overcast;
                break;
            case 'Rain':
                result = symbols.rain;
                break;
            default:
                break;
        }
        return result;
    }
    function checkForExistingInfo() {
        let curForecastEl = document.getElementsByClassName('forecasts')[0];
        if (curForecastEl !== undefined) {
            divCurConditionEl.removeChild(curForecastEl)
        }

        let curForecastInfoEl = document.getElementsByClassName('forecast-info')[0];
        if (curForecastInfoEl !== undefined) {
            divUpcomingEl.removeChild(curForecastInfoEl)
        }
    }
}

attachEvents();