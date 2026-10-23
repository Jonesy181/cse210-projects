class ScriptureReference
{
    private string _bookName;
    private int _chapter;
    private int[] _verse;

    public ScriptureReference(string name, int chapter, int verse)
    {
        _bookName = name;
        _chapter = chapter;
        _verse = new int[] { verse };
    }

    public ScriptureReference(string name, int chapter, int startVerse, int endVerse)
    {
        _bookName = name;
        _chapter = chapter;
        _verse = new int[] { startVerse, endVerse };
    }

    public void DisplayScriptureReference()
    {
        Console.Write(GetScriptureReference());
    }

    public string GetScriptureReference()
    {
      return GetScriptureReferenceString();
    }

    private string GetScriptureReferenceString()
    {
        if (_verse.Length == 1)
      {
        return $"{_bookName} {_chapter}:{_verse[0]}";
      }

      return $"{_bookName} {_chapter}:{_verse[0]}-{_verse[1]}";
    }
}