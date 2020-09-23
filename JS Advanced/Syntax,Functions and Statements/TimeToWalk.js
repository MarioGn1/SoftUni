function timeWalk(steps, footprint, speed) {
    let distance = steps * footprint ;
    let timeSeconds = distance / speed * 3.6;

    let restMinutes = Math.floor(distance / 500);
    let seconds = timeSeconds;
    let minutes = 0;
    let hours = 0;
    if (timeSeconds > 59) {
        seconds = Math.round(timeSeconds % 60);
        minutes = restMinutes + Math.floor(timeSeconds / 60);
        if (minutes > 59) {
            hours = Math.floor(minutes / 60)
            minutes = Math.round(minutes % 60)
        }
    }

    if (hours < 10) { hours = "0" + hours; }
    if (minutes < 10) { minutes = "0" + minutes; }
    if (seconds < 10) { seconds = "0" + seconds; }

    console.log(`${hours}:${minutes}:${seconds}`)
}

//timeWalk(2564, 0.70, 5.5)
timeWalk(1000, 0.60, 5)
timeWalk(1000, 2, 0.3)