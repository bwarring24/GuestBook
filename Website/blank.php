<?php

require_once 'vendor/autoload.php';
chdir(dirname("C:\\xampp\\htdocs\\Website"));
use GuzzleHttp\Client;

$client = new Client();
$response = $client->request('GET', 'http://httpbin.org/get');

echo $response->getStatusCode(); // 200
echo $response->getReasonPhrase(); // OK
echo $response->getProtocolVersion(); // 1.1

//$res = $client->get('http://httpbin.org/get');
echo $response->json();


?>