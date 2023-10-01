using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    public class Location
    {
        public float latitude;
        public float longitude;
        public Location()
        {

        }
        public Location(float Latitude, float Longitude)
        {
            latitude = Latitude;
            longitude = Longitude;
        }

        public void setLocation(float Longitude, float Latitude)
        {
            longitude = Longitude;
            latitude = Latitude;
        }
    }

}
