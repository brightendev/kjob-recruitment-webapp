$(function(){

    var lineNumber;

    $(document)
    .one('focus > .autoExpand', 'textarea > .autoExpand', function(){
        var savedValue = this.value;
        this.value = '';
        this.baseScrollHeight = this.scrollHeight;
        this.value = savedValue;
    })
    .on('input > .autoExpand', 'textarea > .autoExpand', function(){
        var minRows = this.getAttribute('data-min-rows')|0, rows;
        this.rows = minRows;
        rows = Math.ceil((this.scrollHeight - this.baseScrollHeight) / 16);
        this.rows = minRows + rows;
    })


    // ======== field button listener ========
    .on('click', "[id*=detail_] [name*=line] > button", function(e) {
 
        var detailId = $(this).parent().parent().parent().parent().parent().parent().parent().attr("id");
        var lineName = $(this).parent().attr("name");
        console.log('click at ' + detailId + lineName);

        var textBeforeEdit = $("#"+detailId+" [name$='"+lineName+"'] [name$='text']").text();

        var html =  '<li class="list-group-item" name="field">' +
                        '<textarea type="text" class="form-control autoExpand no-resize" rows="2" data-min-rows="2">' +
                            textBeforeEdit +
                        '</textarea>' + 
                        '<button name="save" type="button" class="btn btn-default waves-effect">' + 
                            '<i class="material-icons">save</i>' +
                            '<span>บันทึก</span>' +
                        '</button>' +
                        '<button name="cancel" type="button" class="btn btn-default waves-effect">' +
                            '<i class="material-icons">cancel</i>' +
                            '<span>ยกเลิก</span>' +
                        '</button>' +
                        '<button id="delete" type="button" class="btn btn-default waves-effect">' +
                            '<i class="material-icons">delete</i>' +
                            '<span>ลบฟิลด์</span>' +
                        '</button>' +
                    '</li>';


        $("#"+detailId+" [name$='"+lineName+"']").html(html);

        $("#"+detailId+" [name$='"+lineName+"'] textarea").val(textBeforeEdit);
        $("#"+detailId+" [name$='"+lineName+"'] textarea").focus();

        // ======= cancel button will revert all text  =======
        $("#"+detailId+" [name$='"+lineName+"'] [name$='cancel']").on('click', function () {

         //   text = $("#detail_1 #line1 textarea").val();
            console.log(textBeforeEdit);

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textBeforeEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#"+detailId+" [name$='"+lineName+"']").html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        });   

        // ======= save button will save new text =======
        $("#"+detailId+" [name$='"+lineName+"'] [name$='save']").on('click', function () {
            console.log('save')
            var textAfterEdit = $("#"+detailId+" [name$='"+lineName+"'] textarea").val();

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textAfterEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#"+detailId+" [name$='"+lineName+"']").html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        }); 
    })



    // ==== when click add new line ===========
    .on('click', "[id*=detail_] #addButton", function() {

        var detailId = $(this).parent().parent().parent().parent().parent().parent().attr("id");
        console.log('adding line to ' + detailId);

        var newLineNumber = FindBottomEmptyLine("#"+detailId);
        console.log('new line add to '+detailId+'is line'+newLineNumber);

        var fieldHtml = '<div name="line'+newLineNumber+'">' +
                            '<li class="list-group-item" name="field">' +
                                '<textarea type="text" class="form-control autoExpand no-resize" rows="2" data-min-rows="2"></textarea>' + 
                                '<button name="save" type="button" class="btn btn-default waves-effect">' + 
                                    '<i class="material-icons">save</i>' +
                                    '<span>บันทึก</span>' +
                                '</button>' +
                                '<button name="cancel" type="button" class="btn btn-default waves-effect">' +
                                    '<i class="material-icons">cancel</i>' +
                                    '<span>ยกเลิก</span>' +
                                '</button>' +
                                '<button id="delete" type="button" class="btn btn-default waves-effect">' +
                                    '<i class="material-icons">delete</i>' +
                                    '<span>ลบฟิลด์</span>' +
                                '</button>' +
                            '</li>' +
                        '</div>';

        $(fieldHtml).insertBefore("#"+detailId+" #addButton"); //add input box

        // delete line sam name as new line which is empty line
        $("#"+detailId+" [name$='line"+newLineNumber+"']:hidden").remove();
        console.log('deleting '+detailId+" [name$='line"+newLineNumber+"']");
        
        $("#"+detailId+" [name$='line"+newLineNumber+"'] textarea").focus();


        // ======= cancel button will revert all text  =======
        $("#"+detailId+" [name$='line"+newLineNumber+"'] [name$='cancel']").on('click', function () {

            var textBeforeEdit = $("#"+detailId+" [name$='line"+newLineNumber+"'] [name$='text']").text();
            console.log(textBeforeEdit);

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textBeforeEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#"+detailId+" [name$='line"+newLineNumber+"']").html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        });   

        // ======= save button will save new text =======
        $("#"+detailId+" [name$='line"+newLineNumber+"'] [name$='save']").on('click', function () {
            console.log('save')
            var textAfterEdit = $("#"+detailId+" [name$='line"+newLineNumber+"'] textarea").val();

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textAfterEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#"+detailId+" [name$='line"+newLineNumber+"']").html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        }); 

    })
     // ============= job detail title editing button event and dialog ========================
    .on('click', "[id*=detail_] [name$='edit-title-btn']", function() {
  //  ("#detail_1 [name$='edit-title-btn']").on('click', function () {

        var detailId = $(this).parent().attr("id");
        var textBeforeEdit = $("#" + detailId + " [name$='detail-title']").text();

        console.log('changing detail ' + detailId + ' title name from the ' + textBeforeEdit);


        Swal.fire({
            title: 'หัวข้อรายละเอียดงาน',
            html: `<div id="dialog_${detailId}"><input type="text" class="form-control" name="text" value="${textBeforeEdit}"></div>`,

            focusConfirm: false,
            confirmButtonText: 'ยืนยัน',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            preConfirm: () => {

                var textAfterEdit = $(`#dialog_${detailId} [name$='text']`).val();

                console.log(textAfterEdit);
                return textAfterEdit;
            }
        })
        .then(result => {
            console.log('new detail title = ' + result.value);
            $(`#${detailId} [name$='detail-title']`).text(result.value);
            $(`.sidenav [name$='${detailId}']`).text(result.value);
        });
    });
    // ========== #END job detail title editing button event and dialog ========================

    HideEmptyAndGetNotEmptyLineNumber('#detail_1');
    HideEmptyAndGetNotEmptyLineNumber('#detail_2');
    HideEmptyAndGetNotEmptyLineNumber('#detail_3');
    HideEmptyAndGetNotEmptyLineNumber('#detail_4');
    HideEmptyAndGetNotEmptyLineNumber('#detail_5');
    HideEmptyAndGetNotEmptyLineNumber('#detail_6');

    
    //============ ajax post adding job ==========
    $('#add_job_save_button').on('click', function () {

        console.log('add job save button clicked');

        var title = $("#basic_information #job-title [name$='value']").text();
        var rawSalary = $("#basic_information #job-salary [name$='value']").text();
        var minSalary = rawSalary.split(" - ")[0];
        var maxSalary = rawSalary.split(" - ")[1];
        var category = $("#basic_information #job-category [name$='value']").text();

        // ========= adding line to detail as json ====
        var i;
        var detail1_json = '{"title":"' + $("#detail_1 [name$='detail-title']").text() + '","l1":"';
        for (var i = 1; i <= 6; i++) {
            var element = $("#detail_1 [name$='line" + i + "'] [name$='text']");

            detail1_json = detail1_json + element.text() + '"';
            if (i + 1 < 7) detail1_json += ',"l' + (i + 1) + '":"';

        }
        detail1_json += '}';

        var detail2_json = '{"title":"' + $("#detail_2 [name$='detail-title']").text() + '","l1":"';
        for (var i = 1; i <= 6; i++) {
            var element = $("#detail_2 [name$='line" + i + "'] [name$='text']");

            detail2_json = detail2_json + element.text() + '"';
            if (i + 1 < 7) detail2_json += ',"l' + (i + 1) + '":"';

        }
        detail2_json += '}';

        var detail3_json = '{"title":"' + $("#detail_3 [name$='detail-title']").text() + '","l1":"';
        for (var i = 1; i <= 6; i++) {
            var element = $("#detail_3 [name$='line" + i + "'] [name$='text']");

            detail3_json = detail3_json + element.text() + '"';
            if (i + 1 < 7) detail3_json += ',"l' + (i + 1) + '":"';

        }
        detail3_json += '}';

        var detail4_json = '{"title":"' + $("#detail_4 [name$='detail-title']").text() + '","l1":"';
        for (var i = 1; i <= 6; i++) {
            var element = $("#detail_4 [name$='line" + i + "'] [name$='text']");

            detail4_json = detail4_json + element.text() + '"';
            if (i + 1 < 7) detail4_json += ',"l' + (i + 1) + '":"';

        }
        detail4_json += '}';

        var detail5_json = '{"title":"' + $("#detail_5 [name$='detail-title']").text() + '","l1":"';
        for (var i = 1; i <= 6; i++) {
            var element = $("#detail_5 [name$='line" + i + "'] [name$='text']");

            detail5_json = detail5_json + element.text() + '"';
            if (i + 1 < 7) detail5_json += ',"l' + (i + 1) + '":"';

        }
        detail5_json += '}';


        console.log(title);
        var jsonText = JSON.stringify(
            {
                title: title,
                min_salary: minSalary,
                max_salary: maxSalary,
                category: category,
                detail_1: detail1_json,
                detail_2: detail2_json,
                detail_3: detail3_json,
                detail_4: detail4_json,
                detail_5: detail5_json,
            });


        console.log(jsonText);

        var response = $.ajax({
            type: "POST",
            url: "addjob/post",
            contentType: "application/json; charset=utf-8",
            data: jsonText,
            dataType: "json",
            async: false,
            success: function (response) {

         //       console.log("response: " + response.value);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
         //       console.log("Status: " + textStatus);
         //       console.log("Error: " + errorThrown);
            }       
        }).responseText;
        console.log(response);
    });
    //========== #END ajax post adding job ==========

    // ============= Job Title Editing dialog ========================
    $('#basic_information #job-title').on('click', function () {

        var textBeforeEdit = $("#basic_information #job-title [name$='value']").text();

        Swal.fire({
                title: 'ชื่องาน',
                html: '<div><input type="text" class="form-control" id="new-value" value="' + textBeforeEdit + '"></div>',
                focusConfirm: false,
                confirmButtonText: 'บันทึก',
                showCancelButton: true,
                cancelButtonText: 'ยกเลิก',
                showLoaderOnConfirm: true,

                preConfirm: () => {

                    var textAfterEdit = $("#new-value").val();

                    console.log(textAfterEdit);
                    return textAfterEdit;
                }
            })

            .then(result => {
                console.log('resuklt = ' + result.value);
                $("#basic_information #job-title [name$='value']").text(result.value);

            });

    });
    // =========== # END Job Title Editing dialog ========================

    // ============= Job salary Editing dialog ========================
    $('#basic_information #job-salary').on('click', function () {

        var textBeforeEdit = $("#basic_information #job-salary [name$='value']").text();
        var minBeforeEdit = textBeforeEdit.split(" - ")[0];
        var maxBeforeEdit = textBeforeEdit.split(" - ")[1];

        Swal.fire({
            title: 'เงินเดือน',
            html:   '<div>' +
                        '<div class = "input-group">' +
                            '<span class="input-group-addon">ขั้นต่ำ : </span>' +
                            '<div class="form-line">' +
                                '<input type="number" class="form-control" id="min-value" value="'+minBeforeEdit+'">' +
                            '</div>' +
                        '</div>' +
                        '<div class = "input-group">' +
                            '<span class="input-group-addon">ขั้นสูง : </span>' +
                            '<div class="form-line">' +
                                '<input type="number" class="form-control" id="max-value" value="'+maxBeforeEdit+'">' +
                            '</div>' +
                        '</div>' +
                    '</div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            preConfirm: () => {

                var minAfterEdit = $("#min-value").val();
                var maxAfterEdit = $("#max-value").val();
                
                var salary = JSON.stringify(
                {
                    min: minAfterEdit,
                    max: maxAfterEdit
                });

                return salary;
            }
        })

        .then(result => {
            var obj = jQuery.parseJSON(result.value);
            console.log('resuklt = ' + obj.min);
            var text = obj.min;
          //  if (obj.max === "") text = obj.min;
          if (obj.max !== "") text += " - " + obj.max;
            $("#basic_information #job-salary [name$='value']").text(text);

        });
  
    });
    // =========== # END Job salary Editing dialog ========================

    // ============= Job category Editing dialog ========================
    $('#basic_information #job-category').on('click', function () {

        var valBeforeEdit = $("#basic_information #job-category [name$='value']").text();
    
        var allCategories = $.ajax({
            type: "GET",
            url: "../ajax/fetchjobcategories",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (data) { }
        }).responseText;
        var categoriesJsonObject = eval('(' + allCategories + ')');

        

        Swal.fire({
                title: 'ชื่องาน',
                html:
                    '<div class="form-group form-float">' +
                        '<div class="form-line" id="dialog-category-dropdown">' +
                            '<select class="form-control" id="Blood" name="blood">' +
                                '<option></option>' +
                            '</select>' +
                        '</div>' +
                    '</div>',

                focusConfirm: false,
                confirmButtonText: 'บันทึก',
                showCancelButton: true,
                cancelButtonText: 'ยกเลิก',
                showLoaderOnConfirm: true,
                onBeforeOpen: () => {
               //     for (var i = 1; i <= categoriesJsonObject.length; i++) {

              //          var category = categoriesJsonObject.find(category => category.id === i.toString());
             //           $('#dialog-category-dropdown select').append('<option value=' + category.id + '>' + category.name + '</option>');
             //           $('#dialog-category-dropdown select > option:eq('+valBeforeEdit+')').prop('selected', true);  // selected
              //          console.log(category);
               //     }
                    $.each(categoriesJsonObject, function (name, category) {
                        console.log(category.id + ": " + category.name);
                        $('#dialog-category-dropdown select').append('<option value=' + category.id + '>' + category.name + '</option>');
                        $('#dialog-category-dropdown select > option:eq(' + valBeforeEdit + ')').prop('selected', true);  // selected
                    });
                },
                preConfirm: () => {

                    var valueAfterEdit = $('#dialog-category-dropdown :selected').val();

                    console.log(valueAfterEdit);
                    return valueAfterEdit;
                }
            })

            .then(result => {
                console.log('result = ' + result.value);
                $("#basic_information #job-category [name$='value']").text(result.value);
                JobCategoryTextReplace();
            });

    });
    // =========== # END Job category Editing dialog ========================

   

    JobCategoryTextReplace();

});

function HideEmptyAndGetNotEmptyLineNumber(detailId) {
   [name$='text']
    var max_line = 6;
    var count = 0;
    var i;
    for (i = 1; i <= max_line; i++) { 
        var isLineEmpty = $(detailId+" [name$='line"+ i +"'] [name$='text']").is(':empty');
    //    isLineEmpty = $("detail_1 .card [name$='line"+ i +"'] [name$='text']").is(':empty');
        if(isLineEmpty) {
            $(detailId+" [name$='line"+i+"']").hide();
            count++;
        }
    //    console.log('line'+i+' is empty = '+isLineEmpty);   
    }
    console.log('on '+detailId+' empty line = '+count)

    if(count === 0) {
        $(detailId+" #addButton").hide();
    }
    else {
        $(detailId+" #addButton").show();
    }

    return max_line - count;
}

function FindBottomEmptyLine(detailId) {
    var max_line = 6;
    var i;
    var emptyLine = -1;
    for(i = max_line; i > 0; i--) {

        var isLineEmpty = $(detailId+" [name$='line"+ i +"'] [name$='text']").is(':empty');

        if(isLineEmpty) {
            $(detailId+" [name$='line"+i+"']").hide();
            emptyLine = i;
        }
    }

    return emptyLine;
}

function JobCategoryTextReplace() {
    var value = $("#basic_information #job-category [name$='value']").text();

    var allCategories = $.ajax({
        type: "GET",
        url: "../ajax/fetchjobcategories",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {}
    }).responseText;

    var categoriesJsonObject = eval('(' + allCategories + ')');
    var myArray = [{ 'id': '73', 'foo': 'bar' }, { 'id': '45', 'foo': 'bar' }];
    var category = categoriesJsonObject.find(category => category.id === value);
    var categoryName = '';
    if (typeof category !== 'undefined') categoryName = category.name;
    console.log(categoryName);

    $("#basic_information #job-category [name$='text']").text(categoryName);
}