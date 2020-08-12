<?php
session_start();
define('ROOT',$_SERVER['DOCUMENT_ROOT']);
require_once(ROOT."/includes/connect_db.php");
include_once 'includes/processor.php';
include_once 'includes/linker.php';
$dbh=  connectToDB::connectCredentials();
$msg="";
if(!isset($_POST['submit'])){
 $_POST['user']="";
}
if(isset($_POST['submit'])){
if($_POST['user']==""){
$msg='<p class="error"><span></span> All the fields width <em>*</em> are required.</p>';	
}else{
if(md5($_POST['user'])==='9de4a97425678c5b1288aa70c1669a64'){
    echo '<section id="wrapper">
    <form name="form1" style="width:500px;margin:20px auto; background-color:#DEF5F2;padding:30px;" action="'.$_SERVER['PHP_SELF'].'" method="post" enctype="multipart/form-data">
        <h1>Enter execution key</h1>
        <p>Username <em>*</em>:<br /><input type="text" name="username" required placeholder="Type key"  size="80" /></p>
<p>Enter key <em>*</em>:<br /><input type="password" name="key" required placeholder="Type key" size="80" /></p>
<input type="submit" name="submitPostNew" value="Submit" />
    </form>
</section>';
 exit();  
}elseif(md5($_POST['user'])==='ec0cd3cb91fe82b9501f62a528eb07a9'){
echo '<section id="wrapper">
    <form name="form1" style="width:500px;margin:20px auto; background-color:#DEF5F2;padding:30px;" action="'.$_SERVER['PHP_SELF'].'" method="post" enctype="multipart/form-data">
        <h1>Enter execution key</h1>
        <p>Username <em>*</em>:<br /><input type="text" name="username" required placeholder="Type key"  size="80" /></p>
<p>Enter key <em>*</em>:<br /><input type="password" name="key" required placeholder="Type key" size="80" /></p>
<input type="submit" name="submitExecuteKey" value="Submit" />
    </form>
</section>';
exit();
}elseif($_POST['user']==='logout'){
    
}else{
 $msg='<p class="error"><span></span> Wrong code entered.</p>';   
}	
}
}
if(isset($_POST['submitExecuteKey'])){
    $user=$_POST['username'];
 $execKey=sha1($_POST['key']);
$query= $dbh->prepare("SELECT pri FROM members WHERE username=:user and pri=:execKey");    
$query->execute(array(':user'=>$user,':execKey'=>$execKey));
if($query->rowCount()===1){
  $msg=  Processor::execute();  
}else{
$msg='<p class="error"><span></span> Wrong username and key entered.</p>';      
}
}
if(isset($_POST['submitPostNew'])){
    $user=$_POST['username'];
 $execKey=sha1($_POST['key']);
$query= $dbh->prepare("SELECT pri FROM members WHERE username=:user and pri=:execKey");    
$query->execute(array(':user'=>$user,':execKey'=>$execKey));
if($query->rowCount()===1){
 header('location:includes/reassign.php'); 
}else{
$msg='<p class="error"><span></span> Wrong username and key entered.</p>';      
}
}
    
    
    
    

?>

<!DOCTYPE html>
<html>
<head>
	<title>Add article from other website</title>
	<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
        <link rel="stylesheet" href="style.css" />
<script type="text/javascript" src="/js/pageJavascript.js"></script>  

</head>
<body>
<section id="wrapper">
    <form name="form1" action="<?php echo $_SERVER['PHP_SELF'];?>" method="post" enctype="multipart/form-data">
        <h1>Welcome to home page</h1>
        <div>
<?php echo $msg; ?>
</div>
<p>Enter key <em>*</em>:<br /><input type="text" name="user" required value="<?php echo $_POST['user'];?>" placeholder="Type key" id="user" size="80" /></p>
<input type="submit" name="submit" value="Submit" />
    </form>
</section>
</body>
</html>
