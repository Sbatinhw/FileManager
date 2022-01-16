using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.DiskList.Elements.Disk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.DiskList.Windows
{
    class DisksWindow : WindowBase
    {
        private IDisk disk;
        private List<IDisk> diskList;
        public IDisk GetDisk
        {
            get { return disk; }
        }
        public DisksWindow()
        {
            base.heading = "Выберите диск";
        }
        protected override List<IElement> GenerateElements()
        {
            DriveInfo[] alldrive = DriveInfo.GetDrives();
            List<IElement> elements = new List<IElement>();
            diskList = new List<IDisk>();
            
            foreach(var f in alldrive)
            {
                diskList.Add(new DiskData(f.Name));
            }

            elements.AddRange(diskList);
            return elements;
        }
        public override void UseElement()
        {
            base.UseElement();
            disk = diskList[currentPosition];
            base.CloseWindow();
        }
    }
}
