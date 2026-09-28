class Program
{
    static void Main()
    {
        Console.WriteLine("Hello Circle");

        Circle myCircle = new Circle();
        myCircle._radius = 10;

        double area = myCircle.GetArea();

        Console.WriteLine(area);
    }
}
