﻿using Commandos.Logs;
using Commandos.Logs.InterfacesAndEnums;
using Commandos.Models.Carts;
using Commandos.Models.Products.General;
using Commandos.Models.Users;
using Commandos.Serialize;
using Commandos.Storage;
using ConsoleUI.CommandsFactory;
using ConsoleUI.Drawers;
using ConsoleUI.Inputs;
using ConsoleUI.IO;
using ConsoleUI.Menu;
using ConsoleUI.Menu.Music;
using Microsoft.Extensions.Configuration;
internal static class Program
{
    public static void Main()
    {
        //Console.OutputEncoding = System.Text.Encoding.Unicode;
        //Console.InputEncoding = System.Text.Encoding.Unicode;
        try
        {
<<<<<<< Updated upstream

            Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(Path.GetFullPath(@"..\..\..\..\Commandos\Files\config.json")));
            IOSettings.GetInstance(new ConsoleDrawer(), new ConsoleInputByArrows());
=======
            Configuration.GetInstance(new ConfigurationBuilder().AddJsonFile(Path.GetFullPath(@"../../../../Commandos/Files/config.json")));            
            IOSettings.GetInstance(new ConsoleDrawer(), new ConsoleInput());
>>>>>>> Stashed changes

            ProductStorage<IProduct>
                .GetInstance(DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>())
                .Load());

            UsersRepository
                .GetInstance(DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>())
                .Load());

            CartsRepository
                .GetInstance(DownloaderProcessor.GetCartsDataSerializer(new XmlStreamSerialization<CartsRepository>())
                .Load());

<<<<<<< Updated upstream

            MenuProcess menu = new(new AuthorizationElements().GetMenuElements());
            LoadingMenu decoratedMenu = new(menu);
            decoratedMenu.SetMusic(new MarioMusic());
            decoratedMenu.Start();

=======
            MenuProcess menu = new(new List<IMenuElement>()
            {
                new InfoElement("Welcome to the mega storage!"),
                new SelectableElement("Login", "1", new AuthorizationCommand()),
                new SelectableElement("Exit", "0", new ExitCommand())
            });
           // menu.SetMusic(new MarioMusic());
            menu.Start();

            //Console.WriteLine(new Check(CartsRepository.GetInstance().GetCart(UserAccount.GetInstance().User)));
>>>>>>> Stashed changes
        }
        catch (Exception ex)
        {
            LogDistributor.GetInstance().Add(new Log(LogType.Exception, ex.Message));
            IOSettings.GetInstance().Drawer.Write(ex.Message + ex.StackTrace);
        }
        finally
        {
            // Saving repositories and logs. These steps are done in any case when the program finishes
            DownloaderProcessor.GetStorageDataSerializer(new XmlStreamSerialization<ProductStorage<IProduct>>()).Save(ProductStorage<IProduct>.GetInstance());
            DownloaderProcessor.GetUserDataSerializer(new XmlStreamSerialization<UsersRepository>()).Save(UsersRepository.GetInstance());
            DownloaderProcessor.GetCartsDataSerializer(new XmlStreamSerialization<CartsRepository>()).Save(CartsRepository.GetInstance());
            LogDistributor.GetInstance().SaveAndClear();
        }
    }
}

