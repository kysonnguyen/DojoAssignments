// for (var daysUntilMyBirthday = 60; daysUntilMyBirthday > -1; daysUntilMyBirthday--) {
//   if (daysUntilMyBirthday > 30) {
//     console.log(daysUntilMyBirthday + " days until my birthday. Such a long time... :(");
//   }
//   else if (daysUntilMyBirthday > 0) {
//     console.log(daysUntilMyBirthday + " DAYS UNTIL MY BIRTHDAY!!!");
//   }
//   else {
//     console.log("HAPPY BIRTHDAY!!! LET'S GO HAVE FUN");
//   }
// }


var users = {
 'Students': [
     {first_name:  'Michael', last_name : 'Jordan'},
     {first_name : 'John', last_name : 'Rosales'},
     {first_name : 'Mark', last_name : 'Guillen'},
     {first_name : 'KB', last_name : 'Tonel'}
  ],
 'Instructors': [
     {first_name : 'Michael', last_name : 'Choi'},
     {first_name : 'Martin', last_name : 'Puryear'}
  ]
 }
 console.log(users.Students[0].first_name);
