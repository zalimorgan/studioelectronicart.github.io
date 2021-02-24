
$(document).ready(function(){

var myUrl;	
	
makeLink();
$('iframe').attr('src', myUrl);
	
function makeLink() {
	var result = '';

	var characters='ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_-';

	var charactersLength = characters.length;

	for ( var i = 0; i < 11; i++)
	{result += characters.charAt(Math.floor(Math.random() * charactersLength));}

	    myUrl = "https://www.youtube.com/embed/";
		myUrl += result;
		myUrl += "?autoplay=1";
	    return myUrl;
}
});


//document.getElementById("specialDiv1").innerText = ();

//document.getElementById("specialDiv2").innerText = (makeLink());