function clickDtBeg() {
    $("#dtBeg").datepicker({
        language: "ru"
    });
};
function clickDtEnd() {
    $("#dtEnd").datepicker({
        language: "ru"
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
    $("#excelDiv").hide();
}

function enableExcelDiv() {
    $("#excelDiv").show();
}