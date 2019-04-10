$(function() {

    $('.quickbar .button-group #apply-button').on('click', function() {

        console.log('applying job');

        Swal.fire({
            type: "info",
            title: 'กรุณาลงชื่อเข้าใช้ระบบ',
            html: '<h5>กรุณาลงชื่อเข้าใช้ระบบก่อนจะทำการสมัครงาน</h5><p>กดตกลงเพื่อไปหน้าเข้าสู่ระบบ</p>',


            focusConfirm: false,
            confirmButtonText: 'ยืนยัน',
            showCancelButton: true,
            cancelButtonText: 'ยกเลิก',
            showLoaderOnConfirm: true,

            preConfirm: () => {

                return true;
            }
        })
        .then(result => {
            if(result.value) window.location.replace("/login");
            
        });

    });


});