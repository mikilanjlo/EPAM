using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Kuzmichkin._18
{
    /// <summary>
    /// Conteins splited URL
    /// </summary>
    public class URL
    {
        public string Host { get; set; }

        public List<string> Path { get; set; }

        public Dictionary<string, string> Parameters { get; set; }
       
    }
}
