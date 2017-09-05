using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_POC.Views
{

    public class BlueOysterMDMenuItem
    {
        public BlueOysterMDMenuItem()
        {
            TargetType = typeof(BlueOysterMDDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}