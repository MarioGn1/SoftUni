function operations(params) {
    let num = Number(params[0]);

    for (let index = 1; index < params.length; index++) {
        switch (params[index]) {
            case 'chop':
                num = num / 2;
                break;
            case 'dice':
                num = Math.sqrt(num);
                break;
            case 'spice':
                num += 1;
                break;
            case 'bake':
                num = num * 3;
                break;
            case 'fillet':
                num = num - (num * 0.2);
                break;

            default:
                break;
        }
        console.log(num)
    }
}

operations(['32', 'chop', 'chop', 'chop', 'chop', 'chop'])
operations(['9', 'dice', 'spice', 'chop', 'bake', 'fillet'])