using ViewModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewLayer.DI;

namespace ViewLayer
{
    /// <summary>
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : Window
    {
        public ProductListView()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ProductListViewModel mc = (ProductListViewModel)DataContext;
            mc.MessageBoxShowDelegate = text => MessageBox.Show(text, "Button interaction", MessageBoxButton.OK, MessageBoxImage.Information);
            mc.WindowResolver = new ProductDetailsResolver();
        }

        private void ProductList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((ProductListViewModel)DataContext).DisplayDetails.Execute(null);
        }
    }
}
