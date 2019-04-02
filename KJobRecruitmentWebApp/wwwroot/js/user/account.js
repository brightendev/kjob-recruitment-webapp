

//// ===== notification settings ==========


// ================= html notification text replace ============= 
function notificationStatusTextReplacer() {

    console.log($("#notification-all > [name$='value']").text());
    if ($("#notification-all > [name$='value']").text() === 'True') {
        $("#notification-all > [name$='status-text']").text('เปิดการใช้งานอยู่');
    }
    else if ($("#notification-all > [name$='value']").text() === 'False') {
        $("#notification-all > [name$='status-text']").text('ปิดการใช้งานอยู่');
    }

    if ($("#notification-email > [name$='value']").text() === 'True') {
        $("#notification-email > [name$='status-text']").text('เปิดการใช้งานอยู่');
    }
    else if ($("#notification-email > [name$='value']").text() === 'False') {
        $("#notification-email > [name$='status-text']").text('ปิดการใช้งานอยู่');
    }

    if ($("#notification-news > [name$='value']").text() === 'True') {
        $("#notification-news > [name$='status-text']").text('เปิดการใช้งานอยู่');
    }
    else if ($("#notification-news > [name$='value']").text() === 'False') {
        $("#notification-news > [name$='status-text']").text('ปิดการใช้งานอยู่');
    }

    if ($("#notification-interested > [name$='value']").text() === 'True') {
        $("#notification-interested > [name$='status-text']").text('เปิดการใช้งานอยู่');
    }
    else if ($("#notification-interested > [name$='value']").text() === 'False') {
        $("#notification-interested > [name$='status-text']").text('ปิดการใช้งานอยู่');
    }
}
// =========== # end html notification text replace

$(function () {

    
    notificationStatusTextReplacer();

    /*---------------------------------------- edit notification-all----------------------------------------*/
    $('#notification-all').on('click', function () {

        var isCheck = '';
        if ($("#notification-all > [name$='value']").text() === 'True') {
            isCheck = 'checked';
        }
        else if ($("#notification-all > [name$='value']").text() === 'False') {
            isCheck = '';
        }

        Swal.fire({
            title: 'ตั้งค่าการแจ้งเตือนทั้งหมด',
            html: '<div class="switch"><label>ปิด<input type="checkbox" id="status"' + isCheck +'><span class="lever"></span>เปิด</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var status = $('#status').is(':checked');
                var value;
                /* check status*/
                if (status) {
                    value = 'on';
                    $("#notification-all > [name$='value']").text('True');
                }
                else {
                    value = 'off';
                    $("#notification-all > [name$='value']").text('False');
                }
                console.log(`setting notification_all to ${value}`);
                return fetch(`/ajax/set_notification_all/${value}`,
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
                    return response.text();
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
            console.log(result.value);

            if (result.value === 'success') {
                notificationStatusTextReplacer(); // reload status
                Swal.fire({
                    type: 'success',
                    title: `แก้ไขแล้ว`
                });
            }
            else if (result.value === 'error') {
                Swal.fire({
                    type: 'error',
                    title: 'เกิดข้อผิดพลาด'
                });
            }
            else if (result.value){
                Swal.fire({
                    type: 'warning',
                    title: 'unkwnown error'
                });
            }
        });
    });
    /*----------------------------------------end of edit notification-all----------------------------------------*/


    /*----------------------------------------edit email notification----------------------------------------*/
    $('#notification-email').on('click', function () {
        Swal.fire({
            title: 'ตั้งค่าการแจ้งเตือนอีเมล์',
            html: '<div class="switch"><label>OFF<input type="checkbox" id="status" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var status = $('#status').is(':checked');
                var value;
                /* check status*/
                if (status) {
                    document.getElementById("notification-statusEmail").innerHTML = "เปิดใช้งานอยู่";
                    value = 'on';
                }
                else {
                    document.getElementById("notification-statusEmail").innerHTML = "ปิดใช้งานอยู่";
                    value = 'off';
                }
                console.log(`setting notification_email to ${value}`);
                return fetch(`/ajax/set_notification_email/${value}`,
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
                    return response.text();
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
            console.log(result.value);

            if (result.value == 'success') {
                Swal.fire({
                    type: 'success',
                    title: `แก้ไขแล้ว`
                });
            }
            else if (result.value == 'error') {
                Swal.fire({
                    type: 'error',
                    title: 'เกิดข้อผิดพลาด'
                });
            }
            else if (result.value) {
                Swal.fire({
                    type: 'warning',
                    title: 'unkwnown error'
                });
            }
        });
    });
    /*----------------------------------------end of edit email notification----------------------------------------*/

     /*----------------------------------------edit  notification-news----------------------------------------*/
    $('#notification-news').on('click', function () {
        Swal.fire({
            title: 'ตั้งค่าการแจ้งเตือนข่าวสาร',
            html: '<div class="switch"><label>OFF<input type="checkbox" id="status" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var status = $('#status').is(':checked');
                var value;
                /* check status*/
                if (status) {
                    document.getElementById("notification-statusEmail").innerHTML = "เปิดใช้งานอยู่";
                    value = 'on';
                }
                else {
                    document.getElementById("notification-statusEmail").innerHTML = "ปิดใช้งานอยู่";
                    value = 'off';
                }
                console.log(`setting notification_news to ${value}`);
                return fetch(`/ajax/set_notification_news/${value}`,
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
                    return response.text();
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
            if (result.value == 'success') {
                console.log(result.value);
                Swal.fire({
                    type: 'success',
                    title: `แก้ไขแล้ว`
                });
            }
            else if (result.value) {
                Swal.fire({
                    type: 'warning',
                    title: 'unkwnown error'
                });
            }
        });
    });
    /*----------------------------------------end of edit  notification-news ----------------------------------------*/


    /*----------------------------------------edit notification-interested-job----------------------------------------*/
    $('#notification-interested').on('click', function () {
        Swal.fire({
            title: 'ตั้งค่าการแจ้งเตือนงานที่สนใจ',
            html: '<div class="switch"><label>OFF<input type="checkbox" id="status" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            // Ajax request
            preConfirm: () => {
                var status = $('#status').is(':checked');
                var value;
                /* check status*/
                if (status) {
                    document.getElementById("notification-statusEmail").innerHTML = "เปิดใช้งานอยู่";
                    value = 'on';
                }
                else {
                    document.getElementById("notification-statusEmail").innerHTML = "ปิดใช้งานอยู่";
                    value = 'off';
                }
                console.log(`setting notification_interested to ${value}`);
                return fetch(`/ajax/set_notification_interested/${value}`,
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
                    return response.text();
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
            console.log(result.value);

            if (result.value == 'success') {
                Swal.fire({
                    type: 'success',
                    title: `แก้ไขแล้ว`
                });
            }
            else if (result.value == 'error') {
                Swal.fire({
                    type: 'error',
                    title: 'เกิดข้อผิดพลาด'
                });
            }
            else if (result.value) {
                Swal.fire({
                    type: 'warning',
                    title: 'unkwnown error'
                });
            }
        });
    });
    /*----------------------------------------end of edit notification-interested-job----------------------------------------*/





    // ============= edit profile section ============================================================================================

    /*edit account*/
    $('#account-email').on('click', function () {
        Swal.fire({
            title: 'แก้ไขอีเมล์',
            html: '<div ><input type="text" class="form-control" id="dataEmail" </div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,
            // Ajax request
            preConfirm: () => {
                var data = $('#dataEmail').val();
                console.log(data);
                return fetch(`/ajax/set_email`,
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
                        return response.text();
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
                if (result.value == 'success') {
                    console.log(result.value);
                    Swal.fire({
                        type: 'success',
                        title: `แก้ไขแล้ว`
                    });
                }
                if (result.value == 'error') {
                    Swal.fire({
                        type: 'error',
                        title: 'เกิดข้อผิดพลาด'
                    });
                }
            });
        
    });
    /*end edit email*/


    /*edit password*/
    $('#account-pass').on('click', function () {
        Swal.fire({
            title: 'แก้ไขรหัสผ่าน',
            html: '<div ><input type="text" class="form-control" id="dataPass" </div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,
            // Ajax request
            preConfirm: () => {
                var data = $('#dataPass').val();
                console.log(data);
                return fetch(`/ajax/set_password`,
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
                        return response.text();
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
                if (result.value == 'success') {
                    console.log(result.value);
                    Swal.fire({
                        type: 'success',
                        title: `แก้ไขแล้ว`
                    });
                }
                if (result.value == 'error') {
                    Swal.fire({
                        type: 'error',
                        title: 'เกิดข้อผิดพลาด'
                    });
                }
            });

    });
    /*end of edit passoword*/











    //end of all function
});
