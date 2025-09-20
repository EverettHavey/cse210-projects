// _reference : Reference
// _words :List<Word>

// Scripture(Reference : Reference, text : string)

// HideRandomWords(numberToHide : int) :void
// GetDisplayText() : string
// IsCompletelyHidden() : bool

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        string[] wordArray = text.Split(' ');
        foreach (string wordText in wordArray)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;

        var unhiddenWords = _words.Where(word => !word.IsHidden()).ToList();

        while (wordsHidden < numberToHide && unhiddenWords.Count > 0)
        {
            int randomIndex = random.Next(unhiddenWords.Count);
            unhiddenWords[randomIndex].Hide();
            unhiddenWords.RemoveAt(randomIndex);
            wordsHidden++;
        }
    }
    public string GetDisplayText()
    {
        System.Text.StringBuilder displayText = new System.Text.StringBuilder();
        displayText.Append(_reference.GetDisplayText());

        foreach (Word word in _words)
        {
            displayText.Append(" " + word.GetDisplayText());
        }
        return displayText.ToString();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}