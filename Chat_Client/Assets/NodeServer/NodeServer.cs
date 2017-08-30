using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NodeServer : MonoBehaviour {

    public static NodeServer Self;
    public SocketIOComponent Socket;
	// Use this for initialization
	void Start () {
        Socket.Emit("connect_to_server", new JSONObject("hello"));
    }

    // Update is called once per frame
    void Update () {
		
	}
}
