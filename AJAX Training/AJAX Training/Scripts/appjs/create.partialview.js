
$(document).ready(function () {
    //Create jQuery timpicker
    $("#timepicker").timepicker();
    //Create jQueryUI datepicker
    $("#startdatepicker").datepicker();
    //Create jQueryUI datepicker
    $("#enddatepicker").datepicker();

    $.ajax({
        //Call GetInstructorList action method
        url: "/Home/GetInstructorList",
        type: 'Get',
        success: function (data) {
            $.each(data, function (i, value) {
                $('#selectInstructor').append($('<option>').text(value).attr('value', value));
            });
        }
    });
});

$("#submit-button").click(function () {
    // On submit button click close dialog box
    $("#createForm").dialog("close");

    //Set inserted vlaues
    var name = $("#trainingname").val();
    var selectInstructor = $("#selectInstructor").val();
    var startdatepicker = $("#startdatepicker").val();
    var enddatepicker = $("#enddatepicker").val();
    var timepicker = $("#timepicker").val();
    var duration = $("#duration").val();

    // Call Create action method
    $.post('/Home/Create', { "name": name, "instructor": selectInstructor, "startdate": startdatepicker, "enddate": enddatepicker, "time": timepicker, "duration": duration },
        function () {
            alert("data is posted successfully");
            window.location.reload(true);

        });
});

