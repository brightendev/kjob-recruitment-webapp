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
    .on('click', '#detail_1 > #line1 > button', function() {
        console.log('click');

        var textBeforeEdit = $("#detail_1 #line1 [name$='text']").text();

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


        $("#detail_1 > #line1").html(html);

        $("#detail_1 #line1 textarea").val(textBeforeEdit);
        $("#detail_1 #line1 textarea").focus();

        // ======= cancel button will revert all text  =======
        $("#detail_1 #line1 [name$='cancel']").on('click', function () {

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

            $("#detail_1 > #line1").html(html);
        });   

        // ======= save button will save new text =======
        $("#detail_1 #line1 [name$='save']").on('click', function () {
            console.log('save')
            var textAfterEdit = $("#detail_1 #line1 textarea").val();

            html =  '<button type="button" class="list-group-item waves-effect">' +
                        '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">' +
                            textAfterEdit +
                        '</div>' +
                        '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                            '<i class="material-icons">create</i>' +
                        '</div>' +
                    '</button>';

            $("#detail_1 > #line1").html(html);
            scanLine();
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

   //     $("[name$='addfield[]").html(fieldHtml);
      //  this.
    //    $("[name$='addfield[]").focus();

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


    scanLine();

});

function scanLine() {
    var i;
    for (i = 1; i < 7; i++) { 
      var isLineEmpty = $("#line"+ i +" [name$='text']").is(':empty');

      if(isLineEmpty) {
        $('#line'+i).hide();
      }
      console.log('line'+i+' is empty = '+isLineEmpty);
    }
}