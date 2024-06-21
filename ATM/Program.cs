using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;

public class cardHolder
{
    String cardNum;
    int pin;
    String Fname;
    String Lname;
    double Balance;

    public cardHolder(String cardNub, int pin, String Fname, String Lname, double Balance)
    {
        this.cardNum = cardNub;
        this.pin = pin;
        this.Fname = Fname;
        this.Lname = Lname;
        this.Balance = Balance;
    }
    public String getcardNum()
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFname()
    {
        return Fname;
    }
    public String getLname()
    {
        return Lname;
    }
    public double getbalance()
    {
        return Balance;
    }

    public void setcardNum(String newNum)
    {
        cardNum = newNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFname(String newFname)
    {
        Fname = newFname;
    }

    public void setLname(String newLname)
    {
        Lname = newLname;
    }
    public void setbalance(double newBalance)
    {
        Balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printoptions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Please choose from one of the following options");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
            Console.ResetColor();
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposite");
            double depsoit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(depsoit + currentUser.getbalance());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Thank you for your deposite you new Balance is {0}", currentUser.getbalance());
            Console.ResetColor();

        }

        void Withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to widthdraw");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.getbalance() < withdraw)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Insufficient Balance :( ");
                Console.ResetColor();
            }
            else
            {
                currentUser.setbalance(currentUser.getbalance() - withdraw);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Thanks for your withdraw");
                Console.ResetColor();
            }
        }

        void Balance(cardHolder currentUser)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Current Balance is {0}", currentUser.getbalance());
            Console.ResetColor();
        }

        List<cardHolder> cardholders = new List<cardHolder>();
        cardholders.Add(new cardHolder("4597562514564824", 1357, "Harry", "Magwaer", 152.205));
        cardholders.Add(new cardHolder("4597846518132458", 2564, "Wally", "Sandle", 135.55));
        cardholders.Add(new cardHolder("4597795184324805", 2987, "Huthayfa", "Shaheen", 155550.2));
        cardholders.Add(new cardHolder("4597321485976854", 9531, "Abd", "abosamra", 15000.5));

        Console.WriteLine("Welcome to my ATM");
        Console.WriteLine("Please Enter your card Number");
        String debitCardnum = " ";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardnum = Console.ReadLine();
                currentUser = cardholders.FirstOrDefault(a => a.cardNum == debitCardnum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid card number. Please try again!");

                }
            }
            catch { Console.WriteLine("Invalid card number. Please try again!"); }
        }
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please Enter you pin");
        Console.ResetColor();
        int userpin = 0;
        while (true)
        {
            try
            {
                userpin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userpin)
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid card number. Please try again!");
                    Console.ResetColor();
                }
            }     
            catch { Console.WriteLine("Invalid card number. Please try again!"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFname() + " :-) ");
        int option = 0;
        do
        {
          
            printoptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {}
            if(option == 1)
            {
                deposit(currentUser);
            }
            else if (option == 2)
            {
                Withdraw(currentUser);
            }
            else if (option == 3)
            {
                Balance(currentUser);
            }
            else if (option == 4)
            {
                break;
            }
            else { option = 0; }
          
        }
        
        while (option != 4);
        Console.ForegroundColor = ConsoleColor. Blue;
        Console.WriteLine("Thank you! Have a nice day");
        Console.ResetColor();
    }
}

