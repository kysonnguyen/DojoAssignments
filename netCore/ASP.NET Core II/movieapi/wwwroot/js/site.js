// Write your Javascript code.
$(document).ready(function(){
    get();
    document.getElementById("search").onsubmit = function(){Search()}; 
})


function Search(){ 
    var input = document.getElementById("search"); 
    $.post("/search/{movie}", $(input).serialize(),function(){
        get();
    });
}

function get(){
    $("table").text("")
    $("table").append(`
        <tr>
            <th>Title</th>
            <th>Rating</th>
            <th>Release Date</th>
        </tr>
    `)
    $.get("/get", function(movies){
        for(movie of movies){
            console.log(movie.title);
            show(movie);
        }
    });
}

function show(movie){
    var date = new Date(movie.release_date).toDateString();
    $("table").append(`
        <tr>
            <td>${movie.title}</td>
            <td>Rating: ${movie.rating}</td>
            <td>${date}</td>
        </tr>
    `)
}

