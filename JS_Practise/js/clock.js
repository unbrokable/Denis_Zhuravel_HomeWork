function clock(){
    let date = new Date();
    this.innerHTML = date.toLocaleDateString();
    var location = document.getElementById("clock");
    location.innerHTML = date.getHours() + ":" + date.getMinutes() + ":" + date.getSeconds();
}  

setInterval(clock,1000);
clock();