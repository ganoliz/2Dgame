using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage
{
    public class Stage1
    {
        Stage stage = new Stage();
        int[,] RoomBlocks1 = new int[,] { 
            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
            { 14, 12, 14, 12, -1, 14, 14, 12, -1, -1 },  
            { -1, 13, 13, 13, -1, -1, 13, 13, -1, 13 },
            { 13, -1, -1, 13, -1, -1, 13, 13, 13, -1 },
            { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 } 
        };

        int[,] RoomBlocks2 = new int[,]
        { 
            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
            { 14, 12, 12, -1, -1, 14, 14, 12, -1, -1 },
            { -1, -1, -1, 13, -1, -1, -1, 13, -1, 13 },
            { 13, -1, 13, 13, -1, -1, 13, 13, 13, -1 },
            { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }
        };

        int[,] RoomBlocks3 = new int[,]
        {
            { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
            { 14, 12, 14, 12, -1, 14, 14, 12, -1, 12, 12, -1, 14, -1, 12},
            { 13, -1, -1, 13, -1, 13, 13, -1, -1, -1, 13, 13, -1, -1, -1},
            { -1, 13, -1, 13, 13, -1, -1, 13, 13, 13, -1, -1, 13, -1, -1},
            { 13, 13, -1, -1, -1, 13, 13, 13, -1, -1, 13, 13, -1, 13, -1},
            { 13, 13, -1, 13, -1, 13, -1, 13, -1, 13, -1, -1, -1, -1, -1},
            { 13, 13, 13, -1, -1, 13, -1, 13, 13, 13, 13, 13, 13, 13, -1},
            { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5}
        };

        public Stage GetStage()
        {
            CreateStage();
            return stage;
        }

        private void CreateStage()
        {
            Room room1 = new Room("Room1", 0, 0, 10, 5);
            room1.SetRoomBlocks(RoomBlocks1);

            for(int i = 0; i < 11; i++)
            {
                room1.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall), "PL_10");
                room1.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4), "PL_3");
            }
            room1.SetObject(new Vector2(2f, 1.5f), "Sensor", 0, 0);
            room1.SetObject(new Vector2(3.5f, 2.0f), "Box_0");
            room1.SetObject(new Vector2(5.0f, 5.2f), "Laser_0", 1, 0);

            room1.SetObject(new Vector2(6f, 1.5f), "Sensor", 0, 1);
            room1.SetObject(new Vector2(7.5f, 2.0f), "Box_1");
            room1.SetObject(new Vector2(9.0f, 5.2f), "Laser_1", 1, 1);

            room1.SetObject(new Vector2(10f, 1.5f), "Sensor", 0, 2);
            room1.SetObject(new Vector2(13f, 5.2f), "Laser_1", 1, 2);

            room1.SetObject(new Vector2(-0.5f, 1f), "wall");
            room1.SetObject(new Vector2(-0.5f, 1.5f), "wall");
            room1.SetObject(new Vector2(-0.5f, 3f), "wall");
            room1.SetObject(new Vector2(-0.5f, 4.5f), "wall");

            stage.Rooms.Add(room1);

            Room room2 = new Room("Room2", 10, 0, 10, 5);
            room2.SetRoomBlocks(RoomBlocks2);

            for (int i = 0; i < 11; i++)
            {
                room2.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall), "PL_10");
                room2.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4), "PL_3");
            }
            room2.SetObject(new Vector2(2f, 1.5f), "Sensor", 0, 0);
            room2.SetObject(new Vector2(3.5f, 2.0f), "Box_0");
            room2.SetObject(new Vector2(5.0f, 5.2f), "Laser_0", 1, 0);

            room2.SetObject(new Vector2(6f, 1.5f), "Sensor", 0, 1);
            room2.SetObject(new Vector2(9.0f, 5.2f), "Laser_1", 1, 1);

            room2.SetObject(new Vector2(10f, 1.5f), "Sensor", 0, 2);
            room2.SetObject(new Vector2(13f, 5.2f), "Laser_1", 1, 2);

            stage.Rooms.Add(room2);

            Room room3 = new Room("Room3", 20, 0, 10, 5);
            room3.SetRoomBlocks(RoomBlocks1);

            for (int i = 0; i < 11; i++)
            {
                room3.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall), "PL_10");
                room3.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4), "PL_3");
            }
            room3.SetObject(new Vector2(2f, 1.5f), "Sensor", 0, 0);
            room3.SetObject(new Vector2(3.5f, 2.0f), "Box_0");
            room3.SetObject(new Vector2(5.0f, 5.2f), "Laser_0", 1, 0);

            room3.SetObject(new Vector2(6f, 1.5f), "Sensor", 0, 1);
            room3.SetObject(new Vector2(7.5f, 2.0f), "Box_1");
            room3.SetObject(new Vector2(9.0f, 5.2f), "Laser_1", 1, 1);

            room3.SetObject(new Vector2(13f, 5.2f), "Laser_1", 1, 0);

            stage.Rooms.Add(room3);

            Room room4 = new Room("Room4", 30, 0, 15, 8);
            room4.SetRoomBlocks(RoomBlocks3);

            for (int i = 0; i < 16; i++)
            {
                room4.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall), "PL_10");
             //   room4.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4), "PL_3");
            }

            for (int i = 4; i < 16; i++)
            {
                room4.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 3), "PL_10");
            }

            for (int i = 0; i < 16; i++)
            {
                room4.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall* 7) , "PL_10");
            }
            room4.SetPlatform(new Vector2(2f, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 2f), "PL_3");
            room4.SetPlatform(new Vector2(10f, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4.5f), "PL_3");
            room4.SetPlatform(new Vector2(12.5f, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 5.5f), "PL_3");

            for (int i = 11; i < 16; i++)
            {
                room4.SetPlatform(new Vector2(i * StageUtils.Offset_Plat_x - StageUtils.Offset_Plat_x / 2, (StageUtils.Offset_Plat_y - StageUtils.Offset_Wall) / 2 + StageUtils.Offset_Wall * 4.5f), "PL_3");
            }

            room4.SetObject(new Vector2(10, 5f), "Box_0");
            room4.SetObject(new Vector2(12.5f, 8.5f), "Box_1");
            room4.SetObject(new Vector2(20.8f, 6.5f), "Box_0");

            room4.SetObject(new Vector2(11.8f, 9.5f), "wall");
            room4.SetObject(new Vector2(11.8f, 8.2f), "wall");
            room4.SetObject(new Vector2(21.5f, 9f), "wall");
            room4.SetObject(new Vector2(21.5f, 8f), "wall");
            room4.SetObject(new Vector2(21.5f, 7f), "wall");
            room4.SetObject(new Vector2(21.5f, 6f), "wall");
            room4.SetObject(new Vector2(21.5f, 5f), "wall");
            room4.SetObject(new Vector2(0f, 9f), "wall");
            room4.SetObject(new Vector2(0f, 8f), "wall");
            room4.SetObject(new Vector2(0f, 7f), "wall");
            room4.SetObject(new Vector2(0f, 6f), "wall");

            room4.SetObject(new Vector2(11.7f, 4.6f), "Sensor", 0, 0);
            room4.SetObject(new Vector2(11.7f, 3.6f), "Laser_0", 1, 0);
            
            room4.SetObject(new Vector2(13.2f, 4.6f), "Sensor", 0, 1);
            room4.SetObject(new Vector2(13.2f, 3.6f), "Laser_1", 1, 1);
            
            room4.SetObject(new Vector2(14.7f, 4.6f), "Sensor", 0, 2);
            room4.SetObject(new Vector2(14.7f, 3.6f), "Laser_0", 1, 2);
            
            room4.SetObject(new Vector2(10f, 6.8f), "Sensor", 0, 3);
            room4.SetObject(new Vector2(12.45f, 7.25f), "Laser_0", 1, 3);
            
            room4.SetObject(new Vector2(17.5f, 6.8f), "Sensor", 0, 4);
            room4.SetObject(new Vector2(19.5f, 9.68f), "Laser_1", 1, 4);

            stage.Rooms.Add(room4);
        }
    }
}
