using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PublicObj
{
    static public class Template
    {
        static Dictionary<string, GameObject> _resourceGameobject = new Dictionary<string, GameObject>();
        static Dictionary<string, Sprite> _resourceSprite = new Dictionary<string, Sprite>();

        public static void LoadAllGameObjects(string[] files)
        {
            for (int i = 0; i < files.Length; i++)
            {
                var gameObject = Resources.LoadAll(files[i], typeof(GameObject));
                for (int j = 0; j < gameObject.Length; j++)
                {
                    _resourceGameobject[gameObject[j].name] = (GameObject)gameObject[j];
                }
            }
        }

        public static void LoadAllGameObjects()
        {
            LoadAllGameObjects(new string[] { "Prefab/Object", "Prefab/Platform", "Prefab/Wall" });
        }

        public static GameObject GetGameobject(string name)
        {
            return _resourceGameobject[name];
        }

        public static void LoadAllSprites(string[] files)
        {
            for(int i = 0; i < files.Length; i++)
            {
                var sprites = Resources.LoadAll(files[i], typeof(Sprite));
                for (int j = 0; j < sprites.Length; j++)
                {
                    _resourceSprite[sprites[j].name] = (Sprite)sprites[j];
                }
            }

        }

        public static void LoadAllSprites()
        {
            LoadAllSprites(new string[] { "Texture/Keyboard", "Texture/Object", "Texture/Platform", "Texture/Other" });
        }

        public static Sprite GetSprite(string name)
        {
            return _resourceSprite[name];
        }
    }
}
