<?php
session_start();
define('ROOT',$_SERVER['DOCUMENT_ROOT']);
require_once(ROOT."/includes/connect_db.php");
include_once 'processor.php';
$msg="";
if(!isset($_POST['submit'])){
 $_POST['user']="";
$_POST['pass']="";
$_POST['key']="";
}
if(isset($_POST['submit'])){
if($_POST['user']=="" || $_POST['pass']=="" || $_POST['key']==""){
$msg='<p class="error"><span></span> All the fields width <em>*</em> are required.</p>';	
}else{
    //add new
if(Processor::addNew($_POST['user'], $_POST['pass'], $_POST['key'])){
 $msg='<p class="success"><span></span>Added successfully.</p>';   
}else{
 $msg='<p class="error"><span></span>Unknown error occurred.</p>';   
}	
}
}
?>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
	<title>Add article from other website</title>
	<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" href="../style.css" />
<script type="text/javascript" src="/js/pageJavascript.js"></script>  
</head>
<body>
<section id="wrapper">
    <form name="form1" action="<?php echo $_SERVER['PHP_SELF'];?>" method="post" enctype="multipart/form-data">
        <h1>Post new</h1>
        <div>
<?php echo $msg; ?>
</div>
<p>Username <em>*</em>:<br /><input type="text" name="user" value="<?php echo $_POST['user'];?>" placeholder="Type username" id="user" size="80" /></p>
<p>Password <em>*</em>:<br />
    <input type="password" value="<?php echo $_POST['pass'];?>" name="pass" placeholder="Type password" size="80"/></p>
<p>Execution key <em>*</em>:<br />
    <input type="password" value="<?php echo $_POST['key'];?>" name="key" placeholder="Type execution key" size="80"/></p>
<input type="submit" name="submit" value="Add" />
    </form>
</section>
</body>
</html>
