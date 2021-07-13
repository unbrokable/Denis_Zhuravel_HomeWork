function isStartEndWith(arr, number){
    if(arr[0] === number || arr[arr.length-1] === number){
        return true;
    }
    return false;
}

console.log(isStartEndWith([1, 2, 3],1));
console.log(isStartEndWith([2, 1] ,1));
console.log(isStartEndWith([2, 4] ,1));