function printRange(start_point, end_point, skip_amount)
{
  var num = start_point;
  if (skip_amount === undefined) {
    skip_amount = 1;
    for (var i=0; num <= end_point-skip_amount; i+=skip_amount) {
    num = start_point + i;
    console.log(num);
    }
  }
  if (end_point === undefined) {
    if (start_point > 0) {
      num = 0;
      for (var i=0; num <= start_point-1; i++) {
        num = i;
        console.log(num);
      }
    }
    else if (start_point < 0) {
      num = 0;
      for (var i=0; num >= start_point+1; i--){
        num = i;
        console.log(num);
      }
    }
  }
  else {
    for (var i=0; num <= end_point-skip_amount; i+=skip_amount) {
      num = start_point + i;
      console.log(num);
    }
  }
}
