$(document).ready(function () {
    $("#tog").click(function () {
        $("tr").siblings().each(function () {
            if ($(this).find("p").text() === "No") {
                $(this).toggle();
            }
        });
    });
});