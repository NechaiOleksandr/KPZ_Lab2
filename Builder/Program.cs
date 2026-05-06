public class Character
{
    public string Name { get; set; }
    public string Build { get; set; }
    public int Height { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public string Clothing { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();
    public List<string> Deeds { get; set; } = new List<string>();

    public void Introduce()
    {
        Console.WriteLine(Name);
        Console.WriteLine($"Статура: {Build}, Зріст: {Height} см");
        Console.WriteLine($"Зовнішність: волосся - {HairColor}, очі - {EyeColor}");
        Console.WriteLine($"Одяг: {Clothing}");
        Console.WriteLine($"Інвентар: {string.Join(", ", Inventory)}");
        Console.WriteLine($"Історія діянь: {string.Join(", ", Deeds)}");
        Console.WriteLine();
    }
}
public interface ICharacterBuilder
{
    ICharacterBuilder SetName(string name);
    ICharacterBuilder SetBuild(string build);
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetAppearance(string hair, string eyes);
    ICharacterBuilder SetOutfit(string outfit);
    ICharacterBuilder AddToInventory(string item);
    Character BuildCharacter();
}

public class HeroBuilder : ICharacterBuilder
{
    private Character _hero = new Character();

    public HeroBuilder SetName(string name) { _hero.Name = name; return this; }
    public HeroBuilder SetBuild(string build) { _hero.Build = build; return this; }
    public HeroBuilder SetHeight(int height) { _hero.Height = height; return this; }
    public HeroBuilder SetAppearance(string hair, string eyes) { _hero.HairColor = hair; _hero.EyeColor = eyes; return this; }
    public HeroBuilder SetOutfit(string outfit) { _hero.Clothing = outfit; return this; }
    public HeroBuilder AddToInventory(string item) { _hero.Inventory.Add(item); return this; }

    public HeroBuilder AddGoodDeed(string deed)
    {
        _hero.Deeds.Add("Справа світла: " + deed);
        return this;
    }

    public Character BuildCharacter() => _hero;

    ICharacterBuilder ICharacterBuilder.SetName(string name) => SetName(name);
    ICharacterBuilder ICharacterBuilder.SetBuild(string build) => SetBuild(build);
    ICharacterBuilder ICharacterBuilder.SetHeight(int height) => SetHeight(height);
    ICharacterBuilder ICharacterBuilder.SetAppearance(string h, string e) => SetAppearance(h, e);
    ICharacterBuilder ICharacterBuilder.SetOutfit(string o) => SetOutfit(o);
    ICharacterBuilder ICharacterBuilder.AddToInventory(string i) => AddToInventory(i);
}

public class EnemyBuilder : ICharacterBuilder
{
    private Character _enemy = new Character();

    public EnemyBuilder SetName(string name) { _enemy.Name = name; return this; }
    public EnemyBuilder SetBuild(string build) { _enemy.Build = build; return this; }
    public EnemyBuilder SetHeight(int height) { _enemy.Height = height; return this; }
    public EnemyBuilder SetAppearance(string hair, string eyes) { _enemy.HairColor = hair; _enemy.EyeColor = eyes; return this; }
    public EnemyBuilder SetOutfit(string outfit) { _enemy.Clothing = outfit; return this; }
    public EnemyBuilder AddToInventory(string item) { _enemy.Inventory.Add(item); return this; }

    public EnemyBuilder AddEvilDeed(string deed)
    {
        _enemy.Deeds.Add("Темний вчинок: " + deed);
        return this;
    }

    public Character BuildCharacter() => _enemy;

    ICharacterBuilder ICharacterBuilder.SetName(string name) => SetName(name);
    ICharacterBuilder ICharacterBuilder.SetBuild(string build) => SetBuild(build);
    ICharacterBuilder ICharacterBuilder.SetHeight(int height) => SetHeight(height);
    ICharacterBuilder ICharacterBuilder.SetAppearance(string h, string e) => SetAppearance(h, e);
    ICharacterBuilder ICharacterBuilder.SetOutfit(string o) => SetOutfit(o);
    ICharacterBuilder ICharacterBuilder.AddToInventory(string i) => AddToInventory(i);
}

public class Director
{
    public void ConstructNobleKnight(HeroBuilder builder)
    {
        builder.SetName("Іван")
                .SetBuild("Атлетична")
                .SetHeight(185)
                .SetAppearance("Золотаве", "Блакитні")
                .SetOutfit("Сяючі обладунки")
                .AddToInventory("Екскалібур")
                .AddToInventory("Щит віри")
                .AddGoodDeed("Визволив королівство від дракона")
                .AddGoodDeed("Заснував притулок для сиріт");
    }

    public void ConstructDarkGladiator(EnemyBuilder builder)
    {
        builder.SetName("Темний гладіатор")
                .SetBuild("Масивна, демонічна")
                .SetHeight(210)
                .SetAppearance("Чорне як ніч", "Палаючі червоні")
                .SetOutfit("Обсидіанова броня з шипами")
                .AddToInventory("Молот пекла")
                .AddEvilDeed("Затьмарив сонце на тисячу років")
                .AddEvilDeed("Зруйнував бібліотеку мудрості");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Director director = new Director();

        var heroBuilder = new HeroBuilder();
        director.ConstructNobleKnight(heroBuilder);
        Character myHero = heroBuilder.BuildCharacter();

        var enemyBuilder = new EnemyBuilder();
        director.ConstructDarkGladiator(enemyBuilder);
        Character myEnemy = enemyBuilder.BuildCharacter();

        var dreamHero = new HeroBuilder()
            .SetName("Еліна")
            .SetBuild("Струнка")
            .SetHeight(170)
            .SetAppearance("Сріблясте", "Фіолетові")
            .SetOutfit("Мантія зоряного неба")
            .AddToInventory("Посох істини")
            .AddGoodDeed("Відновила гармонію стихій")
            .BuildCharacter();

        myHero.Introduce();
        myEnemy.Introduce();
        dreamHero.Introduce();
    }
}