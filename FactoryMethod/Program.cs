public abstract class Subscription
{
    public abstract decimal MonthlyFee { get; }
    public abstract int MinPeriodMonths { get; }
    public abstract List<string> Channels { get; }
    public string CreatedBy { get; set; }

    public void PrintDetails()
    {
        Console.WriteLine(this.GetType().Name);
        Console.WriteLine($"Спосіб придбання: {CreatedBy}");
        Console.WriteLine($"Щомісячна плата: {MonthlyFee} грн");
        Console.WriteLine($"Мін. період: {MinPeriodMonths} міс.");
        Console.WriteLine($"Канали: {string.Join(", ", Channels)}");
        Console.WriteLine();
    }
}

public class DomesticSubscription : Subscription
{
    public override decimal MonthlyFee => 150.00m;
    public override int MinPeriodMonths => 1;
    public override List<string> Channels => new List<string> { "Новини", "Кіно", "Мультфільми" };
}

public class EducationalSubscription : Subscription
{
    public override decimal MonthlyFee => 80.00m;
    public override int MinPeriodMonths => 3;
    public override List<string> Channels => new List<string> { "Discovery", "History", "National Geographic", "TED" };
}

public class PremiumSubscription : Subscription
{
    public override decimal MonthlyFee => 400.00m;
    public override int MinPeriodMonths => 1;
    public override List<string> Channels => new List<string> { "Всі канали", "4K Cinema", "Спорт HD", "HBO" };
}

public abstract class SubscriptionPurchaseChannel
{
    public abstract Subscription CreateSubscription(string type);

    public Subscription Purchase(string type)
    {
        var sub = CreateSubscription(type);
        sub.CreatedBy = this.GetType().Name;
        return sub;
    }
}

public class WebSite : SubscriptionPurchaseChannel
{
    public override Subscription CreateSubscription(string type)
    {
        return type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невідомий тип підписки")
        };
    }
}

public class MobileApp : SubscriptionPurchaseChannel
{
    public override Subscription CreateSubscription(string type)
    {
        return type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невідомий тип підписки")
        };
    }
}

public class ManagerCall : SubscriptionPurchaseChannel
{
    public override Subscription CreateSubscription(string type)
    {
        return type.ToLower() switch
        {
            "domestic" => new DomesticSubscription(),
            "educational" => new EducationalSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невідомий тип підписки")
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SubscriptionPurchaseChannel web = new WebSite();
        SubscriptionPurchaseChannel mobile = new MobileApp();
        SubscriptionPurchaseChannel manager = new ManagerCall();

        var sub1 = web.Purchase("premium");
        var sub2 = mobile.Purchase("educational");
        var sub3 = manager.Purchase("domestic");

        sub1.PrintDetails();
        sub2.PrintDetails();
        sub3.PrintDetails();
    }
}