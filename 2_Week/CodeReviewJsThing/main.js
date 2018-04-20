
var button = document.getElementById("btn");


button.addEventListener("click", function(){
    var pTag = document.createElement("p");
    pTag.innerHTML = "I WAS CREAETED WITH CODESSS";
    var div = document.getElementById("test");
    console.log(div);
    div.appendChild(pTag);
});
