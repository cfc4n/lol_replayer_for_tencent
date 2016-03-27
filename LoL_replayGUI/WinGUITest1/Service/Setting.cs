using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinGUITest1.Service
{
    public partial class Setting : BaseEntity
    {

        //[DisplayName("参数名")]
        public string Name { get; set; }

        //[DisplayName("参数值")]
        public string Value { get; set; }


        public string Describe { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
