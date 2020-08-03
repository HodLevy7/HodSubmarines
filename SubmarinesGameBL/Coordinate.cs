using System;
using System.Collections.Generic;

namespace SubmarinesGameBL
{
    public class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Coordinate(int row, int column)
        {
            Row = row;
            Column = column;
        }

        private double GetIncline(Coordinate secondCoordinate)
        {
            return ((double)(Column - secondCoordinate.Column) / (double)(Row - secondCoordinate.Row));
        }

        public List<Coordinate> GetRangeWith(Coordinate secondCoordinate)
        {
            List<Coordinate> coordinatesInRange = new List<Coordinate>();

            try //for the case of meaningless number
            {
                double incline = GetIncline(secondCoordinate);

                switch (incline)
                {
                    case 1:
                        for (int i = 0; i <= Math.Abs(Column - secondCoordinate.Column); i++)
                        {
                            coordinatesInRange.Add(new Coordinate(Row + i, Column + i));
                        }
                        break;
                    case -1:
                        for (int i = 0; i <= Math.Abs(Column - secondCoordinate.Column); i++)
                        {
                            coordinatesInRange.Add(new Coordinate(Row - i, Column - i));
                        }
                        break;
                    case 0:
                        int indicator = LowestBetweenTwo(Column, secondCoordinate.Column);
                        for (int i = 0; i <= Math.Abs(Column - secondCoordinate.Column); i++)
                        {
                            coordinatesInRange.Add(new Coordinate(Row, indicator + i));
                        }
                        break;
                }
            }
            catch (Exception)
            {
                for (int i = 0; i <= Math.Abs(Column - secondCoordinate.Column); i++)
                {
                    coordinatesInRange.Add(new Coordinate(Row + i, Column));
                }
            }

            return coordinatesInRange;
        }

        private int LowestBetweenTwo(int first, int second) //if numbers are even, it will return the second one. (doesnt really matter)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
