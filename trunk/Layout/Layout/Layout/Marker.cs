using System;
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
        Bitmap img = new Bitmap(@"C:\Users\Warh\Pictures\Pong\asteroid.png");
        
       
       
       public Marker()
        { }

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
            graph.DrawImage(img, new Point(100, 100));
            
        
        
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
