
$(document).ready(function(){	

var myUrl = makeLink();
	
//var myUrl = 'Test';
	
//$('iframe').attr('src', myUrl);

$('#specialDiv2').append('<iframe width="560" height="315" src="' + myUrl + '" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>');

document.getElementById('specialDiv1').innerText = (myUrl);

});
	
	
function makeLink() {
	var result = '';

	var characters='ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-';

	var charactersLength = characters.length;

	for ( var i = 0; i < 11; i++)
	{result += characters.charAt(Math.floor(Math.random() * charactersLength));}

		
		var myUrl = "https://www.youtube.com/embed/";
		myUrl += result;
		myUrl += "?autoplay=1";
		return myUrl;

}


function timedRefresh(timeoutPeriod) {
   var timer = setInterval(function() {
   if (timeoutPeriod > 0) {
       timeoutPeriod -= 1;
       document.getElementById("countdown").innerHTML = timeoutPeriod +  "<br />";
   } else {
       clearInterval(timer);
            window.location.href = window.location.href;
       }
   }, 1000);
}
timedRefresh(120);

//code borrowed from https://stackoverflow.com/questions/16532577/javascript-refresh-countdown-text

//document.getElementById("specialDiv1").innerText = ();

//script borrowed from https://css-tricks.com/snippets/javascript/select-random-item-array/ and https://www.geeksforgeeks.org/generate-random-string-of-given-size-in-java/ and https://stackoverflow.com/questions/1349404/generate-random-string-characters-in-javascript	