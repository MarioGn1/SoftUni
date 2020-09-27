function tTT(playersTurns) {
    let defField = [[false, false, false],
    [false, false, false],
    [false, false, false]];

    let firstPlayerTurn = true;

    for (let i = 0; i < playersTurns.length; i++) {
        let playerTurnArr = playersTurns[i].split(/\s*/);
        let fieldRow = Number(playerTurnArr[0]);        
        let fieldCol = Number(playerTurnArr[1]);        

        if (firstPlayerTurn) {
            if (checkNextStep(fieldRow, fieldCol)) {
               defField[fieldRow][fieldCol] = 'X';
               
            }else{
                console.log('This place is already taken. Please choose another!'); 
                continue;               
            }
            firstPlayerTurn = false;
        }else{
            if (checkNextStep(fieldRow, fieldCol)) {
                defField[fieldRow][fieldCol] = 'O';
                
            }else{
                console.log('This place is already taken. Please choose another!');
                continue;                
            }
            firstPlayerTurn = true;
        }

        if (checkForWin(defField)) {
            console.log(`Player ${checkForWin(defField)} wins!`)
            break;
        }

        if (!checkFreeSpaces()) {
            console.log('The game ended! Nobody wins :(');
            break;
        }
        
    }

    defField.forEach(el => console.log(el.join('\t')))

    function checkForWin(arr) {

        for (let i = 0; i < arr.length; i++) {
            if (arr[i].every(el => el === 'X')) {
                return arr[i][0];
            }
            if (arr[i].every(el => el === 'O')) {
                return arr[i][0];
            }            
            for (let j = 0; j < arr.length; j++) {
                if (arr[i][j] !== false && arr[0][j] === arr[1][j] && arr[1][j] === arr[2][j]) {                    
                        return arr[i][j];                                       
                }                
            }                       
        }

        if (defField[0][0] === defField[1][1] && defField[1][1] === defField[2][2] && defField[0][0] !== false) {
            return defField[0][0];
        }
        if (defField[0][3] === defField[1][1] && defField[1][1] === defField[3][0] && defField[0][3] !== false) {
            return defField[0][3];
        }
        
    }

    function checkFreeSpaces(){
        return defField.some(arr => arr.some(el => el === false))
    }

    function checkNextStep(row, col) {
        return defField[row][col] === false;
    }

}

tTT(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]
);