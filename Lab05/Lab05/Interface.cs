using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
{
    interface ITrial
    {
        bool IsPassed();
        int RaiseMark();
    }

    interface ISame
    {
        bool Letters();
    }
}
