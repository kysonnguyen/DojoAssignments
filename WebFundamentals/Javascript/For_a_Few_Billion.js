var reward = 0.01;
for (var i=2; i<31; i++){
  reward = reward * 2;
  console.log(reward + " dollars at day " + i);
}
return reward;
