function getDateAndTime(){
    let day;
switch (new Date().getDay()) {
  case 0:
    day = "Nedjelja";
    break;
  case 1:
    day = "Ponedjeljak";
    break;
  case 2:
    day = "Utorak";
    break;
  case 3:
    day = "Srijeda";
    break;
  case 4:
    day = "Četvrtak";
    break;
  case 5:
    day = "Petak";
    break;
  case  6:
    day = "Subota";
}
document.getElementById("dateAndTime").innerHTML = "Danas je " + day + Date();
}