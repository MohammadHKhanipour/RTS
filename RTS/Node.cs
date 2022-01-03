using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS
{
    public class Node
    {
        public int Counter { get; set; }
        public List<Query> Queries { get; set; }
        public Node Parent { get; set; }
        public Node RightChild { get; set; }
        public Node LeftChild { get; set; }
    }
}
