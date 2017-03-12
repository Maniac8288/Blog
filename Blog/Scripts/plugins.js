/* mobile */
isMobile = false;
isiPad = false;
function isMobile_f() {
    var array_mobileIds = new Array('iphone', 'android', 'ipad', 'ipod');
    var uAgent = navigator.userAgent.toLowerCase();
    for (var i=0; i<array_mobileIds.length; i++) {
		if(uAgent.search(array_mobileIds[i]) > -1) {
			isMobile = true;
			if(array_mobileIds[i] == 'ipad') isiPad = true;
		}
    }
}
isMobile_f();

//Animation
if (!isMobile) document.write('<link rel="stylesheet" href="/Content/animate.css" type="text/css">');
if (!isMobile) document.write('<link rel="stylesheet" href="/Content//delays.css" type="text/css">');

//FlexSlider
document.write('<link rel="stylesheet" href="/Content/flexslider.css" type="text/css">');
if (!isMobile) document.write('<link rel="stylesheet" href="/Content/animation_delays.css" type="text/css"/>');
document.write('<script type="text/javascript" src="/Scripts/jquery.flexslider-min.js"></script>');

//Calendar
document.write('<link rel="stylesheet" href="/Content/calendar.css" type="text/css">');
document.write('<script type="text/javascript" src="/Scripts//calendar.js"></script>');

//Sort
document.write('<script type="text/javascript" src="/Scripts/jquery.sort.min.js"></script>');

//Media Element
document.write('<link rel="stylesheet" href="/Content/mediaelementplayer.css" type="text/css"/>');
document.write('<script type="text/javascript" src="/Scripts/mediaelement-and-player.min.js"></script>');
document.write('<script type="text/javascript" src="/Scripts/custom.js"></script>');

//PrettyPhoto
document.write('<link rel="stylesheet" href="/Content/prettyPhoto.css" type="text/css">');
document.write('<script type="text/javascript" src="/Scripts/prettyPhoto.js"></script>');

//jQuery tools
document.write('<script type="text/javascript" src="/Scripts/jquery.tools.min.js"></script>');


