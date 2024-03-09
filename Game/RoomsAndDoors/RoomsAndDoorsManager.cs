using System;
using System.IO;

namespace MainGame.Managers
{
	public class RoomsAndDoorsManager
	{
        public string[] rooms;
        public static int counter { get; set; }
        public static int total { get; set; }

        public void LoadRooms()
        {
            rooms = Directory.GetFiles("../Content/CSV", "*.csv");
            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i] = "@\"" + rooms[i] + "\"";
                total = i;
            }
        }
        public string GetRoom(int i)
        {
            return rooms[i];
        }
    }
}