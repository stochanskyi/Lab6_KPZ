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

namespace Lab5.presentation.common.inputView
{
    /// <summary>
    /// Interaction logic for InputView.xaml
    /// </summary>
    public partial class InputView : UserControl
    {
        public InputView()
        {
            InitializeComponent();
        }

        [Localizability(LocalizationCategory.Text)]
        public string InputTitle
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            OnTitleChanged();
        }

        public void OnTitleChanged()
        {   
            var titleView = this.FindName("TextTitle") as TextBlock;
            titleView.Text = InputTitle;
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("InputTitle", typeof(string), typeof(InputView), new PropertyMetadata(default(string)));

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}