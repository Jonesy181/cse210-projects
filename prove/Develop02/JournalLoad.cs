using System;
using System.Collections.Generic;
using System.IO;

class JournalLoader
{
    public List<JournalEntry> LoadJournal()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        // Add .txt to the filename
        filename = filename + ".txt";

        List<JournalEntry> entries = new List<JournalEntry>();

        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string date = reader.ReadLine();
                string prompt = reader.ReadLine();
                string response = reader.ReadLine();

                // Read the blank line between entries
                reader.ReadLine();

                JournalEntry entry = new JournalEntry();

                entry._date = date;
                entry._prompt = prompt;
                entry._response = response;

                entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded successfully!");

        return entries;
    }
}