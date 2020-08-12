 <div class="top-header">
      <h1>Revenue Collection <span style="color: #0a0;">and Management System</span></h1>
  </div>
       <nav class="navbar navbar-inverse top-nav-menu" id="top-nav-bar">
  <div class="container-fluid">
    <div class="navbar-header">
         <a class="navbar-brand" href="#">Ajeromi Ifelodun LGA, Lagos State</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
        <ul class="nav navbar-nav">
            <li><a href="Home.php"><i class="fa fa-home" style="font-size: 20px;"></i></a></li>
                        </ul> 
      <ul class="nav navbar-nav navbar-right">
        <li><a><span class="glyphicon glyphicon-user"></span> <?php if(isset($_SESSION['username'])) echo $_SESSION['username']; ?></a></li>
        <li><a href="Logout.php"><span class="glyphicon glyphicon-log-out"></span> Logout</a></li>
      </ul>
     
    </div>
  </div>
</nav>  