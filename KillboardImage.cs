using System;
using System.Collections.Generic;
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

        Bitmap equipmentTemplate = new Bitmap(@"C:\Users\Dreyark\Desktop\EquipmentTemplate.png");
        Bitmap inventoryTemplate = new Bitmap(@"C:\Users\Dreyark\Desktop\InventoryTemplate.png");

        public Graphics DownloadImage(Item item, Bitmap bitmap, int x, int y, int sizeX, int sizeY, int countX, int countY)
        {
            Graphics itemImage = Graphics.FromImage(bitmap);
            if (item != null)
            {
                WebClient webClient = new WebClient();
                Bitmap singleItem = new Bitmap(Image.FromStream(new MemoryStream(webClient.DownloadData(srcitemImg + item.Type + itemCount + item.Count + itemQuality + item.Quality))), sizeX, sizeY);
                itemImage.DrawImage(singleItem, new Point(x, y));
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                itemImage.DrawString(item.Count.ToString(), drawFont, drawBrush, x + countX, y + countY, drawFormat);
            }
            return itemImage;
        }

        public void EquipmentImage(Template temp)
        {
            Graphics stringImage = Graphics.FromImage(equipmentTemplate);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            stringImage.DrawString(temp.Killer.Name, drawFont, drawBrush, 150, 5, drawFormat);
            stringImage.DrawString(temp.Killer.GuildName, drawFont, drawBrush, 150, 20, drawFormat);
            stringImage.DrawString("IP: " + temp.Killer.AverageItemPower.ToString(), drawFont, drawBrush, 225, 300, drawFormat);
            stringImage.DrawString(temp.Victim.Name, drawFont, drawBrush, 475, 5, drawFormat);
            stringImage.DrawString(temp.Victim.GuildName, drawFont, drawBrush, 475, 20, drawFormat);
            stringImage.DrawString("IP: " + temp.Victim.AverageItemPower.ToString(), drawFont, drawBrush, 550, 300, drawFormat);

            DownloadImage(temp.Killer.Equipment.Bag, equipmentTemplate, 15, 45, 122,122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Head, equipmentTemplate, 105, 35, 122, 122,62,61);
            DownloadImage(temp.Killer.Equipment.Cape, equipmentTemplate, 195, 45, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.MainHand, equipmentTemplate, 15, 125, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Armor, equipmentTemplate, 105, 115, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.OffHand, equipmentTemplate, 195, 125, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Food, equipmentTemplate, 15, 205, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Shoes, equipmentTemplate, 105, 195, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Potion, equipmentTemplate, 195, 205, 122, 122, 62, 61);
            DownloadImage(temp.Killer.Equipment.Mount, equipmentTemplate, 105, 275, 122, 122, 62, 61);

            DownloadImage(temp.Victim.Equipment.Bag, equipmentTemplate, 340, 45, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Head, equipmentTemplate, 430, 35, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Cape, equipmentTemplate, 520, 45, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.MainHand, equipmentTemplate, 340, 125, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Armor, equipmentTemplate, 430, 115, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.OffHand, equipmentTemplate, 520, 125, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Food, equipmentTemplate, 340, 205, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Shoes, equipmentTemplate, 430, 195, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Potion, equipmentTemplate, 520, 205, 122, 122, 62, 61);
            DownloadImage(temp.Victim.Equipment.Mount, equipmentTemplate, 430, 275, 122, 122, 62, 61);
            //return nowa;
            equipmentTemplate.Save(@"C:\Users\Dreyark\Desktop\path_to_your_file.png", ImageFormat.Png);
        }
        public void InventoryImage(Template temp)
        {
            int items = temp.Victim.Inventory.Count(s => s != null);
            double x = Math.Ceiling(Convert.ToDouble(items) / 8);
            int height = Convert.ToInt32(x) * 115;
            Bitmap inventoryImg = new Bitmap(1100, height);
            Graphics inventoryImage = Graphics.FromImage(inventoryImg);
            for (int i = 0; i < x; i++)
                inventoryImage.DrawImage(inventoryTemplate, new Point(0, Convert.ToInt32(i * 100)));
            int cells = 0;
            for (int i = 0; i <= items; i++)
            {
                double row = Math.Floor(Convert.ToDouble((i / 8)));
                if (cells > 7)
                {
                    cells = 0;
                }
                DownloadImage(temp.Victim.Inventory[i], inventoryImg, cells * 130 + 20, Convert.ToInt32(row) * 110, 125 , 125, 84, 85);
                cells++;
            }
            inventoryImg.Save(@"C:\Users\Dreyark\Desktop\inventory.png", ImageFormat.Png);
        }
    }
}
