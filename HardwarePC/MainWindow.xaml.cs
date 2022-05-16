using HardwarePC.Models;
using Microsoft.EntityFrameworkCore;
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

namespace HardwarePC
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            try 
            {
                LoadDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void LoadDB()
        {
            try
            {
                using (db = new ApplicationContext())
                {
                    db.Pc.Load();
                    db.Processors.Load();
                    db.Motherboards.Load();
                    db.RAMS.Load();
                    db.VideoCards.Load();
                    db.HardDrives.Load();
                    db.PowerSupplys.Load();
                    dataGrid.ItemsSource = db.Pc.Local.ToBindingList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Add()
        {
            try
            {
                if (int.Parse(tb_AmoutRam.Text) == 4 || int.Parse(tb_AmoutRam.Text) == 8 || int.Parse(tb_AmoutRam.Text) == 16 || int.Parse(tb_AmoutRam.Text) == 32 || int.Parse(tb_AmoutRam.Text) == 64)
                {
                    using (db = new ApplicationContext())
                    {
                        ProcessorTb processorTb = new ProcessorTb
                        {
                            ProcessorName = tb_ProcName.Text,
                            ProcessorModel = tb_ProcModel.Text,
                            ProcessorPrice = int.Parse(tb_ProcPrice.Text)
                        };
                        db.Processors.Add(processorTb);
                        db.SaveChanges();

                        MotherboardTb motherboardTb = new MotherboardTb
                        {
                            MotherboardName = tb_MotherbName.Text,
                            MotherboardPrice = int.Parse(tb_MotherbPrice.Text)
                        };
                        db.Motherboards.Add(motherboardTb);
                        db.SaveChanges();

                        RAMTb rAMTb = new RAMTb
                        {
                            AmountRAM = int.Parse(tb_AmoutRam.Text),
                            RAMPrice = int.Parse(tb_RAMPrice.Text)
                        };
                        db.RAMS.Add(rAMTb);
                        db.SaveChanges();

                        VideoCardTb videoCardTb = new VideoCardTb
                        {
                            VideoCardName = tb_VideoCName.Text,
                            VideoCardPrice = int.Parse(tb_VidCardPrice.Text)
                        };
                        db.VideoCards.Add(videoCardTb);
                        db.SaveChanges();

                        HardDriveTb hardDriveTb = new HardDriveTb
                        {
                            HardDriveName = tb_HarddriveName.Text,
                            HardDrivePrice = int.Parse(tb_harddrivePrice.Text)
                        };
                        db.HardDrives.Add(hardDriveTb);
                        db.SaveChanges();

                        PowerSupplyTb powerSupplyTb = new PowerSupplyTb
                        {
                            PowerSupplyName = tb_PowerSupName.Text,
                            PowerSupplyPrice = int.Parse(tb_PowSupPrice.Text)
                        };
                        db.PowerSupplys.Add(powerSupplyTb);
                        db.SaveChanges();

                        int? priceProc = db.Processors.Where(x => x.IdProcessor == processorTb.IdProcessor).Sum(x => x.ProcessorPrice).Value;
                        int? priceMother = db.Motherboards.Where(x => x.IdMotherboard == motherboardTb.IdMotherboard).Sum(x => x.MotherboardPrice).Value;
                        int? priceRam = db.RAMS.Where(x => x.IdRAM == rAMTb.IdRAM).Sum(x => x.RAMPrice).Value;
                        int? priceVidCard = db.VideoCards.Where(x => x.IdVideoCard == videoCardTb.IdVideoCard).Sum(x => x.VideoCardPrice).Value;
                        int? priceHardDrive = db.HardDrives.Where(x => x.IdHardDrive == hardDriveTb.IdHardDrive).Sum(x => x.HardDrivePrice).Value;
                        int? pricePowerSup = db.PowerSupplys.Where(x => x.IdPowerSupply == powerSupplyTb.IdPowerSupply).Sum(x => x.PowerSupplyPrice).Value;

                        var totalPrice = priceProc + priceMother + priceRam + priceVidCard + priceHardDrive + pricePowerSup;

                        PcTb pcTb = new PcTb
                        {
                            ProcessorId = processorTb.IdProcessor,
                            MotherboardId = motherboardTb.IdMotherboard,
                            RAMId = rAMTb.IdRAM,
                            VideoCardId = videoCardTb.IdVideoCard,
                            HardDriveId = hardDriveTb.IdHardDrive,
                            PowerSupplyId = powerSupplyTb.IdPowerSupply,
                            Price = totalPrice,
                            SuitableSurfing = checkBoxSurphingAdd.IsChecked,
                            SuitableWorkingTextEd = checkBoxTextEditAdd.IsChecked,
                            SuitableComputerGames = checkBoxGamesAdd.IsChecked
                        };
                        db.Pc.Add(pcTb);
                        db.SaveChanges();
                        LoadDB();
                        
                    }
                }
                else
                    MessageBox.Show("Об'єм ОЗУ має дорівнювати 4/8/16/32!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (db = new ApplicationContext())
                {
                    db.Pc.Load();
                    db.Processors.Load();
                    db.Motherboards.Load();
                    db.RAMS.Load();
                    db.VideoCards.Load();
                    db.HardDrives.Load();
                    db.PowerSupplys.Load();
                    dataGrid.ItemsSource = db.Pc.Where(x => x.Price <= int.Parse(tb_Price.Text) && x.SuitableComputerGames == checkBoxGame.IsChecked && x.SuitableSurfing == checkBoxSerfing.IsChecked && x.SuitableWorkingTextEd == checkBoxTextEdit.IsChecked).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
