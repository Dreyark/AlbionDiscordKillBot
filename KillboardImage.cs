using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AlbionKillboard
{
    class KillboardImage
    {
        string srcitemImg = "https://render.albiononline.com/v1/item/";
        string itemCount = "?count=";
        string itemQuality = "&quality=";
        static string startupPath = Environment.CurrentDirectory;
        Bitmap equipmentTemplate = new Bitmap("EquipmentTemplate.png");
        Bitmap inventoryTemplate = new Bitmap("InventoryTemplate.png");

        public void DownloadImage(Item item, Bitmap bitmap, int x, int y, int sizeX, int sizeY, int countX, int countY)
        {
            Graphics itemImage = Graphics.FromImage(bitmap);
            if (item != null)
            {
                Bitmap singleItem;
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFileCompleted += DownloadCompleted;
                    singleItem = new Bitmap(Image.FromStream(new MemoryStream(webClient.DownloadData(srcitemImg + item.Type + itemCount + item.Count + itemQuality + item.Quality))), sizeX, sizeY);
                }
                itemImage.DrawImage(singleItem, new Point(x, y));
                
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 11, FontStyle.Bold);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                itemImage.DrawString(item.Count.ToString(), drawFont, drawBrush, x + countX, y + countY, drawFormat);
            }
            // return itemImage;
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Success");
        }

        public bool EquipmentImage(Template temp)
        {
            Graphics stringImage = Graphics.FromImage(equipmentTemplate);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 13);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            stringImage.DrawString(temp.Killer.Name, drawFont, drawBrush, 150, 5, drawFormat);
            stringImage.DrawString(temp.Killer.GuildName, drawFont, drawBrush, 150, 20, drawFormat);
            stringImage.DrawString("IP: " + temp.Killer.AverageItemPower.ToString(), drawFont, drawBrush, 225, 300, drawFormat);
            stringImage.DrawString(temp.Victim.Name, drawFont, drawBrush, 475, 5, drawFormat);
            stringImage.DrawString(temp.Victim.GuildName, drawFont, drawBrush, 475, 20, drawFormat);
            stringImage.DrawString("IP: " + temp.Victim.AverageItemPower.ToString(), drawFont, drawBrush, 550, 300, drawFormat);

            DownloadImage(temp.Killer.Equipment.Bag, equipmentTemplate, 15, 45, 90,90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Head, equipmentTemplate, 105, 35, 90, 90,60,57);
            DownloadImage(temp.Killer.Equipment.Cape, equipmentTemplate, 195, 45, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.MainHand, equipmentTemplate, 15, 125, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Armor, equipmentTemplate, 105, 115, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.OffHand, equipmentTemplate, 195, 125, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Food, equipmentTemplate, 15, 205, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Shoes, equipmentTemplate, 105, 195, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Potion, equipmentTemplate, 195, 205, 90, 90, 60, 57);
            DownloadImage(temp.Killer.Equipment.Mount, equipmentTemplate, 105, 275, 90, 90, 60, 57);

            DownloadImage(temp.Victim.Equipment.Bag, equipmentTemplate, 340, 45, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Head, equipmentTemplate, 430, 35, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Cape, equipmentTemplate, 520, 45, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.MainHand, equipmentTemplate, 340, 125, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Armor, equipmentTemplate, 430, 115, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.OffHand, equipmentTemplate, 520, 125, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Food, equipmentTemplate, 340, 205, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Shoes, equipmentTemplate, 430, 195, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Potion, equipmentTemplate, 520, 205, 90, 90, 60, 57);
            DownloadImage(temp.Victim.Equipment.Mount, equipmentTemplate, 430, 275, 90, 90, 60, 57);
            //return nowa;
            equipmentTemplate.Save("Kill.png", ImageFormat.Png);
            return true;
        }
        public bool InventoryImage(Template temp)
        {
            int items = temp.Victim.Inventory.Count(s => s != null);
            double x = Math.Ceiling(Convert.ToDouble(items) / 8);
            int height = Convert.ToInt32(x) * 130;
            Bitmap inventoryImg = new Bitmap(1060, height);
            Graphics inventoryImage = Graphics.FromImage(inventoryImg);
            for (int i = 0; i < x; i++)
                inventoryImage.DrawImage(inventoryTemplate, new Point(0, Convert.ToInt32(i * 100)));
            int cells = 0;
            // double rows = Math.Floor(Convert.ToDouble((items / 8)));
            int row = 0;
            foreach (Item item in temp.Victim.Inventory)
            {
                if (item != null)
                {
                    if (cells > 7)
                    {
                        row++;
                        cells = 0;
                    }

                    DownloadImage(item, inventoryImg, cells * 98 + 8, Convert.ToInt32(row) * 100, 104, 104, 70, 68);
                    cells++;
                }
            }

            inventoryImg.Save("inventory.png", ImageFormat.Png);
            return true;
        }
    }
}
