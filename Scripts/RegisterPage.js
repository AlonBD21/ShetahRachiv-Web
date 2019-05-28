window.onload = function () {
    document.forms[0].onsubmit = function () {
        return totalCheck();
    }
};
function totalCheck() {
    if (verifyPass() && checkUserName() && checkEmail() && checkName() && checkBio()) {
        return true;
    }
    return false;
}
function verifyPass() {
    var pass1 = document.getElementById("txtPass");
    var pass2 = document.getElementById("txtVerify");
    var error = document.getElementById("passErr");
    if (pass1.value === pass2.value) {
        error.innerHTML = "";
    }
    else {
        error.innerHTML = "הסיסמאות אינן תואמות";
        return false;
    }
    if (pass1.value.length < 6 || pass1.value.length > 50) {
        error.innerHTML = "הסיסמה חייבת לכלול בין 6 ל50 תווים";
        return false;
    }
    return true;
}
function checkUserName() {
    var checkIfTaken = true;
    var label = document.getElementById("userErr");
    label.innerHTML = "";
    var input = document.getElementById("txtUser");
    var string = input.value;
    if (string.length < 4 || string.length > 15) {
        checkIfTaken = false;
        label.innerHTML = "חייב להיות בין 4 ל15 תווים";
    }
    if (!onlyLettersAndEng(string)) {
        checkIfTaken = false;
        label.innerHTML = "יכול לכלול אנגלית ומספרים בלבד";
    }
    if (checkIfTaken) {
        callWS();
    }
    return checkIfTaken;
}
function checkEmail() {
    var email = document.getElementById("txtEmail").value;
    var label = document.getElementById("emailErr");
    label.innerHTML = "";
    if (!onlyEmailChars(email)) {
        label.innerHTML = label.innerHTML = "מכיל תווים לא חוקיים";
        return false;
    }
    if (email.length > 50 || email.length < 4) {
        label.innerHTML = "בין 4 ל50 תווים";
        return false;
    }
    if (!email.includes("@")) {
        label.innerHTML = "חסר @";
        return false;
    }
    if (!email.includes(".")) {
        label.innerHTML = "חסרה .";
        return false;
    }
    return true;
}
function checkName() {
    name = document.getElementById("txtFullname").value;
    err = document.getElementById("fullNameErr");
    err.innerHTML = "";
    if (name.length > 15) {
        err.innerHTML = "עד 15 תווים";
        return false;
    }
    return true;
}
function checkBio() {
    bio = document.getElementById("txtMoto").value;
    err = document.getElementById("motoErr");
    err.innerHTML = "";
    if (bio.length > 140) {
        err.innerHTML = "עד 140 תווים";
        return false;
    }
    return true;
}
function onlyLettersAndEng(str) {
    var ALLOWED = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    for (var i = 0; i < str.length; i++) {
        if (!ALLOWED.includes(str.charAt(i))) {
            return false;
        }
    }
    return true;
}
function onlyEmailChars(str) {
    var ALLOWED = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789@._/";
    for (var i = 0; i < str.length; i++) {
        if (!ALLOWED.includes(str.charAt(i))) {
            return false;
        }
    }
    return true;
}
function callWS(action, data, succesFn) {
    // פעולה המקבלת פעולת־רשת (מחרוזת), נתונים (עצם), ופעולה לטיפול בתגובה לכשתגיע
    var request = new XMLHttpRequest();

}