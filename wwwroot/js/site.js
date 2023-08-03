var appsElem = document.getElementById('applications-list');
var appsList = document.getElementById('apps');

var usersElem = document.getElementById('users-list');
var usersList = document.getElementById('users');

var openImgApps = appsElem.firstElementChild;
var openImgUsers = usersElem.firstElementChild;

var isAppsListOpen  = false;
var isUsersListOpen = false;

appsElem.style.userSelect = 'none';
usersElem.style.userSelect = 'none';

appsElem.onclick = function(event) {
    event.preventDefault();

    if (isAppsListOpen) {
        appsList.style.maxHeight = '0';
        appsList.style.transition = '0.5s ease-out';

        openImgApps.style.transform = 'rotate(45deg)';

        isAppsListOpen = false;
    } else {
        appsList.style.maxHeight = '100vh';
        appsList.style.transition = '0.5s ease-in';

        openImgApps.style.transform = 'rotate(0deg)';

        isAppsListOpen = true;
    }
}

usersElem.onclick = function(event) {
    event.preventDefault();

    if (isUsersListOpen) {
        usersList.style.maxHeight = '0';
        usersList.style.transition = '0.5s ease-out';

        openImgUsers.style.transform = 'rotate(45deg)';

        isUsersListOpen = false;
    } else {
        usersList.style.maxHeight = '100vh';
        usersList.style.transition = '0.5s ease-in';

        openImgUsers.style.transform = 'rotate(0deg)';

        isUsersListOpen = true;
    }
}