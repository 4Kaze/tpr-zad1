using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTest
{
    class TestWindow : IOperationWindow
    {
        public event VoidHandler OnClose;

        public IViewModel ViewModel { get; set; }
        public Boolean Showed { get; set; }

        public void BindViewModel<T>(T viewModel) where T : IViewModel
        {
            ViewModel = viewModel;
        }

        public void Show()
        {
            Showed = true;
        }
    }
    class TestWindowResolver : IWindowResolver
    {
        public TestWindow Window { get; set; }
        public IOperationWindow GetWindow()
        {
            Window = new TestWindow();
            return Window;
        }
    }
}
