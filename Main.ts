import { Room, EntityMap, Client, nosync } from "colyseus";

export class StateHandlerRoom extends Room {
    onInit (options) {
        console.log("StateHandlerRoom created!", options);
    }

    onJoin (client) {
        this.state.createPlayer(client.sessionId);
    }

    onLeave (client) {
        this.state.removePlayer(client.sessionId);
    }

    onMessage (client, data) {
        console.log("StateHandlerRoom received message from", client.sessionId, ":", data);
    }

    onDispose () {
        console.log("Dispose StateHandlerRoom");
    }

}