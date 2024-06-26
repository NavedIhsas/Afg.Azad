
//position: top left, top right, middle,bottom,top,center,right,top right, 
//type: success,warn ,error,info
https://notifyjs.jpillora.com/

function notify(position, text, type) {
    $.notify(text, {
        className: type,
        clickToHide: true,
        autoHide: true,
        globalPosition: position
    });
}



function getCookie(cname) {
    var name = cname + '=';
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return '';
}

function getParseCookie(cname) {
    var stringify = getCookie(cname);
    if (stringify == "")
        return false;
    return JSON.parse(stringify);
}

function setCookie(cname, cvalue, path = "/", exdays = 1) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    var expires = 'expires=' + d.toUTCString();
    document.cookie = cname + '=' + JSON.stringify(cvalue) + ';' + expires + ';path=' + path;
}


function deleteAllCookies() {
    const cookies = document.cookie.split(";");

    for (let i = 0; i < cookies.length; i++) {
        const cookie = cookies[i];
        const eqPos = cookie.indexOf("=");
        const name = eqPos > -1 ? cookie.substr(0, eqPos) : cookie;
        document.cookie = name + "=;expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
}
function deleteCookie(name, path = "/") {
    document.cookie = name + '=; Path=' + path + '; Expires = Thu, 01 Jan 1970 00: 00: 01 GMT; ';
}






$(function () {
    $("#tags").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Index?handler=AutocompleteSearch',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: { "prefix": request.term },
                type: "POST",
                success: function (data) {
                   
                    $(".text-dark-1").empty();
                    var element = document.getElementById("contentSearch");
                    while (element.firstChild) {
                        element.removeChild(element.firstChild);
                    }

                   /* $(".text-dark-1").remove();*/
                    response($.map(data, function (item) {
                       
                        var list = document.getElementById('contentSearch');
                        var anchor = document.createElement('a');
                        anchor.innerHTML = item.name;
                        anchor.setAttribute("class", "text-dark-1");
                        anchor.setAttribute("href", "CourseDetails/" + item.slug);

                        list.appendChild(anchor);
                       
                       

                        return item;
                    }));
                   
                },
                error: function (response) {
                   
                    alert(response.responseText);
                },
                failure: function (response) {
                   
                    alert(response.responseText);
                }
            });
        },
        position: { collision: "flip" },
        select: function (e, i) {
           
            $("#tags1").text(i.item.val);
        },

        minLength: 1
    });
});

var textArea = document.getElementById("tags");
textArea.addEventListener("keypress",
    function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            document.getElementById("submitSearch").click();
        }
    });

var textArea = document.getElementById("searchValue");
textArea.addEventListener("keypress",
    function (event) {
        if (event.key === "Enter") {
            event.preventDefault();
            document.getElementById("submitSearch1").click();
        }
    });

