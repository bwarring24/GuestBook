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
            <div class="center header" style-"margin-top: 200px;"><p class="header_top">Reserve Today</p><h2>Enjoy your Stay</h2></div>
     </div>
     <div class="row" style="margin-top:50px;">
        <div class="col-sm-offset-2 col-sm-8">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title">Choose Your Room</h3>
                    </div>
                <div class="panel-body">
                    <form action="Verification.php" method="get">
                    <div class="col-sm-3">
                    Check-In <input  class="form-control" type="date" name="check-in" ></input>
                    </div>
                    <div class="col-sm-3">
                    Check-Out <input class="form-control" type="date" name="check-out"></input>
                    </div>
                    <div class="col-sm-2">
                    Adults <select name="Adults" class="form-control">
                        <option value="1br">1</option>
                        <option value="2br">2</option>
                        <option value="4br">4</option>
                    </select>
                    </div>
                    <?php include 'cloudAzure.php';?>
                    <input type="submit" value="Reserve" class="btn btn-warning" style="margin-top:20px"/>
                    <table class="table" style="margin-top:20px">
                        <tr>
                            <th>Room Type</th>
                            <th>Amenities</th>
                            <th>Price</th>
                            <th></th>
                        </tr>
                    <?php 
                        foreach($arr1 as $key=>$rooms){
                        echo "<tr>";
                        echo "<td><h4>".$rooms->room_type." Bed</h4><img class='prospect' src='Pics/rm".rand(1, 13).".jpg'/><br><br><span>315 Square feet</span><br><span>Room sleeps 2 guest</span></td>";
                        echo "<td><strong>".$rooms->room_type."</strong><br>".($rooms->cost_per_day*4.5)." sq feet <br></td>";
                        echo "<td><p>Average Price Estimate</p><p>$".$rooms->cost_per_day."</p></td>";
                        echo "<td>Reserve Room<input name='".$key."' type='checkbox' value='".$rooms->room_type.",".$rooms->room_number.",".$rooms->cost_per_day."' class='btn btn-warning'/></td>";
                        echo "</tr>";
                    }
                    
                    ?>
                   
                    </table>
                    </form>
                </div>
            </div>
        </div>
        
    </div>


    
    
<?php  include 'decks/Footer.php';?>
</body>
<script type="text/javascript " src="gb.js "></script>

</html>