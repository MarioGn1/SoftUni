function radar(args) {
    let speed = args[0];
    let place = args[1];
    let overspeed;
    switch (place) {
        case 'motorway':
            overspeed = speed - 130;
            break;
        case 'interstate':
            overspeed = speed - 90;
            break;
        case 'city':
            overspeed = speed - 50;
            break;
        case 'residential':
            overspeed = speed - 20;
            break;    
        default:
            break;
    }

    if (overspeed > 0 && overspeed <= 20) {
        console.log('speeding')
    }
    if (overspeed > 20 && overspeed <= 40) {
        console.log('excessive speeding')
    }
    if(overspeed > 40){
        console.log('reckless driving')
    }
}

//radar([40, 'city'])
radar([21, 'residential'])
//radar([120, 'interstate'])
//radar([200, 'motorway'])