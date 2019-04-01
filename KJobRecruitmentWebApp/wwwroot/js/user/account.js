

//// ===== notification settings ==========


$(function () {
    //============ edit notification section ===========





     /*---------------------------------------- edit notification-all----------------------------------------*/
    $('#notification-all').on('click', function () {
        Swal.fire({
            title: 'ตั้งค่าการแจ้งเตือนทั้งหมด',
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
                    document.getElementById("notification-status").innerHTML = "เปิดใช้งานอยู่";
                    value  = 'on';
                }
                else {
                    document.getElementById("notification-status").innerHTML = "ปิดใช้งานอยู่";
                    value = 'off';
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
    $('#notification-interested-job').on('click', function () {
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
