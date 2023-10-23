using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_4
{
    public class CellPos
    {
        public int x;
        public int y;
    }
    public class Application
    {
        int _width = 0;
        int _height = 0;
        int[,] _matrix;
        Random _rand = new Random();
        public void Waiter()
        {
            Console.Write("Нажмина на любую клавишу чтобы выйти: ");
            Console.ReadKey();
            Console.Clear();
        }
        private void OutMatrix(int height,int width, int[,] matrix)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void CreateMatrix()
        {
            int width, height;
            Console.Write("Введите длинну: ");
            width = int.Parse(Console.ReadLine());
            Console.Write("Введите высоту: ");
            height = int.Parse(Console.ReadLine());
            _width = width;
            _height = height;
            int[,] matrix = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = _rand.Next(0, 10);
                }
            }
            OutMatrix(height,width,matrix);
            _matrix = matrix;
        }
        public void UnionMatrix()
        {
            if (_height == 0 || _width == 0)
            {
                Console.Write("Введите длинну: ");
                _width = int.Parse(Console.ReadLine());
                Console.Write("Введите высоту: ");
                _height = int.Parse(Console.ReadLine());
            }
            int[,] secondMatrix = new int[_height,_width];
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    secondMatrix[i, j] = _rand.Next(0, 10);
                }
            }
            if (_matrix == null)
            {
                _matrix = new int[_width,_height];
                for (int i = 0; i < _height; i++)
                {
                    for (int j = 0; j < _width; j++)
                    {
                        _matrix[i, j] = _rand.Next(0, 10);
                    }
                }
            }
            Console.WriteLine("Первая матрица:");
            OutMatrix(_height,_width,_matrix);
            Console.WriteLine("Вторая матрица:");
            OutMatrix(_height, _width, secondMatrix);
            Console.WriteLine("Сумма матриц:");
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    Console.Write(String.Format("{0,4}", _matrix[i, j] + secondMatrix[i, j]));
                }
                Console.WriteLine();
            }
        }
        public void DetailOutGameLife(int height, int width, bool[,] field)
        {
            char lifeCell = 'x';
            char emptyCell = ' ';
            Console.Write("  ");
            if (height > 9)
            {
                Console.Write(" ");
            }
            for (int j = 0; j < width; j++)
            {
                Console.Write($"{j + 1} ");
            }
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                if (height > 9 && i < 9)
                {
                    Console.Write($"{i + 1}  ");
                }
                else
                {
                    Console.Write($"{i + 1} ");
                }
                for (int j = 0; j < width; j++)
                {
                    char visualisationCell = field[i, j] ? lifeCell : emptyCell;
                    if (j < 9)
                    {
                        Console.Write($"{visualisationCell} ");
                    }
                    else if (j >= 9)
                    {
                        Console.Write($" {visualisationCell} ");
                    }
                }
                Console.WriteLine();
            }
        }
        public void OutGameLife(int height, int width, bool[,] field)
        {
            char lifeCell = 'x';
            char emptyCell = ' ';
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    char visualisationCell = field[i, j] ? lifeCell : emptyCell;
                    Console.Write($"{visualisationCell} ");
                }
                Console.WriteLine();
            }
        }
        public void GameLife()
        {
            List<CellPos> removeCellList = new List<CellPos>();
            int width, height;
            Console.Write("Введите длинну поля: ");
            width = int.Parse(Console.ReadLine());
            Console.Write("Введите высоту поля: ");
            height = int.Parse(Console.ReadLine());
            bool[,] field = new bool[height, width];
            int input = 1;
            while (input > 0)
            {
                Console.WriteLine("Жизнь:");
                OutGameLife(width, height, field);
                Console.Write("Меню:\n" +
                              "1 - След цикл\n" +
                              "2 - Заменить ячейку\n" +
                              "3 - Заполнить поле рандомно\n" +
                              "0 - Выйти\n" +
                              "ВВод: ");
                input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        List<CellPos> DeadCell = new List<CellPos>();
                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                int counter = 0;
                                CellPos tempCell = new CellPos() { x = i, y = j };
                                for (int k = i - 1; k < i + 2; k++)
                                {
                                    for (int d = j - 1; d < j + 2; d++)
                                    {
                                        if ((k > -1 && d > -1) && (k < height && d < width))
                                        {
                                            if (field[k,d])
                                                counter++;
                                        }
                                    }
                                }

                                switch (field[i,j])
                                {
                                    case true:
                                        counter--;
                                        if (counter > 3)
                                        {
                                            DeadCell.Add(tempCell);
                                        }
                                        if (counter < 3)
                                        {
                                            DeadCell.Add(tempCell);
                                        }
                                        break;
                                    case false:
                                        if (counter >= 3)
                                        {
                                            DeadCell.Add(tempCell);
                                        }
                                        break;
                                }
                            }
                        }
                        foreach (var item in DeadCell)
                        {
                            field[item.x, item.y] = !field[item.x, item.y];
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        while (true)
                        {
                            DetailOutGameLife(width, height, field);
                            Console.WriteLine("Введите координаты ячейки значение которые нужно инвертировать");
                            Console.Write("Введите строку: ");
                            int heightPoss = (int.Parse(Console.ReadLine())) - 1;
                            Console.Write("Введите столбец: ");
                            int widthPoss = (int.Parse(Console.ReadLine())) - 1;
                            field[heightPoss, widthPoss] = !field[heightPoss, widthPoss];
                            Console.Clear();
                            DetailOutGameLife(width, height, field);
                            Console.WriteLine("Для выхода нажмите 'E'");
                            char inputForExit = Console.ReadKey().KeyChar;
                            if (inputForExit == 'E' || inputForExit == 'e')
                            {
                                Console.Clear();
                                break;
                            }
                            Console.Clear();
                        }
                        break;
                    case 3:
                        for (int i = 0; i < height; i++)
                        {
                            for (int j = 0; j < width; j++)
                            {
                                switch (_rand.Next(0, 2))
                                {
                                    case 0:
                                        field[i, j] = false;
                                        break;
                                    case 1:
                                        field[i, j] = true;
                                        break;
                                }
                            }
                        }
                        Console.Clear();
                        break;
                }
            }    
            

        }
    }
}
