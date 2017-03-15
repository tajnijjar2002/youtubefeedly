$(document).ready(function()
{
    
    $(document).on("load", dofirst());
});

var dropDiv, youtubeChannel;

var dofirst = function ()
{
    //console.log("aa");
    
    
    youtubeChannel = document.querySelectorAll(".allSubscriptions ul li");

    //console.log(youtubeChannel);

    //$(".allSubscriptions ul").on("dragstart", "li", startDrag);

    document.querySelector(".allSubscriptions ul").addEventListener("dragstart", startDrag, false);
    //youtubeChannel.addEventListener("dragend", endDrag, false);

    dropDiv = document.querySelector(".dropDiv");

    dropDiv.addEventListener("dragenter", dragenter, false);
    dropDiv.addEventListener("dragleave", dragleave, false);
    dropDiv.addEventListener("dragover", function (e) { e.preventDefault(); }, false);

    dropDiv.addEventListener("drop", dropped, false);
}



function startDrag(e)
{
    
    var code = e.target.innerHTML;
    e.dataTransfer.setData('Text', code);

    console.log("startasded drag " + code);
}

function endDrag(e)
{
    // pic = e.target;
    // pic.style.visibility = 'hidden';
}


function dragenter(e)
{
    e.preventDefault();
    dropDiv.style.background = "#eee";
    dropDiv.style.border = "2px solid orange";
}

function dragleave(e)
{
    e.preventDefault();
    dropDiv.style.background = "white";
    dropDiv.style.border = "1px solid red";
}


function dropped(e)
{
    e.preventDefault();

    var dropDivUL = document.querySelector(".dropDiv ul");

    //dropDiv.innerHTML = e.dataTransfer.getData('Text');
    var channelName = e.dataTransfer.getData('Text');
    var entry = document.createElement('li');
    entry.appendChild(document.createTextNode(channelName));
    dropDivUL.appendChild(entry);

    

    //var image = document.querySelector("#rightbox>img");
    //image.style.visibility = "hidden";

}




//function doFirst()
//{
//    console.log("aa");
//    var youtubeChannel = document.getElementById(".allSubscriptions ul li");

//    youtubeChannel.addEventListener("dragstart", startDrag, false);
//    youtubeChannel.addEventListener("dragend", endDrag, false);

//    var dropDiv = document.getElementById("dropDiv");

//    dropDiv.addEventListener("dragenter", dragenter, false);
//    dropDiv.addEventListener("dragleave", dragleave, false);
//    dropDiv.addEventListener("dragover", function (e) { e.preventDefault(); }, false);

//    dropDiv.addEventListener("drop", dropped, false);
//}
