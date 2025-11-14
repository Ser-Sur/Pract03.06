using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Effects;

//Использовать класс Pair(пара чисел). Определить класс-наследник Money с характеристиками: 
//рубли и копейки. Переопределить операцию сложения и определить методы вычитания и деления 
//денежных сумм.

namespace Pract03._06
{
    class Pair
    {
        public int A { get; set; }
        public int B { get; set; }

        /// <summary>
        /// Пара чисел
        /// </summary>
        public Pair()
        {
            A = 0;
            B = 0;
        }
        /// <summary>
        /// Пара чисел с параметрами
        /// </summary>
        /// <param name="a">Параметр 1</param>
        /// <param name="b">Параметр 2</param>
        public Pair(int a, int b)
        {
            A = a;
            B = b;
        }

        /// <summary>
        /// Сложение пар
        /// </summary>
        /// <param name="pair1">Пара 1</param>
        /// <param name="pair2">Пара 2</param>
        /// <returns>Итоговая пара</returns>
        public static Pair operator +(Pair pair1, Pair pair2)
        {
            Pair pair3 = new Pair();
            pair3.A = pair1.A + pair2.A;
            pair3.B = pair1.B + pair2.B;
            return pair3;
        }

        /// <summary>
        /// Плюс 1 к паре
        /// </summary>
        /// <param name="pair1">Пара</param>
        /// <returns>Пара</returns>
        public static Pair operator ++(Pair pair1)
        {
            pair1.B++;
            pair1.A++;
            return pair1;
        }

        /// <summary>
        /// Минус 1 к паре
        /// </summary>
        /// <param name="pair1">Пара</param>
        /// <returns>Пара</returns>
        public static Pair operator --(Pair pair1)
        {
            pair1.A--;
            pair1.B--;
            return pair1;
        }
    }

    class Money : Pair 
    { 
        public int Rub { get; set; }
        public int Cop { get; set; }

        public Money() : base ()
        {
            
        }

        public Money(int rub, int cop) : base (rub, cop)
        {
            if (cop >= 100)
            {
                Rub += cop / 100;
                Cop = cop % 100;
            }
        }


        public static Money operator +(Money money2, Money money1)
        {
            Money money3 = new Money();
            money3.Rub = money1.Rub + money2.Rub;
            money3.Cop = money1.Cop + money2.Cop;
            if (money3.Cop >= 100)
            {
                money3.Rub += money3.Cop / 100;
                money3.Cop = money3.Cop % 100;
            }
            return money3;
        }

        static public Money Subtraction (Money money1, Money money2)
        {
            Money money3 = new Money();
            int totalCop1 = money1.Rub * 100 + money1.Cop;
            int totalCop2 = money2.Rub * 100 + money2.Cop;

            if (totalCop1 < totalCop2)
            {
                MessageBox.Show("!!! Нельзя вычитать большую сумму из меньшей !!!");
                return money3;
            }
            else
            {
                int resultCop = totalCop1 - totalCop2;
                money3.Rub = resultCop / 100;
                money3.Cop = resultCop % 100;
                return money3;
            }
        }

        static public Money Division (Money money1, int divider)
        {
            Money money2 = new Money();
            int cop = money1.Rub * 100 + money1.Cop;
            int quotient = cop / divider;
            money2.Cop = quotient % 100;
            money2.Rub = quotient / 100;
            return money2;
        }
    }
}