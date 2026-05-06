public class Virus : ICloneable
{
    public double Weight { get; set; }
    public int Age { get; set; }
    public string Name { get; set; }
    public string Species { get; set; }
    public List<Virus> Children { get; set; }

    public Virus(double weight, int age, string name, string species)
    {
        Weight = weight;
        Age = age;
        Name = name;
        Species = species;
        Children = new List<Virus>();
    }

    public object Clone()
    {
        Virus clone = (Virus)this.MemberwiseClone();

        clone.Children = new List<Virus>();

        foreach (var child in this.Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }

        return clone;
    }

    public void PrintTree(int level = 0)
    {
        string indent = new string(' ', level * 4);
        Console.WriteLine($"{indent} {Name} (Вид: {Species}, Вік: {Age} год., Вага: {Weight} мг)");

        foreach (var child in Children)
        {
            child.PrintTree(level + 1);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Virus grandParent = new Virus(0.5, 48, "Alpha-Ancestor", "Original-Strain");

        Virus parent1 = new Virus(0.3, 24, "Beta-1", "Mutation-X");
        Virus parent2 = new Virus(0.3, 20, "Beta-2", "Mutation-X");

        parent1.Children.Add(new Virus(0.1, 5, "Gamma-1.1", "Sub-Strain-Z"));
        parent1.Children.Add(new Virus(0.1, 6, "Gamma-1.2", "Sub-Strain-Z"));
        parent2.Children.Add(new Virus(0.1, 4, "Gamma-2.1", "Sub-Strain-Y"));

        grandParent.Children.Add(parent1);
        grandParent.Children.Add(parent2);


        Console.WriteLine("ОРИГІНАЛЬНЕ СІМЕЙСТВО");
        grandParent.PrintTree();

        Virus clonedFamily = (Virus)grandParent.Clone();

        grandParent.Name = "CHANGED-ORIGINAL";
        grandParent.Children[0].Name = "MUTATED-BETA";
        grandParent.Children[0].Children.Clear();

        Console.WriteLine("\nОРИГІНАЛ ПІСЛЯ ЗМІН");
        grandParent.PrintTree();

        Console.WriteLine("\nКЛОНОВАНЕ СІМЕЙСТВО ПІСЛЯ ЗМІНИ ОРИГІНАЛУ");
        clonedFamily.PrintTree();
    }
}