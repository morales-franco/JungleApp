using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JungleApp.Models
{
    public class AnimalFileExplorer
    {
        public void Explorer()
        {
            ShowDriveInfo();
        }

        private void ShowDriveInfo()
        {
            //TODO: DriveInfo
            /*
             * This class gives you information about the drives, such as the name, size, 
             * and free space of the drive
             */

            Debug.WriteLine("############ DriveInfo ############");
            DriveInfo info = new DriveInfo(@"C:\");
            Debug.WriteLine($"Name is: { info.Name }");
            Debug.WriteLine($"Drive type is: { info.DriveType }");

            var drivesInfo = DriveInfo.GetDrives();
            foreach (var driveData in drivesInfo)
            {
                Debug.WriteLine(".....................");
                Debug.WriteLine($"Name is: { driveData.Name }");
                Debug.WriteLine($"Drive type is: { driveData.DriveType }");
                Debug.WriteLine($"TotalSize: {  driveData.TotalSize.BytesToGb() } gb");
            }

            Debug.WriteLine("############ Directory ############");

            Debug.WriteLine("##Get Files from specific directory using Directory (only names). Unit C##");
            string[] fileNames = Directory.GetFiles(@"C:\");
            for (int i = 0; i < fileNames.Length ; i++)
            {
                Debug.WriteLine($"[{ i + 1 }] File Name: { fileNames[i] }");
            }

            Debug.WriteLine("##Get Files from specific directory using DirectoryInfo. Unit C##");
            var directoryExplorer = new DirectoryInfo(@"C:\");
            var infoOfFiles = directoryExplorer.GetFiles();
            for (int i = 0; i < infoOfFiles.Length; i++)
            {
                Debug.WriteLine($"[{ i + 1 }] File Name: { infoOfFiles[i].Name }");
            }



        }
    }
}
