

//// ===== notification settings ==========
$(function () {
    $('#notification-all').on('click', function () {
        Swal.fire({
            title: 'การแจ้งเตือน',
            html: '<div class="switch"><label>OFF<input type="checkbox" id="status" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บัยทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

                    // Ajax request
            preConfirm: () => {
                var status = $('#status').is(':checked');
                console.log(status);
                return fetch(`/ajax/set_notification_all`, 
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
});

$(function () {
    $('#notification-email').on('click', function () {
        Swal.fire({
            title: 'การแจ้งเตือน',
            html: '<div class="switch"><label>OFF<input type="checkbox" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บัยทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

                    // Ajax request
            preConfirm: () => {
                return fetch(`/ajax/getallblood`, 
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
                    return response.json();
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    );
                });
            }
        })
        .then((result) => {
            if (result.value) {
                console.log(result.value);
                Swal.fire({
                    title: `response`,
                    html: 'response : ' + result.value
                });
            }
        });
    });
});

$(function () {
    $('#notification-news').on('click', function () {
        Swal.fire({
            title: 'การแจ้งเตือน',
            html: '<div class="switch"><label>OFF<input type="checkbox" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บัยทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

                    // Ajax request
            preConfirm: () => {
                return fetch(`/ajax/getallblood`, 
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
                    return response.json();
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    );
                });
            }
        })
        .then((result) => {
            if (result.value) {
                console.log(result.value);
                Swal.fire({
                    title: `response`,
                    html: 'response : ' + result.value
                });
            }
        });
    });
});

$(function () {
    $('#notification-interested-job').on('click', function () {
        Swal.fire({
            title: 'การแจ้งเตือน',
            html: '<div class="switch"><label>OFF<input type="checkbox" checked><span class="lever"></span>ON</label></div>',
            focusConfirm: false,
            confirmButtonText: 'บัยทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

                    // Ajax request
            preConfirm: () => {
                return fetch(`/ajax/getallblood`, 
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
                    return response.json();
                })
                .catch(error => {
                    Swal.showValidationMessage(
                        `Request failed: ${error}`
                    );
                });
            }
        })
        .then((result) => {
            if (result.value) {
                console.log(result.value);
                Swal.fire({
                    title: `response`,
                    html: 'response : ' + result.value
                });
            }
        });
    });
});