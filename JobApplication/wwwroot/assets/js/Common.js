const ResponseMsgType = {
    success: 1,
    error: 2,
    warning: 3,
    info: 4
}

function ShowDynamicSwalAlert(title, msg) {
    const myArray = msg.split("||");
    msg = myArray[0];
    var type = myArray[1];
    if (msg != null && msg != '') {
        if (type.toString() == ResponseMsgType.success.toString()) {
            swal({
                title: title,
                text: msg,
                type: "success",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
                //}, function () {
                //    window.location = '/home/ApplicationDetails?ApplicationId=7';
            });
        } else if (type.toString() == ResponseMsgType.error.toString()) {
            swal({
                title: title,
                text: msg,
                type: "error",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        } else if (type.toString() == ResponseMsgType.warning.toString()) {
            swal({
                title: title,
                text: msg,
                type: "warning",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        } else if (type.toString() == ResponseMsgType.info.toString()) {
            swal({
                title: title,
                text: msg,
                type: "info",
                showCancelButtonClass: "btn-primary",
                confirmButtonText: 'OK'
            });
        }
    }
}

//$(function () {
//    $('.datepicker').datepicker({
//        changeMonth: true,
//        changeYear: true,
//        format: "dd/mm/yyyy",
//        language: "local",
//        todayHighlight: 'TRUE',
//        autoclose: true
//    });
//});
//$(function () {
//    $(".pastdisdatepicker").datepicker({
//        changeMonth: true,
//        changeYear: true,
//        format: "dd/mm/yyyy",
//        language: "local",
//        todayHighlight: 'TRUE',
//        autoclose: true,
//        startDate: new Date()
//    }).datepicker();
//});
$(function () {
    $('.datepicker').datetimepicker({
        //format: 'L',
        format: 'DD/MM/YYYY',
        useCurrent: false
    });
});
$(function () {
    $('.datetimepicker').datetimepicker({
        //format: 'L',
        format: 'DD/MM/YYYY HH:mm',
        useCurrent: false,
    });
});

function AllowNumeric(e) {
    var keyCode = e.which ? e.which : e.keyCode
    if (!((keyCode >= 48 && keyCode <= 57) || keyCode == 46)) {

        return false;
    } else {
    }
}

function AllowAlphaNumeric(e) {


    var k = e.keyCode || e.which;
    var ok = k >= 65 && k <= 90 || // A-Z
        k >= 96 && k <= 105 || // a-z
        k >= 37 && k <= 40 || // arrows
        k == 9 || //tab
        k == 46 || //del
        k == 8 || // backspaces
        (!e.shiftKey && k >= 48 && k <= 57); // only 0-9 (ignore SHIFT options)

    if (!ok || (e.ctrlKey && e.altKey)) {
        e.preventDefault();
    }

}

function funCancelForm(controllerName, actionName) {
    //debugger;
    window.location.href = "/" + controllerName + "/" + actionName;
}

function GetTalukaByDistrictId(districtId) {
    //debugger;
    $.ajax({
        type: "get",
        url: "/Common/GetTalukaByDistrictId",
        data: { districtId: districtId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            //debugger;
            var TalukaList = "";
            console.log(data.data.result.length);
            TalukaList = TalukaList + '<option value="">- Please Select Taluka -</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                TalukaList = TalukaList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listTaluka').html(TalukaList);
        }
    });
}

function GetBlockByTalukaId(talukaId) {
    //debugger;
    $.ajax({
        type: "get",
        url: "/Common/GetBlockByTalukaId",
        data: { talukaId: talukaId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            //debugger;
            var BlockList = "";
            console.log(data.data.result.length);
            BlockList = BlockList + '<option value="">- Please Select Block -</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                BlockList = BlockList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listBlock').html(BlockList);
        }
    });
}

function GetSejaByBlockId(blockId) {
    //debugger;
    $.ajax({
        type: "get",
        url: "/Common/GetSejaByBlockId",
        data: { blockId: blockId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            //debugger;
            var SejaList = "";
            console.log(data.data.result.length);
            SejaList = SejaList + '<option value="">- Please Select Seja -</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                SejaList = SejaList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listSeja').html(SejaList);
        }
    });
}

function GetVillageBySejaId(sejaId) {
    //debugger;
    $.ajax({
        type: "get",
        url: "/Common/GetVillageBySejaId",
        data: { sejaId: sejaId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            //debugger;
            var VillageList = "";
            console.log(data.data.result.length);
            VillageList = VillageList + '<option value="">- Please Select Village -</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                VillageList = VillageList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listVillage').html(VillageList);
        }
    });
}

function GetAanganwadiByVillageId(villageId) {
    //debugger;
    $.ajax({
        type: "get",
        url: "/Common/GetAanganwadiByVillageId",
        data: { villageId: villageId },
        datatype: "json",
        traditional: true,
        success: function (data) {
            //debugger;
            var AanganwadiList = "";
            console.log(data.data.result.length);
            AanganwadiList = AanganwadiList + '<option value="">- Please Select Aanganwadi -</option>';
            for (var i = 0; i < data.data.result.length; i++) {
                AanganwadiList = AanganwadiList + '<option value=' + data.data.result[i].value + '>' + data.data.result[i].text + '</option>';
            }
            $('#listAanganwadi').html(AanganwadiList);
        }
    });
}

function LoadDynamicTPDashboardPartial(currentInstanceIdDistrict, currentInstanceIdTaluka, currentInstanceIdBlock, currentInstanceIdSeja, currentInstanceIdYear, currentInstanceIdMonth, usertypeId, controllerName, actionName, partialDiv) {

    //debugger;
    var currentInstanceId_District = $("#" + currentInstanceIdDistrict).val();
    var currentInstanceId_Taluka = $("#" + currentInstanceIdTaluka).val();
    var currentInstanceId_Block = $("#" + currentInstanceIdBlock).val();
    var currentInstanceId_Seja = $("#" + currentInstanceIdSeja).val();
    var currentInstanceId_Year = $("#" + currentInstanceIdYear).val();
    var currentInstanceId_Month = $("#" + currentInstanceIdMonth).val();

    $.ajax({
        type: "GET",
        url: "/" + controllerName + "/" + actionName,
        data: {
            strdistrictid: currentInstanceId_District,
            strtalukaid: currentInstanceId_Taluka,
            strblockid: currentInstanceId_Block,
            strsejaid: currentInstanceId_Seja,
            stryear: currentInstanceId_Year,
            strmonth: currentInstanceId_Month,
            strusertypeId: usertypeId
        },
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $("#" + partialDiv).html('');
            $("#" + partialDiv).html(response);
        },
        failure: function (response) {
            window.location = "/Home/Error"
        },
        error: function (response) {
            window.location = "/Home/Error"
        }
    });
}

function LoadSchemePartialView(controllerName, actionName, fromDate, toDate, weight, locationId) {
    debugger;
    $.ajax({
        type: "GET",
        url: "/" + controllerName + "/" + actionName,
        data: { fromDate: fromDate, toDate: toDate, ACW: weight, locationId: locationId },
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#dvChargesPartial').html('');
            $('#dvChargesPartial').html(response);
            //$("form").removeData("validator").removeData("unobtrusiveValidation");
            //$.validator.unobtrusive.parse($("form"));
        },
        failure: function (response) {
            window.location = "/Home/Error"
        },
        error: function (response) {
            window.location = "/Home/Error"
        }
    });
}

function ValidatePicture(result) {

    //debugger;
    const file = document.getElementById("FormFile123").files[0];
    const filereader = new FileReader()

    filereader.readAsArrayBuffer(file);

    filereader.onloadend = function () {
        //debugger;
        var arrayBuffer = filereader.result
        //var bytes = new Uint8Array(arrayBuffer);
        //console.log(bytes);


        //const uint = new Uint8Array(arrayBuffer)
        const uint = (new Uint8Array(arrayBuffer)).subarray(0, 4);
        let bytes = []
        uint.forEach((byte) => {
            bytes.push(byte.toString(16))
        })
        const hex = bytes.join('').toUpperCase()
        const mimeType = getMimetype(hex)
        if (!mimeType) {

            alert('Invalid file type');
            document.getElementById('clock').setAttribute("src", '');
            $("#FormFile123").val('');
            /* $('.custom-file-input').siblings(".custom-file-label").removeClass("selected").html('Choose file');*/
            return false;
        }
        if (file.size > 1000000) {
            alert('Uploaded documents are less than 1 MB');
            document.getElementById('clock').setAttribute("src", '');
            $("#FormFile123").val('');
            /*$('.custom-file-input').siblings(".custom-file-label").removeClass("selected").html('Choose file');*/
            return false;
        } else {
            document.getElementById('clock').setAttribute("src", result);
        }
    }


    const getMimetype = (signature) => {
        switch (signature) {
            case '89504E47':
                return true //'image/png'
            case 'FFD8FFE1':
                return true //'image/jpeg'
            case 'FFD8FFE0':
                return true //'image/jpg'
            default:
                return false // 'Unknown filetype'
        }
    }
}
function clearTempData() {
    $.ajax({
        url: '/Home/ClearTempData',
        type: 'POST',
        success: function () {
            //console.log('TempData cleared successfully.');
        },
        error: function () {
            //console.error('Error clearing TempData.');
        }
    });
}