/*
   perform ajax calls to server
 */

function get(url, callback) {
    ajax("GET", url, null, callback);
}

function post(url, body, callback) {
    ajax("POST", url, body, callback);
}

function put(url, body, callback) {
    ajax("PUT", url, body, callback);
}

function load(url, element, action) {
    get(url, function (response) {
        document.getElementById(element).innerHTML = response;

        if (action !== null && typeof action !== "undefined")
            action();
    });
}

function append(url, element, action) {
    get(url, function (response) {
        document.getElementById(element).insertAdjacentHTML('beforeend', response);

        if (action !== null && typeof action !== "undefined")
            action();
    });
}

function ajax(method, url, body, callback) {
    var request = new XMLHttpRequest();

    if (callback !== null) {
        request.onreadystatechange = function () {
            if (this.readyState === 4 && this.status === 200) {
                callback(this.responseText);
            }
        };
    }

    request.open(method, url, true);

    if (body !== null) {
        request.setRequestHeader("Content-Type", "application/json");
        request.send(JSON.stringify(body));
    }
    else {
        request.send();
    }
}