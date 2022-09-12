using System;
namespace BootCampTrainig
{
    class riangleCalculator
    {
        static int round = -1; 
        static void Main(string[] args)
        {
            double ax, ay, bx, by, cx, cy;
            double abLength, acLength, bcLength;
            if(args.Length > 0){
                if(args[0] == "round"){
                    if(!String.IsNullOrEmpty(args[1])){
                        round = int.TryParse(args[1], out int roundValue) ? roundValue : -1;
                    } 
                }
            }
            
            Console.WriteLine("Enter coordinate x of dot A : ");
            ax = CheckUserInput(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot A : ");
            ay = CheckUserInput(Console.ReadLine());
            Console.WriteLine("Enter coordinate x of dot B : ");
            bx = CheckUserInput(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot B : ");
            by = CheckUserInput(Console.ReadLine());
            Console.WriteLine("Enter coordinate x of dot C : ");
            cx = CheckUserInput(Console.ReadLine());
            Console.WriteLine("Enter coordinate y of dot C : ");
            cy = CheckUserInput(Console.ReadLine());

            // Check if triangle exists 
            // Sum of length of any 2 sides is bigger then 3rd
            abLength = GetSideLength(ax, ay, bx, by);
            acLength = GetSideLength(ax, ay, cx, cy);
            bcLength = GetSideLength(bx, by, cx, cy);

            //Print out length of sides
            Console.WriteLine($"{Environment.NewLine} Length of AB is: '{abLength}'");
            Console.WriteLine($"{Environment.NewLine} Length of BC is: '{bcLength}'");
            Console.WriteLine($"{Environment.NewLine} Length of AC is: '{acLength}'");

            //Check if triangle is valid
            if (!(abLength + acLength > bcLength && abLength + acLength > abLength && acLength + bcLength > abLength))
            {
                Console.WriteLine($"Coordinates were provided are not valid triangle.{Environment.NewLine}Please try again and rerun the program");
                Environment.Exit(1);
            }

            //Check if triangle is Equilaterial
            string isTriangleEquilaterial = (abLength == acLength && abLength == bcLength && acLength == bcLength) ? " " : " NOT ";
            Console.WriteLine($"{Environment.NewLine} Triangle is{isTriangleEquilaterial}'EQUILATERIAL'");
            
            
            //Check if triangle is Isosceles
            string isTriangleIsosceles = (abLength == acLength || acLength == bcLength || abLength == bcLength) ? " " : " NOT ";
            Console.WriteLine($"{Environment.NewLine} Triangle is{isTriangleIsosceles}'ISOSCELES'");
            

    
            //Check if triangle is Right
            string isRightTriangle = (Math.Pow(acLength, 2).Equals(Math.Pow(abLength,2) + Math.Pow(bcLength,2))) ? " " : " NOT ";
            Console.WriteLine($"{Environment.NewLine} Triangle is{isTriangleIsosceles}'RIGHT'");
            
            
            // Perimetr
            double perimeter = acLength + bcLength + abLength;
            Console.WriteLine($"{Environment.NewLine} Perimeter: '${perimeter}'");
            

            //Even numbers
            Console.WriteLine($"{Environment.NewLine} Parity numbers in range from 0 to triangle perimeter:");
            for(double i = 0; i <= perimeter; i++){
                if(i % 2 == 0){
                    Console.WriteLine($"{i}");
                }
            }
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            var sideLength = Math.Sqrt(Math.Pow(x2 - x1, 2.0) + Math.Pow(y2 - y1, 2.0));
             if(round == -1){
                    return sideLength;
                } else {
                    return Math.Round(sideLength,round);
                }
        }

        private static double CheckUserInput(string? input)
        {
            bool success = Double.TryParse(input, out double output);
            if (success)
            {
               return output;
            }
            else {
                Console.WriteLine($"Entered value \"{input}\"  for the coordinate in not valid.{Environment.NewLine}Please try again and rerun the program");
                Environment.Exit(1);
                return 0;
            }
        }
    }
}