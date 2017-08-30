
var io = require('socket.io')({
    transports: ['websocket']
});

var db = require('./Models/database');

setTimeout(function(){
    console.log("all users ----"+ db.users().length);
    console.log("all conversations ----"+ db.conversations().length);
    console.log("all friends ----"+ db.friends().length);
    console.log("all invite_friends ----"+ db.invite_friends().length);
    console.log("all message_seen ----"+ db.message_seen().length);
    console.log("all messages ----"+ db.messages().length);
},1000);

io.on('connecting',function(socket){
    console.log(socket.client.conn.id + ", ip : " + socket.handshake.address);

    socket.on('connect_to_server', function (data) {        
        console.log("connected devices")
        hClient.connect(socket,data);
    });

    socket.on('disconnect', function (data) {
        hClient.disconnect(socket);
    });
});
io.attach(9482);
console.log("Listening on port 9482");
