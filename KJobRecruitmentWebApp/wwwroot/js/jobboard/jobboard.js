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

    });


    HideEmptyAndGetNotEmptyLineNumber('#detail_1');
    HideEmptyAndGetNotEmptyLineNumber('#detail_2');
    HideEmptyAndGetNotEmptyLineNumber('#detail_3');
    HideEmptyAndGetNotEmptyLineNumber('#detail_4');
    HideEmptyAndGetNotEmptyLineNumber('#detail_5');
    HideEmptyAndGetNotEmptyLineNumber('#detail_6');


    //============ ajax post adding job ==========


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