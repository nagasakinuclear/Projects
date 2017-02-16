//general options

    $(document).ready(function () {
        send_result(0);
    });
    //Calculate price
    var summ = 0;
    function calc(item) {
        setTimeout(function () {
            summ += parseInt(item.checked ? item.value : -item.value);
            summ < 0 ? 0 : summ;
            send_result();
        }, 15);
    }
    function send_result() {
        document.getElementById('FinalResult').innerHTML = summ;
    }
