using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    public static class StageUtils
    {
        public static float Offset_Wall = 1.5f;
        public static float Offset_Plat_x = 1.5f;
        public static float Offset_Plat_y = 0.5f;

        public static void CreateStage(Stage stage)
        {
            if(stage.Rooms.Count > 0)
            {
                GameObject Stage = CreateNewRoomObj("Stage", Vector3.zero);
                foreach (Room room in stage.Rooms)
                {
                    GameObject roomObj = CreateRoom(room);
                    roomObj.transform.parent = Stage.transform;
                }
            }
        }

        private static GameObject CreateRoom(Room room)
        {
            GameObject roomObj = CreateNewRoomObj(room.RoomName, room.RoomPos);
            roomObj.tag = "Room";
            roomObj.layer = 11;
            roomObj.AddComponent<BoundaryTrigger>();
            BoxCollider2D BC2D = roomObj.AddComponent<BoxCollider2D>();
            BC2D.isTrigger = true;
            BC2D.size = new Vector2(room.RoomSize.x, room.RoomSize.y) * Offset_Wall;
            BC2D.offset = new Vector2(room.RoomSize.x - 1, room.RoomSize.y - 1) * Offset_Wall / 2;
            

            CreateRoomBlocks(roomObj, room.RoomBlocks, room.RoomSize);
            CreatePlatforms(roomObj, room.Platforms);
            CreateObjects(roomObj, room.Objects);
            return roomObj;
        }

        private static GameObject CreateNewRoomObj(string name, Vector3 pos)
        {
            GameObject obj = new GameObject();
            obj.transform.position = pos * Offset_Wall;
            obj.name = name;
            return obj;
        }

        private static void CreateRoomBlocks(GameObject parent, List<List<RoomBlock>> roomBlocks, Vector2 size)
        {
            foreach(var RB in roomBlocks)
            {
                int y = roomBlocks.IndexOf(RB);
                foreach (var rb in RB)
                {
                    int x = RB.IndexOf(rb);
                    int index = rb.BlockType;

                    if(index != -1)
                    {
                        string ObjName = "Wall_" + index.ToString();

                        GameObject tempWall = PublicObj.Template.GetGameobject(ObjName);
                        Vector3 pos = new Vector3(x * Offset_Wall, y * Offset_Wall, 0) + parent.transform.position;
                        GameObject wall = MonoBehaviour.Instantiate(tempWall, pos, Quaternion.identity);
                        wall.transform.parent = parent.transform;
                    }
                }
            }
        }

        private static void CreatePlatforms(GameObject parent, List<Platform> platforms)
        {
            foreach(Platform platform in platforms)
            {
                GameObject tempPlatform = PublicObj.Template.GetGameobject(platform.PlatformName);
                Vector3 pos = new Vector3(platform.pos.x, platform.pos.y, 0) + parent.transform.position;
                GameObject Obj = MonoBehaviour.Instantiate(tempPlatform, pos, Quaternion.identity);
                Obj.transform.parent = parent.transform;
            }
        }

        private static void CreateObjects(GameObject parent, List<Object> objects)
        {
            List<GameObject> Objects = new List<GameObject>();
            foreach(Object obj in objects) {
                GameObject tempObj = PublicObj.Template.GetGameobject(obj.ObjectName);
                Vector3 pos = new Vector3(obj.pos.x, obj.pos.y, 0) + parent.transform.position;
                GameObject Obj = MonoBehaviour.Instantiate(tempObj, pos, Quaternion.identity);
                Obj.transform.parent = parent.transform;
                Objects.Add(Obj);
            }

            foreach(Object giver in objects)
            {
                if(giver.objectType == Object.ObjectType.giver)
                {
                    int giverIndex = objects.IndexOf(giver);
                    foreach (Object getter in objects)
                    {
                        if(getter.objectType == Object.ObjectType.getter && giver.connectID == getter.connectID)
                        {
                            int getterIndex = objects.IndexOf(getter);
                            Objects[giverIndex].GetComponent<Sensor>().LaserObjs.Add(Objects[getterIndex]);
                        }
                    }
                }
            }
        }
    }
}