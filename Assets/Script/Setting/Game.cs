using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setting
{
    public static class Game
    {
        private static int _stageIndex = 0;
        private static string _currentRoom = "";

        public static int STAGEINDEX
        {
            get { return _stageIndex; }
            set { _stageIndex = value; }
        }

        public static string CURRENTROOM
        {
            get { return _currentRoom; }
            set { _currentRoom = value; }
        }
    }
}
