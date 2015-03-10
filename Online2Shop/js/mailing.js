function setupMailing() {
    /* I bind the click on the mailing list button to the popup window */
    $("#mailingListWrapper").bind("click", function () {
        /* I show the overlay layer */
        $("#overlayLayer").show();
        /* I show the popup window */
        $("#popupMailing").show();
        //$("#loginDiv").show();
    });

    $(".loginBeforePaypal").bind("click", function () {
        /* I show the overlay layer */
        $("#overlayLayer").show();
        /* I show the popup window */
        $("#loginDiv").show();
        //$("#loginDiv").show();
    });

    $(".smallImgDetails").bind("click", function () {
        /* I show the popup window */
        $("#overlayLayerInvisible").show();
        $("#popupImages").show();
        var src = $(this).attr('src');
        document.getElementById("popupImagesInternal").style.background = " url('"+ src+"')";
       // document.body.style.background = "#f3f3f3 url('img_tree.png') no-repeat top";
        
    });

    $("#overlayLayerInvisible").bind("click", function () {
        /* I hide the overlay */
        $(this).hide();
        /* I hide the popup window */
        $("#popupImages").hide();
    });

    /* I bind the click on the overlay layer to the closure of the popup window */
    $("#overlayLayer").bind("click", function () {
        /* I hide the overlay */
        $(this).hide();
        /* I hide the popup window */
        $("#popupMailing").hide();
        $("#loginDiv").hide();
        $("#registerDiv").hide();
    });

    $("#mailingClose").bind("click", function () {
        /* I hide the overlay */
        $(this).hide();
        /* I hide the popup window */
        $("#popupMailing").hide();
        $("#overlayLayer").hide();
    });

    $("#Login1_registerButton").bind("click", function () {
        /* I hide the overlay */
        $(this).hide();
        /* I hide the popup window */
        $("#loginDiv").hide();
        $("#popupMailing").show();
    });

};