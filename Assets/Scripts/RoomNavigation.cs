using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNavigation : MonoBehaviour {

    public Room currentRoom;
    Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();

    GameController controller;

    void Awake()
    {
        controller = GetComponent<GameController>();

    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);

            controller.interactionDescriptionsInRoom.Add(currentRoom.exits[i].exitDescription + " " + currentRoom.exits[i].keyString.ToUpper());
        }
    }
    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn("You move to the " + directionNoun);
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn("You can't go " + directionNoun);
        }    
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }

}
