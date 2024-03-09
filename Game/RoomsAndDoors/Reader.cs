using System;
using MainGame.Rooms;
using Microsoft.VisualBasic.FileIO;

namespace MainGame.RoomsAndDoors
{
	public class Reader
	{
        public (string room_type, string[] doors, string[][] roomArray) read (string file_name)
        {
            string room_type;
            string[] doors = new string[4];
            string[][] roomArray = new string[9][];

            using (TextFieldParser textFieldParser = new TextFieldParser(file_name))
            {
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(",");

                //First row: Room type
                string[] first_row = textFieldParser.ReadFields();
                room_type = first_row[0];

                //Second row: The 4 Doors
                doors = textFieldParser.ReadFields();

                //Third to Ninth row: The playable room
                roomArray = new string[9][];
                int row = 0;
                while (!textFieldParser.EndOfData)
                {
                    roomArray[row] = textFieldParser.ReadFields();
                    row++;
                }

            }
            return (room_type, doors, roomArray);
        }
    }
}
