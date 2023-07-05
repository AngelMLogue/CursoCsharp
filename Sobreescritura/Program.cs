using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        A a = new A();
        B b = new B();
        Console.WriteLine(b.saludar());
    }
}

public class A
    {
        public virtual string saludar()
        {
            return "Metodo A";
        }
    }

public class B : A
    {
    public override string saludar()
    {
        return base.saludar() + " Metodo B";
    }
}

