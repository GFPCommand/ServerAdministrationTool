var appsElem = document.getElementById('applications-list');
var appsList = document.getElementById('apps');

var usersElem = document.getElementById('users-list');
var usersList = document.getElementById('users');

var isAppsListOpen  = false;
var isUsersListOpen = false;

appsElem.onclick = function(event) {
    event.preventDefault();

    if (isAppsListOpen) {
        appsList.style.maxHeight = '0';
        appsList.style.transition = '0.5s ease-out';
        isAppsListOpen = false;
        appsElem.textContent = 'Показать';
    } else {
        appsList.style.maxHeight = '100vh';
        appsList.style.transition = '0.5s ease-in';
        isAppsListOpen = true;
        appsElem.textContent = 'Скрыть'
    }
}

usersElem.onclick = function(event) {
    event.preventDefault();

    if (isUsersListOpen) {
        usersList.style.maxHeight = '0';
        usersList.style.transition = '0.5s ease-out';
        isUsersListOpen = false;
        usersElem.textContent = 'Показать';

    } else {
        usersList.style.maxHeight = '100vh';
        usersList.style.transition = '0.5s ease-in';
        isUsersListOpen = true;
        usersElem.textContent = 'Скрыть';
    }
}