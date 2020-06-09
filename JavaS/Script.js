function myfunction() { 
var x,y,z,total;
var i = document.getElementById("custom-select1").value;
var n = document.getElementById("custom-select2").value;
var k = document.getElementById("custom-select3").value; 
var number = document.getElementById("number1").value; 
var numberx = document.getElementById("number2").value;  
var numbery = document.getElementById("number3").value;  
    if ((i == 0 && number == 0) && (n == 0 && numberx == 0) && (k == 0 && numbery == 0))
        {
            alert("You should select size and how many item you want ");
       
        }
    else{
    if ((number > 50 || number < 0) || (numberx > 50 || numberx <0) || (numbery > 50 || numbery <0) )
        {
            alert( "Maximum number for the individual item is 50 and minimum number is 1");}
    else{
    
    if((i == 0 && number>0) || (n == 0 && numberx >0) || (k==0 && numbery > 0))
        alert("You should choose size");
else{
    if (i == 1 && number > 0) 
    {x = number*30;}
else if (i == 2 && number > 0) {x = number*45; } 
else{ x = 0;}
if (n == 1 && numberx > 0) 
     {y = numberx*40;}
else if (n == 2 && numberx > 0) {y = numberx*55; } 
    else {y =0;}
if (k == 1 && numbery > 0) 
     {z = numbery*50;}
else if (k == 2 && numbery > 0) {z = numbery*65; } 
    else {z = 0;}
total = x+y+z;
document.getElementById("text").value = total;
var userPreference;
if (confirm(  "Your total price is "+ total + " EGP" +" do you want to save it ?" ) == true) {
userPreference = "Your order is saved successfully!";
} 
    else {
			userPreference = "Your order is canceled!";
		}
         alert(userPreference);
  	//document.getElementById("msg").innerHTML = userPreference;
    
  } 
}
    }

}
