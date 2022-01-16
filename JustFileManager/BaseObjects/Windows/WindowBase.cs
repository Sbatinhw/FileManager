using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows.Gui.Head;
using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using JustFileManager.BaseObjects.Windows.Gui.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows
{
    abstract class WindowBase : IWindow
    {
        protected int currentPosition;
        protected string heading;
        protected string subHeading;
        protected List<IElement> elements;
        private bool workflag;
        protected bool guiworkflag;
        protected bool regenerateGui;

        protected IPrintHead printHead;
        protected IPrintListElements printList;
        protected IKeyBoard keyBoard;
        public WindowBase()
        {
            this.currentPosition = 0;
            this.regenerateGui = true;
        }
        private void Gui()
        {

            while (guiworkflag)
            {
                ValidPosition();
                Console.Clear();
                printHead.Print(heading, subHeading);
                printList.Print(currentPosition, elements);
                Navigation();
            }
        }
        private void Navigation()
        {
            keyBoard.Navigation();
        }

        virtual protected void GenerateGui()
        {
            if (regenerateGui)
            {
                printHead = new DefaultPrintHead();
                printList = new DefaultPrintList();
                keyBoard = GenerateKeyBoard();
                regenerateGui = false;
            }
        }
        virtual protected IKeyBoard GenerateKeyBoard()
        {
            return new DefaultKeyBoard(this);
        }
        public virtual void CloseWindow()
        {
            guiworkflag = false;
            workflag = false;
        }

        private void ValidPosition()
        {
                if (currentPosition == elements?.Count)
                {
                    currentPosition = 0;
                }
                else if (currentPosition < 0)
                {
                    currentPosition = 0;
                }
                else if (currentPosition > elements?.Count)
                {
                    currentPosition = elements.Count - 1;
                }
        }

        public void CurrentPositionDown()
        {
            currentPosition++;
            ValidPosition();
        }

        public void CurrentPositionUp()
        {
            currentPosition--;
            ValidPosition();
        }

        public virtual void OpenWindow()
        {
            workflag = true;
            GenerateGui();
            while (workflag)
            {
                guiworkflag = true;
                elements = GenerateElements();
                Gui();
            }
        }

        public void UpdateWindow()
        {
            guiworkflag = false;
        }

        virtual public void UseElement()
        {
            try
            {
                elements[currentPosition].Action();
                UpdateWindow();
            }
            catch
            {
                UpdateWindow();
            }
        }

        abstract protected List<IElement> GenerateElements();
    }
}
