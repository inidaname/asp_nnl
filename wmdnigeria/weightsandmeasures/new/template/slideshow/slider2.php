

    <link rel="stylesheet" href="template/slideshow/themes/default/default.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="template/slideshow/css/nivo-slider.css" type="text/css" media="screen" />

    <div id="wrapper">

        <div class="slider-wrapper theme-default">
            <div class="ribbon"></div>
            <div id="slider2" class="nivoSlider">
                <img src="template/slideshow/images/5.jpg" alt="" />
                <img src="template/slideshow/images/6.jpg" alt="" />
                <img src="template/slideshow/images/7.jpg" alt="" />
                <img src="template/slideshow/images/8.jpg" alt="" data-transition="slideInLeft" />
                <img src="template/slideshow/images/12.jpg" alt="" />
                <img src="template/slideshow/images/9.jpg" alt="" />
                <img src="template/slideshow/images/11.jpg" alt="" />
            </div>
        </div>

    </div>
    <script type="text/javascript" src="template/slideshow/scripts/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="template/slideshow/scripts/jquery.nivo.slider.pack.js"></script>
    <script type="text/javascript">
    $(window).load(function() {
        $('#slider2').nivoSlider();
    });
    </script>