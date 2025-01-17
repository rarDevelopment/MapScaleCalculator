using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapScaleCalculator.Model
{
    internal class Mark
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
    }

    internal class Location
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
    public enum GrabLocation
    {
        None, TopLeft, Top, TopRight, Right, BottomRight, Bottom, BottomLeft, Left
    }
}
