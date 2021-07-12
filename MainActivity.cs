using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System.IO;

namespace ReadWriteTextFile
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView text;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            Button saveBt = FindViewById<Button>(Resource.Id.savebt);
            Button showBt = FindViewById<Button>(Resource.Id.showbt);
            text = FindViewById<TextView>(Resource.Id.text);

            saveBt.Click += SaveBt_Click;
            showBt.Click += ShowBt_Click;

        }

          private void ShowBt_Click(object sender, System.EventArgs e)
        {
            ReadFromFile();
        }

        private void SaveBt_Click(object sender, System.EventArgs e)
        {
            WriteToFile("Hello world!");
        }

        public void WriteToFile(string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "data.txt");
            System.IO.File.WriteAllText(filePath, text);
        }

        public void ReadFromFile()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, "data.txt");
            string textFromPath = System.IO.File.ReadAllText(filePath);

            text.Text = textFromPath;
        }
      
    }
}