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
            <div class="center header" style-"margin-top: 200px;"><p class="header_top">Take Some Time </p><h2>Enjoy yourself</h2></div>
     </div>
<?php  include 'decks/GeneratedContent.php';?>
    <div class="row">
        <div class="col-sm-offset-2 col-sm-8 panel panel-primary " style="padding:0px">
                    <div class="panel-heading">
                        <h2 style="text-align:center">Explore!</h2>
                        <h3 style="text-align:center">Northeast Ohio is home to a concentration of world-class attractions and activities that few other areas in the country can offer. World-class museums, modern sporting venues, an extensive theatre complex, parks, fairs, festivals, shopping and an international selection of dining options offer compelling answers to that most persistent of questions, What do you want to do today?</h3>
                    </div>
            </div>
         <div class="col-sm-offset-2 col-sm-8 play_content">
             
         <div class="col-sm-6"style="border-right:1px solid lightgray;">
            <img class="prospect" src="Pics/event1.jpg"/>
            <h3>Potter Fest!</h3>
            <p><?php echo $content1 ?></p>
            <img class="prospect" src="Pics/event2.jpg"/>
            <h3>No Type Tour!</h3>
            <p><?php echo $content1 ?></p>
            <img class="prospect" src="Pics/event4.jpg"/>
            <h3>CornHole Tourney</h3>
            <p><?php echo $content3 ?></p>
            <img class="prospect" src="Pics/event6.jpg"/>
            <h3>North Coast Classic</h3>
            <p><?php echo $content2 ?></p>
            <img class="prospect" src="Pics/event8.jpg"/>
            <h3>Latin Prom</h3>
            <p><?php echo $content2 ?></p>
            <img class="prospect" src="Pics/event10.jpg"/>
            <h3>Bowman-Cup</h3>
            <p><?php echo $content2 ?></p>
            
         </div>
         <div class="col-sm-6">
            <img class="prospect" src="Pics/event3.jpg"/>
            <h3>Flash Fest!</h3>
            <p><?php echo $content2 ?></p>
            <img class="prospect" src="Pics/event5.jpg"/>
            <h3>Late Night Reels</h3>
            <p><?php echo $content1 ?></p>
            <img class="prospect" src="Pics/event7.jpg"/>
            <h3>H20 Spiritual retreat</h3>
            <p><?php echo $content1 ?></p>
            <img class="prospect" src="Pics/event9.jpg"/>
            <h3>Flash-a-thon</h3>
            <p><?php echo $content3 ?></p>
            <img class="prospect" src="Pics/event11.jpg"/>
            <h3>Explore a Park Day!</h3>
            <p><?php echo $content3 ?></p>
            
         </div>
         </div>
    </div>


    
    
<?php  include 'decks/Footer.php';?>
</body>
 <script type="text/javascript" src="gb.js"></script>
<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCbrjZHo-Aw-VJfxzj_S9LtaL1V7h5x61M&callback=myMap"></script>

</html>