using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareAreaBuilder
{ 
    class SquareAreaBuilder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Square { get; set; }
    }

    class TypeArea : SquareAreaBuilder
    {
        public string Type { get; set; }

    }

}
       
