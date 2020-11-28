using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNI_Project
{
    class Game
    {
        int size;
        int[,] map;
        int space_x, space_y;
        static Random rand = new Random();

        public Game(int size)
        {
            if (size < 2) size = 2;
            if (size > 5) size = 5;
            this.size = size;
            map = new int[size, size];
        }

        public void Start()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    map[x, y] = coordToPos(x, y) + 1;
                }
            }
            space_x = size - 1;
            space_y = size - 1;
            map[space_x, space_y] = 0;
        }

        public void Shift(int position)
        {
            int x, y;
            posToCoord(position, out x, out y);
            if (Math.Abs(space_x - x) + Math.Abs(space_y - y) != 1)
                return;
            map[space_x, space_y] = map[x, y];
            map[x, y] = 0;
            space_x = x;
            space_y = y; 
        }

        public void ShiftShuffle()
        {
            Shift(rand.Next(0, size * size));
        }

        public bool checkNumbers()
        {
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != coordToPos(x, y) + 1)
                        return false;
                }
            }
            return true;
        }
        public int getNumber(int position)
        {
            int x, y;
            posToCoord(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];
        }

        private int coordToPos(int x, int y)
        {
            return y * size + x;

        }

        private void posToCoord (int position, out int x, out int y)
        {
            x = position % size;
            y = position / size;
        }
    }
}
