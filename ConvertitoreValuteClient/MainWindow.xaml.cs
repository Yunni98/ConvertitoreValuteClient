using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ConvertitoreValuteClient.ServiceReference1;

namespace ConvertitoreValuteClient
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Valuta> _sigleValuteDA;
        public ObservableCollection<Valuta> sigleValuteDA
        {
            get
            {
                return _sigleValuteDA;
            }
            set
            {
                _sigleValuteDA = value;
            }
        }

        private ObservableCollection<Valuta> _sigleValuteA;
        public ObservableCollection<Valuta> sigleValuteA
        {
            get
            {
                return _sigleValuteA;
            }
            set
            {
                _sigleValuteA = value;
            }
        }

        private Valuta _valuteSelzionateDA;

        public Valuta ValuteSelzionateDA
        {
            get
            {
                return _valuteSelzionateDA;
            }
            set
            {
                _valuteSelzionateDA = value;
            }
        }

        private Valuta _valuteSelzionateA;

        public Valuta ValuteSelzionateA
        {
            get
            {
                return _valuteSelzionateA;
            }
            set
            {
                _valuteSelzionateA = value;
            }
        }

        private string _importo;
        public string Importo
        {
            get
            {
                return _importo;
            }
            set
            {
                _importo = value;
            }
        }

        private string _importoConvertito;
        public string ImportoConvertito
        {
            get
            {
                return _importoConvertito;
            }
            set
            {
                _importoConvertito = value;
            }
        }

        private string _tassoCambioUnitario;
        public string TassoCambioUnitario
        {
            get
            {
                return _tassoCambioUnitario;
            }
            set
            {
                _tassoCambioUnitario = value;
            }
        }

        public MainWindow(Valuta a)
        {
            ServiceClient service = new ServiceClient();
            InitializeComponent();
            sigleValuteDA = new ObservableCollection<Valuta>(service.getValute());
            sigleValuteA = new ObservableCollection<Valuta>(service.getValute());
            this.DataContext = this;
        }
        
        private void Calcola_Click(object sender, RoutedEventArgs e)
        {
            ServiceClient service = new ServiceClient();
            double convertito = service.Converti(Convert.ToDouble(Importo), ValuteSelzionateDA.sigla, ValuteSelzionateA.sigla);
            ImportoConvertito = convertito.ToString();
            TassoCambioUnitario = "Tasso di cambio " + ValuteSelzionateA.tassoCambio + " " + ValuteSelzionateDA.sigla + " = " + ValuteSelzionateA.tassoCambio + " " + ValuteSelzionateA.sigla;

        }

       


    }
}
