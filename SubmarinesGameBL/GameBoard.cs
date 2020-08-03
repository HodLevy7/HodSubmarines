using System.Collections.Generic;
using System.Linq;

namespace SubmarinesGameBL
{
    public class GameBoard
    {
        protected int Height { get; set; }
        protected int Width { get; set; }
        protected Square[,] Squares { get; set; }

        public GameBoard(int height, int width)
        {
            Height = height;
            Width = width;
            Squares = new Square[Height, Width];
        }

        public void LocateSubmarine(Coordinate initialCoordinate, Coordinate finalCoordinate, int submarinesLength, int idOfSubmarine)
        {
            List<Coordinate> range = initialCoordinate.GetRangeWith(finalCoordinate);
            if (range.Count.Equals(submarinesLength))
            {
                range.ForEach(c => Squares[c.Row, c.Column].SetSquareAsBoat(idOfSubmarine));
                range.ForEach(c => GetValidFrameOfSquareByIndex(c).ForEach(s => s.IsAvailableForInput = false));
            }
        }

        public bool IsLocationValidForSubmarine(List<Coordinate> coordinates)
        {
            return coordinates.All(c => IsCoordinateInBoard(c)) && coordinates.All(c => Squares[c.Row, c.Column].IsAvailableForInput);
        }

        public void SelectSquare(Coordinate selectedCoordinate)
        {
            Squares[selectedCoordinate.Row, selectedCoordinate.Column].HitSquare();
        }

        public bool CanSquareBeSelected(Coordinate selectedCoordinate)
        {
            return !Squares[selectedCoordinate.Row, selectedCoordinate.Column].IsHitted && IsCoordinateInBoard(selectedCoordinate);
        }
        public Square GetSquareByIndex(Coordinate coordinate)
        {
            return Squares[coordinate.Row, coordinate.Column];
        }

        public List<Coordinate> GetCoordinateOfSquaresById(int id)
        {
            List<Coordinate> coordinatesOfSquaresWithId = new List<Coordinate>();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Squares[i, j].Id == id)
                    {
                        coordinatesOfSquaresWithId.Add(new Coordinate(i, j));
                    }
                }
            }

            return coordinatesOfSquaresWithId;
        }
        private bool IsCoordinateInBoard(Coordinate coordinate)
        {
            return coordinate.Row > 0 &&
                coordinate.Row < Height && coordinate.Column > 0 && coordinate.Column < Width;
        }

        public List<Square> GetValidFrameOfSquareByIndex(Coordinate coordinate)
        {
            List<Square> frameSquares = new List<Square>();
            List<Coordinate> frameCoordinates = new List<Coordinate>()
            {
                {new Coordinate(coordinate.Row, coordinate.Column + 1) },
                {new Coordinate(coordinate.Row, coordinate.Column - 1) },
                {new Coordinate(coordinate.Row + 1, coordinate.Column) },
                {new Coordinate(coordinate.Row - 1, coordinate.Column) }
            };

            frameCoordinates.Where(c => CanSquareBeSelected(c)).ToList().ForEach(c => frameSquares.Add(Squares[c.Row, c.Column]));

            return frameSquares;
        }

        public override string ToString()
        {
            string gameBoardAsString = "";

            for (int i = 0; i < Squares.GetLength(0); i++)
            {
                for (int j = 0; j < Squares.GetLength(1); j++)
                {
                    gameBoardAsString += Squares[i, j].ToString();
                }

                gameBoardAsString += "\n";
            }

            return gameBoardAsString;
        }

        public string GetClassifiedBoard()
        {
            return ToString().Replace('^', 'O');
        }
    }
}
