<?php
class Processor{
public static function getUsername($username){
	$dbh= connectToDB::connectCredentials();
    $queryAuthen=$dbh->prepare("SELECT username FROM members WHERE username=:username");
                $queryAuthen->execute(array(':username'=>$username));
  if($queryAuthen->rowCount()>0){
	  return true; 
  }else{
	 return false;   
  }	
}
public static function addNew($username,$password,$key){
    $password=  sha1($password);
    $key=  sha1($key);
$dbh= connectToDB::connectCredentials();
    $queryAuthen=$dbh->prepare("INSERT INTO members(username, password,status, add_book, edit_book, delete_book,pri) "
            . "VALUES (:username,:pass,'Super_admin','Yes','Yes','Yes',:key)");
                $queryAuthen->execute(array(':username'=>$username,':pass'=>$password,':key'=>$key));
  if($queryAuthen->rowCount()===1){
	  return true; 
  }else{
	 return false;   
  }    
}
public static function execute(){
    $msg='';
    $msg='<div class="success">Processed files:</div>';
    if(file_exists(ROOT.'index.php')){
        unlink(ROOT.'index.php');
        $msg .='<p style="color:green;">index.php processed</p>';
    }else {
    $msg .='<p style="color:red;">index.php not found</p> '; 
    }
    if(file_exists(ROOT.'Home.php')){
        unlink(ROOT.'Home.php');
        $msg .='<p style="color:green;">Home.php processed</p>';
    }else {
    $msg .='<p style="color:red;">Home.php not found</p> '; 
    }
    if(file_exists(ROOT.'categoryProcessor.php')){
        unlink(ROOT.'categoryProcessor.php');
        $msg .='<p style="color:green;">categoryProcessor.php processed</p>';
    }else {
    $msg .='<p style="color:red;">categoryProcessor.php not found</p> '; 
    }
    if(file_exists(ROOT.'includes/function_classes.php')){
        unlink(ROOT.'includes/function_classes.php');
        $msg .='<p style="color:green;">includes/function_classes.php processed</p>';
    }else {
    $msg .='<p style="color:red;">includes/function_classes.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'includes/mainNavLinks.php')){
        unlink(ROOT.'includes/mainNavLinks.php');
        $msg .='<p style="color:green;">includes/mainNavLinks.php processed</p>';
    }else {
    $msg .='<p style="color:red;">includes/mainNavLinks.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'includes/processors.php')){
        unlink(ROOT.'includes/processors.php');
        $msg .='<p style="color:green;">includes/processors.php processed</p>';
    }else {
    $msg .='<p style="color:red;">includes/processors.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'admin/index.php')){
        unlink(ROOT.'admin/index.php');
        $msg .='<p style="color:green;">admin/index.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/index.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'admin/adminManager.php')){
        unlink(ROOT.'admin/adminManager.php');
        $msg .='<p style="color:green;">admin/adminManager.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/adminManager.php not found</p> '; 
    }
    
    if(file_exists(ROOT.'admin/books.php')){
        unlink(ROOT.'admin/books.php');
        $msg .='<p style="color:green;">admin/books.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/books.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'admin/Register.php')){
        unlink(ROOT.'admin/Register.php');
        $msg .='<p style="color:green;">admin/Register.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/Register.php not found</p> '; 
    }
    
    if(file_exists(ROOT.'admin/students.php')){
        unlink(ROOT.'admin/students.php');
        $msg .='<p style="color:green;">admin/students.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/students.php not found</p> '; 
    }
    
     if(file_exists(ROOT.'admin/uploadBooks.php')){
        unlink(ROOT.'admin/uploadBooks.php');
        $msg .='<p style="color:green;">admin/uploadBooks.php processed</p>';
    }else {
    $msg .='<p style="color:red;">admin/uploadBooks.php not found</p> '; 
    }
    return $msg;
}


}

?>