public interface ILaptop { void GetDetails(); }
public interface INetbook { void GetDetails(); }
public interface IEBook { void GetDetails(); }
public interface ISmartphone { void GetDetails(); }

public class IProneLaptop : ILaptop { public void GetDetails() => Console.WriteLine("Laptop від IProne."); }
public class IProneNetbook : INetbook { public void GetDetails() => Console.WriteLine("Netbook від IProne."); }
public class IProneEBook : IEBook { public void GetDetails() => Console.WriteLine("EBook від IProne."); }
public class IProneSmartphone : ISmartphone { public void GetDetails() => Console.WriteLine("Smartphone від IProne."); }

public class KiaomiLaptop : ILaptop { public void GetDetails() => Console.WriteLine("Laptop від Kiaomi."); }
public class KiaomiNetbook : INetbook { public void GetDetails() => Console.WriteLine("Netbook від Kiaomi."); }
public class KiaomiEBook : IEBook { public void GetDetails() => Console.WriteLine("EBook від Kiaomi."); }
public class KiaomiSmartphone : ISmartphone { public void GetDetails() => Console.WriteLine("Smartphone від Kiaomi."); }

public class BalaxyLaptop : ILaptop { public void GetDetails() => Console.WriteLine("Laptop від Balaxy."); }
public class BalaxyNetbook : INetbook { public void GetDetails() => Console.WriteLine("Netbook від Balaxy."); }
public class BalaxyEBook : IEBook { public void GetDetails() => Console.WriteLine("EBook від Balaxy."); }
public class BalaxySmartphone : ISmartphone { public void GetDetails() => Console.WriteLine("Smartphone від Balaxy."); }

public interface ITechFactory
{
    ILaptop CreateLaptop();
    INetbook CreateNetbook();
    IEBook CreateEBook();
    ISmartphone CreateSmartphone();
}

public class IProneFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new IProneLaptop();
    public INetbook CreateNetbook() => new IProneNetbook();
    public IEBook CreateEBook() => new IProneEBook();
    public ISmartphone CreateSmartphone() => new IProneSmartphone();
}

public class KiaomiFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new KiaomiLaptop();
    public INetbook CreateNetbook() => new KiaomiNetbook();
    public IEBook CreateEBook() => new KiaomiEBook();
    public ISmartphone CreateSmartphone() => new KiaomiSmartphone();
}

public class BalaxyFactory : ITechFactory
{
    public ILaptop CreateLaptop() => new BalaxyLaptop();
    public INetbook CreateNetbook() => new BalaxyNetbook();
    public IEBook CreateEBook() => new BalaxyEBook();
    public ISmartphone CreateSmartphone() => new BalaxySmartphone();
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Виробництво IProne:");
        ITechFactory iproneFactory = new IProneFactory();
        var phone1 = iproneFactory.CreateSmartphone();
        var laptop1 = iproneFactory.CreateLaptop();
        phone1.GetDetails();
        laptop1.GetDetails();

        Console.WriteLine("\nВиробництво Kiaomi:");
        ITechFactory kiaomiFactory = new KiaomiFactory();
        var phone2 = kiaomiFactory.CreateSmartphone();
        var ebook2 = kiaomiFactory.CreateEBook();
        phone2.GetDetails();
        ebook2.GetDetails();

        Console.WriteLine("\nВиробництво Balaxy:");
        ITechFactory balaxyFactory = new BalaxyFactory();
        var netbook3 = balaxyFactory.CreateNetbook();
        netbook3.GetDetails();
    }
}