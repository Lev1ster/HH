using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerLibrary
{
    public interface IControl
    {
        void PrintLine(string line);

        string EnterLine();
    }
}
