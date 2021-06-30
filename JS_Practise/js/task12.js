function square(n){

    let area = 0;
    for(let i = 0,step = 1; i < n; i++){
        if(i === n-1 ){
            area += step
            break;
        }
        area += step*2;
        step += 2;
    }
    return area;
}
console.log(square(3));