using System;
using System.Collections.Generic;
using Assets.Source.Messaging.Messages;
using UnityEngine;

namespace Assets.Source.Messaging
{
    public static class MessagingCenter
    {
        private static CollectionByType _receivers = new CollectionByType();
        private static List<object> _toBeDeleted = new List<object>();
        private static List<object> _toBeAdded = new List<object>();
        private static int _depth;

        public static void RegisterReceiver(object receiver)
        {
            if (receiver == null)
            {
                Debug.LogWarning("Attempted to regsiter Message Receiver but was null");
                return;
            }
            _toBeAdded.Add(receiver);	
        }

        public static void AddRegisteredReceiver()
        {
            if (_depth > 0)
                return;

            foreach (var receiver in _toBeAdded)
            {

                foreach (var type in receiver.GetType().GetInterfaces())
                {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (IReceivesMessages<>))
                        _receivers.AddItem(type, receiver);
                }

                if (_toBeDeleted.Contains(receiver))
                    _toBeDeleted.Remove(receiver);
            }
            _toBeAdded.Clear();
        }

        public static void DeregisterReceiver(object receiver)
        {
            if (receiver == null)
            {
                Debug.LogWarning("Attempted to deregsiter Message Receiver but was null");
                return;
            }
            _toBeDeleted.Add(receiver);
	        _toBeAdded.Remove(receiver);
        }

        private static void RemoveUnregisteredReceivers()
        {
            if (_receivers == null || _depth > 0)
                return;

            foreach (var receiver in _toBeDeleted)
            {
                foreach (var type in receiver.GetType().GetInterfaces())
                {
                    if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof (IReceivesMessages<>))
                        _receivers.RemoveItem(type, receiver);
                }
            }
            _toBeDeleted.Clear();
        }

        public static void BroadcastMessage<T>(T message) where T : GameMessage
        {
            if (message == null)
            {
                Debug.LogWarning("Attempted to broadcast message but was null");
                return;
            }

            RemoveUnregisteredReceivers();
            AddRegisteredReceiver();
            var receivers = _receivers.GetItems<IReceivesMessages<T>>();

            _depth++;
            foreach (var receiver in receivers)
            {
                try
                {
                    if (receiver != null)
                        receiver.HandleMessage(message);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
            _depth--;
        }
    }
}