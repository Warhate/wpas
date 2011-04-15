using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu;
using Emgu.Util;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;

namespace Myprojekt
{
    class Face_Contour
    {
        public Face_Contour() { }

        public Image<Gray, Byte> FaceCountors(Image<Bgr, Byte> img)
        {
            //настройки для класса канни для распознавания контуров Canny
            Gray cannyThreshold = new Gray(180);
            Gray cannyThresholdLinking = new Gray(120);
            //Конвертируем изображение в серый
            //и выделяем контуры
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            //находим замкнутые контуры
            using (MemStorage stor = new MemStorage())
            {
                CvInvoke.cvCanny(gray, cannyEdges, 100, 50, 3);
                Contour<Point> contours = cannyEdges.FindContours(
                    Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
                    Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_TREE,
                stor);
                Contour<Point> approxContour = contours.ApproxPoly(contours.Perimeter * 0.02, contours.Storage);
                cannyEdges.Draw(approxContour.BoundingRectangle, new Gray(255), 1);
                //lblConData.Text = "Contour X pos: " + approxContour.BoundingRectangle.X + " Contour Y pos: " + approxContour.BoundingRectangle.Y;
                //lblConData2.Text = " Contour Height: " + approxContour.BoundingRectangle.Height + " Contour Width: " + approxContour.BoundingRectangle.Width;
            }
            //startImg.Image = cannyEdges;

            return cannyEdges;
        }
    }
}
