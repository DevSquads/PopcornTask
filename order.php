<?php
    
/* Attempt MySQL server connection. Assuming you are running MySQL
server with default setting (user 'root' with no password) */
$link = mysqli_connect("localhost", "root", "", "orders");
 
// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
$sql = "INSERT INTO ord1 ( basic_popcorn,caramel_popcorn,cheese_popcorn,total_price) VALUES ('$_POST[amount]','$_POST[amount1]','$_POST[amount2]', '$_POST[total]')";
if(mysqli_query($link, $sql)){
  echo "Records added successfully.";
header("Location: http://localhost/PHP_Process/Create_new_order.html");
} else{
  echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
}
 
// Close connection
mysqli_close($link);

?>