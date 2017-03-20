using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Rectangle = AutoClicker.Model.Rectangle;

namespace AutoClicker.Inputs
{
    class ImageSearch : IImageSearch
    {
        public Rectangle Search(Bitmap image, Bitmap sample, double accuracy = 0.9)
        {
            Image<Bgr, byte> template = new Image<Bgr, byte>(image); // Image A
            Image<Bgr, byte> source = new Image<Bgr, byte>(sample); // Image B

            using (Image<Gray, float> result = source.MatchTemplate(template, TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                result.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                // You can try different values of the threshold. I guess somewhere between 0.75 and 0.95 would be good.
                if (maxValues[0] > accuracy) //0.5
                {
                    // This is a match. Do something with it, for example draw a rectangle around it.
                    System.Drawing.Rectangle match = new System.Drawing.Rectangle(maxLocations[0], template.Size);
                    return Rectangle.From(match);
                }
            }
            return Rectangle.Empty;
        }

        ////https://www.codeproject.com/Articles/38619/Finding-a-Bitmap-contained-inside-another-Bitmap
        //private System.Drawing.Rectangle searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
        //{
        //    BitmapData smallData =
        //      smallBmp.LockBits(new System.Drawing.Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
        //               System.Drawing.Imaging.ImageLockMode.ReadOnly,
        //               System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        //    BitmapData bigData =
        //      bigBmp.LockBits(new System.Drawing.Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
        //               System.Drawing.Imaging.ImageLockMode.ReadOnly,
        //               System.Drawing.Imaging.PixelFormat.Format24bppRgb);

        //    int smallStride = smallData.Stride;
        //    int bigStride = bigData.Stride;

        //    int bigWidth = bigBmp.Width;
        //    int bigHeight = bigBmp.Height - smallBmp.Height + 1;
        //    int smallWidth = smallBmp.Width * 3;
        //    int smallHeight = smallBmp.Height;

        //    System.Drawing.Rectangle location = System.Drawing.Rectangle.Empty;
        //    int margin = Convert.ToInt32(255.0 * tolerance);

        //    unsafe
        //    {
        //        byte* pSmall = (byte*)(void*)smallData.Scan0;
        //        byte* pBig = (byte*)(void*)bigData.Scan0;

        //        int smallOffset = smallStride - smallBmp.Width * 3;
        //        int bigOffset = bigStride - bigBmp.Width * 3;

        //        bool matchFound = true;

        //        for (int y = 0; y < bigHeight; y++)
        //        {
        //            for (int x = 0; x < bigWidth; x++)
        //            {
        //                byte* pBigBackup = pBig;
        //                byte* pSmallBackup = pSmall;

        //                //Look for the small picture.
        //                for (int i = 0; i < smallHeight; i++)
        //                {
        //                    int j = 0;
        //                    matchFound = true;
        //                    for (j = 0; j < smallWidth; j++)
        //                    {
        //                        //With tolerance: pSmall value should be between margins.
        //                        int inf = pBig[0] - margin;
        //                        int sup = pBig[0] + margin;
        //                        if (sup < pSmall[0] || inf > pSmall[0])
        //                        {
        //                            matchFound = false;
        //                            break;
        //                        }

        //                        pBig++;
        //                        pSmall++;
        //                    }

        //                    if (!matchFound) break;

        //                    //We restore the pointers.
        //                    pSmall = pSmallBackup;
        //                    pBig = pBigBackup;

        //                    //Next rows of the small and big pictures.
        //                    pSmall += smallStride * (1 + i);
        //                    pBig += bigStride * (1 + i);
        //                }

        //                //If match found, we return.
        //                if (matchFound)
        //                {
        //                    location.X = x;
        //                    location.Y = y;
        //                    location.Width = smallBmp.Width;
        //                    location.Height = smallBmp.Height;
        //                    break;
        //                }
        //                //If no match found, we restore the pointers and continue.
        //                else
        //                {
        //                    pBig = pBigBackup;
        //                    pSmall = pSmallBackup;
        //                    pBig += 3;
        //                }
        //            }

        //            if (matchFound) break;

        //            pBig += bigOffset;
        //        }
        //    }

        //    bigBmp.UnlockBits(bigData);
        //    smallBmp.UnlockBits(smallData);

        //    return location;
        //}
    }
}