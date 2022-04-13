﻿using System;
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

namespace FileDirectoriser {
    public partial class MainWindow : Window {
        public MainViewModel ViewModel { get; set; }

        public MainWindow() : this(null) {
        }

        public MainWindow(MainViewModel? pViewModel = null) {
            this.ViewModel = pViewModel != null ? pViewModel : new MainViewModel();
            this.DataContext = this.ViewModel;
            this.InitializeComponent();
        }
    }
}