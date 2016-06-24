using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Emotible.Model;
using Emotible.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Emotible
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await MigrateDatabase();
            var viewmodel = (EmotibleViewModel) App.Current.Resources["emotibleViewModel"];
            viewmodel.UpdateEmotesAsync();
        }
        private void GridResized(object sender, SizeChangedEventArgs e)
        {
            ((EmotibleViewModel)((FrameworkElement)sender).DataContext).Width = e.NewSize.Width;
        }

        private async Task MigrateDatabase()
        {
            // Before starting the app, migrate it's database to the latest version!
            using (var db = new EmoteContext())
            {
                await db.Database.MigrateAsync();

                //If the database has no entries, seed it.
                if (!db.Emotes.Any())
                {
                    Debug.WriteLine("Seeding Database Began");
                    await db.Seed(await BuildSeedData());
                    Debug.WriteLine("Seeding Database Completed");
                }
            }
        }

        private async Task<IEnumerable<EmoteModel>> BuildSeedData()
        {
            IList<EmoteModel> dataToSeed = new List<EmoteModel>();
            string fileContent;
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(@"ms-appx:///seed.json"));
            using (StreamReader sRead = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                fileContent = await sRead.ReadToEndAsync();
            }
            await Task.Run(() =>
            {
                //Async build seed data
                var seedDataSource = JsonConvert.DeserializeObject<Dictionary<string, string>>(fileContent);
                var seedData = seedDataSource.Select(seed => new EmoteModel()
                {
                    Name = seed.Key,
                    Content = seed.Value,
                    CreatedOn = DateTime.Now,
                    LastUsed = DateTime.Now
                });
                dataToSeed = seedData.ToList(); //Force evaluation
            });
            //Not all seed data will include a width and height attribute. Generate them.
            foreach (var element in dataToSeed)
            {
                var size = measuringElement.MeasureString(element.Content);
                element.Width = size.Width;
                element.Height = size.Height;
            }
            return dataToSeed;
        }
    }
}
