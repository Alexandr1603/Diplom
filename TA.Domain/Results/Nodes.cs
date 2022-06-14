using System;
using System.Collections.ObjectModel;

namespace TA.Domain.Results
{
    public class Node
    {
        public string Name { get; set; }
        public ObservableCollection<Node> Nodes { get; set; }
    }
}
