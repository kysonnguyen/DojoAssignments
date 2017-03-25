//Optional assignment//
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
   for (var i = 0; i < users.Students.length; i++){

     var student_name = users.Students[i].first_name + " " + users.Students[i].last_name;
     console.log(i+1 + " - " + student_name +  " - " +(student_name.length - 1));
   }
  // console.log(users);
  // console.log(users.Students.length);
