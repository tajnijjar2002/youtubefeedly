(function ()
{

    var YoutubeController = function ($scope, YoutubeFactory)
    {

        $scope.channels = [];
        $scope.channelVideos = [];

        //Gets videos for a channelgroup when someone clicks on a ChannelGroup.
        //This will do following:
        //  1. First get the list of Channels in the clicked ChannelGroup.
        //  2. Then get the videos for each Channel in ChannelGroup.
        $scope.getVideosForChannelGroup = function (groupId)
        {
            //1. Getting list of channels by groupId.
            var getListOfChannelsByGroup = YoutubeFactory.getChannelsByGroupId(groupId)
                .then(function (listOfChannels)
                {
                    $scope.channels = listOfChannels;

                    //2. Getting list of videos for each Channel in ChannelGroup.
                    var i;
                    var counterLength = listOfChannels.length;
                    for (i = 0; i < counterLength; i++)
                    {
                        $scope.channelVideos = [];
                        var channelId = listOfChannels[i].ChannelUrl;
                        var videosByChannelId = YoutubeFactory.getVideosByChannelId(channelId)
                            .then(function (videos)
                            {
                                angular.forEach(videos.items, function(video)
                                {
                                    $scope.channelVideos.push(video);
                                });
                            },
                            function (reason)
                            {
                                console.log("Error occured: ", reason);
                            });

                    }


                },
                function (reason)
                {
                    console.log("Error occured: ", reason);
                });




            //console.log(channelId);
            //var youtubeChannelsByGroup = YoutubeFactory.getChannelsByGroupId(channelId)
            //    .then(function(listOfChannels)
            //    {
            //        $scope.channels = listOfChannels;

            //        //var i;
            //        //var counterLength = $scope.channels.length;
            //        //for(i = 0; i < counterLength; i++)
            //        //{
            //        //    var channelId = $scope.channels[i].ChannelUrl;
            //        //    var videos = YoutubeFactory.getVideosByChannelId(channelId)
            //        //        .then(function (listOfVideos)
            //        //        {
            //        //            $scope.channelVideos.push(listOfVideos);
            //        //        },
            //        //        function (reason)
            //        //        {
            //        //            console.log("Error occured: ", reason);
            //        //        });
            //        //}

            //    },
            //    function(reason)
            //    {
            //        console.log("Error occured: ", reason);
            //    });
        };





        //$scope.clicked = function ()
        //{


        //    var channelId = "UCsbfPM5Wd1REwCIBYJFIyOw";
        //    var channelPlaylistId = YoutubeFactory.getVideosByChannelId(channelId)
        //        .then(function (data)
        //        {
        //            var uploadId = data;
        //        },
        //        function (reason)
        //        {
        //            console.log("Error occured: ", reason);
        //        });



        //};
    };









    var app = angular.module("app");
    app.controller("YoutubeController", ['$scope', 'YoutubeFactory', YoutubeController]);
})();