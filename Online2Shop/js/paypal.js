function setupPaypal() {
    /* I get the transaction Id */
    var transactionId = location.search.substr(4);
    var transactionId = transactionId.substr(0, transactionId.indexOf("&"));
    /* If it's not empty I track back the transaction */
    if (transactionId != "") {
        // Send the data using post
        var postingData =
            {
                cmd: "_notify-synch",
                tx: transactionId,
                at: "abguBANFHrN_mIGopxWErMJY_uIWeGcwp_S8X2biotJY4VTZ9dXdhzg6L-0"
            };
        //alert(postingData.tx);
        $.post("https://www.paypal.com/cgi-bin/webscr", postingData, function (data) {
            $("#transactionResult").append(data);
        }).fail(function(jqXHR, textStatus, errorThrown)
        {
            alert("errore");
        });
    }    
}
