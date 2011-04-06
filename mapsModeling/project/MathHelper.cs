using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Layout
{
    class MathHelper
    {

        /// <summary>
        /// Возвращает вторую координату точки на линии
        /// </summary>
        /// <param name="x1">Координата первой точка</param>
        /// <param name="y1">Координата первой точка</param>
        /// <param name="x2">Коордиата второй точки</param>
        /// <param name="y2">Коордиата второй точки</param>
        /// <param name="x3">Координата третей точки</param>
        /// <param name="x">Является ли координата третей точки Х</param>
        /// <returns></returns>
        public static int GetNextPoint(int x1, int y1, int x2, int y2,int x3, bool x)
        {

            double k, b;
            k = ((double)x2 - (double)x1) / ((double)y2 - (double)y1);
            b = x1 - k * y1;
            if (x)
            {

                return (int)(k * x3 + b);

            }
            else 
            {
                if (k == 0)
                {
                    return (int)b;
                }
                else
                {
                    return (int)((x3 - b) / k);
                }
            
            }
           
        
        }


        /// <summary>
        /// Пложадь многоугольника
        /// </summary>
        /// <param name="points">координаты углов многоугольника</param>
        /// <returns></returns>
        public static double GetPoligonSpace(Point[] points)
        {

            double space = 0;

            for (int i = 0; i < points.Length-1; i++)
            {
                space += ((points[i + 1].Y + points[i].Y) / 2) * (points[i + 1].X - points[i].X);
            
            }

            return space;
        
        }



        /// <summary>
        /// Определяет находится ли точка внутри многоугольника
        /// </summary>
        /// <param name="poligon">Многоугольник</param>
        /// <param name="point">Точка</param>
        /// <returns></returns>
        public static bool InPoly(MarkPlace poligon, Point point)
        {

           Point[] poly = poligon.Points;
           int pCount = poligon.Points.Length;
           int xNew, yNew;
           int xOld, yOld;
           int x1, y1;
           int x2, y2;
           bool inside = false;

           if (pCount < 3) return false;


           xOld = poly[pCount - 1].X;
           yOld = poly[pCount - 1].Y;

           for (int i = 0; i < pCount; i++)
           {
               xNew = poly[i].X;
               yNew = poly[i].Y;

               if (xNew > xOld)
               {
                   x1 = xOld;
                   x2 = xNew;
                   y1 = yOld;
                   y2 = yNew;

               }
               else
               {
                   x1 = xNew;
                   x2 = xOld;
                   y1 = yNew;
                   y2 = yOld;
               }
               if ((xNew < point.X) == (point.X <= xOld)
                   &&(point.Y-y1)*(x2-x1)
                   <(y2-y1)*(point.X-x1))
               {
                   inside = !inside;
               }

               xOld = xNew;
               yOld = yNew;

           }


               return inside;
        
        }




    }
}
