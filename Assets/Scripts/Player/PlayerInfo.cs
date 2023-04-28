using System;

public class PlayerInfo
{
      public string Name { get; set; } = "";

      public string GameID { get; private set; } = Guid.NewGuid().ToString();
}
