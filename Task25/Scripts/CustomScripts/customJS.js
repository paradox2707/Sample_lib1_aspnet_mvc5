//import { hidden } from "modernizr";

//var navBurger = document.getElementById("nav-burger");
var btnMoreLess = document.getElementsByClassName("btnMoreLess");
//navBurger.addEventListener("click", clickBurger, false);
for (var i = 0; i < btnMoreLess.length; i++) {
    btnMoreLess[i].addEventListener('click', textMoreLess, false);
}

var mySidenav = document.getElementById("mySidenav");

//function clickBurger() {
//    navBurger.style.visibility = "hidden";
//    mySidenav.style.visibility = "visible";
//}

function textMoreLess() {
    var btnText = this;
    var dots = this.parentElement.getElementsByClassName("dots")[0];
    var moreText = this.parentElement.getElementsByClassName("more")[0];
    

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Read more";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "Read less";
        moreText.style.display = "inline";
    }
}