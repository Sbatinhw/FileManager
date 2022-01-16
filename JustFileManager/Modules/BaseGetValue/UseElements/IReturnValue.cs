using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseGetValue.UseElements
{
    interface IReturnValue<T>
    {
        T GetValue { get; }
    }
}

