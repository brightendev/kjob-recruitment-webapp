

//// ===== profile settings ==========
$(function () {
    $('#profile-name').on('click', function () {
        Swal.fire({
            title: 'แก้ไขชื่อ',
            html: '<div ><input type ="text" class="form-control" id = "name"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var name = $('#name').val();
                console.log(name);
                return fetch(`/ajax/set_profile_name`,
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
    $('#profile-Name').on('click', function () {
        Swal.fire({
            title: 'แก้ไขName',
            html: '<div ><input type ="text" class="form-control" id = "engname"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var engname = $('#engname').val();
                console.log(engname);
                return fetch(`/ajax/set_engname`,
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
    $('#profile-birth').on('click', function () {
        Swal.fire({
            title: 'แก้ไขวันเกิด',
            html: '<div ><input type ="text" class="form-control" id = "birth"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var birthdate = $('#birth').val();
                console.log(birthdate);
                return fetch(`/ajax/set_birthdate`,
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
    $('#profile-race').on('click', function () {
        Swal.fire({
            title: 'แก้ไขเชื้อชาติ',
            html: '<div ><input type ="text" class="form-control" id="race"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var race = $('#race').val();
                console.log(race);
                return fetch(`/ajax/set_race`,
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
    $('#profile-nation').on('click', function () {
        Swal.fire({
            title: 'แก้ไขสัญชาติ',
            html: '<div ><input type ="text" class="form-control" id="nation"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var nation = $('#nation').val();
                console.log(nation);
                return fetch(`/ajax/set_nation`,
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
    $('#profile-religion').on('click', function () {
        Swal.fire({
            title: 'แก้ไขศาสนา',
            html: '<div ><input type ="text" class="form-control" id="religion"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var religion = $('#religion').val();
                console.log(religion);
                return fetch(`/ajax/set_religion`,
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
    $('#profile-blood').on('click', function () {
        Swal.fire({
            title: 'แก้ไขกรุ๊ปเลือด',
            html: '<div ><input type ="text" class="form-control" id="blood"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var blood = $('#blood').val();
                console.log(blood);
                return fetch(`/ajax/set_blood`,
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
    $('#status-s').on('click', function () {
        Swal.fire({
            title: 'แก้ไขสถานภาพ',
            html: '<div ><input type ="text" class="form-control" id="status"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var status = $('#status').val();
                console.log(status);
                return fetch(`/ajax/set_status`,
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
    $('#status-military').on('click', function () {
        Swal.fire({
            title: 'แก้ไขสถานภาพทางทหาร',
            html: '<div ><input type ="text" class="form-control" id="military"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var mil = $('#military').val();
                console.log(mil);
                return fetch(`/ajax/set_military`,
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
    $('#contact-address').on('click', function () {
        Swal.fire({
            title: 'แก้ไขที่อยู่',
            html: '<div ><input type ="text" class="form-control" id="address"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var address = $('#address').val();
                console.log(address);
                return fetch(`/ajax/set_address`,
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
    $('#contact-provice').on('click', function () {
        Swal.fire({
            title: 'แก้ไขจังหวัด',
            html: '<div ><input type ="text" class="form-control" id="provice"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var provice = $('#provice').val();
                console.log(provice);
                return fetch(`/ajax/set_provice`,
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
    $('#contact-id').on('click', function () {
        Swal.fire({
            title: 'แก้ไขรหัสไปรษณีย์',
            html: '<div ><input type ="text" class="form-control" id="idaddress"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var idaddress = $('#idaddress').val();
                console.log(idaddress);
                return fetch(`/ajax/set_idaddress`,
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
    $('#contact-tel').on('click', function () {
        Swal.fire({
            title: 'แก้ไขโทรศัพท์',
            html: '<div ><input type ="text" class="form-control" id="tel"></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var tel = $('#tel').val();
                console.log(tel);
                return fetch(`/ajax/set_tel`,
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
    $('#contact-email').on('click', function () {
        Swal.fire({
            title: 'แก้ไขอีเมล',
            html: '<div ><input type ="text" class="form-control" id=""email></div>',
            focusConfirm: false,
            confirmButtonText: 'บันทึก',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            // Ajax request
            preConfirm: () => {
                var email = $('#email').val();
                console.log(email);
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
});
