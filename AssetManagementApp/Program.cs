using AssetManagementApp.Service;
using DigitalAssetsManagement.main;


namespace Digitalasset
{
    internal class Program
        {
            static void Main(string[] args)
            {


                IAssetManagementService service = new AssetManagementServiceImpl();
                MainProgram program = new MainProgram(service);
                program.DisplayMenu();


            }
        }
    }

