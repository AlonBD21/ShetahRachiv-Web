window.onload = function() {
    document.forms[0].onchange = formChange;
    formChange();
};
function formChange() {
    var typeList = document.querySelector("[id$=ddlFS]");
    var styleList = document.querySelector("[id$=ddlStyle]");
    var label = document.getElementById("styleLbl");

    if (typeList.selectedIndex == 0) {
        label.innerHTML = "";
    }
    if (typeList.selectedIndex == 1) {
        label.innerHTML = "זנב קשיח בלבד - לא יוצגו אופני דאונהיל או אול מאונטיין ";
        if (styleList.selectedIndex == 3 || styleList.selectedIndex == 4) styleList.selectedIndex = 0;
    }
    if (typeList.selectedIndex == 2) {
        label.innerHTML = "שיכוך מלא בלבד - לא יוצגו אופני דירט ג'אמפ ";
        if (styleList.selectedIndex == 1) styleList.selectedIndex = 0;
    }
}