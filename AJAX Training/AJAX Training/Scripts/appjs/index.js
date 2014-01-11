
var selectedId = 0;
$(document).ready(function () {
    $(".itemIdClass").hide();
    $("#deleteForm").hide();
});
//jQueryUI method to create dialog box
$("#createForm").dialog({
    autoOpen: false,
    modal: true,
    width: 450,
    title: "Create Training"
});
//jQueryUI method to create dialog box
$("#editForm").dialog({
    autoOpen: false,
    modal: true,
    width: 450,
    title: "Edit Selected Training"
});
//jQueryUI method to create dialog box
$("#deleteForm").dialog({
    autoOpen: false,
    modal: true,
    title: "Delete Selected Training"
});

$(".buttonCreate").button().click(function () {
       $.ajax({
	    // Call CreatePartialView action method
        url: "/Home/_CreatePopUp",
        type: 'Get',
        success: function (data) {          
            $("#createForm").dialog("open");
            $("#createForm").empty().append(data);
            $("#editForm").hide();
        },
        error: function () {
            alert("Something wrong in Create.");
        }
    });
});

var selectedTrainer;

$(".buttonEdit").button().click(function () {   
    // Get the Id if selected training and assign in selectedId variable    
    var selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
    selectedTrainer = $(this).parents('tr:first').children('td:nth-child(3)').text().trim();
    
    $.ajax({
	// Call EditPartialView action method
        url: "/Home/_EditPopUp",
        data: { id: selectedId },
        type: 'Get',
        success: function (msg) {
            $("#editForm").dialog("open");
            $("#editForm").empty().append(msg);
            $("#createForm").hide();
			},
        error: function () {
            alert("Something wrong in Edit.");
        }
    });
});



$(".buttonDelete").button().click(function () {
    //Open the dialog box
    $("#deleteForm").dialog("open");
    //Get the TrainingId
    selectedId = $(this).parents('tr:first').children('td:first').children('input:first').attr('value');
});

$(".okDelete").button().click(function () {
// Close the dialog box on Yes button is clicked
    $("#deleteForm").dialog("close");

    $.ajax({
	// Call Delete action method
        url: "/Home/Delete",
        data: { id: selectedId },
        type: 'Get',
        success: function (msg) {
            window.location.reload(true);
        },
        error: function (xhr) {
            alert("Something wrong in Delete.");
        }
    });
});


