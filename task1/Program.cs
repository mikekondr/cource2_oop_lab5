namespace task1
{

    public abstract class Parent
    {
        public abstract string Info();

        public abstract float Method();
    }

    public class Child1 : Parent
    {
        float pole1, pole2;

        public Child1(float pole1, float pole2)
        {
            this.pole1 = pole1;
            this.pole2 = (float)Math.Round(pole2, 2);
        }

        public override string Info()
        {
            return $"Дохід: {pole1:F2}, податок: {pole2:F2}";
        }

        public override float Method()
        {
            return (float)Math.Round(pole1 * pole2 / 100, 2);
        }
    }

    public class Child2 : Parent
    {
        float pole3, pole4, pole5, pole6;

        public Child2(float pole3, float pole4, float pole5, float pole6)
        {
            this.pole3 = pole3;
            this.pole4 = pole4;
            this.pole5 = pole5;
            this.pole6 = (float)Math.Round(pole6, 2);
        }

        public override string Info()
        {
            return $"Виручка: {pole3:F2}, собівартість: {pole4:F2}, " +
                $"дод.витрати: {pole5:F2}, ставка податку: {pole6:F2}";
        }

        public override float Method()
        {
            float sum = (float)Math.Round((pole3 - pole4 - pole5) * pole6 / 100, 2);
            return (sum >= 0) ? sum : 0;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();

                if (rnd.Next(1, 100) <= 50)
                {
                    Child1 o = new Child1(
                        rnd.Next(1, 100000),
                        rnd.NextSingle() * rnd.Next(0, 100)
                        );
                    Console.WriteLine(o.Info());
                    Console.WriteLine($"Сума податку: {o.Method():F2}");
                }
                else
                {
                    Child2 o = new Child2(
                        rnd.Next(1,100000),
                        rnd.Next(1,50000),
                        rnd.Next(1, 10000),
                        rnd.NextSingle() * rnd.Next(0, 100)
                        );
                    Console.WriteLine(o.Info());
                    Console.WriteLine($"Сума податку: {o.Method():F2}");
                }
            }
        }
    }
}