function clickDtBeg() {
    $("#dtBeg").datepicker({
    });
};
function clickDtEnd() {
    $("#dtEnd").datepicker({
    });
};
function disableButtons() {
    $("#createBt").hide();
    $("#showCreateBt").hide();
    $("#unloadBt").hide();
}

function enableButtons() {
    $("#createBt").show();
    $("#unloadBt").show();
}

function disableExcelDiv() {
    $("#createBt").hide();
    $("#excelDiv").hide();
    $("#pages").hide();
}

function enableExcelDiv() {
    $("#createBt").show();
    $("#excelDiv").show();
    $("#pages").show();
}