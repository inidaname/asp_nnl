
function printdiv(ExportApplicationDetails) {
    var headstr = "<html><head><title></title></head><body style='width:40px'>";
    var footstr = "</body></html>";
    var newstr = document.all.item(ExportApplicationDetails).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
};


function printdiv(InvoiceDetails) {
    var headstr = "<html><head><title></title></head><body>";
    var footstr = "</body></html>";
    var newstr = document.all.item(InvoiceDetails).innerHTML;
    var oldstr = document.body.innerHTML;
    document.body.innerHTML = headstr + newstr + footstr;
    window.print();
    document.body.innerHTML = oldstr;
    return false;
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

function TextChangingExportPermit() {
    $('#FilterParameter').on('input', function (e) {
        if ($(this).data("lastval") != $(this).val()) {
            $(this).data("lastval", $(this).val());
            //change action
            //alert($(this).val());
            document.getElementById("Filters").click();
            $('#FilterParameter').focus()

        };
    });
};


function TextChangingBill() {
    $('#FilterBills').on('input', function (e) {
        if ($(this).data("lastval") != $(this).val()) {
            $(this).data("lastval", $(this).val());
            //change action
            //alert($(this).val());
            document.getElementById("FilterBill").click();
            $('#FilterBills').focus()

        };
    });
};


function TextChanging() {
    $('#FilterUpload').on('input', function (e) {
        if ($(this).data("lastval") != $(this).val()) {
            $(this).data("lastval", $(this).val());
            //change action
            //alert($(this).val());
            document.getElementById("FilterUploadButton").click();
            $('#FilterUpload').focus()

        };
    });
};




function TextChangingExport() {
    $('#SearchExportPermit').on('input', function (e) {
        if ($(this).data("lastval") != $(this).val()) {
            $(this).data("lastval", $(this).val());
            //change action
            //alert($(this).val());
            document.getElementById("SearchPermit").click();
            $('#SearchExportPermit').focus()

        };
    });
};


$(function () {
    $("#DateFrom").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#DateTo").datepicker({ dateFormat: 'dd-mm-yy' });

});


$(function () {
    $("#BillofLadingDate").datepicker({ dateFormat: 'dd-mm-yy' });

});

$(function () {
    $("#AcceptanceDate").datepicker({ dateFormat: 'dd-mm-yy' });

});


$(document).on('click', function (e) {
    if ($(e.target).closest(".calendar").length === 0) {
        $(".calendar").hide();
        $(".calendar").slideup("slow");
    }


});


$(function () {
    $("#DateFrom").datepicker({ dateFormat: 'dd-mm-yy' });

});



$(function () {
    $("#DateTo").datepicker({ dateFormat: 'dd-mm-yy' });

});

$(function () {
    $("#InspectionDate").datepicker({ dateFormat: 'dd-mm-yy' });

});
$(function () {
    $("#EnforcementDate").datepicker({ dateFormat: 'dd-mm-yy' });

});


function CheckCompany() {
    if (document.getElementById("CompanyName").value == "...Select Company...") {

        alert("Select company name please!")
    }
}
