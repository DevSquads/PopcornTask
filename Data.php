<?php
    
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */
$link = mysqli_connect("localhost", "root", "", "orders");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
$x = $_POST[psw];
if ( $x == 0 )
{
$sql = "INSERT INTO users ( name, Password) VALUES ('$_POST[uname]','$_POST[psw]')";
if(mysqli_query($link, $sql))
{ 
  echo "Records added successfully.";
header("Location: http://localhost/PHP_Process/Home_Page.html");
    } 
    else{
  echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
}
else {  header("Location: http://localhost/PHP_Process/Register.html");   }

// Close connection
mysqli_close($link);
?>