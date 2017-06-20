<?php
$data = array("start_date" => "/Date(1492466400)/","end_date"=>"/Date(1493466400)/");
$data_string = json_encode($data);
$ch = curl_init('http://guestbook.eastus.cloudapp.azure.com/GuestBook/RestServiceImpl.svc/rooms/avaiable?token=68f2f755c5e1408fb4a1e3c39ba371b3');
curl_setopt($ch,CURLOPT_CUSTOMREQUEST,"POST");
curl_setopt($ch,CURLOPT_POSTFIELDS,$data_string);
curl_setopt($ch,CURLOPT_RETURNTRANSFER,true);
curl_setopt($ch,CURLOPT_HTTPHEADER,array('Content-Type:application/json','Content-Length:'.strlen($data_string)));

$arr = curl_exec($ch);

$arr1 = json_decode($arr);
//var_dump($arr1);
?>