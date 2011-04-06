using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Layout
{
[Serializable()]
    public class Map
    {
        public Map()
        { 
    
    
           }
        /// <summary>
        /// Изображение в строковом формате
        /// </summary>
        private Bitmap img; //Tak nado(=
        

        /// <summary>
        /// Масив линий ограничения
        /// </summary>
        List<Line> stertPoints = new List<Line>();
        /// <summary>
        /// Скорость вертра, направление ветра, влажность, температура, масштаб
        /// </summary>
        private int? speed, direction, humi, temp, scale;


        List<Line> newLines = new List<Line>();
        List<MarkPlace> poligons = new List<MarkPlace>();

        /// <summary>
        /// Полигоны
        /// </summary>
        public List<MarkPlace> Poligons
        {
            get { return poligons; }
            set { poligons = value; }
        }

        /// <summary>
        /// Новые линии розметки
        /// </summary>
        public List<Line> NewLines
        {
            get { return newLines; }
            set { newLines = value; }
        }

        /// <summary>
        /// Масштаб
        /// </summary>
        public int? Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        
        /// <summary>
        /// Температура
        /// </summary>
        public int? Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        
        /// <summary>
        /// Влажность воздуха
        /// </summary>
        public int? Humi
        {
            get { return humi; }
            set { humi = value; }
        }
        
        /// <summary>
        /// Направление ветра
        /// </summary>
        public int? Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        
        /// <summary>
        /// Скорость ветра
        /// </summary>
        public int? Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        
        /// <summary>
        /// Карта
        /// </summary>
        public Bitmap Img
        {
            get { return img; }
            set { img = value; }
        }

        private Bitmap ToBitMap(String img)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(img));
            return new Bitmap(ms);

            
        }

        private string BitMapToString(Bitmap value)
        {
            MemoryStream ms = new MemoryStream();
            value.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return Convert.ToBase64String(ms.ToArray());
        }

        
        /// <summary>
        /// Линии ограничения
        /// </summary>
        public List<Line> StartPoints
        {
            get { return stertPoints; }
            set { stertPoints = value; }
        }

        /// <summary>
        /// Устанавливает все параметры карты
        /// </summary>
        /// <param name="scale">Масштаб</param>
        /// <param name="temp">Температура</param>
        /// <param name="humi">Влажность</param>
        /// <param name="speed">Скорость ветра</param>
        /// <param name="direction">Направление ветра</param>
        public void SetAllParam(Bitmap img,int? scale, int? temp, int? humi, int? speed, int? direction)
        {
            Img = img;
            SetAllParam(scale, temp, humi, speed, direction);
        }

        /// <summary>
        /// Устанавливает все параметры карты
        /// </summary>
        /// <param name="scale">Масштаб</param>
        /// <param name="temp">Температура</param>
        /// <param name="humi">Влажность</param>
        /// <param name="speed">Скорость ветра</param>
        /// <param name="direction">Направление ветра</param>
        public void SetAllParam(int? scale, int? temp, int? humi, int? speed, int? direction)
        {
            this.scale = scale;
            this.temp = temp;
            this.humi = humi;
            this.speed = speed;
            this.direction = direction;
            
                 
        }

    }
}
