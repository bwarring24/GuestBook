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
<?php include 'mail.php';?>
 <div class="row" style="margin-top:80px; text-align:center">
            <div class="center header" style-"margin-top: 200px;"><p class="header_top">Reserve Today</p><h2>Enjoy your Stay</h2></div>
     </div>
     <div class="row" style="margin-top:50px;">
        <div class="col-sm-offset-2 col-sm-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Confirm Your Reservation</h3>
                    </div>
                <div class="panel-body">
                    
                    
                   <h2>Your Reservation has been Confirmed</h2>
                   <h4>An Confirmation email has been sent to you</h4>
                   <?php 

                   
                   $roomTypes['Double'] = 0; 
                    $roomTypes['Single'] = 0;
                    $roomTypes['Double Double'] = 0;
                    $roomTypes['Family Suite'] = 0;
                   for($i = 0;$i < 300;$i++){
                            if(!empty($_GET[$i])){
                                $roomTypes[$_GET[$i]] += 1;
                            }
                   }
                   $Reserves = [];
                   
                //    $time = explode("/",$_GET['check-in']);
                //    $zone = new DateTimeZone("UTC");
                //    $checkin = new DateTime("now",$zone);
                //    $checkin->format('u');
                   $checkin = date('U', strtotime($_GET['check-in']) + 86400);
                   
                //    $time = explode("/",$_GET['check-out']);
                   $checkout = date('U', strtotime($_GET['check-out'])  + 86400);
                   //$checkin = date("z",strtotime($_GET['check-out']));
                   //$checkout =  time() - date('Z',$_GET["check-out"]);
                   array_push($Reserves,array('room_type' => 'Double','number_of_rooms'=>$roomTypes['Double']));
                   array_push($Reserves,array('room_type' => 'Single','number_of_rooms'=>$roomTypes['Single']));
                   array_push($Reserves,array('room_type' => 'Double Double','number_of_rooms'=>$roomTypes['Double Double']));
                   array_push($Reserves,array('room_type' => 'Family Suite','number_of_rooms'=>$roomTypes['Family Suite']));
                   $myarry = array('first_name' => $_GET["first_name"],"last_name" => $_GET["last_name"],'Email' => $_GET["email"], 'Phone' => $_GET["phone"],'start_date' =>"/Date(".$checkin."000)/","end_date" => "/Date(".$checkout."000)/",'reserveRooms' => $Reserves);
                   $myarry['Rooms']= [];

                   for($i = 0;$i < 300;$i++){
                            if(!empty($_GET[$i])){
                                array_push($myarry['Rooms'],array('Room_number'=>$_GET['rm_'.$i],'room_type' => $_GET[$i], 'cost_of_stay' => '39'));
                            }
                   }
                    
                    
                    $myarry = json_encode($myarry, JSON_PRETTY_PRINT);

                   ?>
                   <?php include "postRes.php"; ?>
                </div>
            </div>
        </div>
        
    </div>


    
    
<?php  include 'decks/Footer.php';?>
</body>
<script type="text/javascript " src="gb.js "></script>

</html>