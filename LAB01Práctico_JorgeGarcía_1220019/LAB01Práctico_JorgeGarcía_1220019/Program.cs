using System;

namespace LAB01Práctico_JorgeGarcía_1220019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingresar una expresión algebraica");
            string ExpAlg =  Console.ReadLine();
            Parser parser = new Parser();
            float result = parser.Parse(ExpAlg);
            Console.WriteLine("El resultado es " + Convert.ToString(result));
            Console.ReadLine();

        }
    }
}
