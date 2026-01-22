using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//My Event Loop

public static class EventLoop
{

    /*
    * We need a data structure that can contain room_name, eventname and payload
    * The idea is to have it dynamic in a sense that if I add or remove an item in the container it will be auto adjusted
    * Again, I want it to be not in the domain to be halted
    * The container must have a queue where I will keep the payload and the payload will be poped out when the listener is invoked automatically
    * The container must have the capability to contain all the objects of the unity platform
    * It is the listeners duty to get the correct data from the queue
    * And it is the producers duty to not to post something that is not in coherence with the system
    * It should have some kind of system to deal with producer consumer problem but there should not be any lock at all
    */

    // this dictionary should be responsible for implementing the full datastructure
    private static Dictionary<string, Dictionary<string, Queue<object>>> EventQueue = new();

    public static void Post(string room_name, string event_name, object payload)
    {
        if (!EventQueue.ContainsKey(room_name))
        {
            EventQueue[room_name] = new Dictionary<string, Queue<object>>();
        }
        if (!EventQueue[room_name].ContainsKey(event_name))
        {
            EventQueue[room_name][event_name] = new Queue<object>();
        }
        EventQueue[room_name][event_name].Enqueue(payload);
    }

    public static object Listen(string room_name, string event_name)
    {
        if (!EventQueue.ContainsKey(room_name))
        {
            return null;
        }
        if (!EventQueue[room_name].ContainsKey(event_name))
        {
            return null;
        }
        return EventQueue[room_name][event_name].Dequeue();
    }

}