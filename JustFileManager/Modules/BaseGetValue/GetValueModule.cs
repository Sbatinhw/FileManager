using JustFileManager.Modules.BaseGetValue.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseGetValue
{
    abstract class GetValueModule<T>: IReturnValue<T>
    {
        private T value;
        private bool haveValue;
        public T GetValue
        {
            get
            {
                if (haveValue)
                {
                    return value;
                }
                else
                {
                    RequestValue();
                    return value;
                }
            }
        }
        public GetValueModule()
        {
            haveValue = false;
        }

        private void RequestValue()
        {
            value = Calculate();
            haveValue = true;
        }

        abstract protected T Calculate();
    }
}
