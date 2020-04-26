using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setting
{
    public static class Keys
    {
        private static KeyCode _up = KeyCode.UpArrow;
        private static KeyCode _down = KeyCode.DownArrow;
        private static KeyCode _left = KeyCode.LeftArrow;
        private static KeyCode _right = KeyCode.RightArrow;
        private static KeyCode _jump = KeyCode.Z;
        private static KeyCode _ability = KeyCode.X;
        private static KeyCode _changeMode = KeyCode.LeftShift;


        public static KeyCode KEY_UP
        {
            get { return _up; }
            set { _up = value; }
        }
        public static KeyCode KEY_DOWN
        {
            get { return _down; }
            set { _down = value; }
        }
        public static KeyCode KEY_LEFT
        {
            get { return _left; }
            set { _left = value; }
        }
        public static KeyCode KEY_RIGHT
        {
            get { return _right; }
            set { _right = value; }
        }
        public static KeyCode KEY_JUMP
        {
            get { return _jump; }
            set { _jump = value; }
        }
        public static KeyCode KEY_ABILITY
        {
            get { return _ability; }
            set { _ability = value; }
        }

        public static KeyCode KEY_CHANGEMODE
        {
            get { return _changeMode; }
            set { _changeMode = value; }
        }

        public static void Default()
        {
            _up = KeyCode.UpArrow;
            _down = KeyCode.DownArrow;
            _left = KeyCode.LeftArrow;
            _right = KeyCode.RightArrow;
            _jump = KeyCode.Z;
            _ability = KeyCode.X;
            _changeMode = KeyCode.LeftShift;
        }
    }
}