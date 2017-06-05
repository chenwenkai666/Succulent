$("#head_car").hover(function () {
    $(this).css("background", "#FBFEE9");
    $(".head_car_text").css("color", "#b0b0b0");
    //$("#car_content").css({ "width": "300px" }).animate({
    //    height: "100px"
    //}, 400).finish();
}
, function () {
    $(this).css("background", "#424242");
    $(".head_car_text").css("color", "#b0b0b0");
    //$("#car_content").css({ "width": "300px" }).animate({
    //    height: "0px"
    //}, 400);
})
//导航栏控制显示
$(".menu_li").hover(function () {
    $("#menu_content_bg").css("border", "1px solid #D0D0D0");
    $(this).css("color", "#339933");
    $("#" + $(this).attr("control")).show();
    $("#menu_content_bg").height(230);
}, function () {
    $("#" + $(this).attr("control")).hide();
    $(this).css("color", " #424242");
    $("#menu_content_bg").height(0);
    $("#menu_content_bg").css("border", "0px solid #D0D0D0");
})
//搜索框失去和获取焦点border颜色改变
$("#find_input").focus(function () {
    $("#find_wrap").css("border", "1px solid #339933");
    $("#find_but").css("border-left", "1px solid #339933");
})
$("#find_input").blur(function () {
    $("#find_wrap").css("border", "1px solid #F0F0F0");
    $("#find_but").css("border-left", "1px solid #F0F0F0");
})
//搜索按钮的背景颜色改变
$("#find_but").hover(function () {
    $(this).css({ "background": "#339933", color: "#fff" });
}, function () {
    $(this).css({ "background": "#fff", color: "#424242" });
})




$(".foot_bottom_r").children("span").hover(function () {
    $(this).css({ "background": "#339933", color: "#fff" });
}, function () {
    $(this).css({ "background": "none", color: "#339933" });
})