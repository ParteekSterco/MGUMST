(function ($) {
  "use strict";

  // Anchor Smooth Scroll
  jQuery(function ($) {
    $('a[href*="#"]:not([href="#"])').click(function () {
      var target = $(this.hash);
      $("html,body")
        .stop()
        .animate(
          {
            scrollTop: target.offset().top - 120,
          },
          "linear"
        );
    });
    if (location.hash) {
      var id = $(location.hash);
    }

    $(window).on("load", function () {
      if (location.hash) {
        $("html,body").animate({ scrollTop: id.offset().top - 120 }, "linear");
      }
    });
  });

  // // ----Header----//

  $(window).scroll(function () {
    var sticky = $(".main_header"),
      scroll = $(window).scrollTop();

    if (scroll >= 200) sticky.addClass("sticky");
    else sticky.removeClass("sticky");
  });


  // Filter Menu

  $(document).ready(function(){
    $(".Filter_btn, .side_menu_inner .close").click(function(){
      $('.side_menu_inner').toggleClass('show'); // toggle collapse
    });
  });

  
  // Main Menu Js
  // --------------------------------------------------------------
  $(document).ready(function () {
    $(".navbar-toggler").click(function () {
      $(".navbar-collapse").slideToggle(300);
    });

    smallScreenMenu();
    let temp;
    function resizeEnd() {
      smallScreenMenu();
    }

    $(window).resize(function () {
      clearTimeout(temp);
      temp = setTimeout(resizeEnd, 100);
      resetMenu();
    });
  });

  const subMenus = $(".sub-menu");
  const menuLinks = $(".admission_tabnk");

  function smallScreenMenu() {
    if ($(window).innerWidth() <= 992) {
      menuLinks.each(function (item) {
        $(this).click(function () {
          $(this).next().slideToggle();
        });
      });
    } else {
      menuLinks.each(function (item) {
        $(this).off("click");
      });
    }
  }

  function resetMenu() {
    if ($(window).innerWidth() > 992) {
      subMenus.each(function (item) {
        $(this).css("display", "none");
      });
    }
  }

  // Body Add Class

  jQuery(".navbar-nav>.dropdown_menu").hover(function () {
    find(".sub-menu"), jQuery("body").toggleClass("showme");
  });

  // --------------------------------------------------------------
  // Main Menu Js End

  // ----Home Page Main Slider----//

  $(document).ready(function () {
    $(".home_slider").owlCarousel({
      loop: true,
      dots: false,
      nav: false,
      navText: [
        '<i class="bi bi-chevron-double-left"></i>',
        '<i class="bi bi-chevron-double-right"></i>',
      ],
      items: 1,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: false,
      autoHeight: true,
      animateIn: "fadeIn",
      animateOut: "fadeOut",
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        1200: {
          items: 1,
        },
      },
    });
  });

  $(document).ready(function () {
    $(".lifeMGU_carousel").owlCarousel({
      loop: true,
      dots: false,
      nav: false,
      navText: [
        '<i class="bi bi-chevron-double-left"></i>',
        '<i class="bi bi-chevron-double-right"></i>',
      ],
      items: 2,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      autoHeight: true,
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        320: {
          items: 1,
          nav: true,
        },
        768: {
          items: 2,
        },
        1366: {
          items: 2,
        },
        1367: {
          items: 3,
        },
      },
    });
  });

  $(document).ready(function () {
    $(".ForeignCollab_carousel").owlCarousel({
      loop: true,
      dots: false,
      nav: false,
      navText: [
        '<i class="bi bi-chevron-double-left"></i>',
        '<i class="bi bi-chevron-double-right"></i>',
      ],
      items: 2,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      autoHeight: true,
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        375: {
          items: 2,
          margin: 10,
        },
        600: {
          items: 2,
          margin: 10,
        },
        768: {
          items: 3,
          margin: 10,
        },
        1024: {
          items: 4,
          margin: 10,
        },
        1366: {
          items: 5,
          margin: 30,
        },
        1367: {
          items: 5,
          margin: 30,
        },
      },
    });
  });

  $(document).ready(function () {
    $(".notification_slider").owlCarousel({
      loop: true,
      dots: false,
      nav: true,
      navText: [
        '<i class="bi bi-chevron-double-left"></i>',
        '<i class="bi bi-chevron-double-right"></i>',
      ],
      items: 1,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      autoHeight: true,
      animateIn: "fadeIn",
      animateOut: "fadeOut",
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        767: {
          items: 1,
          margin: 0,
        },
        992: {
          items: 1,
          margin: 0,
        },
      },
    });
  });

  $(document).ready(function () {
    $(".newsTwoItems_carousel").owlCarousel({
      loop: true,
      dots: false,
      nav: true,
      navText: ["<span>Previous</span>", "<span>Next</span>"],
      items: 1,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      autoHeight: true,
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        375: {
          items: 1,
          margin: 0,
        },
        767: {
          items: 2,
          margin: 20,
        },
        992: {
          items: 2,
          margin: 30,
        },
        1400: {
          items: 3,
          margin: 30,
        },
      },
    });
  });
  // hamburger
  // --------------------------------------------------------------

  $(".js-hamburger").click(function () {
    $("span.bars").toggleClass("active");
    $(this).toggleClass("active");
    $(".js-nav").toggleClass("show");
  });
  $(".search_hamburger").click(function () {
    $("span.srch").toggleClass("active");
    $(this).toggleClass("active");
    $(".js-search").toggleClass("show");
  });
  $(".search_close").click(function () {
    $(".js-search").removeClass("show");
  });

  // Dropdown
  // --------------------------------------------------------------
  // $(".dropdown").hover(function () {
  //   $(".dropdown-toggle", this).trigger("click");
  // });



  $(document).ready(function () {
    $(".dropdown").hover(
      function () {
        $(this).find(".dropdown-menu").stop(true, true).delay(200).fadeIn(200);
      },
      function () {
        $(this).find(".dropdown-menu").stop(true, true).delay(200).fadeOut(200);
      }
    );
  
    $(".sub_dropdown").hover(
      function () {
        $(this).find(".dropdown_list").addClass("show");
      },
      function () {
        $(this).find(".dropdown_list").removeClass("show");
      }
    );
  });


  
// Number Counter

// var counted = 0;
// $(window).scroll(function() {

//   var oTop = $('.counter_wraper').offset().top - window.innerHeight;
//   if (counted == 0 && $(window).scrollTop() > oTop) {
//     $('.count').each(function() {
//       var $this = $(this),
//         countTo = $this.attr('data-count');
//       $({
//         countNum: $this.text()
//       }).animate({
//           countNum: countTo
//         },

//         {

//           duration: 2000,
//           easing: 'swing',
//           step: function() {
//             $this.text(Math.floor(this.countNum));
//           },
//           complete: function() {
//             $this.text(this.countNum);
//             //alert('finished');
//           }

//         });
//     });
//     counted = 1;
//   }

// });

  

  // Gallery Slider
  // --------------------------------------------------------------
  $(document).ready(function () {
    $(".rtl-slider").slick({
      slidesToShow: 1,
      slidesToScroll: 1,
      arrows: true,
      fade: true,
      swipeToSlide: true,
      swipe: true,
      asNavFor: ".rtl-slider-nav",
      prevArrow: '<button class="slick-prev bi bi-arrow-left" type="button"></button>',
      nextArrow: "false",
    });
    $(".rtl-slider-nav").slick({
      slidesToShow: 6.5,
      slidesToScroll: 1,
      vertical: false,
      infinite: false,
      draggable: true,
      asNavFor: ".rtl-slider",
      focusOnSelect: true,
      prevArrow:
        '<button class="thumb-prev bi bi-chevron-double-left" type="button"></button>',
      nextArrow:
        '<button class="thumb-next bi bi-chevron-double-right" type="button"></button>',
      responsive: [
        {
          breakpoint: 1024,
          settings: {
            slidesToShow: 3.5,
            slidesToScroll: 3,
            infinite: true,
          },
        },
        {
          breakpoint: 600,
          settings: {
            slidesToShow: 2.5,
            slidesToScroll: 2,
          },
        },
        {
          breakpoint: 480,
          settings: {
            slidesToShow: 2.5,
            slidesToScroll: 1,
          },
        },
      ],
    });
    // $(".rtl-slider").on("afterChange", function (event, slick, currentSlide) {
    //   if (currentSlide === 7) {
    //     $(".slick-next").addClass("hidden");
    //   } else {
    //     $(".slick-next").removeClass("hidden");
    //   }

    //   if (currentSlide === 0) {
    //     $(".slick-prev").addClass("hidden");
    //   } else {
    //     $(".slick-prev").removeClass("hidden");
    //   }
    // });
  });

  $(document).ready(function () {
    $(".facilities_carousel").owlCarousel({
      loop: true,
      dots: false,
      nav: true,
      navText: [
        '<i class="bi bi-chevron-double-left"></i>',
        '<i class="bi bi-chevron-double-right"></i>',
      ],
      items: 1,
      mouseDrag: false,
      touchDrag: false,
      autoplay: true,
      autoplayTimeout: 5000,
      autoplayHoverPause: true,
      autoHeight: true,
      responsiveClass: true,
      responsive: {
        0: {
          items: 1,
        },
        375: {
          items: 1,
          margin: 0,
        },
        767: {
          items: 2,
          margin: 20,
        },
        992: {
          items: 2,
          margin: 30,
        },
        1100: {
          items: 3,
          margin: 30,
        },
        1400: {
          items: 4,
          margin: 30,
        },
      },
    });
  });

  // Mobile Menu

  $(".program_tab").click(function () {
    $(".mobile-program-panel").toggleClass("show"),
      $(".mobile-contact-panel").removeClass("show"),
      $(".mobile-admission-panel").removeClass("show"),
      $(".mobile-menulist-panel").removeClass("show"),
      $(".admission_tab").removeClass("active");
      $(".contact_tab").removeClass("active");
      $(".menu_tab").removeClass("active");
      $(this).toggleClass("active");
  }),
    $(".contact_tab").click(function () {
      $(".mobile-contact-panel").toggleClass("show"),
        $(".mobile-program-panel").removeClass("show"),
        $(".mobile-admission-panel").removeClass("show"),
        $(".mobile-menulist-panel").removeClass("show"),
        $(".admission_tab").removeClass("active");
      $(".program_tab").removeClass("active");
      $(".menu_tab").removeClass("active");
      $(this).toggleClass("active");
    }),
    $(".admission_tab").click(function () {
      $(".mobile-admission-panel").toggleClass("show"),
        $(".mobile-program-panel").removeClass("show"),
        $(".mobile-contact-panel").removeClass("show"),
        $(".mobile-menulist-panel").removeClass("show"),
        $(".program_tab").removeClass("active");
      $(".contact_tab").removeClass("active");
      $(".menu_tab").removeClass("active");
      $(this).toggleClass("active");
    }),
    $(".menu_tab").click(function () {
      $(".mobile-menulist-panel").toggleClass("show"),
        $(".mobile-program-panel").removeClass("show"),
        $(".mobile-contact-panel").removeClass("show"),
        $(".mobile-admission-panel").removeClass("show"),
        $(".admission_tab").removeClass("active");
      $(".contact_tab").removeClass("active");
      $(".program_tab").removeClass("active");
      $(this).toggleClass("active");
    }),

    // Mobile Menu Tab

    $(".menu_mobile li a").click(function (e) {
      // remove the active class with every click
      var same = $(this).hasClass("active");
      var siblings = $(this).parent(".menu_item").parent().children();
      siblings.find("a.active + .sub_menu").slideUp();
      siblings.find("a").removeClass("active");

      if ($(this).next().hasClass("sub_menu") && !same) {
        e.preventDefault();
        $(this).addClass("active");
        $(this).next(".sub_menu").slideDown();
      }
    });


 
    

  // ScrollTop
  // --------------------------------------------------------------
  $(document).ready(function () {
    "use strict";

    //Scroll back to top

    var progressPath = document.querySelector(".progress-wrap path");
    var pathLength = progressPath.getTotalLength();
    progressPath.style.transition = progressPath.style.WebkitTransition =
      "none";
    progressPath.style.strokeDasharray = pathLength + " " + pathLength;
    progressPath.style.strokeDashoffset = pathLength;
    progressPath.getBoundingClientRect();
    progressPath.style.transition = progressPath.style.WebkitTransition =
      "stroke-dashoffset 10ms linear";
    var updateProgress = function () {
      var scroll = $(window).scrollTop();
      var height = $(document).height() - $(window).height();
      var progress = pathLength - (scroll * pathLength) / height;
      progressPath.style.strokeDashoffset = progress;
    };

    updateProgress();
    $(window).scroll(updateProgress);
    var offset = 50;
    var duration = 550;
    jQuery(window).on("scroll", function () {
      if (jQuery(this).scrollTop() > offset) {
        jQuery(".progress-wrap").addClass("active-progress");
      } else {
        jQuery(".progress-wrap").removeClass("active-progress");
      }
    });
    jQuery(".progress-wrap").on("click", function (event) {
      event.preventDefault();
      jQuery("html, body").animate({ scrollTop: 0 }, duration);
      return false;
    });
  });
  // Lightcase Gallery
  // --------------------------------------------------------------
  $("a[data-rel^=lightcase]").lightcase();

  // Wow JS
  // --------------------------------------------------------------
  new WOW().init();
 
// Milestone Time line End
})(jQuery);
 
// Milestone Time line Start

// Arrow Movement
var interval;

jQuery('.timeline_nav_prev').mousedown(function(event) {
        let target = jQuery(".timeline_slider");
        let current_x = target.scrollLeft();
        if (target.length) {
            event.preventDefault();
            jQuery(target).animate({
                scrollLeft: current_x - 100
            }, 100, "linear");
        }
        interval = setInterval(function() {
            let target = jQuery(".timeline_slider");
            let current_x = target.scrollLeft();

            if (target.length) {
                event.preventDefault();
                jQuery(target).animate({
                    scrollLeft: current_x - 100
                }, 100, "linear");
            }
        }, 100);
    })
    .mouseup(function() {
        clearInterval(interval);
    });

jQuery('.timeline_nav_next').mousedown(function(event) {
        let target = jQuery(".timeline_slider");
        let current_x = target.scrollLeft();

        if (target.length) {
            event.preventDefault();
            jQuery(target).animate({
                scrollLeft: current_x + 100
            }, 100, "linear");
        }
        interval = setInterval(function() {
            let target = jQuery(".timeline_slider");
            let current_x = target.scrollLeft();

            if (target.length) {
                event.preventDefault();
                jQuery(target).animate({
                    scrollLeft: current_x + 100
                }, 100, "linear");
            }
        }, 100);
    })
    .mouseup(function() {
        clearInterval(interval);
    });

// Grab and Move
const container = document.querySelector('.timeline_slider');

let startY;
let startX;
let scrollLeft;
let scrollTop;
let isDown;

container.addEventListener('mousedown', e => mouseIsDown(e));
container.addEventListener('mouseup', e => mouseUp(e))
container.addEventListener('mouseleave', e => mouseLeave(e));
container.addEventListener('mousemove', e => mouseMove(e));

function mouseIsDown(e) {
    isDown = true;
    startY = e.pageY - container.offsetTop;
    startX = e.pageX - container.offsetLeft;
    scrollLeft = container.scrollLeft;
    scrollTop = container.scrollTop;
}

function mouseUp(e) {
    isDown = false;
}

function mouseLeave(e) {
    isDown = false;
}

function mouseMove(e) {
    if (isDown) {
        e.preventDefault();
        //Move vertcally
        const y = e.pageY - container.offsetTop;
        const walkY = y - startY;
        container.scrollTop = scrollTop - walkY;

        //Move Horizontally
        const x = e.pageX - container.offsetLeft;
        const walkX = x - startX;
        container.scrollLeft = scrollLeft - walkX;

    }
}