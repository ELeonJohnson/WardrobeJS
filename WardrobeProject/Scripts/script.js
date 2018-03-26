window.onload = function () {
    document.getElementById('close').onclick = function () {
        this.parentNode.parentNode.parentNode
            .removeChild(this.parentNode.parentNode);
        return false;
    };
};

function Redirect(x) {
    var confirmButton = document.getElementById(x);
    var userResponse = confirm('You are about to leave this site. If you want to stay, please select cancel.');
    var displayContainer = document.getElementById('confirmResponse');
    var displayMessage = '';
    if (userResponse) {
        var win = window.open("https://blog.ometria.com/online-fashion-lookbook-examples", '_blank');
        win.focus("");
    }
}

function bigText(x) {
    x.style.fontSize = "20px";
    x.style.color = "red";
    
}

function normalText(x) {
    x.style.fontSize = "14px";
    x.style.color = "#393939";
}

function defaultCopy() {
    var display = document.getElementById('footerChange');
    display.innerHTML= '&copy; 2018'
}

function changeCopy() {
    var display = document.getElementById('footerChange');
    display.innerHTML = 'Created By Enoch Johnson';
    
}



function dragStart(event) {
    event.dataTransfer.setData("img", event.target.Tag);
}

function dragging(event) {
    document.getChildren("change-of-text").innerHTML = "";
}

function allowDrop(event) {
    event.preventDefault();
}

function drop(event) {
    event.preventDefault();
    var data = event.dataTransfer.getData("Text");
    event.target.appendChild(document.getElementById(data));
    document.getElementById("change-of-text").innerHTML = "";
}

