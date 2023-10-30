namespace task2;

interface IParent
{
    string Info();
    float Square();
    float Value();
}

class Child1 : IParent
{
    float pole1, pole2, pole3;

    public Child1(float pole1, float pole2, float pole3)
    {
        this.pole1 = pole1;
        this.pole2 = pole2;
        this.pole3 = pole3;
    }

    public string Info()
    {
        return $"Паралелепіпед: a = {pole1:F3}, b = {pole2:F3}, c = {pole3:F3}";
    }

    public float Square()
    {
        return 2 * (pole1 * pole2 + pole2 * pole3 + pole3 * pole1);
    }

    public float Value()
    {
        return pole1 * pole2 * pole3;
    }
}

class Child2 : IParent
{
    float pole4, pole5;

    public Child2(float pole4, float pole5)
    {
        this.pole4 = pole4;
        this.pole5 = pole5;
    }

    public string Info()
    {
        return $"Конус: R = {pole4:F3}, h = {pole5:F3}";
    }

    public float Square()
    {
        return (float)Math.PI * pole4 * (pole4 + (float)Math.Sqrt(pole4*pole4 + pole5*pole5));
    }

    public float Value()
    {
        return ((float)Math.PI * pole4*pole4 * pole5) / 3f;
    }
}

class Child3 : IParent
{
    float pole6;

    public Child3(float pole6)
    {
        this.pole6 = pole6;
    }

    public string Info()
    {
        return $"Куля: R = {pole6:F3}";
    }

    public float Square()
    {
        return 4 * (float)Math.PI * pole6 * pole6;
    }

    public float Value()
    {
        return ( 4 * (float)Math.PI * pole6 * pole6 * pole6 ) / 3f;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IParent o;
        Random rnd = new Random();

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine();

            int fig = rnd.Next(1, 9);
            if (fig >= 1 && fig < 3)
            {
                o = new Child1(
                    rnd.NextSingle() * rnd.Next(1, 10),
                    rnd.NextSingle() * rnd.Next(1, 10),
                    rnd.NextSingle() * rnd.Next(1, 10)
                    );
            }else if (fig >= 3 && fig < 6)
            {
                o = new Child2(
                    rnd.NextSingle() * rnd.Next(1, 10),
                    rnd.NextSingle() * rnd.Next(1, 10)
                    );
            }else
            {
                o = new Child3(
                    rnd.NextSingle() * rnd.Next(1, 10)
                    );
            }

            Console.WriteLine(o.Info());
            Console.WriteLine($"S = {o.Square():F3}, V = {o.Value():F3}");
        }
    }
}

