<?php
$data_string = $myarry;
$ch = curl_init('http://guestbook.eastus.cloudapp.azure.com/GuestBook/RestServiceImpl.svc/reservations/book?token=68f2f755c5e1408fb4a1e3c39ba371b3');
curl_setopt($ch,CURLOPT_CUSTOMREQUEST,"POST");
curl_setopt($ch,CURLOPT_POSTFIELDS,$data_string);
curl_setopt($ch,CURLOPT_RETURNTRANSFER,true);
curl_setopt($ch,CURLOPT_HTTPHEADER,array('Content-Type:application/json','Content-Length:'.strlen($data_string)));

$arr = curl_exec($ch);



if (!curl_errno($ch)) {
  switch ($http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE)) {
    case 201:  # good
      break;
    default:
      echo 'Unexpected HTTP code: ', $http_code, "\n";
  }
}

// require("C:/xampp/htdocs/Website/SendGrid.php");
// require("C:/xampp/htdocs/Website/sendgrid-php/sendgrid-php.php");


// $from = new SendGrid\Email("Example User", "Alision@guestBook.com");
// $subject = "Reservation confirmation";
// $to = new SendGrid\Email("Example User", "tmcelrat@kent.edu");
// $content = new SendGrid\Content("text/plain", "and easy to do anywhere, even with PHP");
// $mail = new SendGrid\Mail($from, $subject, $to, $content);

// $apiKey = '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';
// $sg = new \SendGrid($apiKey);

// $response = $sg->client->mail()->send()->post($mail);
// echo $response->statusCode();
// echo $response->headers();
// echo $response->body();

?>