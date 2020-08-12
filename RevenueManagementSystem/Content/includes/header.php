<div class="top-header">
      <h1>Logical Links <span style="color: #0a0;">CBT Solution</span></h1>
  </div>
       <nav class="navbar navbar-inverse top-nav-menu" id="top-nav-bar">
  <div class="container-fluid">
    <div class="navbar-header">
      <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
        <span class="icon-bar"></span>
      </button>
      <a class="navbar-brand" href="#">KCM CBT Solution</a>
    </div>
    <div class="collapse navbar-collapse" id="myNavbar">
      <ul class="nav navbar-nav">
                <li><a href="Home"><i class="glyphicon glyphicon-home"></i> Home</a></li>
           <li><a href="test"><i class="fa fa-desktop"></i> Start a test</a></li>
        <?php if(isset($_SESSION['username'])): ?>
           <li><a href="addSubject"><i class="fa fa-book"></i> Add subject</a></li> 
    <li><a href="addQuestion"><i class="fa fa-question-circle"></i> Add question</a></li> 
    <li><a href="register"><i class="fa fa-user"></i> Register a new user</a></li> 
     <li><a href="testHistory"><i class="fa fa-desktop"></i> Test history</a></li> 
    <li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown" href="#"><i class="fa fa-user"></i> More <span class="caret"></span></a>
          <ul class="dropdown-menu">
            <li><a href="users"><i class="fa fa-users"></i> View users</a></li> 
             <li><a href="viewSubjects"><i class="fa fa-eye"></i> View subjects</a></li>
            <li><a href="viewQuestions"><i class="fa fa-question"></i> View questions</a></li> 
      </ul>
         </li> 
        <?php endif ?> 
       </ul>
        
      <ul class="nav navbar-nav navbar-right">
         <li class="dropdown">
          <a class="dropdown-toggle" data-toggle="dropdown" href="#">
              <img src="images/member.png" width="20" height="20" alt="" title="Welcome <?php if(isset($_SESSION['username'])) echo $_SESSION['username']; else echo "Guest";?>"/>
              <span class="caret"></span></a>
         <?php if(isset($_SESSION['username'])): ?>
             <ul class="dropdown-menu">
              <li><a href="changePass"><i class="fa fa-power-off"></i> Change password</a></li>
              <li><a href="Logout"><i class="glyphicon glyphicon-log-out"></i> Logout</a></li>
          </ul>
           <?php endif ?> 
      </ul>
    </div>
  </div>
</nav>  