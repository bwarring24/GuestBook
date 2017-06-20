<html>

<head>
    <meta charset="UTF-8">
    <meta name="description" content="">
    <meta name="keywords" content="">
    <meta name="author" content="">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <link type="text/css" rel="stylesheet" href="bootstrap-3.3.7-dist/css/bootstrap.css">
    <link type="text/css" rel="stylesheet" type="text/css" href="bootstrap-3.3.7-dist/css/guestbook.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    
    <title>Guest Book Hotel Management System</title>
</head>

<body>
<?php include 'decks/Nav.php';?>
    <div class="row" style="margin-top:80px; text-align:center">
            <div class="center header" style-"margin-top: 200px;"><p class="header_top">Enjoy Our Delicous </p><h2>Restaurants</h2></div>
     </div>
    <div class="row">
         <div class="col-sm-offset-1 col-sm-10">
             <div class="col-sm-10"><div id="map" style="width:100%;height:500px;"></div></div>
             <div class="col-sm-2">
                <div id="infowindow-content">
                    <span id="place-name"  </span><br>
                    <span id="place-address"></span>
                </div>
        </div>
        </div>
        

    </div>


    
    
<?php  include 'decks/Footer.php';?>
</body>
 <script type="text/javascript" src="gb.js"></script>
 <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCbrjZHo-Aw-VJfxzj_S9LtaL1V7h5x61M&callback=initMap&libraries=places"></script>


</html>