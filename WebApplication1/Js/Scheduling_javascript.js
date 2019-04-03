$(function () {

    $(".datepicker_btn").datepicker();
    
    $(".title_textbox").blur(function () {
        var maxLength = 50;
        var nowLength = $(".title_textbox").val().length;
        if (maxLength < nowLength) {
            $("span.title_length").text("50文字以内で入力してください");
        }
    });
    
    $("textarea").blur(function () {
        var maxLength = 1000;
        var nowLength = $("textarea").val().length;
        if (maxLength < nowLength) {
            if (this.className == "textarea_description") {
                $("span.description_length").text("1000文字以内で入力してください");
            } else if (this.className == "textarea_note") {
                $("span.note_length").text("1000文字以内で入力してください");
            }
        }
    });

    
});


