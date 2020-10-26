using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic
{
    class Rabbit_Task
    {
        /// <summary>
        /// Задача о прыгающем зайчике
        /// </summary>
        /// <param name="n">Число ступенек</param>
        /// <param name="k">Максимальная высота прыжка(в ступеньках)</param>
        /// <returns>возможное число вариаций прыжков до верхей ступени</returns>
        public static int RabbitMoves (int n, int k)
        {
            int[] moves = new int[n + 1];
            moves[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                int start = Math.Max(0, i - k);
                moves[i] = 0;
                for (int j = start; j < i; j++)
                {
                    moves[i] += moves[j];
                }
            }
            return moves[n];
        }
    }
}
