class Scripture
{
    List<Word> _words;
    private ScriptureReference _reference;

    public Scripture(string bookName, int chapter, int verse, string text)
    {
        _reference = new ScriptureReference(bookName, chapter, verse);
        _words = ConvertToWords(text);
    }

     public Scripture(string bookName, int chapter, int startVerse, int endVerse, string text)
    {
        _reference = new ScriptureReference(bookName, chapter, startVerse, endVerse);
        _words = ConvertToWords(text);
    }

    public void ShowScripture()
    {
        _reference.DisplayScriptureReference();
        Console.WriteLine();

        foreach(Word word in _words)
        {
            word.Display();
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHidden = 0;

        while (wordsHidden < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                wordsHidden++;
            }
        }
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

    private List<Word> ConvertToWords(string text)
    {
        List<Word> tempWords = new List<Word>();

        string[] words = text.Split(' ');
        foreach(string word in words)
        {
            Word tempWord = new Word(word);
            tempWords.Add(tempWord);
        }

        return tempWords;
    }
}