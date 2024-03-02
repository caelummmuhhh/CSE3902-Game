using System;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;

namespace MainGame.Managers
{
	public class RoomsAndDoorsManager
	{
        public string[] rooms;
        public static int total { get; set; }

        public void LoadRooms()
        {
            rooms = Directory.GetFiles("../../../Content/Rooms", "*.csv");
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = "@\"../../../../../Content/Rooms" + rooms[i];
            }
            total = rooms.Count();
        }
        public string GetRoom(int i)
        {
            return rooms[i];
        }
    }
}