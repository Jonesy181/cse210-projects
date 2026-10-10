using System;
using System.Collections.Generic;
using System.IO;

class JournalFile
{
    public void SaveJournal(List<JournalEntry> entries)
    {
        Console.Write("Enter a filename to save the journal: ");
        string filename = Console.ReadLine();

        // Add .txt to the filename
        filename = filename + ".txt";

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine(entry._date);
                writer.WriteLine(entry._prompt);
                writer.WriteLine(entry._response);
                writer.WriteLine();
            }
        }

        Console.WriteLine("Journal saved successfully!");
    }

}