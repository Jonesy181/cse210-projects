using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Menu myMenu = new Menu();

        int response = 0;
        List<JournalEntry> entries = new List<JournalEntry>();

        while (response != 5)
        {
            response = myMenu.ProcessMenu();

            switch (response)
            {
                case 1:
                    Console.WriteLine("Create");

                    JournalEntry newEntry = new JournalEntry();
                    newEntry.CreateJournalEntry();

                    entries.Add(newEntry);
                    break;

                case 2:
                    Console.WriteLine("Display");

                    foreach (JournalEntry entry in entries)
                    {
                        entry.DisplayEntry();
                    }
                    break;

                case 3:
                    Console.WriteLine("Save");

                    JournalFile journalFile = new JournalFile();
                    journalFile.SaveJournal(entries);
                    break;

                case 4:
                    Console.WriteLine("Load");

                    JournalLoader loader = new JournalLoader();
                    entries = loader.LoadJournal();

                    foreach (JournalEntry entry in entries)
                        {
                            entry.DisplayEntry();
                        }

                    break;
            }
        }
    }
}