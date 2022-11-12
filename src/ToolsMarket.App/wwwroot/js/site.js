var myCarousel = document.querySelector('#carousel')
var carousel = new bootstrap.Carousel(myCarousel, {
    interval: 2000,
    wrap: false
});

$('.owl-carousel').owlCarousel({
    loop: true,
    autoplay: true,
    autoplayTimeout: 5000,
    dots: false,
    margin: 10,
    nav: false,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        },
        650: {
            items: 1
        },
        900: {
            items: 2
        },
        1000: {
            items: 3
        },
        1400: {
            items: 4
        }
    }
})