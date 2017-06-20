<?php

require("C:/xampp/htdocs/Website/SendGrid.php");
require("C:/xampp/htdocs/Website/sendgrid-php/sendgrid-php.php");


$from = new SendGrid\Email("GuestBook", "Alision@guestBook.com");
$subject = "Reservation confirmation";
$to = new SendGrid\Email("tmcelrat@kent.edu", "tmcelrat@kent.edu");
$content = new SendGrid\Content("text/plain", "<h1> Thank you for your Reservation</h1>
<h3>Dear Guest</h3><h4>Thank you For choosing GuestBook Hotels.We are pleased to accept the following reservations.Click her to confirm if you require any further assitance.please contact our Reservations departmetn via return email</h4>
");
$mail = new SendGrid\Mail($from, $subject, $to, $content);

$apiKey = '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';
$sg = new \SendGrid($apiKey);

$response = $sg->client->mail()->send()->post($mail);
echo $response->statusCode();
echo $response->headers();
echo $response->body();

?>
