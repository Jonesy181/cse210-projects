using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Paleontologist";
        job1._company = "Royal Tyerrell Museum of Paleontology";
        job1._startYear = 2020;
        job1._endYear = 2026;

        Job job2 = new Job();
        job2._jobTitle = "Electrical Engineer";
        job2._company = "Rocky Mountain Power";
        job2._startYear = 2016;
        job2._endYear = 2020;

        Resume myResume = new Resume();
        myResume._name = "Jason Jones";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}