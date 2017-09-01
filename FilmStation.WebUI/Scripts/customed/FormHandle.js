$(document).ready(function () {
    $("#submit").click(function () {
        //if ($("#adminlist>input").text === "") {
        //    $(this).removeAttr("name");
        //}
        //$("select").siblings().each(function () {
        //    if ($(this).text == "0") {
        //        $(this).removeAttr("name");
        //    }
        //});
        var d = $("#adminlist").serializeArray();
        for (i = 0; i < d.length; i++)
        {
            if (d[i].value == "" || "0") {
                d[i].name = "none";
            }
        }

        $.ajax({
            url: "/Admin/List",
            async: false,
            type: "post",
            data: d,
            success: function () { location: "/Admin/List" }
        })
    });
});