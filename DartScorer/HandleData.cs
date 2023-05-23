﻿using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DartScorer
{
    internal class HandleData
    {

        public static bool DartData()
        {
            string filePath = "/data.json";
            if (!File.Exists(filePath))
            {
                // Create the file if it doesn't exist
                File.WriteAllText(filePath, "{}");
            }
            File.WriteAllText(filePath, "{}");
            return true;
        }

        public static int Get180Count()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["180"] != null ? (int)data["180"] : 0;
            return count;

        }

        public static int Get170Count()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["170"] != null ? (int)data["170"] : 0;
            return count;
        }

        public static int Get140Count()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["140"] != null ? (int)data["140"] : 0;
            return count;
        }

        public static int Get100Count()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["100"] != null ? (int)data["100"] : 0;
            return count;
        }

        public static float GetAverage()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            float count = data["average"] != null ? (float)data["average"] : 0;
            return count;
        }

        public static int GetDartsThrown()
        {
            string filePath = "/data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["dartsThrown"] != null ? (int)data["dartsThrown"] : 0;
            return count;
        }

        public static bool HandleScore(int score)
        {
            string filePath = "/data.json";

            string jsonString = File.ReadAllText(filePath);

            JObject data = JObject.Parse(jsonString);
            if (score == 180)
            {
                int count = data["180"] != null ? (int)data["180"] : 0;
                count += 1;
                data["180"] = count;
            }
            if (score > 169 && score < 180)
            {
                int count = data["170"] != null ? (int)data["170"] : 0;
                count += 1;
                data["170"] = count;

            }
            if (score > 139 && score < 170)
            {
                int count = data["140"] != null ? (int)data["140"] : 0;
                count += 1;
                data["140"] = count;
            }
            if(score > 99 && score < 140)
            {
                int count = data["100"] != null ? (int)data["100"] : 0;
                count += 1;
                data["100"] = count;
            }
           float totalScored = data["totalScored"] != null ? (float)data["totalScored"] : 0;
           float dartsThrown = data["dartsThrown"] != null ? (float)data["dartsThrown"] : 0;
            
            data["totalScored"] = totalScored + score;
            data["dartsThrown"] = dartsThrown + 3;
            data["average"] = (totalScored+score)/((dartsThrown+3)/3);
            Debug.WriteLine((totalScored + score) / ((dartsThrown + 3) / 3));
            Debug.WriteLine(data["average"]);
            string updatedJsonString = data.ToString();
            File.WriteAllText(filePath, updatedJsonString);

            return true;
        }
    }
}
