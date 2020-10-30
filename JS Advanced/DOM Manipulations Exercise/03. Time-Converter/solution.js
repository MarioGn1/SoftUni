function attachEventsListeners() {

    let mainElement = document.getElementsByTagName('main')[0];
    mainElement.addEventListener('click', function(e){
        if (e.target.value === 'Convert') {
            let daysElement = document.getElementById('days')
            let hoursElement = document.getElementById('hours')
            let minutesElement = document.getElementById('minutes')
            let secondsElement = document.getElementById('seconds')
            let days = Number(daysElement.value);
            let hours = Number(hoursElement.value);
            let minutes = Number(minutesElement.value);
            let seconds = Number(secondsElement.value)

            if (days) {                
                hoursElement.value = days*24;                
                minutesElement.value = days*24*60;
                secondsElement.value = days*24*60*60;
                return;
            }
            
            if (hours) {
                daysElement.value = hours/24;
                minutesElement.value = hours*60;
                secondsElement.value = hours*60*60;
                return;
            }
            if (minutes) {
                secondsElement.value = minutes*60;
                hoursElement.value = minutes/60;
                daysElement.value = minutes/60/24;
                return;
            }
            if (seconds) {
                minutesElement.value = seconds/60;
                hoursElement.value = seconds/60/60;
                daysElement.value = seconds/60/60/24
                return;
            }
            console.log('TODO:...');
        }
    })
    
}