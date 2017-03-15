(function ()
{

    var DragDropController = function ($scope)
    {
        dofirst();
    };



    var dropDiv, youtubeChannel, createNewList;

    var dofirst = function ()
    {
        youtubeChannel = document.querySelectorAll(".allSubscriptions ul li");

        document.querySelector(".allSubscriptions ul").addEventListener("dragstart", startDrag, false);


        createNewList = $(".createNewList");
        dropDiv = $(".dropDivsContainer");


        
        dropDiv.on("dragenter", ".dropDiv", dragenter);
        dropDiv.on("dragleave", ".dropDiv", dragleave);
        dropDiv.on("dragover", function (e) { e.preventDefault(); });
        dropDiv.on("drop", ".dropDiv", dropped);

        //dropDiv.addEventListener("dragenter", dragenter, false);
        //dropDiv.addEventListener("dragleave", dragleave, false);
        //dropDiv.addEventListener("dragover", function (e) { e.preventDefault(); }, false);

        //dropDiv.addEventListener("drop", dropped, false);
    }

    function startDrag(e)
    {

        var code = e.target.innerHTML;
        var id = e.target.id;
        e.dataTransfer.setData('Text', code);
        e.dataTransfer.setData('Id', id);

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
        var listItems = $('.dropDiv ul li');
        var listId = "";

        //Checking if the item dropped in createNewList div or someother div.
        if (e.currentTarget.className.indexOf("createNewList") !== -1)
        {
            listId = createNewDropDiv();
        }
        else
        {
            listId = e.currentTarget.id;
        }

        var dropDiv = document.querySelector("#" + listId);

        //Adding li to the ul in the new list.
        var channelName = e.originalEvent.dataTransfer.getData('Text');
        var entry = document.createElement('li');
        entry.appendChild(document.createTextNode(channelName));
        dropDiv.appendChild(entry);


        //Removing added li from parent list.
        var id = e.originalEvent.dataTransfer.getData('Id');
        var listItem = document.querySelector('#' + id);
        var allChannelsList = document.querySelector(".allSubscriptions ul");
        allChannelsList.removeChild(listItem);

    }


    //Creating new DropDiv which includes a heading and an empty <ul>.
    var createNewDropDiv = function ()
    {
        //Ask for the name of the div.
        var listName = prompt("Enter name of the list");

        //Creating a div.
        var $div = $("<div>", { id: listName, "class": "dropDiv" });

        //Adding heading to newly created div
        $div.append('<h3>' + listName + '</h3>');


        //Creating a ul inside div.
        $div.append('<ul></ul>');

        //Adding newly created div to page.
        $(".dropDivsContainer").append($div);

        return listName;

        //alert(1);
    };








    var app = angular.module("app");
    app.controller("DragDropController", ['$scope', DragDropController]);
})();