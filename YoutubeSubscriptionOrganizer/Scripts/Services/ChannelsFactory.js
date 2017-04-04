(function ()
{
    var ChannelsFactory = function($http)
    {
        var createNewChannelGroup = function (channelGroupName)
        {
            var ChannelGroupName = {
                ChannelGroupName: channelGroupName
            };

            var channelGroup = $http.post("/api/UpdateChannelGroup", ChannelGroupName)
            .then(
            //Success function
            function (response)
            {
                var newChannelGroup = response.data;
                return newChannelGroup;
            },
            //Error function
            function (reason)
            {
                console.log("Failed to add newChannelGroup. " + reason);
            });

            return channelGroup;
        };

        var updateYoutubeChannelGroup = function (channelGroupName, youtubeChannelId)
        {
            var updateYoutubeChannel = {
                ChannelGroupName: channelGroupName,
                YoutubeChannelId: youtubeChannelId
            };


            //var updated = $http({
            //    url: "/api/UpdateChannelGroup",
            //    method: "PUT",
            //    params: updateYoutubeChannel
            //});

            //var query = "/api/UpdateChannelGroup?groupId=" +
            //    updateYoutubeChannel.ChannelGroupName +
            //    "&yotubeChannelId=" +
            //    updateYoutubeChannel.YoutubeChannelId;

            var updated = $http.put("/api/UpdateChannelGroup", updateYoutubeChannel)
                .then(
                //Success function
                function (response)
                {
                    var updateChannel = response.data;
                    return updateChannel;
                },
                //Error function
                function (reason)
                {
                    console.log("Failed to update YoutubeChannel. " + reason);
                });

            return updated;
        }



        return {
            createNewChannelGroup: createNewChannelGroup,
            updateYoutubeChannelGroup: updateYoutubeChannelGroup
        };
    };

    angular.module('app')
    .factory('ChannelsFactory', ChannelsFactory);

})();