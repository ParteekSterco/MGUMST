$(window).scroll(function() {
    if ($(this).scrollTop() > 0){  
        $('header').addClass("sticky");
        $('.left_menu').addClass("sticky");
        $('.inner_common_menu').addClass("sticky");
    }
    else{
        $('header').removeClass("sticky");
        $('.left_menu').removeClass("sticky");
        $('.inner_common_menu').removeClass("sticky");
    }
   
    
});

//search
$(document).ready(function(){
    $(".slide-toggle").click(function(){
        $(".side-menu").addClass("open-slide");
        $(".close-icon").addClass("open-slide");
    });
    $(".close-icon").click(function(){
        $(".side-menu").removeClass("open-slide");
    });
    $(".opacity-bg").click(function(){
        $(".side-menu").removeClass("open-slide");
    });

    $(".notif-open").click(function(){
        $(".notif-popup").addClass("open-slide");
        $(".notification").addClass("open-slide");
    });
    $(".notif-close").click(function(){
        $(".notif-popup").removeClass("open-slide");
        $(".notification").removeClass("open-slide");
    });

});

// Mobile Bottom Sticky
    $(function(){
        $('section.mobile-bottom-menu li a').click( function() {
          $(this).parent().siblings().children().removeClass('active');
          $(this).addClass('active');
        });
      });
      $(document).ready(function(){
        $(".notificat").on("click", function(){
        $(".call-mobile").toggleClass("show");
        $(".enquiry-mobile").removeClass("show1");
        $(".insurance-mobile").removeClass("show2");
        });
      });
      $(document).ready(function(){
        $(".m-enquiry").on("click", function(){
        $(".enquiry-mobile").toggleClass("show1");
        $(".call-mobile").removeClass("show");
        $(".insurance-mobile").removeClass("show2");
        });
      });
      $(document).ready(function(){
        $(".m-insurance").on("click", function(){
        $(".insurance-mobile").toggleClass("show2");
        $(".call-mobile").removeClass("show");
        $(".enquiry-mobile").removeClass("show1");
        });
      });
// Mobile Bottom Sticky

// $('.m-drop').click(function(e){
//     e.stopPropagation();
//     $(this).find('.m-drop-sub').toggleClass('open');
//   });

//    $( ".m-drop a" ).click(function() {
//     $( this ).toggleClass( "highlight" );
//   });

  $( document ).ready(function() {
    // Carousel
    jQuery(".carousel").carousel({
        interval: 3000,
        pause: true
    });

   // swipe start
    jQuery(".carousel").swipe({
        swipe: function (event, direction, distance, duration, fingerCount, fingerData) {
            if (direction == 'left') $(this).carousel('next');
            if (direction == 'right') $(this).carousel('prev');
        },
        allowPageScroll: "vertical" 
    });
// swipe end 
});

    WOW.prototype.addBox = function(element) {
      this.boxes.push(element);
      };
      var wow = new WOW();
      wow.init();

if ($(window).width() <= 991){ 
$(".wow").removeClass("wow");
}

//$(document).ready(function(){
//    $(".job-repeat-row").slice(0, 4).show();
//    $(".loadMore").on('click', function (e) {
//        e.preventDefault();
//        $(".job-repeat-row:hidden").slice(0, 2).slideDown();
//        if ($(".job-repeat-row:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//            $(".loadMore").text("No Content").addClass("noContent");
//        }
//    });
//  
//$(".Download_box").slice(0, 4).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".Download_box:hidden").slice(0, 2).slideDown();
//        if ($(".Download_box:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//    });

// $(".hgt_btm").slice(0, 6).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".hgt_btm:hidden").slice(0, 3).slideDown();
//        if ($(".hgt_btm:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//        
//    });

//    $(".media-coverage-date-sec .col-md-4").slice(0, 6).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".media-coverage-date-sec .col-md-4:hidden").slice(0, 3).slideDown();
//        if ($(".media-coverage-date-sec .col-md-4:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//        
//    });
//    $(".more-data-press .col-md-4").slice(0, 9).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".more-data-press .col-md-4:hidden").slice(0, 3).slideDown();
//        if ($(".more-data-press .col-md-4:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//        
//    });
//    $(".load-more-slide .col-md-4").slice(0, 6).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".load-more-slide .col-md-4:hidden").slice(0, 3).slideDown();
//        if ($(".load-more-slide .col-md-4:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//        
//    });
//    $(".testimonial .col-md-6").slice(0, 4).show();
//    $(".loadMore").on('click', function (e) {
//        e.stopPropagation();
//        $(".testimonial .col-md-6:hidden").slice(0, 2).slideDown();
//        if ($("..testimonial .col-md-6:hidden").length == 0) {
//            $(".loadMore").fadeOut('slow');
//        }
//        
//    });
//  });  
  var owl = $('.campuses-slide'); 
owl.owlCarousel({
    items:1.5,
    loop:true,
    margin:40,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1,
            margin:0
        },
        600:{
            items:1,
            margin:0
        },
        1000:{
            items:1.5
        }
    }
  });

  var owl = $('.testimo-slide');
owl.owlCarousel({
    items:3,
    loop:true,
    margin:40,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2,
            margin:20
        },
        1000:{
            items:3
        }
    }
  });
//   var owl = $('.celebrat-slide');
// owl.owlCarousel({
//     items:1,
//     loop:true,
//     margin:0,
//     dots:false,
//     nav:true,
//     autoplay:true,
//     smartSpeed: 1000,
//     autoplayTimeout:3000,
//     animateOut: 'fadeOut',
//        animateIn: 'fadeIn',
//     autoplayHoverPause:true,
//     responsive:{
//         0:{
//             items:1
//         },
//         600:{
//             items:1
//         },
//         1000:{
//             items:1
//         }
//     }
//   });

  var owl = $('.text-slide');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:0,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:3
        },
        1000:{
            items:3
        }
    }
  });
    var owl = $('.count-slide');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:0,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
  });
    var owl = $('.gallery-event-slider');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:2
        }
    }
  });


 var owl = $('.infr-facil-slide, .c-office-slide, .multi-slide');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:0,
    dots:false,
    nav:true,
    autoplay:true,
    smartSpeed: 1000,
    autoplayTimeout:3000,
    autoplayHoverPause:true,
    animateOut: 'fadeOut',
       animateIn: 'fadeIn',
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
  });


/*=============Product Slider One========*/

$('#owl-course-slide').owlCarousel({
    loop:true,
   autoplay: true,
   slideSpeed : 300,
   margin:30,
   navText: ['<img src="images/laborty-arrow-1.png" width="40" height="38" alt="Arrow">', '<img src="images/laborty-arrow2.png" width="40" height="38" alt="Arrow">'],
   dots: false,
   responsiveClass:true,
   responsive:{
       0:{
           items:1,
           nav:true
       },
       600:{
           items:1,
           nav:false
       },     
       1200:{
           items:1,
           nav:true,
           margin:40,
           loop:true
       }
   }
  })

var menu01 = new MobileMenu;
menu01.init();
function MobileMenu(){
    var $mobileNav = $('.main-links');
    var $dd = $('.m-drop > a');
    this.init = function(){
        var mobileNavOriginalHeight = $mobileNav.height();
        var mobileNavHeight = $mobileNav.height();
        $('.m-drop > a').addClass('dd-show');
        $('.m-drop > a').each(function(){
            var theHeight = $(this).next().height();
            $(this).next().attr('data-height', theHeight);  
        });

        $('.m-drop > a').removeClass('dd-show');
        
        $dd.click(function(){
            if($(this).hasClass('dd-show')){
                mobileNavHeight = $mobileNav.outerHeight();
                $mobileNav.css('height', (mobileNavHeight - $(this).next().data('height')));
                $(this).next().removeAttr('style');
                $(this).removeClass('dd-show'); 
            }else{
                $dd.next().removeAttr('style');
                $dd.removeClass('dd-show');
                $mobileNav.css('height', (mobileNavOriginalHeight + $(this).next().data('height')));
                $(this).next().css('height', $(this).next().data('height'))
                $(this).addClass('dd-show');
            }
        }) 
    } 
} 





$(".drop-menu").hover(
  function () {
    $(".inner-header").toggleClass("header_hover");
  },
);


$(".karya .corse-list-area").slice(5).hide();

 var mincount = 2;
 var maxcount = 5;


 $(window).scroll(function () {
     if ($(window).scrollTop() + $(window).height() >=
$(document).height() -10) {
         $(".karya .corse-list-area").slice(mincount, maxcount).slideDown(500);
            mincount = mincount + 2;
         maxcount = maxcount + 2
        

     }
 });
