using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myGraph
{
    /// <summary>
    /// Each city node contains a list of other cities it has a route to
    /// Connections can be created between cities
    /// Connections can be removed between cities
    /// </summary>
    public class CityNode
    {
        List<Tuple<CityNode, int>> connectedCities;
        CityNode prevCity;
        string cityName;
        int cost;

        public CityNode PrevCity
        {
            set { prevCity = value; }
            get { return prevCity; }
        }
        public int Cost
        {
            get { return cost; }
            set
            {
                if (cost >= 0)
                {
                    cost = value;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }
        public CityNode(string cityName)
        {
            connectedCities = new List<Tuple<CityNode, int>>();
            this.cityName = cityName;
            this.cost = 0;
        }
        public List<Tuple<CityNode, int>> ConnectedCities
        {
            get { return connectedCities; }
            set { connectedCities = value; }
        }
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }
        //Adds a city to this cities connection list
        public bool AddConnection(CityNode city, int distance)
        {
            Tuple<CityNode, int> toAdd=new Tuple<CityNode, int>(city, distance);
            if (!connectedCities.Contains(toAdd))
            {
                connectedCities.Add(toAdd);
                return true;
            }
            return false;
        }
        //Removes a city from this cities connection list
        public bool removeConnection(CityNode city)
        {
            int i = 0;
            Tuple<CityNode, int> current;
            while (i < connectedCities.Count)
            {
                current = connectedCities[i];
                if (current.Item1.Equals(city))
                {
                    connectedCities.Remove(current);
                    return true;
                }
                i += 1;
            }
            return false;
        }
        //Prints out a city and its list if destination cities
        public override string ToString()
        {
            int i = 0;
            string output = string.Format("{0} ----Destinations:\n", this.cityName);
            string dest = "";
            while(i < connectedCities.Count)
            {
                dest += (connectedCities[i].Item1.CityName +"\n");
                i += 1;
            }
            output += dest;
            return output;
        }
    }
}
