
$(function() {

    $("#email-filter").keyup(function () {
        var input, filter, table, tr, td, i, txtValue;
        input = document.getElementById("email-filter");
        filter = input.value.toUpperCase();
        table = document.getElementById("mytable");
        tr = table.getElementsByTagName("tr");

        for (i = 0; i < tr.length; i++) {
            td = tr[i].getElementsByTagName("td")[0];
            if (td) {
                txtValue = td.textContent || td.innerText;
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    tr[i].style.display = "";
                } else {
                    tr[i].style.display = "none";
                }
            }
        }
    });

    

    /*กรอง role*/
    $("#role-name").change(function () {
        var rex = new RegExp($('#role-name').val());
        if (rex == "/all/") { clearFilter() } else {
            $('.item').hide();
            $('.item').filter(function () {
                return rex.test($(this).text());
            }).show();
        }
    });

    function clearFilter() {
        $('.filterText').val('');
        $('.item').show();
    }

    // ============== table row selection ==========
    $("#tablelist tr").click(function () {
        $(this).addClass('selected').siblings().removeClass('selected');
        var value = $(this).find('td:first').html();

    });
    $("#tablelist tr").hover(function () {
        $(this).css('cursor', 'pointer');
    }, function () {
        $(this).css('cursor', 'auto');
    });
    // ======== #END table row selection ==========

    // ========== test row selection =========
    $('.del').on('click', function (e) {

        alert($("#tablelist tr.selected td:first").html());
    });


    // ============= add new account button event and dialog ========================
    $('.quickbar .button-group #add-new-account-btn').on('click', function() {
        console.log('adding new account');
        Swal.fire({
            title: 'เพิ่มบัญชี',
            html:       '<div id="add-new-account-dialog">' +                           
                            '<div class="input-group">' +
                                '<span class="input-group-addon">' +
                                    '<i class="material-icons">email</i>' +
                                '</span>' +
                                '<div class="form-line">' +
                                    '<input id="email" type="email" class="form-control" name="email" placeholder="ที่อยู่อีเมล์" required="" aria-required="true">' +
                                '</div>' +
                            '</div>' +
                            '<div class="input-group">' +
                                '<span class="input-group-addon">' +
                                    '<i class="material-icons">lock</i>' +
                                '</span>' +
                                '<div class="form-line">' +
                                    '<input id="email" type="password" class="form-control" name="password" placeholder="รหัสผ่าน" required="" aria-required="true">' +
                                '</div>' +
                            '</div>'+
                            '<div class="input-group">' +
                                '<span class="input-group-addon">' +
                                    '<i class="material-icons">lock</i>' +
                                '</span>' +
                                '<div class="form-line">' +
                                    '<input id="email" type="password" class="form-control" name="confirm-password" placeholder="ยืนยันรหัสผ่าน" required="" aria-required="true">' +
                                '</div>' +
                            '</div>' +
                        '</div>' ,


            focusConfirm: false,
            confirmButtonText: 'ยืนยัน',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            preConfirm: () => {

                var email = $("#add-new-account-dialog [name$='email']").val();
                var password = $("#add-new-account-dialog [name$='password']").val();

                console.log(email);

                return fetch(`/ajax/addnewaccount/${email}/${password}`,
                        {
                            method: "GET",
                            mode: "cors",
                            cache: "no-cache",
                            credentials: "same-origin",
                            headers: { "Content-Type": "application/json" },
                        }
                    )
                    .then(response => {
                        if (!response.ok) {
                            throw new Error(response.statusText);
                        }
                        var resp = response.text();
                        console.log('response = ' + resp);
                        return resp;
                    })
                    .catch(error => {
                        Swal.showValidationMessage(
                            `Request failed: ${error}`
                        );
                    });
            }
        })

        // result
        .then((result) => {
            console.log('fghgfhfgh');

            if (result.value === 'RegisterSuccess') {

                Swal.fire({
                    type: 'success',
                    title: 'สร้างบัญชีใหม่แล้ว'
                });
            } else if (result.value && result.value.indexOf('error') != -1) {
                Swal.fire({
                    type: 'error',
                    title: 'เกิดข้อผิดพลาด',
                    text: result.value
                });
            } else if (result.value) {
                Swal.fire({
                    type: 'warning',
                    title: 'unkwnown error'
                });
            }
        });  
    });
    // ========== #END add new account button event and dialog ========================

    // ============= change role button event and dialog ========================
    $('.quickbar .button-group #change-role-btn').on('click', function () {

        var email = $("#tablelist tr.selected td:first").text();

        if (email === '') {

            Swal.fire({
                type: 'info',
                title: 'กรุณาเลือกบัญชี',
            });
        }
        else {

            console.log('changing role of account= ' + email);

            Swal.fire({
                title: 'เปลี่ยน Role',
                html:  
                    `<p>เปลี่ยน Role ของบัญชี ${email}</p>` +
                    '<div id="change-role-dialog">' +   
                        '<div class="form-group form-float">' +
                            '<div class="form-line">' +
                                '<select class="form-control" name="role">' +
                                    '<option value="1">Candidate</option>' +
                                    '<option value="2">Staff</option>' +
                                    '<option value="3">Admin</option>' +
                                '</select>' +
                            '</div>' +
                        '</div>' +
                    '</div>',


                focusConfirm: false,
                confirmButtonText: 'ยืนยัน',
                showCancelButton: true,
                cancelButtonText: 'ยกเลิก',
                showLoaderOnConfirm: true,

                preConfirm: () => {

                    if (email == null) return 'NotSelectAccount';

                    var newRole = $("#change-role-dialog [name$='role']").val();

                    console.log('changing role to= '+newRole);

                    return fetch(`ajax/changerole/${email}/${newRole}`,
                            {
                                method: "GET",
                                mode: "cors",
                                cache: "no-cache",
                                credentials: "same-origin",
                           //     headers: { "Content-Type": "application/json" },
                            }
                        )
                        .then(response => {
                            if (!response.ok) {
                                throw new Error(response.statusText);
                            }
                            var resp = response.text();
                            console.log('response = ' + resp);
                            return resp;
                        })
                        .catch(error => {
                            Swal.showValidationMessage(
                                `Request failed: ${error}`
                            );
                        });
                }
            })

            // result
            .then((result) => {

                if (result.value === '{"ChangeRole" : "success" }') {

                    Swal.fire({
                        type: 'success',
                        title: 'เปลียน Role สำเร็จ'
                    });
                } 
                else if (result.value && result.value.indexOf('error') != -1) {
                    Swal.fire({
                        type: 'error',
                        title: 'เกิดข้อผิดพลาด',
                        text: result.value
                    });
                }
                else if (result.value) {
                    Swal.fire({
                        type: 'warning',
                        title: 'unkwnown error'
                    });
                }
            });  

        }
        
    });
    // ========== #END change role button event and dialog ========================

  //  $("#tablelist tr.selected)
});