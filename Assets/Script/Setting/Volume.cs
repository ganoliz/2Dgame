using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Setting
{
    public static class Volume
    {
        private static int _bgm = 70;
        private static int _effect = 70;

        public static int VOLUME_BGM
        {
            get { return _bgm; }
            set { _bgm = value; }
        }
        public static int VOLUME_EFFECT
        {
            get { return _effect; }
            set { _effect = value; }
        }

        public static void Default()
        {
            _bgm = 70;
            _effect = 70;
        }
    }
}