# DartScorer


Welcome to Version 1 of This Dart Scorer Websocket.

Few Things to Note. 

If you want to change the name and starting score you will need to press new game for those changes to take effect.

The undo will only go back 10 scorer (previous scores also only remembers the last 10)

the websocket is addressed at `ws://127.0.0.1:5010/`

and example for the websocket can be found here https://codepen.io/terrierdarts/pen/VwENXZX

This can also be used this a program like https://streamer.bot 

This c# code shows how you can use that to trigger an action in this case "180 Party" when you hit a 180.

```cs
using System;
using Newtonsoft.Json.Linq;

public class CPHInline
{
	public bool Execute()
	{
		string data = args["message"].ToString();
		var darts = JObject.Parse(data);
		int score = Convert.ToInt32(darts["lastScore"]);
		if(score == 180)
		{
		CPH.RunAction("180 Party");	
		}
		return true;
	}
}
```

This is how the data is stored.

```json
{
  "player": "TerrierDarts",
  "startingScore": 100001,
  "c180": 0,
  "c170": 0,
  "c140": 0,
  "c100": 0,
  "totalScored": 0,
  "dartsThrown": 0,
  "average": 0,
  "lastScore": 0,
  "previousScores": [],
  "remaining": 100001
}
```

# MORE EXAMPLES

### Codepen HTML Overlay by TerrierDarts = https://codepen.io/terrierdarts/pen/poxXaNK?editors=0011
