/* The number of different images to be alternated in the banner section */
/* Edit here to add or remove banners */
var numberOfBanners = 3;
/* The next banner image */
var nextBanner = 2;
/* The updateBanner interval id */
var updateBannerInterval;

function setupBanner() {
    /* I set the timer for the banner change */
    window.setInterval(slideBanner, 6000);
};

function slideBanner() {
    /* I recover the banner image */
    var bannerImage = $("#banner");
    /* I make the image slide so that the background next banner is reveiled */
    bannerImage.animate({ "left": "-1000px" }, "slow");
    /* I set the interval to wait and call the function which will replace the banner to the next
    one which is now in the background and switch the background one to the next one */
    updateBannerInterval = setInterval(updateBanner, 1000);
}

function updateBanner() {
    /* I recover the banner image */
    var bannerImage = $("#banner");
    /* I recover the banner background */
    var bannerBackground = $("#bannerWrapper");

    /* I switch the banner image to the next one */
    bannerImage.attr("src", "images/banner" + nextBanner + ".jpg");
    /* I position the image banner back on top of the background banner */
    bannerImage.attr("style", "left: 0px;");

    /* I update the next banner index */
    nextBanner += 1;
    if (nextBanner > numberOfBanners) {
        nextBanner = 1;
    }

    /* Now that the background banner is covered again is time to update it to the next banner */
    bannerBackground.css("background-image", "url(\"../images/banner" + nextBanner + ".jpg\")");    
    /* I remove this interval */
    window.clearInterval(updateBannerInterval);
}
