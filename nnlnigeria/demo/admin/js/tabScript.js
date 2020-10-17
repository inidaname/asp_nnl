$(document).ready(function() {        
    ('#openModal').click(function() {
        $('.modal').show();
    });         
    //Hide modal box         
    $('#closeModal').click( function() {
        $('.dumbBoxWrap').hide();
    }         ); });

 
$(function () {
    $("#tabs").tabs();
});

$(document).ready(function () {
   
    $('ul.tabs .TabPanel li').click(function () {
        var tab_id = $(this).attr('data-tab');

        $('ul.tabs .TabPanel li').removeClass('current');
        $('.tab-content').removeClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');

        $(this).addClass('current');
        $("#" + tab_id).addClass('current');
    })


});


$(function () {
    $("#InspectionDate").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#EndorsementDate").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#RecommendationDate").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#ApprovalDate").datepicker({ dateFormat: 'dd-mm-yy' });

});

$(function () {
    $("#EntryDate").datepicker({ dateFormat: 'dd-mm-yy' });

});


$(function () {
    $("#LoadingDate").datepicker({ dateFormat: 'dd-mm-yy' });

});


$(function () {
    $("#ExitDate").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#FilterDateFrom").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#FilterDateTo").datepicker({ dateFormat: 'dd-mm-yy' });

});


function NewWindow() {
    document.forms[0].target = "_blank";
};


function CheckOne(obj) {
    var grid = obj.parentNode.parentNode.parentNode;
    var inputs = grid.getElementsByTagName("input");
    for (var i = 0; i < inputs.length; i++) {
        if (inputs[i].type == "checkbox") {
            if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                inputs[i].checked = false;
            }
        }
    }
};


function SetCaretAtEnd(elem) {
    var elemLen = elem.value.length;
    // For IE Only
    if (document.selection) {
        // Set focus
        elem.focus();
        // Use IE Ranges
        var oSel = document.selection.createRange();
        // Reset position to 0 & then set at end
        oSel.moveStart('character', -elemLen);
        oSel.moveStart('character', elemLen);
        oSel.moveEnd('character', 0);
        oSel.select();
    }
    else if (elem.selectionStart || elem.selectionStart == '0') {
        // Firefox/Chrome
        elem.selectionStart = elemLen;
        elem.selectionEnd = elemLen;
        elem.focus();
    } // if
}; // SetCaretAtEnd()

function TextChanging() {
    $('#Parameter').on('input', function (e) {
        if ($(this).data("lastval") != $(this).val()) {
            $(this).data("lastval", $(this).val());
            //change action
            //alert($(this).val());
            document.getElementById("ShowReport").click();
            $('#Parameter').focus()
        };
    });
};

