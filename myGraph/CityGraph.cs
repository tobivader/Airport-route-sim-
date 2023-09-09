using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//Graph representing the network between multiple cities
///METHODS
///1. Add a City (vertex) to the network
///2. Add a route (edge) between 2 Cities (vertices)
///3. Routes (Edges) are directed but can be bidrectional
///4. Routes (Edges) Edges have weight - in this case distance 
///5. Find A city in the network
///6. get a path, find shortest path
namespace myGraph
{
    public class CityGraph<T> where T : CityNode
    {
        List<T> cityNetwork;
        public CityGraph()
        {
            cityNetwork = new List<T>();
        }
        //Adds a city to the network
        public bool addCity(T city)
        {
            if(!(cityNetwork.Contains(city)))
            {
                cityNetwork.Add(city);
                return true;
            }
            return false;
        }
        //Removes a city from the network
        public bool removeCity(T city)
        {
            if(cityNetwork.Contains(city))
            {
                cityNetwork.Remove(city);
                return true;
            }
            return false;
        }
        //Finds and returns city in the network using its name
        public T? findCity(string cityName)
        {
            int i = 0;
            T city;
            while (i < cityNetwork.Count)
            {
                city = cityNetwork[i];
                if (city.CityName.Equals(cityName))
                {
                    return city;
                }
                i += 1;
            }
            return default;
        }
        //Search the tree using breath first search, prints out the name of each city when they are visted
        public void BTS()
        {
            Queue<T> queue = new Queue<T>();
            List<T> discorveredCity = new List<T>();
            T currCity;
            //If the current city has not been discorvered add it then explore it
            if (!(discorveredCity.Contains(cityNetwork[0])))
            {
                //Enqeue the connected cities of the first city 
                foreach (Tuple<CityNode, int> node in cityNetwork[0].ConnectedCities)
                {
                    queue.Enqueue((T)node.Item1);
                }
                //Add city to visited city
                discorveredCity.Add(cityNetwork[0]);
            }
            //While the queue is not empty
            while (queue.Count > 0)
            {
                currCity = queue.Dequeue();
                //If the current city has not been discorvered add it then explore it
                if (!(discorveredCity.Contains(currCity)))
                {
                    discorveredCity.Add(currCity);
                    //Enqueue the cities connecetd to the current city
                    foreach (Tuple<CityNode, int> city in currCity.ConnectedCities)
                    {
                        queue.Enqueue((T)city.Item1);
                    }
                }
            }
            int i = 0;
            //Print out the discorvered set
            foreach(T city in discorveredCity)
            {
                Console.WriteLine(++i + " ." + city.CityName);
            }
        }
        //Find shortest path with Dijkstra's algo
        public string findPath(T originCity, T destCity)
        {
            //Using priority queue so we can sort by the minimum cost 
            PriorityQueue<T, int> queue = new PriorityQueue<T,int>();
            List<T> discorveredCity = new List<T>();
            string path="";
            T current;
            //Enqueue's all the destinations of originCity into the queue
            //NOTE: COST HERE IS = + DISTANCE, BEACUSE WE ARE STARTING FROM THE ORIGIN
            foreach(Tuple<CityNode, int> city in originCity.ConnectedCities)
            {
                city.Item1.Cost = city.Item2;
                city.Item1.PrevCity = originCity;
                queue.Enqueue((T)city.Item1, city.Item1.Cost);
            }
            discorveredCity.Add(originCity);
            //BTS on the graph
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                //IF the current city has not been discorvered
                if (!(discorveredCity.Contains(current)))
                {
                    foreach(Tuple<CityNode, int> city in current.ConnectedCities)
                    {
                        city.Item1.PrevCity = current;
                        //Cost to new node is = distance + prevCity cost
                        city.Item1.Cost += (city.Item2 + city.Item1.PrevCity.Cost);
                        queue.Enqueue((T)city.Item1, city.Item1.Cost);
                    }
                }
                discorveredCity.Add((T)current);
                if(current==destCity)
                {
                    path=getPath(current, originCity);
                    break;
                }
            }
            //Finds the path from the smallest cost
            return path;
        }
        //Returns a string containing the shortest path
        private string getPath(T start, T origin)
        {
            T curr = start;
            string path = string.Format("Quickest Path: {0} --> ", curr.CityName);
            while (curr != origin) 
            {
                curr = (T)curr.PrevCity;
                path += string.Format("{0} --> ", curr.CityName);
            }
            return path;
        }
    }
}