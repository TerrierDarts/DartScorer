using DartSocket;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Windows.Documents;
using static System.Formats.Asn1.AsnWriter;

namespace DartScorer
{
    internal class UndoScore
    {
        public static JArray GetLastScores()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            JArray previousScores = data["previousScores"] != null ? (JArray)data["previousScores"] : new JArray();
            return previousScores;
        }

        public static string LastScore()
        {
            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            JArray previousScores = data["previousScores"] != null ? (JArray)data["previousScores"] : new JArray();
            string score;
            if(previousScores.Count == 0 )
            {
                score = "";
            }
            else
            {
                score= previousScores[previousScores.Count - 1].ToString();
            }
            return score;
        }

        public static bool RemoveLastScore()
        {
            string filePath = "./data.json";

            string jsonString = File.ReadAllText(filePath);
            int score;
            if (int.TryParse(LastScore(), out score))
                {
                JObject data = JObject.Parse(jsonString);
                int count180 = data["c180"] != null ? (int)data["c180"] : 0;
                int count170 = data["c170"] != null ? (int)data["c170"] : 0;
                int count140 = data["c140"] != null ? (int)data["c140"] : 0;
                int count100 = data["c100"] != null ? (int)data["c100"] : 0;
                int starting = data["startingScore"] != null ? (int)data["startingScore"] : 100001;
                if (score == 180)
                {

                    count180 -= 1;

                }
                if (score > 169 && score < 180)
                {

                    count170 -= 1;


                }
                if (score > 139 && score < 170)
                {

                    count140 -= 1;

                }
                if (score > 99 && score < 140)
                {

                    count100 -= 1;

                }
                double totalScored = data["totalScored"] != null ? (double)data["totalScored"] : 0;
                double dartsThrown = data["dartsThrown"] != null ? (double)data["dartsThrown"] : 0;
                data["c180"] = count180;
                data["c170"] = count170;
                data["c140"] = count140;
                data["c100"] = count100;
                data["totalScored"] = totalScored - score;
                data["dartsThrown"] = dartsThrown - 3;
                double averageF = (totalScored - score) / ((dartsThrown - 3) / 3);
                string averageS = averageF.ToString("F2");
                data["average"] = Convert.ToDouble(averageS);
                data["lastScore"] = score;
                data["previousScores"] = UndoScore.RemoveArrayScore();
                data["remaining"] = starting - totalScored + score;

                Debug.WriteLine((totalScored - score) / ((dartsThrown - 3) / 3));
                Debug.WriteLine(data["average"]);
                string updatedJsonString = data.ToString();
                File.WriteAllText(filePath, updatedJsonString);
                WebSocketServerHelper.SendMessage(updatedJsonString);
            }
            return true;
        }

        public static JArray AddLastScore(int score) {

            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            JArray previousScores= data["previousScores"] != null ? (JArray)data["previousScores"] : new JArray();
            while(previousScores.Count > 9) {
                previousScores.RemoveAt(0);
                    }
            previousScores.Add(score);
            return previousScores; 
        
        }
        public static JArray RemoveArrayScore()
        {

            string filePath = "./data.json";
            // Read the JSON data from the file
            string jsonString = File.ReadAllText(filePath);
            JObject data = JObject.Parse(jsonString);
            JArray previousScores = data["previousScores"] != null ? (JArray)data["previousScores"] : new JArray();
            if (previousScores.Count > 0)
            {
                previousScores.RemoveAt(previousScores.Count-1);
            }
            return previousScores;

        }
    }
}
