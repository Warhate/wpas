﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Layout
{
   public class Marker
    {
        /// <summary>
        /// Координаты всех блоков
        /// </summary>
        private List<Block> blocks = new List<Block>();
        List<Line> lines = new List<Line>();
        
       public enum WindDirect
       {
           N,
           W,
           E,
           S
       
       
       }
       
       
       public Marker()
        { 
        
       
       }


       /// <summary>
       /// Наносит изображение на карту
       /// </summary>
       /// <param name="position"></param>
       /// <param name="img"></param>
       /// <param name="graph"></param>
       public void DrawFire(Point position,Image img, ref Graphics graph)
       {

           graph.DrawImage(img, position);
                
       
       
       }


       public void DrawPoint(Point position, ref Graphics graph)
       {
           
       
       }



       public void MakeFaire(ref Graphics graph, MarkPlace polygon, int step,WindDirect wd)
       {
           int maxX = polygon.Points[0].X,
               minX =  polygon.Points[0].X,
               maxY = polygon.Points[0].Y,
               minY = polygon.Points[0].Y,
               midleX = 0,
               midleY = 0;



           for (int i = 0; i < polygon.Points.Length; i++)
           {
               if (polygon.Points[i].X < minX)
               {
                   minX = polygon.Points[i].X;
               }

               if (polygon.Points[i].X > maxX)
               {
                   maxX = polygon.Points[i].X;
               }

               if (polygon.Points[i].Y < minY)
               {
                   minY = polygon.Points[i].Y;
               }

               if (polygon.Points[i].Y > maxY)
               {
                   maxY = polygon.Points[i].Y;
               }
               
                
           }

           midleX = (minX + maxX) / 2;
           midleY = (minY + maxY) / 2;

           /*
           for (int i = 0; i < polygon.Points.Length; i++)
           {

               if (polygon.Points[i].X > midleX) 
               {
                   if (polygon.Points[i].Y > midleY) //1
                   {
                       polygon.Points[i].X += step;
                       polygon.Points[i].Y += step;
                   
                   }

                   if (polygon.Points[i].Y < midleY) //4
                   {
                       polygon.Points[i].X += step;
                       polygon.Points[i].Y -= step;

                   }

               
               }


               if (polygon.Points[i].X < midleX) 
               {
                   if (polygon.Points[i].Y > midleY) //2
                   {
                       polygon.Points[i].X -= step;
                       polygon.Points[i].Y += step;

                   }

                   if (polygon.Points[i].Y < midleY) //3
                   {
                       polygon.Points[i].X -= step;
                       polygon.Points[i].Y -= step;

                   }


               }

               if (polygon.Points[i].X == midleX)
               {
                   if (polygon.Points[i].Y > midleY) //2
                   {
                       polygon.Points[i].X -= step;
                       polygon.Points[i].Y += step;

                   }

                   if (polygon.Points[i].Y < midleY) //3
                   {
                       polygon.Points[i].X -= step;
                       polygon.Points[i].Y -= step;

                   }

                   if (polygon.Points[i].Y == midleY) //2
                   {
                       polygon.Points[i].X -= step;
                       polygon.Points[i].Y += step;

                   }



               }
           
           
           }

           */

               graph.FillPolygon(Brushes.Red, polygon.Points);

               switch (wd)
               {
                   case (WindDirect.N):
                       {


                           graph.DrawBezier(Pens.Red, new Point(minX, midleY), new Point(minX - step * 3, minY - step * 3), new Point(maxX + step * 3, minY - step * 3), new Point(maxX , midleY));
                           

                           break;

                       
                       }

                   case (WindDirect.S):
                       {


                           graph.DrawBezier(Pens.Red, new Point(minX, midleY), new Point(minX - step * 3, maxY + step * 3), new Point(maxX + step * 3, maxY + step * 3), new Point(maxX, midleY));


                           break;


                       }

                   case (WindDirect.W):
                       {


                           graph.DrawBezier(Pens.Red, new Point(midleX, maxY), new Point(minX - step * 3, maxY + step * 3), new Point(minX - step * 3, minY - step * 3), new Point(midleX, minY));


                           break;


                       }

                   case (WindDirect.E):
                       {


                           graph.DrawBezier(Pens.Red, new Point(midleX, maxY), new Point(maxX + step * 3, maxY + step * 3), new Point(maxX + step * 3, minY - step * 3), new Point(midleX, minY));


                           break;


                       }
               
               
               }
               

           //graph.DrawBezier(Pens.Red, new Point(100, 500), new Point(200, 450), new Point(200, 550), new Point(100, 500));
           //graph.DrawBezier(Pens.Red, new Point(100, 500), new Point(250, 400), new Point(250, 600), new Point(100, 500));
           //graph.DrawBezier(Pens.Red, new Point(100, 500), new Point(300, 350), new Point(300, 650), new Point(100, 500));
           //graph.DrawBezier(Pens.Red, new Point(100, 500), new Point(350,300), new Point(350, 700), new Point(100, 500));
           //graph.DrawBezier(Pens.Red, new Point(100, 100), new Point(200, 100), new Point(100, 200), new Point(100, 100));


           //List<Point> points = CalcutePoints(1000);

           //for (int i = 0; i < 1000; i++)
           //{
           //    //DrawPoint(points[i], ref graph);

           //    graph.DrawLine(new Pen(Brushes.Red), points[i], new Point(points[i].X+1,points[i].Y+1));
           
           //}
       
       }

       public List<Point> CalcutePoints(int count)
       {
           List<Point> points = new List<Point>(count);

           points.Add(new Point(100, 100));

           for (int i = 0; i < count; i++)
           {
               for (int j = 0; j < i + 1; j++)
               {

                   points.Add(new Point(points[j].X + j, points[j].Y + j));
                   points.Add(new Point(points[j].X, points[j].Y + j));
                   points.Add(new Point(points[j].X - j, points[j].Y + j));

               }

           }

           return points;
       
       }

        /// <summary>
        /// Рисование сетки 
        /// </summary>
        /// <param name="width">Ширина изображения</param>
        /// <param name="hight">Высота изображения</param>
        /// <param name="blockSize">Размер блока</param>
        /// <param name="graph">Обект графика</param>
        public void DrawGrid(int width, int hight, int blockSize, ref Graphics graph)
        {
            
            for (int i = 0; i < hight / blockSize + 1; i++)
            {
                graph.DrawLine(Pens.LightBlue, 0, i * blockSize, width, i * blockSize);
               
                     
            }

            for (int i = 0; i < width / blockSize + 1; i++)
            {

                graph.DrawLine(Pens.LightBlue, i * blockSize, 0, i * blockSize, hight);

            }
            //graph.DrawImage(img, new Point(100, 100));
            
        
        
        }

        /// <summary>
        /// Возвращает лист обектов градации
        /// </summary>
        /// <param name="width">Ширина изображения</param>
        /// <param name="hight">Высота изображения</param>
        /// <param name="blockSize">Размер блока</param>
        /// <returns>Лист обектов градации</returns>
        public List<Block> GetListBlocks(int width, int hight, int blockSize)
        {
            blocks.Clear();
            for (int i = 0; i < hight / blockSize + 1; i++)
            {
                for (int j = 0; j < width / blockSize + 1; j++)
                {

                    blocks.Add(new Block(j * blockSize, i * blockSize, j * blockSize + blockSize, i * blockSize + blockSize));
                }
            
            }

            return blocks;
        
        }

        /// <summary>
        /// Рисует опасность блока
        /// </summary>
        /// <param name="graph">Обект графика</param>
        /// <param name="blocks">Список блоков</param>
        public void DrawPowerBlocks(ref Graphics graph, List<Block> blocks)
        {
            Brush brush = Brushes.White;





            for(int i =0;i<blocks.Count;i++)
            {
                if (blocks[i].Power == 0)
                {
                    brush = Brushes.White;
                
                }
                else if (blocks[i].Power > 0 && blocks[i].Power<=10)
                {
                    brush = Brushes.Yellow;

                }

                else if (blocks[i].Power > 10 )
                {
                    brush = Brushes.Red;

                }

                else if (blocks[i].Power < 0 && blocks[i].Power >= -5)
                {
                    brush = Brushes.LightBlue;

                }

                else if (blocks[i].Power < -5 && blocks[i].Power >= -10)
                {
                    brush = Brushes.Blue;

                }
                

                graph.DrawString(blocks[i].Power.ToString(),new Font("Arial",9f), brush, blocks[i].Point1);
            }
        
        }


        public void DetectedPower(ref List<Block> grid, List<MarkPlace> poligons)
        {
            //for (int i = 0; i < grid.Count; i++)
            //{

            //    for (int j = 0; j < poligons.Count; j++)
            //    {
            //        if (DetectedCollPoligon(poligons[j], grid[i]))
            //        {
            //            blocks[i].Power += 10;
            //            break;
            //        }


            //    }

            //}





            
            
            for (int i = 0; i < grid.Count; i++)
            {

                
                for (int j = 0; j < poligons.Count; j++)
                {
                    

                        if (DetectedCollPoligon(poligons[j], grid[i]))
                        {
                            switch (poligons[j].Type)
                            {
                                case MarkPlace.PlaceType.Forest:
                                    {
                                        grid[i].Power += 10;
                                        break;
                                    }
                                case MarkPlace.PlaceType.Housing:
                                    {
                                        grid[i].Power += 20;
                                        break;
                                    }
                                case MarkPlace.PlaceType.Sand:
                                    {

                                        grid[i].Power -= 5;
                                        break;
                                    }
                                case MarkPlace.PlaceType.Water:
                                    {

                                        grid[i].Power -= 10;
                                        break;
                                    }


                            }

                            
                        }

            

                        //if (rect.IntersectsWith(new Rectangle(poligons[j].Points[num].X,
                        //    poligons[j].Points[num].Y,
                        //    1,
                        //    1)))
                        //{

                        //    //switch (poligons[j].Type)
                        //    //{
                        //    //    case MarkPlace.PlaceType.Forest:
                        //    //        {
                        //    //            blocks[i].Power += 10;
                        //    //            break;
                        //    //        }
                        //    //    case MarkPlace.PlaceType.Housing:
                        //    //        {
                        //    //            blocks[i].Power += 20;
                        //    //            break;
                        //    //        }
                        //    //    case MarkPlace.PlaceType.Sand:
                        //    //        {

                        //    //            blocks[i].Power -= 5;
                        //    //            break;
                        //    //        }
                        //    //    case MarkPlace.PlaceType.Water:
                        //    //        {

                        //    //            blocks[i].Power -= 10;
                        //    //            break;
                        //    //        }

                        //    blocks[i].Power += 10;

                        //    //}


                        //    break;

                        //}

                    
                    

                
                }
            
            }
        
        }//DetectedPower


        /// <summary>
        /// Проверяет пересечение блока и полигона
        /// </summary>
        /// <param name="poligon">Полигон</param>
        /// <param name="block">Блок</param>
        /// <returns></returns>
        private bool DetectedCollPoligon(MarkPlace poligon, Block block)
        {

           
             //for (int j = 0; j < (poligon.Points.Length-1); j++)
             //   { 
             //       if(CrossLine(new Line(block.Point1,block.Point2),
             //           new Line(poligon.Points[j],poligon.Points[j+1])))
             //       {
             //           return true;
                    
             //       }
                
                
             //   }


            lines.Clear();

            lines.Add(new Line(block.Point1, new Point(block.Point1.X, block.Point2.Y)));
            lines.Add(new Line(block.Point1, new Point(block.Point2.X, block.Point1.Y)));
            lines.Add(new Line(block.Point2, new Point(block.Point2.X, block.Point1.Y)));
            lines.Add(new Line(block.Point2, new Point(block.Point1.X, block.Point2.Y)));


            for (int i = 0; i < 4; i++)
            {


                for (int j = 0; j < (poligon.Points.Length - 1); j++)
                {
                    if (CrossLine(lines[i],
                        new Line(poligon.Points[j], poligon.Points[j + 1])))
                    {
                        return true;

                    }


                }

                if (CrossLine(lines[i],
                        new Line(poligon.Points[poligon.Points.Length - 1], poligon.Points[0])))
                {
                    return true;

                }

                
                if(MathHelper.InPoly(poligon,block.Point1))
                {
                    return true;
                }

            }

            return false;
        }

        public bool DetectedCollisionLine(Line l1, Line l2)
        {
            int x, y;

            x = ((l1.Point1.X * l1.Point2.Y - l1.Point2.X * l1.Point1.Y)
                * (l2.Point2.X - l2.Point1.X)
                - (l2.Point1.X * l2.Point2.Y - l2.Point2.X * l2.Point1.Y)
                * (l1.Point2.X - l1.Point1.X))
                / ((l1.Point1.Y - l1.Point2.Y)
                * (l2.Point2.X - l2.Point1.X)
                - (l2.Point1.Y - l2.Point2.Y)
                * (l1.Point2.X - l1.Point1.X)); //координата х точки пересечения

            y = ((l2.Point1.Y - l2.Point2.Y) 
                * x
                - (l2.Point1.X * l2.Point2.Y - l2.Point2.X * l2.Point1.Y))
                / (l2.Point2.X - l2.Point1.X);//координата y точки пересечения

            if (((l1.Point1.X <= x) && (l1.Point2.X >= x) && (l2.Point1.X <= x) && (l2.Point2.X >= x))
                || ((l1.Point1.Y <= y) && (l1.Point2.Y >= y) && (l2.Point1.Y <= y) && (l2.Point2.Y >= y)))
            {
                return true;

            }//if
            else
            {
                return false;
            
            }//else
            

        }//DetectedCollisionLine



        public bool CrossLine(Line l1, Line l2)
        {


            if ((((l2.Point1.X - l1.Point1.X) * (l1.Point2.Y - l1.Point1.Y)
                - (l2.Point1.Y - l1.Point1.Y) * (l1.Point2.X - l1.Point1.X))
                * ((l2.Point2.X - l1.Point1.X) * (l1.Point2.Y - l1.Point1.Y)
                - (l2.Point2.Y - l1.Point1.Y) * (l1.Point2.X - l1.Point1.X))
                <= 0)
                &&
                (((l1.Point1.X - l2.Point1.X) * (l2.Point2.Y - l2.Point1.Y)
                - (l1.Point1.Y - l2.Point1.Y) * (l2.Point2.X - l2.Point1.X))
                * ((l1.Point2.X - l2.Point1.X) * (l2.Point2.Y - l2.Point1.Y)
                - (l1.Point2.Y - l2.Point1.Y) * (l2.Point2.X - l2.Point1.X))
                <= 0)
                &&(
                ProjectionCross(l1.Point1.X, l1.Point2.X, l2.Point1.X, l2.Point2.X)
                &&
                ProjectionCross(l1.Point1.Y, l1.Point2.Y, l2.Point1.Y, l2.Point2.Y))
                )
            { return true; }


            return false;
        
        }


        /// <summary>
        /// Мего метод, который подказал один крутой дядька на форуме и без корогого функции глючит
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool ProjectionCross(int a,int b, int c, int d)
        { 

            return (Math.Max(c,d)>=Math.Min(a,b))&&(Math.Min(c,d)<=Math.Max(a,b));
        
        
        }

    }
}
