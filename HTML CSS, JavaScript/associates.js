function getAssociates(){
    const associatesList = ["Astronomsko društvo Višnjan", "", "Zvjezdarnica Zagreb", "Zvjezdarnica Rijeka", "Astronomsko društvo Beskraj", "Astronomsko društvo Vega"];

    let text = "";
     for (let i = 0; i < associatesList.length; i++) {
      text += associatesList[i] + "<br>";

    }

    document.getElementById("associatesScript").innerHTML = text;
} 