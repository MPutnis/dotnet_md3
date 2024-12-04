using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using StudyClasses;
using System;
using System.IO;
using System.Reflection;

namespace MD3
{
    public partial class App : Application
    {
        private readonly AppDbContext _appDbContext;

        public App(AppDbContext appDbContext)
        {
            InitializeComponent();

            _appDbContext = appDbContext;
            MainPage = new MainPage(_appDbContext);
        }
    }
}
