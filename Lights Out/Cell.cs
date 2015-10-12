using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lights_Out
{
    class Cell
    {
        bool value;

        public Cell()
        {
            value = false;
        }

        public Cell(bool value)
        {
            this.value = value;
        }

        public void Set()
        {
            value = true;
        }

        public void Turn()
        {
            value = !value;
        }

        public bool Value
        {
            get
            {
                return value;
            }
        }
    }
}
