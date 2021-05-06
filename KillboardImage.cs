using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;

namespace AlbionKillboard
{
    class KillboardImage
    {
        string itemImg = "https://render.albiononline.com/v1/item/";
        string itemCount = "?count=";
        string itemQuality = "&quality=";

        Bitmap nowa = new Bitmap(@"C:\Users\Dreyark\Desktop\ImageTemplate.png");


        public Graphics downloadImage(Item item, int x, int y)
        {
            Graphics itemImage = Graphics.FromImage(nowa);
            if (item != null)
            {
                WebClient webClient = new WebClient();
                Bitmap singleItem = new Bitmap(Image.FromStream(new MemoryStream(webClient.DownloadData(itemImg + item.Type + itemCount + item.Count + itemQuality + item.Quality))), 122, 122);
                itemImage.DrawImage(singleItem, new Point(x, y));
                System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
                System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightGray);
                System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
                itemImage.DrawString(item.Count.ToString(), drawFont, drawBrush, x+62, y+60, drawFormat);
            }
            return itemImage;
        }

        public void makeImage(Template temp)
        {
            Graphics stringImage = Graphics.FromImage(nowa);
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Brown);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            stringImage.DrawString(temp.Killer.Name, drawFont, drawBrush, 150, 5, drawFormat);
            stringImage.DrawString(temp.Killer.GuildName, drawFont, drawBrush, 150, 20, drawFormat);
            stringImage.DrawString("IP: "+temp.Killer.AverageItemPower.ToString(), drawFont, drawBrush, 225, 300, drawFormat);
            stringImage.DrawString(temp.Victim.Name, drawFont, drawBrush, 475, 5, drawFormat);
            stringImage.DrawString(temp.Victim.GuildName, drawFont, drawBrush, 475, 20, drawFormat);
            stringImage.DrawString("IP: "+temp.Victim.AverageItemPower.ToString(), drawFont, drawBrush, 550, 300, drawFormat);

            downloadImage(temp.Killer.Equipment.Bag, 15, 45);
            downloadImage(temp.Killer.Equipment.Head, 105, 35);
            downloadImage(temp.Killer.Equipment.Cape, 195, 45);
            downloadImage(temp.Killer.Equipment.MainHand, 15, 125);
            downloadImage(temp.Killer.Equipment.Armor, 105, 115);
            downloadImage(temp.Killer.Equipment.OffHand, 195, 125);
            downloadImage(temp.Killer.Equipment.Food, 15, 205);
            downloadImage(temp.Killer.Equipment.Shoes, 105, 195);
            downloadImage(temp.Killer.Equipment.Potion, 195, 205);
            downloadImage(temp.Killer.Equipment.Mount, 105, 275);

            downloadImage(temp.Victim.Equipment.Bag, 340, 45);
            downloadImage(temp.Victim.Equipment.Head, 430, 35);
            downloadImage(temp.Victim.Equipment.Cape, 520, 45);
            downloadImage(temp.Victim.Equipment.MainHand, 340, 125);
            downloadImage(temp.Victim.Equipment.Armor, 430, 115);
            downloadImage(temp.Victim.Equipment.OffHand, 520, 125);
            downloadImage(temp.Victim.Equipment.Food, 340, 205);
            downloadImage(temp.Victim.Equipment.Shoes, 430, 195);
            downloadImage(temp.Victim.Equipment.Potion, 520, 205);
            downloadImage(temp.Victim.Equipment.Mount, 430, 275);
            //return nowa;
            nowa.Save(@"C:\Users\Dreyark\Desktop\path_to_your_file.png", ImageFormat.Png);
        }
    }
}
