function  firstJanuaryYear(yearStart, yearEnd,day = "Sunday"){
    for(let i = yearStart; i < yearEnd; i++ ){
        date = new Date(i,0,1).toLocaleString('en-US', {weekday : 'long'});
        if(date === day){
            console.log(i);
        }
    }
}
firstJanuaryYear(2014, 2050);