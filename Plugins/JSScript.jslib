mergeInto(LibraryManager.library,
{
	ShowVideo: function(){
          ysdk.adv.showRewardedVideo({ callbacks: {} });
        },
  ShowFullScreenAd: function(){
          ysdk.adv.showFullscreenAdv();
  },
  SaveExtern: function(date) {
	var dateString = UTF8ToString(date);
    var myobj = JSON.parse(dateString);
	ysdk.getPlayer().then(player => {
    	player.setData(myobj);});
  	},

  	LoadExtern: function(){
		ysdk.getPlayer().then(player => {
    		player.getData().then(_date => {
        	const myJSON = JSON.stringify(_date);
        	myGameInstance.SendMessage('Yandex', 'SetPlayerInfo', myJSON);});
		});
 	},
	SetToLeaderboard: function(value){
		ysdk.getLeaderboards().then(lb => {
    lb.setLeaderboardScore('LeaderDoska', value);});
	},

	GetLang: function () {
    	var lang = ysdk.environment.i18n.lang;
    	var bufferSize = lengthBytesUTF8(lang) + 1;
    	var buffer = _malloc(bufferSize);
    	stringToUTF8(lang, buffer, bufferSize);
    	return buffer;
    },
	
});