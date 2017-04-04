(function ()
{
    var DragDropController = function ($scope, ChannelsFactory)
    {
        var youtubeChannel = document.querySelectorAll(".allSubscriptions ul li");

        document.querySelector(".allSubscriptions ul").addEventListener("dragstart", startDrag, false);

        var createNewList = $(".createNewList");
        var dropDiv = $(".dropDivsContainer");

        dropDiv.on("dragenter", ".dropDiv", dragenter);
        dropDiv.on("dragleave", ".dropDiv", dragleave);
        dropDiv.on("dragover", function (e) { e.preventDefault(); });
        dropDiv.on("drop", ".dropDiv", dropped);

        $scope.processing = false;



        function startDrag(e)
        {
            var code = e.target.innerHTML;
            var id = e.target.id;
            e.dataTransfer.setData('Text', code);
            e.dataTransfer.setData('Id', id);

            //Getting database Id
            var channelId = document.getElementById(id).getAttribute("data-channel-id");

            e.dataTransfer.setData("groupId", channelId);

            console.log("startasded drag " + code);
        }

        function endDrag(e)
        {
            // pic = e.target;
            // pic.style.visibility = 'hidden';
        }


        function dragenter(e)
        {
            //e.preventDefault();
            //dropDiv.style.background = "#eee";
            //dropDiv.style.border = "2px solid orange";
        }

        function dragleave(e)
        {
            //e.preventDefault();
            //dropDiv.style.background = "white";
            //dropDiv.style.border = "1px solid red";
        }

        function dropped(e)
        {
            e.preventDefault();
            $scope.processing = true;

            var dropDivUL = document.querySelector(".dropDiv ul");
            var listItems = $('.dropDiv ul li');
            var channelGroupName = "";

            //Checking if the item dropped in createNewList div or someother div.
            if (e.currentTarget.className.indexOf("createNewList") !== -1)
            {
                channelGroupName = createNewDropDiv();
            }
            else
            {
                channelGroupName = e.currentTarget.id;
            }

            var dropDiv = document.querySelector("#" + channelGroupName);
            //var ulInDropDiv = document.querySelector("#" + listId + " > ul");
            var ulInDropDiv = $("#" + channelGroupName + " > ul");

            //Adding li to the ul in the new list.
            var channelName = e.originalEvent.dataTransfer.getData('Text');
            var li = "<li>" + channelName + "</li>";
            ulInDropDiv.prepend(li);

            //Removing li from the original list.
            var liId = e.originalEvent.dataTransfer.getData('Id');
            var li = $('.allSubscriptions ul #' + liId);
            li.remove();


            //For choosing between the createNewChannelGroup and updateYoutubeChannelGroup methods from ChannelsFactory.s
            if (e.currentTarget.className.indexOf("createNewList") !== -1)
            {
                ChannelsFactory.createNewChannelGroup(channelGroupName)
                    .then(
                    function (data)
                    {
                        ChannelsFactory.updateYoutubeChannelGroup(channelGroupName, liId);
                        $scope.processing = false;
                    },
                    function (reason)
                    {
                        $scope.processing = false;
                    });
            }
            else
            {
                ChannelsFactory.updateYoutubeChannelGroup(channelGroupName, liId);
            }

        }


        //Creating new DropDiv which includes a heading and an empty <ul>.
        var createNewDropDiv = function ()
        {
            //Ask for the name of the div.
            var listName = prompt("Enter name of the list");

            if (listName == null)
            {
                return;
            }

            //Creating a div.
            var $div = $("<div>", { id: listName, "class": "dropDiv" });

            //Adding heading to newly created div
            $div.append('<h3>' + listName + '</h3>');


            //Creating a ul inside div.
            $div.append('<ul></ul>');

            //Adding newly created div to page.
            $(".dropDivsContainer").append($div);

            return listName;

        };

    };

    var app = angular.module("app");
    app.controller("DragDropController", ['$scope', 'ChannelsFactory', DragDropController]);



})();