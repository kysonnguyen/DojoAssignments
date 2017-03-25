var HOUR = 8;
var MINUTE = 50;
var PERIOD = "AM";

var HOUR = 7;
var MINUTE = 15;
var PERIOD = "PM";

//Can I have the time?
if (HOUR == 8 && MINUTE == 50 && PERIOD =='AM') {
  console.log("It's almost 9 in the morning");
}
else if (HOUR == 7 && MINUTE == 15 && PERIOD =='PM') {
  console.log("It's just after 7 in the evening");
}

//Challenge
if (MINUTE < 30) {
  if (PERIOD == 'AM') {
    console.log("It's just after", HOUR, "in the morning");
  }
  else if (PERIOD == 'PM'){
    console.log("It's just after", HOUR, "in the evening");
  }
}
if (MINUTE > 30 && PERIOD == 'AM') {
    console.log("It's almost", HOUR+=1, "in the morning");
}
if (MINUTE > 30 && PERIOD == 'PM'){
    console.log("It's almost", HOUR+=1, " in the evening");
}
