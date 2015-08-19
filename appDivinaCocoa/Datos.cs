using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appDivinaCocoa
{
    public class ChocolateDeMesa
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class ChocolateBlanco
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class Cafe
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class OtrasBebidas
    {
        public string title { get; set; }
        public string description { get; set; }
        public string more { get; set; }
    }

    public class ParaDesayunar
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class AntojosDulces
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class AntojosSalados
    {
        public string title { get; set; }
        public string description { get; set; }
    }

    public class RootObject
    {
        public List<ChocolateDeMesa> ChocolateDeMesa { get; set; }
        public List<ChocolateBlanco> ChocolateBlanco { get; set; }
        public List<Cafe> Cafe { get; set; }
        public List<OtrasBebidas> OtrasBebidas { get; set; }
        public List<ParaDesayunar> ParaDesayunar { get; set; }
        public List<AntojosDulces> AntojosDulces { get; set; }
        public List<AntojosSalados> AntojosSalados { get; set; }
    }
}
