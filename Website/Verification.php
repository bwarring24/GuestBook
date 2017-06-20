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
                    <form action="Confirm.php" method="get">
                    <div class="panel-heading">
                        <h3 class="panel-title">Confirm Your Reservation and information</h3>
                    </div>
                <div class="panel-body">
                    <input  type="hidden" name="check-in" value="<?php echo $_GET["check-in"] ?>"></input>
                    <input  type="hidden" name="check-out" value="<?php echo $_GET["check-out"] ?>"></input> 
                    <div class="col-sm-5">
                    First Name<input  class="form-control" type="text" name="first_name"></input>
                    </div>
                    <div class="col-sm-5">
                     Last Name<input class="form-control" type="text" name="last_name"></input>
                    </div>
                    <div class="col-sm-7">
                     Phone Number<input class="form-control" type="text" name="phone"></input>
                    </div>
                    <div class="col-sm-7">
                     Email <input class="form-control" type="text" name="email"></input>
                    </div>
                    <div class="col-sm-12" style="margin:10"></div>
                    <table class="table" style="margin-top:20px">
                        <tr>
                            <th></th>
                            <th>Room</th>
                            <th>Date</th>
                            <th>Total:</th>
                            <th></th>
                        </tr>
                        <?php 
                        $num_rooms = 0;
                        for($i = 0;$i < 300;$i++){
                            if(!empty($_GET[$i])){
                                $box = explode(',', $_GET[$i]);
                                $num_rooms++;
                            echo "<tr>
                                <td>Room ".$num_rooms."</td>
                                <td><h4>1 ".$box[0]."</h4></td>
                                <input type='hidden' name=".$i." value='".$box[0]."'></input>
                                <input type='hidden' name='rm_".$i."' value=".$box[1]."></input>
                                <input type='hidden' name='price_".$i."' value=".$box[1]."></input>
                                <td><b>Date-in </b>".$_GET["check-in"]."<br><b>Date-out </b>".$_GET["check-out"]."<br>
                                </td>
                                <td><p></p><p>$".$box[2]."</p></td>
                            </tr>";
                            
                            }
                        }
                    ?>
                    <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td><input type="submit" value="Confrim Reservation" class="btn btn-warning"/></td>
                    
                    </tr>
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