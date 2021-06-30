function  firstJanuaryYear(yearStart, yearEnd){
    
    for(let i = yearStart; i < yearEnd; i++ ){

        date = new Date(i,0,1).getDay();
        if(date === 0){
            console.log(i);
        }
    }

    
}

firstJanuaryYear(2014, 2050);