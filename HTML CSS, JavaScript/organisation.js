function getOrganisators(){
    const organisatorList = ["Lorena Miletić", "Petra Lončarević", "Luka Damjanović", "Ivana Ferić", "Tomislav Lukić", "Marko Petrić"];

    let text = "";
     for (let i = 0; i < organisatorList.length; i++) {
      text += organisatorList[i] + "<br>";

    }

    document.getElementById("list").innerHTML = text;
} 