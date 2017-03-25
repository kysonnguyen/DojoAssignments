function slots(quarter){
  var win = 0;
  var lose = 0;
  while (quarter > 0){
    if (Math.trunc(Math.random() * 100) == 77){
      win = Math.floor(Math.random() * 51) + 50;
      quarter = quarter+win;
      return quarter;
    }
    else{
      console.log("quarters: " + quarter);
      quarter--;
      if (quarter == 0){
      return lose;
      }
    }
  }
}

slots(100000);
