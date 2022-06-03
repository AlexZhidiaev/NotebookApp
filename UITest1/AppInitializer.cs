using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            string apkpath = @"C:\Users\Alex\source\repos\NotebookApp\NotebookApp.Android\obj\Debug\120\android\bin\com.companyname.notebookapp.apk";
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.companyname.notebookapp").StartApp();

                return ConfigureApp.Android
                    .Debug().ApkFile(apkpath)
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}