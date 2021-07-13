function getLastNumberFromArray(arr, number= 1){
    return arr.slice(number * -1);
}

console.log(getLastNumberFromArray([7, 9, 0, -2]));
console.log(getLastNumberFromArray([7, 9, 0, -2],3));
console.log(getLastNumberFromArray([7, 9, 0, -2],6));