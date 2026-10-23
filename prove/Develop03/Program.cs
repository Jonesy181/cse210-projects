using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture myScripture = new Scripture("Moses", 1, 39, "Behold, this is my work and my glory to bring to pass the immortality and eternal life of man.");

        while (true)
        {
            Console.Clear();
            myScripture.ShowScripture();

            if (myScripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue or type quit: ");
            string input = Console.ReadLine() ?? "";

            if (input == "quit")
            {
                break;
            }

            if (input == "")
            {
                myScripture.HideRandomWords(1);
            }
        }
    }
}