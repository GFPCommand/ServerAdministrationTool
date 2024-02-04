var popBlock = document.getElementById('pop');
var userName = document.getElementById('user');

var isPopOpen = false;

user.onclick = function (event) {
    event.preventDefault();

    if (isPopOpen) {
        popBlock.style.display = 'none';
        isPopOpen = false;
    } else {
        popBlock.style.display = 'block';
        isPopOpen = true;
    }
}