(function ()
{
    var YoutubeFactory = function ($http)
    {
        //Used to fetch youtube channels based on groupId.
        var getChannelsByGroupId = function (groupId)
        {
            console.log(groupId);
            var query = "/api/channel?groupId=" + groupId;
            var youtubeChannels = $http.get(query)
                .then(
                //Success
                function (response)
                {
                    var youtubeChannels = response.data;

                    return youtubeChannels;
                },
                //Failure
                function ()
                {
                    console.log("Failed to add newChannelGroup. " + reason);
                });

            return youtubeChannels;
        };

        //Get videos by ChannelId. This will
        //first get the Playlist Id for the "Uploads" playlist of a channel.
        //Then it ll call getVideosByChannel, which will fetch videos from "UploadPlaylist".
        var getVideosByChannelId = function (channelId)
        {
            var youtubeKey = "AIzaSyCKSdKv9XAfWR1_BMOxmUjAIDcE1gDMfBo";
            var query = "https://www.googleapis.com/youtube/v3/channels?part=contentDetails&id="
                + channelId + "&key=" + youtubeKey;


            var videos = $http.get(query)
                .then(
                //Success
                function (response)
                {
                    var playlistObject = response.data;
                    var playlistId = playlistObject.items[0].contentDetails.relatedPlaylists.uploads;

                    //Call to get videos from Uploads playlist.
                    var videosByPlaylistId = getVideosByChannel(playlistId);


                    return videosByPlaylistId;
                },
                //Failure
                function (reason)
                {
                    console.log("Failed to add newChannelGroup. " + reason);
                });

            return videos;
            //return channelUploadPlaylistId;
        };

        //Gets the uploaded videos for a channel
        var getVideosByChannel = function (playlistId)
        {
            var youtubeKey = "AIzaSyCKSdKv9XAfWR1_BMOxmUjAIDcE1gDMfBo";
            var numberOfVideos = 5;
            var query = "https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=" + numberOfVideos + "&playlistId=" + playlistId + "&key=" + youtubeKey;

            var videoSnippets = $http.get(query)
                .then(
                //Success
                function (response)
                {
                    var videos = response.data;

                    return videos;
                },
                //Failure
                function (reason)
                {
                    console.log("Failed to add newChannelGroup. " + reason);
                });



            return videoSnippets;
        };


        return {
            getVideosByChannelId: getVideosByChannelId,
            getChannelsByGroupId: getChannelsByGroupId
        };
    };



    var app = angular.module('app');
    app.factory('YoutubeFactory', YoutubeFactory);
})();