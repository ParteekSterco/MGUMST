
$(function() {
"use strict"; // Start of use strict

$(".drop-down_menu").hover(function () {
    $("body").toggleClass("body_hover");
 });

 

 $("section.inner-menu h2").click(function () {
    $("body").toggleClass("body_click");
 });




// Sticky Nav


$(window).on('scroll', function() {
    if ($(window).scrollTop() > 10) {
    $('.scrolling-navbar').addClass('top-nav-collapse');
    } else {
    $('.scrolling-navbar').removeClass('top-nav-collapse');
    }
    });




$("#show_search").click(function () {
  $(".searchoverlay").show();
  });
  $(".hide_search").click(function () {
  $(".searchoverlay").hide();
  });
  $(".openCollapse").click(function () {
  $(".showCollapse").toggle();
  });

var owl = $('.banner-carousel');
owl.owlCarousel({
    items:1,
    loop:true,
    margin:0,
    autoplay:true,
    autoplayTimeout:5000,
    autoplayHoverPause:true,
    mouseDrag:true,
    animateOut: 'fadeOut',
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

  var owl = $('.counter-carousel');
owl.owlCarousel({
    items:1,
    loop:false,
    margin:0,
    autoplay:false,
    autoplayTimeout:5000,
    autoplayHoverPause:true,
    mouseDrag:false,

    responsive:{
        0:{
            items:1,
            autoplay:true,
            mouseDrag:true,
            loop:true,
        },
        600:{
            items:1,
            autoplay:true,
            mouseDrag:true,
            loop:true,
        },
        
        1000:{
            items:2
        }
    }
  });

  var owl = $('.Tie-Ups-carousel');
  owl.owlCarousel({
      items:5,
      loop:false,
      nav:true,
      dots:false,
      margin:0,
      autoplay:false,
      autoplayTimeout:5000,
      autoplayHoverPause:true,
      mouseDrag:false,
  
      responsive:{
          0:{
              items:2,
              autoplay:true,
              mouseDrag:true,
              loop:true,
          },
          600:{
              items:2,
              autoplay:true,
              mouseDrag:true,
              loop:true,
          },
          
          1000:{
              items:5
          }
      }
    });



  var owl = $('.International-Collaborations-carousel');
owl.owlCarousel({
    items:4,
    loop:false,
    nav:true,
    dots:false,
    margin:10,
    autoplay:false,
    autoplayTimeout:5000,
    autoplayHoverPause:true,
    mouseDrag:true,
   
    responsive:{
        0:{
            items:2
        },
        600:{
            items:2
        },
        1000:{
            items:4
        }
    }
  });

  var owl = $('.placement-carousel');
  owl.owlCarousel({
      items:1,
      loop:false,
      nav:true,
      dots:false,
      margin:10,
      autoplay:false,
      autoplayTimeout:5000,
      autoplayHoverPause:true,
      mouseDrag:true,
     
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

    var owl = $('.about-carousel');
    owl.owlCarousel({
        items:1,
        loop:false,
        nav:true,
        dots:false,
        margin:10,
        autoplay:false,
        autoplayTimeout:5000,
        autoplayHoverPause:true,
        mouseDrag:true,
       
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
  
      var owl = $('.academic-carousel');
      owl.owlCarousel({
          items:1,
          loop:false,
          nav:false,
          dots:true,
          margin:10,
          autoplay:false,
          autoplayTimeout:5000,
          autoplayHoverPause:true,
          mouseDrag:true,
         
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


        var owl = $('.infra-carousel');
        owl.owlCarousel({
            items:1,
            loop:false,
            nav:true,
            dots:false,
            margin:10,
            autoplay:false,
            autoplayTimeout:5000,
            autoplayHoverPause:true,
            mouseDrag:true,
           
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

          var owl = $('.our-faculty-carousel');
          owl.owlCarousel({
              items:3,
              loop:false,
              nav:true,
              dots:false,
              margin:0,
              autoplay:false,
              autoplayTimeout:5000,
              autoplayHoverPause:true,
              mouseDrag:true,
             
              responsive:{
                  0:{
                      items:2,  margin:10,
                  },
                  600:{
                      items:2, margin:10,
                  },
                  1000:{
                      items:3
                  }
              }
            });
 

            var owl = $('.explore-carousel');
            owl.owlCarousel({
                items:1,
                loop:false,
                nav:false,
                dots:true,
                margin:0,
                autoplay:false,
                autoplayTimeout:5000,
                autoplayHoverPause:true,
                mouseDrag:true,
               
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

              var owl = $('.apply-carousel');
              owl.owlCarousel({
                  items:1,
                  loop:false,
                  nav:true,
                  dots:false,
                  margin:0,
                  autoplay:false,
                  autoplayTimeout:5000,
                  autoplayHoverPause:true,
                  mouseDrag:true,
                 
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

    

               
    
                var owl = $('.press-carousel');
                owl.owlCarousel({
                    items:1,
                    loop:false,
                    nav:false,
                    dots:true,
                    margin:0,
                    autoplay:true,
                    autoplayTimeout:4000,
                    autoplayHoverPause:true,
                    mouseDrag:true,
                   
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
    


                  var owl = $('.student-testimonial-slider');
                owl.owlCarousel({
                    items:1,
                    loop:false,
                    nav:false,
                    dots:true,
                    margin:0,
                    autoplay:true,
                    autoplayTimeout:4000,
                    autoplayHoverPause:true,
                    mouseDrag:true,
                   
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



                  var owl = $('.student-testimonial-slider');
                  owl.owlCarousel({
                      items:1,
                      loop:false,
                      nav:false,
                      dots:true,
                      margin:0,
                      autoplay:true,
                      autoplayTimeout:4000,
                      autoplayHoverPause:true,
                      mouseDrag:true,
                     
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

                    var owl = $('.carousel-11');
                    owl.owlCarousel({
                        items:2,
                        loop:false,
                        nav:true,
                        dots:false,
                        margin:0,
                        autoplay:true,
                        autoplayTimeout:4000,
                        autoplayHoverPause:true,
                        mouseDrag:true,
                       
                        responsive:{
                            0:{
                                items:2
                            },
                            600:{
                                items:3
                            },
                            1000:{
                                items:3
                            }
                        }
                      });
    
        
    

    


  


  $('.mobile_nav_icon').on('click', function () {

    $("body").toggleClass('current');

    $('#navbarResponsive2').toggleClass('menuopened');

    $(this).toggleClass('open');

    });

    $('.filter-school h5').on('click', function () {

        $("body").toggleClass('filter-add');
    
        $('.filter-school ul').toggleClass('filter-menu');
        
    
        $(this).toggleClass('filter-open');
    
        });

        $(".close-filter").click(function () {
            $("body").removeClass("filter-add");
            $("ul").removeClass("filter-menu");
         });




    $(document).ready(function () {

    $(".mobile_nav li").click(function () {

    //Toggle the child but don't include them in the hide selector using .not()

    $('.mobile_nav li > ul').not($(this).children("ul").toggle()).hide();

    $('.mobile_nav .nav-item ').not($(this).children("ul").toggleClass('add')).removeClass('add');

    });

    });

    // Add slideDown animation to Bootstrap dropdown when expanding.

    $('.mobile_nav .nav-item').on('show.dropdown', function() {

    $(this).find('.dropdown-menu').first().stop(true, true).slideDown();

    });

    // Add slideUp animation to Bootstrap dropdown when collapsing.

    $('.mobile_nav .nav-item').on('hide.dropdown', function() {

    $(this).find('.dropdown-menu').first().stop(true, true).slideUp();

    });

    $('.dropdown-submenu a.link').on("click", function(e){

    //$(this).next('ul').toggle();

    $(this).parent().find('.dropdown-menu').first().stop(true, true).slideToggle();

    $(this).toggleClass('open');

    e.stopPropagation();

    e.preventDefault();

    });




   var bottom = $('.left_scroll_down').offset().top + 1350;
$(window).scroll(function(){    
    if ($(this).scrollTop() > bottom && $(this).scrollTop() < 5500){ 
        $('.left_scroll_down').addClass('fixed'); 
		//console.log($(this).scrollTop());
    }
    else{
        $('.left_scroll_down').removeClass('fixed');
    }
}); 
      
   

// Init WOW.js and get instance
WOW.prototype.addBox = function(element) {
this.boxes.push(element);
};
// Init WOW.js and get instance
var wow = new WOW();
wow.init();







      
        });


        !function(window){
            var $q = function(q, res){
                  if (document.querySelectorAll) {
                    res = document.querySelectorAll(q);
                  } else {
                    var d=document
                      , a=d.styleSheets[0] || d.createStyleSheet();
                    a.addRule(q,'f:b');
                    for(var l=d.all,b=0,c=[],f=l.length;b<f;b++)
                      l[b].currentStyle.f && c.push(l[b]);
          
                    a.removeRule(0);
                    res = c;
                  }
                  return res;
                }
              , addEventListener = function(evt, fn){
                  window.addEventListener
                    ? this.addEventListener(evt, fn, false)
                    : (window.attachEvent)
                      ? this.attachEvent('on' + evt, fn)
                      : this['on' + evt] = fn;
                }
              , _has = function(obj, key) {
                  return Object.prototype.hasOwnProperty.call(obj, key);
                }
              ;
          
            function loadImage (el, fn) {
              var img = new Image()
                , src = el.getAttribute('data-src');
              img.onload = function() {
                if (!! el.parent)
                  el.parent.replaceChild(img, el)
                else
                  el.src = src;
          
                fn? fn() : null;
              }
              img.src = src;
            }
          
            function elementInViewport(el) {
              var rect = el.getBoundingClientRect()
          
              return (
                 rect.top    >= 0
              && rect.left   >= 0
              && rect.top <= (window.innerHeight || document.documentElement.clientHeight)
              )
            }
          
              var images = new Array()
                , query = $q('img.lazy')
                , processScroll = function(){
                    for (var i = 0; i < images.length; i++) {
                      if (elementInViewport(images[i])) {
                        loadImage(images[i], function () {
                          images.splice(i, i);
                        });
                      }
                    };
                  }
                ;
              // Array.prototype.slice.call is not callable under our lovely IE8 
              for (var i = 0; i < query.length; i++) {
                images.push(query[i]);
              };
          
              processScroll();
              addEventListener('scroll',processScroll);
          
          }(this);