using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGraph
{
    public class Program
    {
        public static void Main()
        {
            string[] cities = {"Lagos", "Toronto", "New York", "London", "Hong Kong",
            "Paris", "Istanbul", "Los Angeles", "Rome", "Shanghai", "Tokyo", "Dubai", "Moscow", "Singapore", "Barcelona",
            "Madrid", "San Francisco", "Amsterdam", "Sydney", "Washington"};
            int size = cities.Length;
            //Establish connections between cities
            CityNode[] city = new CityNode[size];
            for (int i = 0; i < size; i++)
            {
                city[i] = new CityNode(cities[i]);
            }

            //Assigns the citys and their possible routes to other cities, along with the distance
            createConnection(ref city);
            //*************************************************
            CityGraph<CityNode> graph = new CityGraph<CityNode>();
            for(int i = 0; i < size; ++i)
            {
                graph.addCity(city[i]);
            }
            graph.BTS();
            Console.WriteLine(graph.findPath(city[1], city[19]));
            //--------------------FEEL FREE TO WRITE YOUR OWN TESTS-----------------//
            Console.ReadLine();
        }
        public static void createConnection(ref CityNode[] cities)
        {
            // Lagos – 0
            cities[0].AddConnection(cities[19], 100);
            // Toronto – 1
            cities[1].AddConnection(cities[2], 20);
            cities[1].AddConnection(cities[3], 70);
            cities[1].AddConnection(cities[7], 40);
            // New York – 2
            cities[2].AddConnection(cities[11], 70);
            cities[2].AddConnection(cities[19], 10);
            // London - 3
            cities[3].AddConnection(cities[1], 70);
            cities[3].AddConnection(cities[4], 90);
            cities[3].AddConnection(cities[5], 30);
            cities[3].AddConnection(cities[18], 50);
            // Hong Kong – 4
            cities[4].AddConnection(cities[2], 105);
            cities[4].AddConnection(cities[9], 20);
            cities[4].AddConnection(cities[10], 50);
            // Paris - 5
            cities[5].AddConnection(cities[6], 40);
            cities[5].AddConnection(cities[12], 50);
            cities[5].AddConnection(cities[15], 50);
            // Istanbul – 6
            cities[6].AddConnection(cities[17], 30);
            // Los Angeles – 7
            cities[7].AddConnection(cities[1], 40);
            cities[7].AddConnection(cities[16], 20);
            cities[7].AddConnection(cities[19], 50);
            // Rome – 8
            cities[8].AddConnection(cities[12], 30);
            // Shanghai – 9
            // Tokyo – 10 
            cities[10].AddConnection(cities[13], 20);
            // Dubai – 11
            cities[11].AddConnection(cities[0], 30);
            // Moscow – 12
            cities[12].AddConnection(cities[3], 45);
            // Singapore - 13
            cities[13].AddConnection(cities[0], 85);
            // Barcelona – 14
            cities[14].AddConnection(cities[6], 40);
            cities[14].AddConnection(cities[17], 80);
            // Madrid – 15
            cities[15].AddConnection(cities[8], 25);
            cities[15].AddConnection(cities[14], 40);
            // San Francisco – 16
            cities[16].AddConnection(cities[19], 20);
            // Amsterdam - 17
            cities[17].AddConnection(cities[4], 115);
            cities[17].AddConnection(cities[13], 60);
            // Sydney - 18
            cities[18].AddConnection(cities[12], 20);
            // Washington - 19
            cities[19].AddConnection(cities[1], 70);
            cities[19].AddConnection(cities[7], 50);
        }
    }
}
