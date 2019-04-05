$(function () {
    //開始時間datepicker
    $(".startDatepicker_btn").datepicker({
    });
    $(".startDatepicker_btn").on("change", function () {
        var startSelectedDate = $(".startDatepicker_btn").val().split('/');
        var startSelectedYear = startSelectedDate[2];
        var startSelectedMonth = startSelectedDate[0];
        var startSelectedDay = startSelectedDate[1];

        $("select.startYear").val(startSelectedYear);
        $("select.startMonth").val(Number(startSelectedMonth));
        $("select.startDay").val(Number(startSelectedDay));
        $(".startDatepicker_btn").val("Cal");
    });
    //終了時間datepicker
    $(".endDatepicker_btn").datepicker({
    });
    $(".endDatepicker_btn").on("change", function () {
        var endSelectedDate = $(".endDatepicker_btn").val().split('/');
        var endSelectedYear = endSelectedDate[2];
        var endSelectedMonth = endSelectedDate[0];
        var endSelectedDay = endSelectedDate[1];

        $("select.endYear").val(endSelectedYear);
        $("select.endMonth").val(Number(endSelectedMonth));
        $("select.endDay").val(Number(endSelectedDay));
        $(".endDatepicker_btn").val("Cal");
    });
    //タイトル文字数チェック
    $(".title_textbox").on("blur",function () {
        var maxLength = 50;
        var nowLength = $(".title_textbox").val().length;
        if (maxLength < nowLength) {
            $("span.title_length").text("50文字以内で入力してください");
        }
    });
    //内容文字数チェック
    var maxLength = 1000;
    $(".textarea_description").on("blur", function () {
        var nowLengthOfDescription = $(".textarea_description").val().length;
        if (maxLength < nowLengthOfDescription) {
            $(".description_length").text("1000文字以内で入力してください");
        }
    });
    //備考文字数チェック
    $(".textarea_note").on("blur", function () {
        var nowLengthOfNote = $(".textarea_note").val().length;
        if (maxLength < nowLengthOfNote) {
            $(".note_length").text("1000文字以内で入力してください");
        }
    });
});

//if ($(".startYear").val() == selectedYear) {
        //    alert($(".startYear").val());
        //    $(".startYear").val(selectedYear);
        //}
        //if ($(".startMonth").val() == selectedMonth) {
        //    alert($(".startMonth").val());
        //    $(".startMonth").val(selectedMonth);
        //}
        //if ($(".startDay").val() == selectedDay) {
        //    alert($(".startDay").val());
        //    $(".startDay").val(selectedDay);
        //}

        //$(".startYear option[value=" + selectedYear + "]").attr("selected", "selected");
        //$(".startYear option[value=" + selectedYear + "]").prop("selected", true);


        //$(".startYear option").filter(function (i) {
        //    return startYearElements[0].options[i].value == selectedYear
        //}).prop("selected", true);



    //    var month =  $(".startMonth").val(selectedDate[0]);
    //    var day = $(".startDay").val(selectedDate[1]);



    //    var startMonthElements = document.getElementsByName("startMonth");
    //    for (i = 0; i < startMonthElements.options.length; i++) {
    //        if (startMonthElements.options[i].value == month) {
    //            startMonthElements[i].selected = true;
    //            break;
    //        }
    //    }
    //    var startDayElements = document.getElementsByName("startDay");
    //    for (i = 0; i < startDayElements.options.length; i++) {
    //        if (startDayElements.options[i].value == day) {
    //            startDayElements[i].selected = true;
    //            break;
    //        }
    //    }

        //if (year == $(".startYear").val()) {
        //    $(".startYear option:selected").attr("selected", "selected");
        //}
        //if (year == $(".startMonth").val()) {
        //    $(".startMonth option:selected").attr("selected", "selected");
        //}
        //if (year == $(".startDay").val()) {
        //    $(".startDay option:selected").attr("selected", "selected");
        //}


