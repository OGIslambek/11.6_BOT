﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._6_BOT.Utilites
{
    internal static class Calc
    {
        public static string CalcSum(string inputText)
        {
            int sum = 0;
            string[] numbers = inputText.Split(' ');
            try
            {
                foreach (var item in numbers)
                {
                    int num;
                    if (int.TryParse(item, out num))
                    {
                        sum += num;
                    }
                    else throw new FormatException("Не допустимое значение!!!");
                }
                return $"Cумма чисел: {sum.ToString()}";
            }
            catch (FormatException ex)
            {
                return ex.Message;
            }
        }
        public static string CalcLength(string inputText)
        {
            if (!string.IsNullOrEmpty(inputText))
                return $"Длина строки: {inputText.Length.ToString()} символов";
            else return $"Пустая строка";
        }
    }
}
