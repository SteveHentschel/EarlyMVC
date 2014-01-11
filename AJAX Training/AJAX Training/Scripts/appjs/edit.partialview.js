
$(document).ready(function () {
    
    $("#traininId").hide();
    //Create jQuery timpicker
    $("#edittimepicker").timepicker();
    //Create jQueryUI datepicker
    $("#startdatepicker").datepicker();
    $("#enddatepicker").datepicker();
    $.ajax({
        url: "/Home/GetInstructorList",
        type: 'Get',
        success: function (data) {
            $.each(data, function (i, value) {                
                if (value === selectedTrainer)
                    $('#editselectInstructor').append($('<option>').text(value).attr('value', value).attr("selected", "selected"));
                $('#editselectInstructor').append($('<option>').text(value).attr('value', value));
            });
        }
    });
});


$("#update-button").click(function () {
    $("#editForm").dialog("close");

    var id = $("#traininId").val();
    var name = $("#name").val();
    var instructor = $("#editselectInstructor").val();
    var startdatepicker = $("#startdatepicker").val();
    var enddatepicker = $("#enddatepicker").val();
    var timepicker = $("#edittimepicker").val();
    var duration = $("#duration").val();
    // Call Edit action method
    $.post('/Home/Edit', { "id": id, "name": name, "instructor": instructor, "startdate": startdatepicker, "enddate": enddatepicker, "time": timepicker, "duration": duration }, function () {
        alert("Success! Session was modified.");
        window.location.reload(true);
    });
});

