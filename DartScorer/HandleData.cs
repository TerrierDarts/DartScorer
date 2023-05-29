using DartSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;

namespace DartScorer
{
    internal class HandleData
    {

        public static bool DartData(string name, int score)
        {
            string filePath = "./data.json";
            if (!File.Exists(filePath))
            {
                // Create the file if it doesn't exist
                File.WriteAllText(filePath, "{}");
                string jsonString = File.ReadAllText(filePath);
                JObject data = JObject.Parse(jsonString);
                data["player"] = name;
                data["startingScore"] = score;
                string updatedJsonString = data.ToString();
                File.WriteAllText(filePath, updatedJsonString);
            }
            return true;
        }

        public static int Get180Count()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["c180"] != null ? (int)data["c180"] : 0;
            return count;

        }

        public static int Get170Count()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["c170"] != null ? (int)data["c170"] : 0;
            return count;
        }

        public static int Get140Count()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["c140"] != null ? (int)data["c140"] : 0;
            return count;
        }

        public static int Get100Count()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["c100"] != null ? (int)data["c100"] : 0;
            return count;
        }

        public static double GetAverage()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            double count = data["average"] != null ? (double)data["average"] : 0;
            return count;
        }

        public static int GetDartsThrown()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["dartsThrown"] != null ? (int)data["dartsThrown"] : 0;
            return count;
        }

        public static int GetRemainingScore()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            int count = data["remaining"] != null ? (int)data["remaining"] : 100001;
            return count;

        }

        public static bool HandleScore(int score)
        {
            string filePath = "./data.json";

            string jsonString = File.ReadAllText(filePath);

            JObject data = JObject.Parse(jsonString);
            int count180 = data["c180"] != null ? (int)data["c180"] : 0;
            int count170 = data["c170"] != null ? (int)data["c170"] : 0;
            int count140 = data["c140"] != null ? (int)data["c140"] : 0;
            int count100 = data["c100"] != null ? (int)data["c100"] : 0;
            int starting = data["startingScore"] != null ? (int)data["startingScore"] : 100001;
            if (score == 180)
            {
                
                count180 += 1;
                
            }
            if (score > 169 && score < 180)
            {
                
                count170 += 1;
                

            }
            if (score > 139 && score < 170)
            {
                
                count140 += 1;
                
            }
            if(score > 99 && score < 140)
            {
                
                count100 += 1;
                
            }
           double totalScored = data["totalScored"] != null ? (double)data["totalScored"] : 0;
           double dartsThrown = data["dartsThrown"] != null ? (double)data["dartsThrown"] : 0;
            data["c180"] = count180;
            data["c170"] = count170;
            data["c140"] = count140;
            data["c100"] = count100;
            data["totalScored"] = totalScored + score;
            data["dartsThrown"] = dartsThrown + 3;
            double averageF = (totalScored + score) / ((dartsThrown + 3) / 3);
            string averageS = averageF.ToString("F2");
            data["average"] = Convert.ToDouble(averageS);
            data["lastScore"] = score;
            data["previousScores"] = UndoScore.AddLastScore(score);
            data["remaining"] =  starting - totalScored - score;

            Debug.WriteLine((totalScored + score) / ((dartsThrown + 3) / 3));
            Debug.WriteLine(data["average"]);
            string updatedJsonString = data.ToString();
            File.WriteAllText(filePath, updatedJsonString);
            WebSocketServerHelper.SendMessage(updatedJsonString);

            return true;
        }
    }
}
