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
            <div class="center header" style-"margin-top: 200px;"><p class="header_top">Live, laugh, Play</p><h2>Be Our Guest</h2></div>
     </div>
     <div class="row" style="margin-top:50px;">
         <div class="col-sm-offset-1 col-sm-10">
             <img src="Pics/hotel5.jpg" class="book_img" id="showimg"/>
             <div class="col-sm-offset-1 col-sm-9 book">
                <p class="book_head">Reserve a Hotel</p>
                <input class="book_option" type="Text" placeholder="Destination"></input>
                <input class="book_option" type="date" placeholder="Start"></input>
                <input class="book_option" type="date"></input>
                <button class="book_btn">Options</button>
                <a href="reserve.php"><button class="book_btn">Search</button></a>
            </div>
            <div class="col-sm-offset-1 col-sm-9 book_display_nav">
                <p class="book_display" style="background-color:lightgreen;"></p><p class="book_display"></p><p class="book_display"></p>
            </div>
        </div>
    </div>
    <div class="row" style=" text-align:center">
        <div class="center header" style-"margin-top: 200px;">
            <p class="header_top">Under Our Sign</p>
            <h2>Your Always Welcome</h2>
        </div>
    </div>
    <div class="row">
         <div class="col-sm-offset-1 col-sm-10" style="text-align:center">
             <div class="amp_box"><img src="Pics/hotel1.jpg" class="amp_box_img"></img></div><div class="amp_box_bg"><p class="amp_box_text">Push</p></div><div class="amp_box"></div>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="text-align:center">
             <div class="amp_box_bg"><p class="amp_box_text">Excite</p></div><div class="amp_box"></div><div class="amp_box"><img src="Pics/hotel6.jpeg" class="amp_box_img"></img></div>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="text-align:center">
             <div class="amp_box"></div><div class="amp_box"><img src="Pics/hotel4.jpg" class="amp_box_img"></img></div><div class="amp_box_bg"><p class="amp_box_text">Run</p></div>
        </div>
        <div class="col-sm-offset-1 col-sm-10" style="text-align:center">
             <div class="amp_box"><img src="Pics/hotel2.jpg" class="amp_box_img"></img></div><div class="amp_box_bg"><p class="amp_box_text">Live</p></div><div class="amp_box"></div>
        </div>
     </div>


    
    
<?php  include 'decks/Footer.php';?>
</body>
<script type="text/javascript" src="gb.js"></script>

</html>