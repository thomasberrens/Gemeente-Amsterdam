[System.Serializable]
public class Choice {
    public bool IsCorrect { get; set; }
    public string Text { get; set; } 
   

    public Choice(bool isCorrect, string text) {
        IsCorrect = isCorrect;
        Text = text;
    }
}
