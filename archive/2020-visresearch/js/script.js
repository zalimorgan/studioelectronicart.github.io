$(document).ready(function() {

  $(window).scroll(function () {
    if($(document).scrollTop() > 100 && $(document).scrollTop() < 1300) {
      //animate cyber grape
      $('body').stop().animate({
        backgroundColor: '#49416D'
      }, 1000);//end animate
    } //end if
    else if ($(document).scrollTop() > 1100){
      //animate apricot
      $('body').stop().animate({
        backgroundColor: '#FAC9B8'
      }, 1000);//end animate
    } //end else if
    else {
      //animate minty fresh
      $('body').stop().animate({
        backgroundColor: '#CFFFE5'
      }, 1000);//end animate
    } //end else
    console.log($(document).scrollTop());
  }); //end window.scroll

}); //end ready
