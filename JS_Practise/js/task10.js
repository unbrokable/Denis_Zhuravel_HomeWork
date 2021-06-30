function findMax(arr){
    let max ;
    for(let i = 0; i < arr.length-1; i++){

        if(max == undefined || arr[i] * arr[i+1] > max){
            max =arr[i] * arr[i+1];
        }
    }
    return max;
}
console.log(findMax([3, 6, -2, -5, 7, 3]));