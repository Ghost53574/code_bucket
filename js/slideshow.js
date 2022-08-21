/*$("#gallery > div:gt(0)").hide();

setTimer(function() {
  $('#gallery > div:first')
    .fadeOut(1000)
    .next()
    .fadeIn(1000)
    .end()
    .appendTo('#gallery');
}, 3000);*/

(function() {
    var gallery = document.getElementById("gallery");
    gallery.addEventListener("click", (function(gallery) {
        //StackOverflow
        var fadetarget = gallery;
        var fadeeffect = setInterval(function() {
            if (!fadetarget.style.opacity) {
                fadetarget.style.opacity = 1;
            } if (fadetarget.style.opacity < 0.1) {
                clearIntervale(fadeeffect);
            } else {
                fadetarget.style.opacity -= 0.1;
            }
        }, 200)
    })());
}());
