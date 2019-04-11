
$(function () {
    var url = window.location.href;
    var jobId = url.substring(url.indexOf('=') + 1, url.length);
    console.log(jobId);

    $('#apply-button').on('click', function () {
        
        var response = '';

        Swal.fire({
            title: 'กำลังบันทึกข้อมูลการสมัครงาน',
           // html: 'I will close in <strong></strong> seconds.',
            allowOutsideClick: false,
            timer: 5000,
            onBeforeOpen: () => {
                Swal.showLoading();

                timerInterval = setInterval(() => {
              //      Swal.getContent().querySelector('strong')
              //          .textContent = Swal.getTimerLeft()


                }, 100);

                return fetch(`/ajax/applyjob/-/${jobId}/`,
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
                        Swal.increaseTimer(-4000);
                        var resp = response.text();
                        console.log('response = ' + resp);
                        return resp;
                    })
                    .then(responseText => {
                        console.log(responseText);
                        response = responseText;
                    });
            },
            onClose: () => {
            //    clearInterval(timerInterval);

                console.log('response from onclose = ' + response);

                if (response === '{"candidate_create" : "success" }') {
                    Swal.fire({
                        type: 'success',
                        title: 'บันทึกการสมัครงานแล้ว'
                    });
                }

                else if (response.indexOf('error') != -1) {
                    Swal.fire({
                        type: 'error',
                        title: 'เกิดข้อผิดพลาด',
                        text: response
                    });
                } 
            //    return
            }
        })
        .then((result) => {
            console.log(result);
        });

    });



    $('#cancel-apply-button').on('click', function () {

        window.location.replace(`/candidate/jobboard/job=${jobId}`);

    });

});