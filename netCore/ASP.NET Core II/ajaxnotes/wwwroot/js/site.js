$(document).ready(function(){
    get();
})



function get(){
    $("main").text("");
    $.get("/get", function(result){
        for(note of result){
            console.log(note.title);
            show(note);
        }
    })
}

function show(note){
    $("main").prepend(`
        <div class="notes">
            <h5>${note.title}</h5>
            <form id="${note.id}" class="update" action="/update/{${note.id}}" method="post">
                <input type="hidden" name="id" value="${note.id}">
                <textarea onchange="update(${note.id})"name="content" class="description" placeholder="Enter description here...">${note.content ? note.content : ""}</textarea>

            </form>
            <form class="del" action="/delete/{${note.id}}" method="post">
                <input type="hidden" name="id" value="${note.id}">
                <input type="submit" value="Delete">
            </form>
        </div>
    `)
}


function update(id){
    $.post("/update", $(`#${id}`).serialize(), function(){
        get();
    });
}
