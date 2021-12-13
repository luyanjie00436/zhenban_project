var ShowDiv = function(theID) {
    var temp = $("div[id^='" + theID + "']").css("display");
    var value = temp == "block" ? "none" : "block";
    //$("div[id^='" + theID + "']").css("display", "block");
    $("div[id^='" + theID + "']").css("display", ""+value+"");
}