$(function(){
   /* $("#detail_1_l1 button").click(function() {
        console.log('click');

        var text = $("#detail_1_l1 > button > [name$='text']").text();
        var html =  '<li class="list-group-item">' +
                        '<textarea type="text" class="form-control autoExpand no-resize" rows="2" data-min-rows="2"></textarea>' + 
                        '<button id="save" type="button" class="btn btn-default waves-effect">' + 
                            '<i class="material-icons">save</i>' +
                            '<span>บันทึก</span>' +
                        '</button>' +
                        '<button id="cancel" type="button" class="btn btn-default waves-effect">' +
                            '<i class="material-icons">cancel</i>' +
                            '<span>ยกเลิก</span>' +
                        '</button>' +
                    '</li>';


        $("#detail_1_l1").html(html);

        $("#detail_1_l1 textarea").val(text);
        $("#detail_1_l1 textarea").focus();*/
        
   /*     $("#detail_1_l1 input").focusout(function() {
            text = $("#detail_1_l1 input").val();
            var html =  '<button type="button" class="list-group-item waves-effect">' +
                            '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' + text +'</div>' +
                            '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                                '<i class="material-icons">create</i>' +
                            '</div>' +
                        '</button>';
            $("#detail_1_l1").html(html);
        });*/

   /*     $('#detail_1_l1 #cancel').on('click', function () {
            text = $("#detail_1_l1 textarea").val();
            console.log(text);
            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            text +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#detail_1_l1").html(html);
        });             

    });*/

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
    .on('click', "[id*=detail_] > [id*=line] > button", function(e) {
 
        var detailId = $(this).parent().parent().attr("id");
        var lineId = $(this).parent().attr("id");
        console.log('click at ' + detailId + lineId);

        var textBeforeEdit = $("#"+detailId+" #"+lineId+" [name$='text']").text();

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


        $("#"+detailId+" > #"+lineId).html(html);

        $("#"+detailId+" #"+lineId+" textarea").val(textBeforeEdit);
        $("#"+detailId+" #"+lineId+" textarea").focus();

        // ======= cancel button will revert all text  =======
        $("#"+detailId+" #"+lineId+" [name$='cancel']").on('click', function () {

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

            $("#"+detailId+" > #"+lineId).html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        });   

        // ======= save button will save new text =======
        $("#"+detailId+" #"+lineId+" [name$='save']").on('click', function () {
            console.log('save')
            var textAfterEdit = $("#"+detailId+" #"+lineId+" textarea").val();

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textAfterEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#"+detailId+" > #"+lineId).html(html);
            HideEmptyAndGetNotEmptyLineNumber("#"+detailId);
        }); 
    })



    // ==== when click add new line ===========
    .on('click', "#detail_1 > #addButton", function() {

        console.log('add click');

        var html =  '<div id="line2">' +
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
                        '</li>'
                    '</div>';


        var newButtonHtml = 
                    '<div name="addfield[]">' + 
                        '<button type="button" class="list-group-item waves-effect">' +
                            '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">เพิ่มฟิลด์</div>' +
                            '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                                '<i class="material-icons">add</i>' +
                            '</div>' +
                        '</button>' +
                    '</div>';

        $(html).insertBefore("#detail_1 > #addButton"); //add input box

        $("#detail_1 #line2 textarea").focus();


    });


    HideEmptyAndGetNotEmptyLineNumber('#detail_1');
    HideEmptyAndGetNotEmptyLineNumber('#detail_2');
    HideEmptyAndGetNotEmptyLineNumber('#detail_3');
    HideEmptyAndGetNotEmptyLineNumber('#detail_4');
    HideEmptyAndGetNotEmptyLineNumber('#detail_5');
    HideEmptyAndGetNotEmptyLineNumber('#detail_6');

});

function HideEmptyAndGetNotEmptyLineNumber(detailId) {
   
    var max_line = 6;
    var count = 0;
    var i;
    for (i = 1; i <= max_line; i++) { 
        var isLineEmpty = $(detailId+" > #line"+ i +" [name$='text']").is(':empty');

        if(isLineEmpty) {
            $(detailId+" > #line"+i).hide();
            count++;
        }
    //    console.log('line'+i+' is empty = '+isLineEmpty);
        console.log('copunt = '+count)
    }

    if(count === 0) {
        $(detailId+" > #addButton").hide();
    }
    else {
        $(detailId+" > #addButton").show();
    }

    return max_line - count;
}