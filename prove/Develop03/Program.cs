using System;

class Program
{
    static void Main(string[] args)
    {
        Word myWord = new Word("Bubba");
        myWord.Display();
        myWord.Hide();
        Console.WriteLine();
        myWord.Display();

        Scripture myScripture = new Scripture("Moses", 1, 39, "Behold, this is my work and my glory to bring to pass the immortality and eternal life of man.");
        Console.Clear();
        myScripture.ShowScripture();
    }
}