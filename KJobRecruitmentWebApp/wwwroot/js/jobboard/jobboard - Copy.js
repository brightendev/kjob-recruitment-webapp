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
    .on('click', '#detail_1_l1 > button', function() {
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
                        '<button id="delete" type="button" class="btn btn-default waves-effect">' +
                            '<i class="material-icons">delete</i>' +
                            '<span>ลบฟิลด์</span>' +
                        '</button>' +
                    '</li>';


        $("#detail_1_l1").html(html);

        $("#detail_1_l1 textarea").val(text);
        $("#detail_1_l1 textarea").focus();

        // ======= cancel will revert all text  =======
        $('#detail_1_l1 #cancel').on('click', function () {
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

        // ======= save will save  =======
        $('#detail_1_l1 #save').on('click', function () {
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
    })

    $(function() {
        var max_fields = 10;
        var wrapper = $("[name$='detail[]']");
        var add_button = $("#detail_1_add button");
        var html = 
                    '<div id="detail_1_add" name="mytext[]">' + 
                        '<button type="button" class="list-group-item waves-effect">' +
                            '<div class="detail col-lg-10 col-md-10 col-sm-10 col-xs-10" name="text">เพิ่มฟิลด์</div>' +
                            '<div class="icon col-lg-2 col-md-2 col-sm-2 col-xs-2">' +
                                '<i class="material-icons">add</i>' +
                            '</div>' +
                        '</button>' +
                    '</div>';
        var x = 1;
        $(add_button).click(function(e) {
            console.log('add')
            e.preventDefault();
            
            if (x < max_fields) {
                x++;
                $(wrapper).append(html); //add input box
            } else {
                alert('You Reached the limits')
            }
        });

        $(wrapper).on("click", ".delete", function(e) {
            e.preventDefault();
            $(this).parent('div').remove();
            x--;
        })
    });

});
