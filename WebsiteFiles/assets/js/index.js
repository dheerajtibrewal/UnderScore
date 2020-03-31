$(document).ready(function() {
    $(".signup-btn").click(function() {
        $(".signup-model").show();
        $(".backdrop-signup").show();
    })
    $(".login-btn").click(function() {
        $(".login-model").show();
        $(".backdrop-signup").show();
    })
    $(".close-btn").click(function() {
        $(".signup-model").hide();
        $(".login-model").hide();
        $(".backdrop-signup").hide();
        location.reload(true);
    })
    $(".create-account").click(function(){
        $(".login-model").hide();
        $(".signup-model").show();
    });

});