using System;

namespace anything
{
    class SolvingQuadraticEquation
    {
        static void Main()
        {
            Console.WriteLine("Hello Wadood!");
            Console.WriteLine("To solve quadratic equation aX2 + bX + c");
            Console.WriteLine("Please enter the values of a,b,c");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Solving quadratic equation {a}X2 + {b}X + {c}");
            double D = (b*b) - (4*a*c);
            double formula = Math.Sqrt(D);
            if(D == 0)
            {
                double x = (-b)/(2*a);
                Console.WriteLine($"The double root of the quadratic equation {a}X2 + {b}X + {c} is {x}");
            }
            if (D > 0)
            {
                double x1 =((-b) + formula)/(2*a);
                double x2 =((-b) - formula)/(2*a);
                Console.WriteLine($"The roots of the quadratic equation " +
                " {a}X2 + {b}X + {c} are {x1} and {x2}");
            }
            if(D < 0)
            {
                Console.WriteLine($"The quadratic equation {a}X2 + {b}X + {c} " +
                "has no real roots");
            }
        }
    }
}
