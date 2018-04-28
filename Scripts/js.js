$(window).scroll(function () {
    if ($(document).scrollTop() > 50) {
        $('#nav').addClass('shrink');
    }
    else {
        $('#nav').removeClass('shrink');
    }
});


$('#nav').click(function () {
    console.log("clicked")
});

    $(function () {
        $('#signBtn').on("click", function () {
            console.log("vote clicked ");
            if ($('#signBtn').text() == "Sign In") {
                $('#signBtn').text("Menu")
                alert("sign in")
            }
            else if ($('#signBtn').text() == "Menu") {
                $('#signBtn').text("Sign In");
                alert("menu")
            }
        })
    });