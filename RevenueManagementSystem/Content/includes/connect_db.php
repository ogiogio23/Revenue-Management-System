<?php
class connectToDB{
public static function connectCredentials(){
try{
    //$dbh  means database host
$dbh=new PDO('mysql:host=localhost; dbname=revenue_system','root','',array(PDO::ATTR_PERSISTENT=>true));
$dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}catch(Exception $e){
//echo $e->getMessage();
//   exit();
}
return $dbh;	
}	
}



?>

