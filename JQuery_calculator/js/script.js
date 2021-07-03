$(window).on('load',function(){
    $("input[type=text]").prop( "readonly", true );
    $("input[type=button]").click(function(){
        let curValue = $("input[type=text]").val();
        let changeValue = setRightCalculatorValue(curValue, $(this).attr("value"));
        $("input[type=text]").val(changeValue);
        $(".result").empty().append(Calculate(changeValue));
    });

    $("input[value='=']").click(function(){
        var curValue = $("input[type=text]").val();
        $(".result").empty().append(Calculate(curValue));
    });
  });


//logic
const delSymbol = "Del"; 
const resultSymbol = "=";
const plusSymbol = "+";
const minusSymbol = "-";
const multiplySymbol = "X";
const divideSymbol = "/";
const arrSymbols = [minusSymbol,delSymbol,multiplySymbol,resultSymbol,divideSymbol,plusSymbol];

function setRightCalculatorValue(cur, value){
    if(resultSymbol == value){
        return cur;
    }
    if(delSymbol == value){
        return cur.slice(0, -1);
    }
    if(arrSymbols.includes(value) && arrSymbols.includes(cur.slice(-1))){
        return cur;
    }
    return cur + value;
}

function Calculate(str){
    try{
        while(str.includes(divideSymbol ) || str.includes(multiplySymbol)){
            if((str.indexOf(divideSymbol ) < str.indexOf(multiplySymbol) || str.indexOf(multiplySymbol) === -1) && str.indexOf(divideSymbol ) != -1){
                str = getResult(str, divideSymbol);
            }
            else{
                str = getResult(str,multiplySymbol);
            }
        }
        while(str.includes(minusSymbol) || str.includes(plusSymbol)){
            if((str.indexOf(minusSymbol ) < str.indexOf(plusSymbol) || str.indexOf(plusSymbol) === -1 )&& str.indexOf(minusSymbol) != -1){
                str = getResult(str, minusSymbol);
            }
            else{
                str = getResult(str,plusSymbol);
            }
        }
    }
    catch{}
    return str;
}

function getResult(str,sym){
    let index = str.indexOf(sym);
    if(index === 0 && sym === minusSymbol){
        index = str.indexOf(sym,index+1);
        if(index === -1){
            index = str.indexOf(plusSymbol);
            sym = plusSymbol;
        }
    }
    if(index === -1){
        throw "Cant find";
    }
    let fromStarIndexMax = str.length;
    let fromEndIndexMin = -1;
    let endSymbol = "any";
    for (let symbol of arrSymbols) {
        let fromStart = str.indexOf(symbol, index+1);
        let fromEnd = str.lastIndexOf(symbol,index);
        if(fromStart === index+1){
            fromStart = str.indexOf(symbol, fromStart+1);
        } 
        if(fromStart != -1 && fromStart < fromStarIndexMax && fromStart != index ){
            fromStarIndexMax = fromStart;
        }
        if(fromEnd != -1 && fromEnd > fromEndIndexMin && fromEnd != index){
                endSymbol = symbol;
                fromEndIndexMin = fromEnd;
        }
    } 
    if( fromEndIndexMin === -1){
        fromEndIndexMin = 0;
    }else if(endSymbol === minusSymbol){
    }else{
        fromEndIndexMin = fromEndIndexMin+1;
    }
    let subResult = str.slice(fromEndIndexMin, fromStarIndexMax == 0?str.length: fromStarIndexMax);
    let result = ChooseOperation(subResult,sym,index - str.indexOf(subResult));
    str = str.replace(subResult,result);
    return str;
}

function ChooseOperation(str, sym, index){
    let first = Number.parseFloat(str.substr(0, index));
    let second = Number.parseFloat(str.substr(index+1));
    if(sym === plusSymbol){
        return second + first;
    }
    if(sym === divideSymbol){
        return first / second;
    }
    if(sym === multiplySymbol){
        return first* second;
    }
    if(sym === minusSymbol){
        return first - second;
    }
}