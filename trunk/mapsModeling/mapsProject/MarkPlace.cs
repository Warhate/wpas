using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Layout
{
    [Serializable()]
  public  class MarkPlace
    {
    
        /// <summary>
        /// Типы територии
        /// </summary>
    [Serializable]
        public enum PlaceType
        { 
            Water,
            Sand,
            Forest,
            Housing
        
        }


    Point[] points;

    public Point[] Points
    {
        get { return points; }
        set { points = value; }
    }
        Color color;


        PlaceType type;


        /// <summary>
        /// Тип полигона
        /// </summary>
        public PlaceType Type
        {
            get { return type; }
            set { type = value; }
        }
        String description;

        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="points">Точки многоугольника</param>
        /// <param name="type">Тип територии</param>
        /// <param name="description">Краткое описание</param>
        public MarkPlace(Point[] points, PlaceType type, String description)
        {

            this.points = points;
            this.type = type;
            this.description = description;

            switch (this.type)
            {
                case PlaceType.Forest:
                    { 
                        color = Color.Green;
                        break;
                    }
                case PlaceType.Housing:
                    {
                        color = Color.HotPink;
                        break;
                    }
                case PlaceType.Sand:
                    {
                        color = Color.Yellow;
                        break;
                    }
                case PlaceType.Water:
                    {
                        color = Color.Blue;
                        break;
                    }
            }
        
        }


        public override string ToString()
        {
            return String.Format("Type:{0} \n Description:{1}", type.ToString(), description);
        }

    }
}
