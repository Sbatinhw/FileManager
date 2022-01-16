using JustFileManager.BaseObjects.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.DataElements
{
    abstract class DataElementBase: IElement, IDataElement
    {
        protected string name;
        private string path;
        public virtual string Name
        {
            get { return name; }
        }

        public string Path {
            get { return path; }
        }

        public DataElementBase(string path)
        {
            this.name = GenerateName(path);
            this.path = path;
        }

        abstract public void Action();
        abstract protected string GenerateName(string path);

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            DataElementBase other;
            try
            {
                other = (DataElementBase)obj;
            }
            catch
            {
                return false;
            }
            return this.Path.Equals(other.Path);
        }
    }
}
