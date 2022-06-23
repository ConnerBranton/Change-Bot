using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ChangeBot2._0
{
    class Program
    {
        struct till
        {
            //declare till
            public double CustomerOnes; //20 =$20
            public int onesAmount;
            public double CustomerFives; //10 = $50
            public int fivesAmount;
            public double CustomerTens; //10 =$100
            public int tensAmount;
            public double CustomerTwentys; //5 =$100
            public int twentysAmount;
            public double CustomerFiftys; //2 = $100
            public int fiftysAmount;
            public double CustomerHundreds; //1 = $100
            public int hundredsAmount;
            public double CustomerPennys; //100 =$1
            public int pennysAmount;
            public double CustomerNickles; //100 =$5
            public int nicklesAmount;
            public double CustomerDimes; //50 =$5
            public int dimesAmount;
            public double CustomerQuarters; //40 =$10
            public int quartersAmount;

        }
        public struct Transaction
        {
            public int transactionNum;
            public string transactionDate;
            public double cashAmount;
            public string cardVendor;
            public double cardAmount;
            public double changeGiven;
        }

        public static Transaction trans;


        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("************************************************************************************************************************");
            Console.WriteLine("*                                       '                                                         '                    *");
            Console.WriteLine("*            *                                             *                           .                               *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*                                                                                                                      *");            
            Console.WriteLine("*                               *                                        *                            *                *");
            Console.WriteLine("*                                                '                                                                     *");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*                               .                     *                                      '                  '      *");
            Console.WriteLine("*             '                                                                                                        *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*              *                                                    *                  .                               *");
            Console.WriteLine("*                                   *                                                                                  *");
            Console.WriteLine("*         '                                                                                           *                *");
            Console.WriteLine("*                                                               '                                                      *");
            Console.Write("*                      ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;            
            Console.Write("                     WELCOME TO D & C CHANGE BOT                             ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("                   *");
            Console.WriteLine("*      *                           .                                          *                                      . *");
            Console.WriteLine("*                       *                              '      *                                            *           *");
            Console.WriteLine("*             .                            *                            '                 *                            *");
            Console.Write("*                      ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                      PRESS ANY KEY TO CONTINUE                              ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("                   *");
            Console.WriteLine("*                             *                                                                     '                  *");
            Console.WriteLine("*                                                           '                                                          *");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*                                                        .                     *                         '             *");
            Console.WriteLine("*         *                                                                                                            *");
            Console.WriteLine("*                                *                                                                                     *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*                                 '                               .                             *                      *");
            Console.WriteLine("*                               *                                                                                      *");
            Console.WriteLine("*              .                                      *                                                                *");
            Console.WriteLine("*                                                                                      '                               *");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*                   *                                                                                         *        *");
            Console.WriteLine("*        '                                  '                                     *                                    *");
            Console.WriteLine("************************************************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.ReadKey();


            Console.Clear();
            double price = 0.0;
            string more = "";
            trans.cashAmount = 0;
            trans.cardVendor = "No_Vendor_Given";
            trans.cardAmount = 0;
            trans.changeGiven = 0;

            do
            {
                //get user input for pricing on items
                Console.Write("Please enter the price of the product: $");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                price = price + Convert.ToDouble(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.White;

                //ask for another item y/n
                Console.Write("Do you have another item? (y/n):  ");
                more = Console.ReadLine();

            } while (more == "y" || more == "Y");
            Math.Round(price, 2);
            price = Math.Round(price, 2);

            Console.ForegroundColor = ConsoleColor.DarkRed;
                        
            Console.ForegroundColor = ConsoleColor.Gray;

            payChoice(price);
        }
        static void payChoice(double purchaseTotal)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"\nThe total for your purchase is: $" + purchaseTotal);
            Console.ForegroundColor = ConsoleColor.Gray;

            string cash = "Cash";
            string cash2 = "cash";

            string card = "Card";
            string card2 = "card";
            string choice = "";
            
            Console.WriteLine();
            Console.Write("Would you like to pay with Cash or Card? ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            choice = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;

            if (choice == cash || choice == cash2)
            {
                trans.cashAmount = purchaseTotal;
                TillUpdate(purchaseTotal);                
            }
            if(choice == card || choice == card2)
            {
                cardEntry(purchaseTotal);
            }
            if(choice != cash && choice != cash2 && choice != card && choice != card2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error, please try again.");
                Console.ForegroundColor = ConsoleColor.Gray;
                payChoice(purchaseTotal);
            }

        }

        static void cardEntry(double total)
        {
                        
            double cBack = 0;
            string choice = "";
            double total2 = 0;

            Console.WriteLine();

            Console.Write("Would you like cash back? (y/n) : ");
            choice = Console.ReadLine();

            if (choice == "y" || choice == "Y")
            {

                Console.WriteLine();
                Console.Write("Please enter the amount you would like to recieve (10) (20) (40) (60) (100) : ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                cBack = Convert.ToDouble(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            total2 = cBack + total;
            trans.cardAmount = total2;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("The new total is: {0:C} ", total2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            //calling verification
            //use cast to convert
            verifyCard((decimal)total, (decimal)cBack);

            Console.WriteLine();
            Console.WriteLine();
                        
        }

        static void verifyCard(decimal total, decimal cBack)
        {
            string result = "";
            long cardNumVeri = 0;

            do
            {//card entry and store to cardnumveri
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Please enter your card number: ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                cardNumVeri = Convert.ToInt64(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.WriteLine();

                Console.WriteLine(cardType(cardNumVeri.ToString()));

                trans.cardVendor = cardType(cardNumVeri.ToString());

                Console.WriteLine();

                Console.Write("Card Number: {0}", cardNumVeri + " is " + (result = (isValid(cardNumVeri) ? "valid. " : "invalid. ")));
                Console.WriteLine();
            } while (result != "valid. ");
            Console.WriteLine();
            Console.WriteLine();

            MoneyRequest(cardNumVeri.ToString(), ((decimal)total), ((decimal)cBack));
        }
        
        static string cardType(string number)
        {
            Regex regVisa = new Regex("^4[0-9]{12}(?:[0-9]{3})?$");
            Regex regMaster = new Regex("^5[1-5][0-9]{14}$");
            Regex regExpress = new Regex("^3[47][0-9]{13}$");
            Regex regDiscover = new Regex("^6(?:011|5[0-9]{2})[0-9]{12}$");


            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (regVisa.IsMatch(number))
                return "Card_type:_VISA ";
            else if (regMaster.IsMatch(number))
                return "Card_type:_MASTER ";
            else if (regExpress.IsMatch(number))
                return "Card_type:_A-EXPRESS ";
            else if (regDiscover.IsMatch(number))
                return "Card_type:_DISCOVER ";
            else
                Console.ForegroundColor = ConsoleColor.DarkRed;
                return "Card type: invalid ";
                

        }
        static bool isValid(long number)
        {
            return (getSize(number) >= 13 &&
                    getSize(number) <= 16) &&
                    (prefixMatched(number, 4) ||
                    prefixMatched(number, 5) ||
                    prefixMatched(number, 37) ||
                    prefixMatched(number, 6)) &&
                    ((sumOfDoubleEvenPlace(number) +
                    sumOfOddPlace(number)) % 10 == 0);
                        
        }

        // Get the result from Step 2
        static int sumOfDoubleEvenPlace(long number)
        {
            int sum = 0;
            String num = number + "";
            for (int i = getSize(number) - 2; i >= 0; i -= 2)
                sum += getDigit(int.Parse(num[i] + "") * 2);

            return sum;
        }

        // Return this number if it is a
        // single digit, otherwise, return
        // the sum of the two digits
        static int getDigit(int number)
        {
            if (number < 9)
                return number;
            return number / 10 + number % 10;
        }

        // Return sum of odd-place digits in number
        static int sumOfOddPlace(long number)
        {
            int sum = 0;
            String num = number + "";
            for (int i = getSize(number) - 1; i >= 0; i -= 2)
                sum += int.Parse(num[i] + "");
            return sum;
        }

        // Return true if the digit d
        // is a prefix for number
        static bool prefixMatched(long number, int d)
        {
            return getPrefix(number, getSize(d)) == d;
        }

        // Return the number of digits in d
        static int getSize(long d)
        {
            String num = d + "";
            return num.Length;
        }

        // Return the first k number of digits from
        // number. If the number of digits in number
        // is less than k, return number.
        static long getPrefix(long number, int k)
        {
            if (getSize(number) > k)
            {
                String num = number + "";
                return long.Parse(num.Substring(0, k));
            }
            return number;
                        
        }

        static string[] MoneyRequest(string account_number, decimal amount, decimal cBack)
        {
            Random rnd = new Random();
            //50% CHANCE TRANSACTION PASSES OR FAILS
            bool pass = rnd.Next(100) < 50;
            //50% CHANCE THAT A FAILED TRANSACTION IS DECLINED
            bool declined = rnd.Next(100) < 50;
            decimal totalAmount = amount + cBack;
            if (pass)
            {
                //change cashback variable to negative so till will update and dispense
                double tillCback = (double)cBack * -1;


                string[] blank = new string[] { };
                string[] approved = new string[] { "Card Number: ", account_number, " approved $", totalAmount.ToString() };
                foreach (string money in approved)
                {
                    Console.Write(money);

                }//end for each

                //calling for cash back from till
                TillUpdate(tillCback);
                return blank;
            }//end if
            else
            {
                if (!declined)
                {
                    string[] blank = new string[] { };
                    //decimal balance = 0;
                    string[] noMoney = new string[] { "Account Number: ", account_number, " available balance: $", Math.Round(amount / rnd.Next(2, 6), 2).ToString() };

                    foreach (string money in noMoney)
                    {
                        Console.Write(money);
                    }//end for each
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Not enough funds available.");
                    Console.WriteLine();
                    Console.WriteLine("Please choose another form of payment.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine();
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey();
                    Console.Clear();
                    payChoice((double)amount);

                    return blank;
                }//end if
                else
                {//if declined repeat pay choice for payment
                    string[] blank = new string[] { };
                    string[] noDough = new string[] { "Card Number: ", account_number, " declined" };

                    foreach (string money in noDough)
                    {
                        Console.Write(money);

                    }//end for each
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please choose another form of payment or try your card again.");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("PRESS ANY KEY TO CONTINUE");
                    Console.ReadKey();
                    Console.Clear();
                    payChoice((double)amount);
                    return blank;
                }//end if
            }//end if

                        
        }
        static void TillUpdate(double Total)
        {
            till bills;
            till coins;
            double dollarEntry = 0.0;
            

            bills.CustomerOnes = 0;
            bills.CustomerFives = 0;
            bills.CustomerTens = 0;
            bills.CustomerTwentys = 0;
            bills.CustomerFiftys = 0;
            bills.CustomerHundreds = 0;

            coins.CustomerPennys = 0;
            coins.CustomerNickles = 0;
            coins.CustomerDimes = 0;
            coins.CustomerQuarters = 0;

            //declare bill amount in till
            bills.onesAmount = 20;
            bills.fivesAmount = 10;
            bills.tensAmount = 10;
            bills.twentysAmount = 5;
            bills.fiftysAmount = 2;
            bills.hundredsAmount = 1;
            //declare coin amount in till
            coins.pennysAmount = 100;
            coins.nicklesAmount = 100;
            coins.dimesAmount = 50;
            coins.quartersAmount = 40;

            if (Total > 0)
            {
                do
                {
                    Console.WriteLine();

                    Console.Write("Please enter a singular bill/coin: $");

                    Console.ForegroundColor = ConsoleColor.Green;

                    dollarEntry = double.Parse(Console.ReadLine());

                    //adding to the till
                    if (dollarEntry == 100)
                    {
                        bills.CustomerHundreds += 1;
                        bills.hundredsAmount += 1;
                    }
                    else if (dollarEntry == 50)
                    {
                        bills.CustomerFiftys += 1;
                        bills.fiftysAmount += 1;
                    }
                    else if (dollarEntry == 20)
                    {
                        bills.CustomerTwentys += 1;
                        bills.twentysAmount += 1;
                    }
                    else if (dollarEntry == 10)
                    {
                        bills.CustomerTens += 1;
                        bills.tensAmount += 1;
                    }
                    else if (dollarEntry == 5)
                    {
                        bills.CustomerFives += 1;
                        bills.fivesAmount += 1;
                    }
                    else if (dollarEntry == 1)
                    {
                        bills.CustomerOnes += 1;
                        bills.onesAmount += 1;
                    }
                    else if (dollarEntry == .25)
                    {
                        coins.CustomerQuarters += 1;
                        coins.quartersAmount += 1;
                    }
                    else if (dollarEntry == .10)
                    {
                        coins.CustomerDimes += 1;
                        coins.dimesAmount += 1;
                    }
                    else if (dollarEntry == .05)
                    {
                        coins.CustomerNickles += 1;
                        coins.nicklesAmount += 1;
                    }
                    else if (dollarEntry == .01)
                    {
                        coins.CustomerPennys += 1;
                        coins.pennysAmount += 1;
                    }

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.WriteLine("");

                    //updated total after money is recieved
                    Total -= dollarEntry;

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    //display current balance to user
                    Console.WriteLine("Your balance is: {0:C}", Total);

                    Console.ForegroundColor = ConsoleColor.Gray;
                }//end if statements for adding to till

                while (Total > 0.00);
                {
                    

                    Console.WriteLine("");

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("Change Due: {0:C}", Math.Abs(Total));

                    trans.changeGiven = Total * -1;

                    Console.WriteLine("");

                    //do loop travense through amount for change until zero
                    do
                    {   //round each value to second decimal point to keep the statements flowing properly
                        Math.Round(Total, 2);
                        Total = Math.Round(Total, 2);

                        if (Total <= -100 && bills.hundredsAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 100)
                            {
                                Total += 100;
                                bills.hundredsAmount--;
                                Console.WriteLine("Dispensing $100");
                            }
                        }
                        else if (Total <= -50 && bills.fiftysAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 50)
                            {
                                Total += 50;
                                bills.fiftysAmount--;
                                Console.WriteLine("Dispensing $50");
                            }
                        }
                        else if (Total <= -20 && bills.twentysAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 20)
                            {
                                Total += 20;
                                bills.twentysAmount--;
                                Console.WriteLine("Dispensing $20");
                            }

                        }
                        else if (Total <= -10 && bills.tensAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 10)
                            {
                                Total += 10;
                                bills.tensAmount--;
                                Console.WriteLine("Dispensing $10");
                            }

                        }
                        else if (Total <= -5 && bills.fivesAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 5)
                            {
                                Total += 5;
                                bills.fivesAmount--;
                                Console.WriteLine("Dispensing $5");
                            }
                        }
                        else if (Total <= -1 && bills.onesAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 1)
                            {
                                Total += 1;
                                bills.onesAmount--;
                                Console.WriteLine("Dispensing $1");
                            }
                        }
                        else if (Total <= -0.25 && coins.quartersAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= .25)
                            {
                                Total += .25;
                                coins.quartersAmount--;
                                Console.WriteLine("Dispensing 0.25");
                            }
                        }
                        else if (Total <= -0.10 & coins.dimesAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= .10)
                            {
                                Total += .10;
                                coins.dimesAmount--;
                                Console.WriteLine("Dispensing 0.10");
                            }
                        }
                        else if (Total <= -0.05 && coins.nicklesAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= .05)
                            {
                                Total += .05;
                                coins.nicklesAmount--;
                                Console.WriteLine("Dispensing 0.05");
                            }
                        }
                        else if (Total <= -0.01 && coins.pennysAmount > 0)
                        {
                            for (double i = 0; i >= Total; i -= 0.01)
                            {
                                Total += 0.01;
                                coins.pennysAmount--;
                                Console.WriteLine("Dispensing 0.01");
                            }
                        }


                    }//continue the do loop until zero is reached
                    while (Total < 0.0);
                }
            }
            else
            {
                //do loop travense through amount for change until zero is reached
                do
                {   //round each value to second decimal point to keep the statements flowing properly
                    Math.Round(Total, 2);
                    Total = Math.Round(Total, 2);
                    trans.changeGiven = Total * -1;
                    Console.WriteLine();
                    Console.WriteLine();
                    if (Total <= -100 && bills.hundredsAmount > 0)
                    {
                        do 
                        {
                            Total += 100;
                            bills.hundredsAmount--;
                            Console.WriteLine("Dispensing $100\n");

                        }while (Total <= -100 && bills.hundredsAmount > 0) ;
                    }
                    else if (Total <= -50 && bills.fiftysAmount > 0)
                    {
                        do
                        {
                            Total += 50;
                            bills.fiftysAmount--;
                            Console.WriteLine("Dispensing $50\n");

                        } while (Total <= -50 && bills.fiftysAmount > 0);
                    }
                    else if (Total <= -20 && bills.twentysAmount > 0)
                    {
                        do
                        {
                            Total += 20;
                            bills.twentysAmount--;
                            Console.WriteLine("Dispensing $20\n");

                        } while (Total <= -20 && bills.twentysAmount > 0);

                    }
                    else if (Total <= -10 && bills.tensAmount > 0)
                    {
                        do
                        {
                            Total += 10;
                            bills.tensAmount--;
                            Console.WriteLine("Dispensing $10\n");
                        } while (Total <= -10 && bills.tensAmount > 0);

                    }
                    else if (Total <= -5 && bills.fivesAmount > 0)
                    {
                        do
                        {
                            Total += 5;
                            bills.fivesAmount--;
                            Console.WriteLine("Dispensing $5\n");
                        } while (Total <= -5 && bills.fivesAmount > 0);
                    }
                    else if (Total <= -1 && bills.onesAmount > 0)
                    {
                        do
                        {
                            Total += 1;
                            bills.onesAmount--;
                            Console.WriteLine("Dispensing $1\n");
                        } while (Total <= -1 && bills.onesAmount > 0);
                    }
                    else if (Total <= -0.25 && coins.quartersAmount > 0)
                    {
                        do
                        {
                            Total += .25;
                            coins.quartersAmount--;
                            Console.WriteLine("Dispensing 0.25\n");
                        } while (Total <= -0.25 && coins.quartersAmount > 0);
                    }
                    else if (Total <= -0.10 && coins.dimesAmount > 0)
                    {
                        do
                        {
                            Total += .10;
                            coins.dimesAmount--;
                            Console.WriteLine("Dispensing 0.10\n");
                        } while (Total <= -0.10 && coins.dimesAmount > 0);
                    }
                    else if (Total <= -0.05 && coins.nicklesAmount > 0)
                    {
                        do
                        {
                            Total += .05;
                            coins.nicklesAmount--;
                            Console.WriteLine("Dispensing 0.05\n");
                        } while (Total <= -0.05 && coins.nicklesAmount > 0);
                    }
                    else if (Total <= -0.01 && coins.pennysAmount > 0)
                    {
                        do
                        {
                            Total += 0.01;
                            coins.pennysAmount--;
                            Console.WriteLine("Dispensing 0.01\n");
                        } while (Total <= -0.01 && coins.pennysAmount > 0);
                    }


                }//continue the do loop until zero is reached
                while (Total < 0.0);
            }
                   
            Console.ForegroundColor = ConsoleColor.Gray;

                    
            Console.WriteLine("");

                    
            Console.ForegroundColor = ConsoleColor.Cyan;

                    
            Console.WriteLine("Please take your change and receipt. ");
            Console.WriteLine();
            Console.WriteLine("THANK YOU FOR USING D & C CHANGEBOT!");
            Console.ForegroundColor = ConsoleColor.Gray;


            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Till Holdings :");                       //amount before purchase
            Console.WriteLine("Ones: {0}", bills.onesAmount);           //20
            Console.WriteLine("Fives: {0}", bills.fivesAmount);         //10
            Console.WriteLine("Tens: {0}", bills.tensAmount);           //10
            Console.WriteLine("Twentys: {0}", bills.twentysAmount);     //5
            Console.WriteLine("Fiftys: {0}", bills.fiftysAmount);       //2
            Console.WriteLine("Hundreds: {0}", bills.hundredsAmount);   //1

            Console.WriteLine("Pennys: {0}", coins.pennysAmount);       //100
            Console.WriteLine("Nickles: {0}", coins.nicklesAmount);     //50
            Console.WriteLine("Dimes: {0}", coins.dimesAmount);         //50
            Console.WriteLine("Quarters: {0}", coins.quartersAmount);   //40
            Console.ForegroundColor = ConsoleColor.Gray;




            transLog();
        }
        static void transLog()
        {
            

            Random rnd = new Random();
            var tnum = rnd.Next(100, 40000);

            string tDate = DateTime.Now.ToString("MM/dd/yyyy");

            string tTime = DateTime.Now.ToString("hh:mm:ss:tt");

            string output = tnum + " " + tDate + " " + tTime + " $" + trans.cashAmount.ToString() + " " + trans.cardVendor.ToString() + " $" + trans.cardAmount.ToString() + " $" + trans.changeGiven.ToString();
                        
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.FileName = "C:\\Users\\conne\\source\\repos\\ChangeBotLOGS\\ChangeBotLOGS\\bin\\Debug\\netcoreapp3.1\\ChangeBotLOGS.exe";

            startInfo.Arguments = output;

            Process.Start(startInfo);


        }
    }
}
