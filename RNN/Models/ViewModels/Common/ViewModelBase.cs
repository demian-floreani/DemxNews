using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RNN.Models.ViewModels.Common
{
    public class ViewModelBase
    {
        public Dictionary<string, object> ViewModelData { get; set; }

        public ViewModelBase()
        {
            ViewModelData = new Dictionary<string, object>();
        }

        public void InsertData(Tuple<string, object> data)
        {
            if(!ViewModelData.ContainsKey(data.Item1))
            {
                ViewModelData.Add(data.Item1, data.Item2);
            }
        }
    }
}
