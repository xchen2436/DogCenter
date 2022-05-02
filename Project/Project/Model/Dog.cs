using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class Dog
    {
        public string id { get; set; }
        public string name { get; set; }
        public string bred_for { get; set; }
        public string temperament { get; set; }
        public string life_span { get; set; }
        public string origin { get; set; }
        public string imperial { get; set; }
        public weight weight { get; set; }
        public image image { get; set; }
    }
    public class weight
    {
        public string imperial { get; set; }
        public string metric { get; set; }
    }
    public class image
    {
        public string url { get; set; }
    }
}
