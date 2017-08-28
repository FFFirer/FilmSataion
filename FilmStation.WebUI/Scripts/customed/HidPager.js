$(document).ready(function () {
    if ($(window).width() < 366) {
        $(".pagination>li").each(function () {
            if ($(this).text() == "上一页" || $(this).text() == "下一页" || $(this).hasClass("active")) {
                $(this).show();
            }
            else {
                $(this).hide();
            }
        });
    }
});
