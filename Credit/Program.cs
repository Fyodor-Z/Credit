using System;

namespace Credit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal sum = 0; //Cумма кредита
            decimal percent = 0; //Cумма кредита
            byte type = 0; //Тип платежей
            string input = "";//строка, которую вводит пользователь


            bool result = false;

            do  //ввод и конвертация данных суммы
            {
                Console.WriteLine("Введите сумму кредита: ");
                input = Console.ReadLine();
                result = decimal.TryParse(input, out sum);

                if (result == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Некорректный ввод");
                    Console.ResetColor();
                }
            }
            while (result == false);

            result = false;

            do  //ввод и конвертация процента по кредиту
            {
                Console.WriteLine("Введите проценты кредита: ");
                input = Console.ReadLine();
                result = decimal.TryParse(input, out percent);

                if (result == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Некорректный ввод");
                    Console.ResetColor();
                }
            }
            while (result == false);

            percent = percent / 100;//переводим проценты в дробь

            result = false;

            do  //ввод типа платежей
            {

                Console.WriteLine("Выберите тип платежей: ");
                Console.WriteLine("1 - аннуитетный; ");
                Console.WriteLine("2 - дифференцированный.");


                input = Console.ReadLine();

                if (input == "1")
                {
                    type = 1;
                    result = true;
                }
                else if (input == "2")

                {
                    type = 2;
                    result = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка! Некорректный ввод");
                    Console.ResetColor();
                }
            }
            while (result == false);



            Console.WriteLine("Платежи по месяцам: ");

            //расчет платежей
            decimal payment = 0 ; //платеж
            decimal total_sum = 0; //общая сумма всех выплат
            decimal const_payment = 0; // выплата основого долга (для дифф платежа)

            if (type == 1) //в случае аннуитентного платежа ежемесячная сумма постоянна
            {
                double M_prcnt = (double)(percent / 12); //месячная процентная ставка
                double K = M_prcnt * Math.Pow((1 + M_prcnt), 12)/(Math.Pow((1 + M_prcnt), 12) - 1); //Коэффициент аннуитета
                //Console.WriteLine($"K={K}");
                payment = (decimal)K * sum; //сумма платежа
                }
            else //рассчитаем постоянную часть диффернцированного платежа (выплата основной части)
            {
                const_payment = sum / 12;
            }

            for (int i = 1; i <= 12; i++)                

            {
                if (type == 2) //рассчитаем платеж по дифф. системе в текущем i-ом месяце
                {
                    decimal prcnt_payment = (sum - (const_payment) * (i-1)) * percent / 12; //выплата процентов для д.п.
                    payment = const_payment + prcnt_payment;
                }

                total_sum = total_sum + payment; //рассчитываем общую сумму выплат, прибавляем к ней платеж в каждом месяце
                Console.WriteLine($"Платеж в месяце {i, 2} составит {payment:0.00}");

            }

            Console.WriteLine("");
            Console.WriteLine($"Общая сумма выплат составит {total_sum:0.00}");
            Console.WriteLine($"из них {(total_sum-sum):0.00} составляют выплаты по процентам");

            Console.ReadLine();





        }
    }
}
