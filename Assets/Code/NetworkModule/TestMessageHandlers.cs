using System;
using Code.BaseUtils;
using Riptide;
using UnityEngine;

namespace Code.NetworkModule
{
    public class TestMessageHandlers 
    {
        [MessageHandler((ushort) MessageType.Test)]
        private static void HandleSomeMessageFromServer(Message message)
        {
            var strTest = message.GetString();
            var intTest = message.GetInt();
            var floatTest = message.GetFloat();

            Debug.LogError($"From Server: {strTest} | {intTest} | {floatTest}");
        }
    }
}