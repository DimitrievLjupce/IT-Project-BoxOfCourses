$(document).ready(function () {

    $("#registerLink").on(function () {
        this.style.backgroundColor = "white";
    })

    $("#registerLink").on("mouseover", function () {
        this.style.backgroundColor = "#303b51";
        this.style.fontWeight = 500;
    }).on("mouseout", function () {
        this.style.backgroundColor = "#1a202c";
        this.style.fontWeight = 400;
    })

    $("#loginLink").on("mouseover", function () {
        this.style.backgroundColor = "#303b51";
        this.style.fontWeight = 500;
    }).on("mouseout", function () {
        this.style.backgroundColor = "#1a202c";
        this.style.fontWeight = 400;
    })


    //text-color for course-level /Courses/Index
    var beginner = "Beginner";
    var intermediate = "Intermediate";
    var advanced = "Advanced";
    $('.course-level-column').each(function () {
        var textColumn = $(this).html();
        if (textColumn.match(beginner)) {
            $(this).addClass("course-level-beginner");
        } else if (textColumn.match(intermediate)) {
            $(this).addClass("course-level-intermediate");
        } else if (textColumn.match(advanced)) {
            $(this).addClass("course-level-advanced");
        }
    });

    $(function () {
        $(".icon-bar-social-links-index-table").hide();
        $(window).scroll(function (e) {
            if ($(this).scrollTop() > 450) {
                $(".icon-bar-social-links-index-table").fadeIn("slow");
            }
            else {
                $(".icon-bar-social-links-index-table").fadeOut();
            }
        });
    });

})
    
