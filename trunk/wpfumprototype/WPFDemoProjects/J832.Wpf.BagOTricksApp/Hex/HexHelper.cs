using System;
using System.Windows;

namespace Microsoft.Samples.KMoore.WPFSamples.Hex
{
    static class HexHelper
    {
        public static readonly double HeightOverWidth = Math.Sqrt(3)/2;

        public static Point GetTopLeft(int count, double itemHeight, PointInt location)
        {
            if (count < 1)
                throw new ArgumentOutOfRangeException("count");
            if (itemHeight <= 0)
                throw new ArgumentOutOfRangeException("itemHeight");

            double itemWidth = itemHeight/HeightOverWidth;

            //determine the location of 0,0
            Point point = new Point(0, itemHeight * .5 * (count - 1));

            //determine the start point for the row
            point.X += (itemWidth * 3 / 4) * location.Row;
            point.Y += (itemHeight / 2) * location.Row;
            
            //calculate the offset for the column
            point.X += (itemWidth * 3 / 4) * location.Column;
            point.Y -= (itemHeight / 2) * location.Column;
            
            return point;
        }
    }
}