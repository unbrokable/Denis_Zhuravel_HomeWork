function guessNumber(){
    const number = Math.floor(Math.random() *20) +1 ;
    alert(number);
    while(true){
        let answer = prompt("Enter number");
        answer = parseInt(answer);
        if(answer === number){
            alert("You win ");
            break;
        }
        else if(answer < number){
            alert("Write bigger number");
        }
        else if (answer > number){
            alert("Write smaller number");
        }
        else{
            alert("It is not number");
        }
    }
}
guessNumber();