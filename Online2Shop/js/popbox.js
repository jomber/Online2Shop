/*function deselectLogin() {
    if ($("#loginpop").hasClass("selected")) {
        $(".loginpop").slideFadeToggle(function () {
            $("#loginpop").removeClass("selected");
        });
    }
}

function deselectRegister() {
    if ($("#register").hasClass("selected")) {
        $(".register").slideFadeToggle(function () {
            $("#register").removeClass("selected");
        });
    }
}


$(function () {
    $("#loginpop").live('click', function () {
        deselectRegister();
        if ($(this).hasClass("selected")) {
            deselectLogin();
        } else {
            $(this).addClass("selected");

            $(".loginpop").slideFadeToggle(function () {
                $("#email").focus();
            });
        }
        return false;
    });

    $("#register").live('click', function () {
        deselectLogin();
        if ($(this).hasClass("selected")) {
            deselectRegister();
        } else {
            $(this).addClass("selected");
            $(".register").slideFadeToggle(function () {
                $("#email").focus();
            });
        }
        return false;
    });

    $(".close").live('click', function () {
        deselect();
        return false;
    });
});

$.fn.slideFadeToggle = function (easing, callback) {
    return this.animate({ opacity: 'toggle', height: 'toggle' }, "fast", easing, callback);
};*/




function deselect() {
    $(".pop").slideFadeToggle(function () {
        $("#contact").removeClass("selected");
    });
}

$(function () {
    $("#contact").live('click', function () {
        if ($(this).hasClass("selected")) {
            deselect();
        } else {
            $(this).addClass("selected");
            $(".pop").slideFadeToggle(function () {
                $("#email").focus();
            });
        }
        return false;
    });

    $(".close").live('click', function () {
        deselect();
        return false;
    });
});

$.fn.slideFadeToggle = function (easing, callback) {
    return this.animate({ opacity: 'toggle', height: 'toggle' }, "fast", easing, callback);
};
