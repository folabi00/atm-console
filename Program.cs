using System;

namespace ATMConsole
{
    public class cardHolder
    {
        string cardNum;
        int pin;
        string firstName;
        string lastName;
        double balance;



        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName; 
            this.lastName = lastName;   
            this.balance = balance; 
        }
           
        public int getPin() { return pin;}
        public string getfirstName() { return firstName;}   
        public string getlastName() { return lastName;} 
        public double getBalance() { return balance;}   

        public void setNum (string cardNum) { this.cardNum = cardNum; }    
        public void setPin(int pin) { this.pin = pin; }
        public void setFirstName(string firstName) { this.firstName = firstName; }  
        public void setLastName(string lastName) { this.lastName = lastName; }  
        public void setBalance(double balance) { this.balance = balance; }  


        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Please select an action from the options available");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Balance");
                Console.WriteLine("4. EXIT"); 
            }

            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to deposit  ");
                double deposit = double.Parse(Console.ReadLine());  
                currentUser.setBalance(currentUser.getBalance() + deposit);
                Console.WriteLine("Thank You, your new balance is  " + currentUser.getBalance());
            }
            
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much would you like to withdraw:  ");
                double withdraw = double.Parse(Console.ReadLine()); 
                if(currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Insifficient blance :( ");
                }
                else { currentUser.setBalance(currentUser.getBalance() - withdraw);  Console.WriteLine( "You are good to go, Take your Cash!"); }
            }

            void balance(cardHolder currentUser)   
            {
                Console.WriteLine("current balance " + currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("89023284792830823924", 1234, "James", "Akinloye", 567000));
            cardHolders.Add(new cardHolder("39403849280283497472", 6048, "Olamide", "Adedeji", 23000));
            cardHolders.Add(new cardHolder("47308297438493893474", 2992, "John", "Akinwunmi", 982000));
            cardHolders.Add(new cardHolder("20193838923682749489", 0000, "alex", "McJohnson", 320000));
            cardHolders.Add(new cardHolder("39982830203827824470", 0110, "Scilla", "Afolabi", 9103932));
            cardHolders.Add(new cardHolder("02973826362823629913", 0000, "Ayoola", "Omooba", 800200));

            Console.WriteLine("WELCOME TO VIC.A BANK");
            Console.WriteLine("PLEASE INSERT YOUR DEBIT CARD: ");
            string debitCardNum;  
            cardHolder currentUser;

            while (true)
            {
                try 
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser != null) { break; }
                    else { Console.WriteLine("card not recognised, try again"); }
                                
                } catch { Console.WriteLine("card not recognised, try again"); }
            }

            Console.WriteLine("please enter your pin ");
            int userPin = 0;
            
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin) { break; }
                    else { Console.WriteLine("Pin not correct, try again"); }

                } catch { Console.WriteLine("Pin not correct, try again"); }
            }

            Console.WriteLine("Welcome " + currentUser.getfirstName() + ":)");
            int option = 0;
            
            do 
            {
                printOptions();
                try 
                {
                    option = int.Parse(Console.ReadLine());
                    
                }
                catch { }
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
               

            } while (option != 4); Console.WriteLine("Have a nice day");

        }
    }
}
