//Map correcting
;(function () {
    $(document).ready(function () {
        getWindowSize();
        window.onresize = getWindowSize;
    })
    var height, width;

    function getWindowSize() {
        height = $(window).height();
        width = $(window).width();
        ChangeMap();
    }
    function cssMarginLeft(value, item) {
        $(item).css('margin-left', value + 'px');
    }
    function cssMarginRight(value, item) {
        $(item).css('margin-right', value + 'px');
    }
    function ChangeMap() {
        let Contacts = $('div#contacts');
        let Address = $('.map_capture .container .raw .col-sm-7');
        let Border = $('.col-sm-5 .map');
        let Map = $('.col-sm-5 .map iframe');
        let Key = width;
        if (Key < 1200 && Key > 992)
            cssMarginLeft(200, Contacts);
        else if (Key < 992 && Key > 750) {

            cssMarginLeft(288, Contacts);
            Address.css('padding', '0px');
            Address.css('margin-top', '13px');
        }
        else if (Key < 624) {
            Border.css('width', width - 44 + 'px');
            Map.css('width', width - 53 + 'px');
        }
        else {
            Border.css('width', '580px');
            Map.css('width', '571px');
            cssMarginLeft(0, Contacts);
        }
    }
})();