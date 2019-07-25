using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    public enum Heading { N, E, S, W };


    public class Rover
    {
        int xpos = 0;
        int ypos = 0;
        int xmax = 0;
        int ymax = 0;

        Heading head = 0;

        public Rover(int x, int y, int xmax, int ymax, Heading h)
        {
            xpos = x;
            ypos = y;
            this.xmax = xmax;
            this.ymax = ymax;
            head = h;
        }

        public void move(string instructions)
        {
            foreach (char c in instructions.ToCharArray())
            {
                switch (c)
                {
                    case 'L':
                        head = (head == Heading.N) ? Heading.W : head - 1;
                        //turn left
                        break;
                    case 'R':
                        head = (head == Heading.W) ? Heading.N : head + 1; ;
                        //turn right
                        break;
                    case 'M':

                        switch (head)
                        {
                            case Heading.N:
                                ypos = (ypos == ymax) ? ymax : ypos+1 ;
                                break;
                            case Heading.E:
                                xpos = (xpos == xmax) ? xmax : xpos + 1;
                                break;
                            case Heading.S:
                                ypos = (ypos == 0) ? 0 : ypos - 1;
                                break;
                            case Heading.W:
                                xpos = (xpos == 0) ? 0 : xpos - 1;
                                break;
                        }

                        //attempt to move forward
                        
                        break;
                }

            }
        }

        public string toString()
        {
            return xpos.ToString() + " " + ypos.ToString() + " " + head.ToString();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(); //string array

            string line; //buffer

            Console.WriteLine("Input max grid dimensions:");

            input.Add(Console.ReadLine());

            Console.WriteLine("Input rover initialization and instructions--2 lines per rover (CTRL+Z, Enter once done):");
            while ((line = Console.ReadLine()) != null)
            {
                input.Add(line); //add each line
            }
            
            if(input.Count < 3)
            {
                Console.WriteLine("Too few lines of input.");
                Thread.Sleep(1000);
                return;
            } else if (input.Count % 2 != 1) //there are an even number of input lines, which is incorrect
            {
                Console.Write("Need two lines of input per rover.");
                Thread.Sleep(1000);
                return;
            }

            int xmax, ymax; //to define limits for rover

            try
            {
                string[] arr = input.ElementAt(0).Split();
                Int32.TryParse(arr[0], out xmax);
                Int32.TryParse(arr[1], out ymax);

                int numRovers = (input.Count - 1) / 2;

                Rover[] rovers = new Rover[numRovers]; //array of rovers

                int xinit, yinit;
                Heading hinit = Heading.N;

                for (int i = 0; i < numRovers; i++) //for each rover, init and move
                {
                    //parse the rover init input line
                    string[] tokens = input.ElementAt(1 + (i * 2)).Split();
                    Int32.TryParse(tokens[0], out xinit);
                    Int32.TryParse(tokens[1], out yinit);

                    switch (tokens[2])
                    {
                        case "N":
                            hinit = Heading.N;
                            break;
                        case "E":
                            hinit = Heading.E;
                            break;
                        case "S":
                            hinit = Heading.S;
                            break;
                        case "W":
                            hinit = Heading.W;
                            break;
                    }

                    rovers[i] = new Rover(xinit, yinit, xmax, ymax, hinit); //init the rover

                    rovers[i].move(input.ElementAt(1 + (i * 2) + 1)); //move the rover

                }

                foreach (Rover r in rovers)
                {
                    Console.WriteLine(r.toString()); //output the final destination of each rover.
                }
            } catch(Exception e)
            {
                Console.WriteLine("Incorrect input.");
            }
            

            Console.ReadKey();
            
        }
    }
}
