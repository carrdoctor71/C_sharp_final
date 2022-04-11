// CSC202 Assignment: Startup company benifits
// Author: Kenneth Carr
// 10/25/21
// This program will have object oriented archetecture added to it by making classes for employees which will then
// get inherited by each type of employee with more specific needs.
// Estimated project time = 8hrs
// Actual time log (Hrs):
//      (2.0) Sunday worked on funtionality of the UI
//      (9.5) Tuesday Got most of the program working and archetecture finished
//      (2.0) Thursday fixed the file IO issues and outputs to file in messagebox to be clean
//      (3.5) Friday worked fix runtime errors and improve error handling from user. Worked on screen so the information flowed better
//          by using the Show/Hide funtion with buttons. I found that the best method of error proofing data entry and work flow
//      (6.5) Saturday worked on lots of testing and error proffing. Also found a better way to manage string outputs
//          so large names don't cause big missalignments of data. Had to test alot to find many random errors from
//          miscoded sections, poor archtecture, or test code that wasn't taken out and forgotten
//
// Retrospective:
//      This project taught me a lot about inheritance and archetecuture. It also forced me to think through the user experience more
//  than to just make funtionality. Since this is a finished product I didn't realize how long and how many test runs it would take to
//  really work the bugs out. There are many times I thought i was done and then went to run it a couple more time and would find
//  a very random error that took a while to see such as cutting and pasting code and missing one part that I needed to change. I really
//  learned the power and consistancy of classes and inheritance from doing this project past just the idea of just making the project
//  happy for a grade. As the project grew I saw how much the "complicated archetecture" was actually easier once it got bigger. I also
//  realized that no matter how much I test it, at production time (the final video) errors are still found that were very edge case
//  that I didn't think to test so I would have to go back and fix it to do a production launch again for the final. In sprint terms
//  I got to multiple protypes, but through testing at production found more errors.
//      

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Media;

namespace Startup_Company_Benefits
{
    public partial class Form1 : Form
    {

        class EmployeeCheck
        {
            protected string employee = "";
            protected double payCheck = 0.0; // bi-weekly paycheck accessable by child classes to quantify
            private double taxRate = 0.13; // b-weekly tax rate accessable by child classes to quantify
            private double bonus = 0.0; // must be approved with a true boolean through setter
            private int vacationDays = 0;
            protected double taxAmount = 0.0;

            public EmployeeCheck()
            {
                // empty since all variables are initialized above
            }
            public EmployeeCheck(string name)
            {
                this.employee = name;
            }
            public EmployeeCheck(string name, double pay)
            {
                this.employee = name;
                this.payCheck = pay;
            }
            public string getEmployee()
            {
                return employee;
            }
            public double getPayCheck()
            {
                return payCheck;
            }
            public double getTax()
            {
                return taxRate;
            }
            public double getTaxAmount()
            {
                return taxAmount;
            }
            public double getBonus()
            {
                return bonus;
            }
            public int getVacationDays()
            {
                return vacationDays;
            }
            public void setEmployee(string name)
            {
                this.employee = name;
            }
            public void setPayCheck(double pay)
            {
                this.payCheck = pay;
            }
            public void setTaxRate(double tax)
            {
                this.taxRate = tax;
            }
            public void approveBonus(double percent, Boolean approved)
            {
                if (approved == true)
                {
                    percent = percent / 100;
                    this.bonus = this.payCheck * percent;
                    this.payCheck += this.bonus;
                }
            }
            public void viewCheck()
            {
                string message = "Employee\tTax Amount\tPay Check\n";
                message = message + this.employee + " " + "\t\t" + String.Format("{0:0,0.00}", this.taxAmount) + "\t\t" + String.Format("{0:0,0.00}", this.payCheck);
                MessageBox.Show(message);
            }
        }
        class SalaryEmployee : EmployeeCheck
        {
            private double annualSalary = 0.0;

            public SalaryEmployee(string name)
            {
                base.employee = name;
            }
            public SalaryEmployee(string name, double offer)
            {
                base.employee = name;
                this.annualSalary = offer;
                base.payCheck = offer / 26;
                base.taxAmount = base.payCheck * this.getTax();
            }
            public void setAnnualSalary(double offer)
            {
                this.annualSalary = offer;
            }
            public double getAnnualSalary()
            {
                return annualSalary;
            }
        }

        class HourlyEmployee : EmployeeCheck
        {
            private double hourlyRate = 0.0;
            private double hoursWorked = 0.0;
            private double overtimeHours = 0.0;

            public HourlyEmployee(string name)
            {
                base.employee = name;
            }
            public HourlyEmployee(string name, double pay)
            {
                base.employee = name;
                this.hourlyRate = pay;
            }
            public HourlyEmployee(string name, double pay, double hours)
            {
                base.employee = name;
                this.hourlyRate = pay;
                this.hoursWorked = hours;
                this.overtimeHours = 0.0;
                base.payCheck = pay * hours;
                base.taxAmount = base.payCheck * this.getTax();
            }
            public double getHourlyRate()
            {
                return hourlyRate;
            }
            public double getHoursWorked()
            {
                return hoursWorked;
            }
            public double getOvertime()
            {
                if (hoursWorked > 40)
                {
                    this.overtimeHours = hoursWorked - 40;
                }
                else
                {
                    this.overtimeHours = 0;
                }
                return overtimeHours;
            }
            public void setHourlyRate(double rate)
            {
                this.hourlyRate = rate;
            }
            public void setHoursWorked(double hours)
            {
                this.hoursWorked = hours;
            }
            public void setOvertime(double hours, Boolean approved)
            {
                if (approved == true)
                {
                    this.overtimeHours = hours;
                }
            }
        }

        class CommissionEmployee : EmployeeCheck
        {
            double sales = 0.0; // amount of sales
            double commissionRate = 0.07; // percentage of sales for commission as a decimal
            public CommissionEmployee(string name)
            {
                base.employee = name;
            }
            public CommissionEmployee(string name, double sales) // rate as percentage
            {
                base.employee = name;
                this.sales = sales;
                base.payCheck = this.sales * this.commissionRate;
                base.taxAmount = base.payCheck * base.getTax();
            }
            public double getSales()
            {
                return sales;
            }
            public double getCommissionRate()
            {
                return commissionRate * 100; // converts back to percentage
            }
            public void setSales(double sale)
            {
                this.sales = sale;
            }
            public void setCommissionRate(double percent)
            {
                this.commissionRate = percent / 100; // input is percentage and turned into decimal for math
            }
        }

                                /****MAIN PROGRAM****/

        // empoyees stored in lists since the length of them will change based on work load
        List<HourlyEmployee> hourlyEmployees = new List<HourlyEmployee>(); // all hoursly employees
        List<SalaryEmployee> salaryEmployees = new List<SalaryEmployee>(); // all salary employees
        List<CommissionEmployee> commissionEmployees = new List<CommissionEmployee>(); // all commission sales employees

        Random rnd = new Random(); // random number object
        double number; // number inputted from user
        double commission = 0.07; // commission as a decimal
        double value = 0.0; // place holder for calculations
        string employee;
        double bonusPercent;
        Boolean approved;

        // sound file for roulete
        SoundPlayer chuching = new SoundPlayer(@"C:\Users\Ken Carr\Dropbox (CR)\Ken Files\Collage\C#\Startup Company Benefits\Startup Company Benefits\Cash Register Cha Ching-SoundBible.com-184076484.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { // controls all visable funtionality to end user to force a certain workflow
            if(comboBox1.SelectedIndex == 0) // Enter salary rate
            {
                label2.Text = "Annual Salary";
                label2.Show();
                textBox1.Show();
                label5.Hide();
                textBox4.Hide();
                label6.Hide();
                textBox5.Hide();
                button5.Hide();
                button1.Show();
                label4.Show();
                textBox3.Show();
                label3.Show();
                label7.Show();
                button3.Show();
                button2.Hide();
                label7.Text = "$0.00";
                button1.Text = "Add Employee Paycheck";
            }
            else if(comboBox1.SelectedIndex == 1) // Enter hourly rate
            {
                label2.Text = "Hourly Rate:";
                label2.Show();
                textBox1.Show();
                label5.Text = "Hours";
                label5.Show();
                textBox4.Show();
                label6.Hide();
                textBox5.Hide();
                button5.Hide();
                button1.Show();
                label4.Show();
                textBox3.Show();
                label3.Show();
                label7.Show();
                button3.Show();
                button2.Hide();
                label7.Text = "$0.00";
                button1.Text = "Add Employee Paycheck";
            }
            else if(comboBox1.SelectedIndex == 2) // Enter commissions
            {
                label2.Text = "Sales Amount";
                label2.Show();
                textBox1.Show();
                label5.Hide();
                textBox4.Hide();
                label6.Hide();
                textBox5.Hide();
                button5.Hide();
                button1.Show();
                label4.Show();
                textBox3.Show();
                label3.Show();
                label7.Show();
                button3.Show();
                button2.Show();
                label7.Text = "$0.00";
                button2.Text = "Bonus Roulete!";
                button1.Text = "Add Employee Paycheck";
            }
            else if(comboBox1.SelectedIndex == 3) // search name
            {
                label2.Hide();
                textBox1.Hide();
                label5.Hide();
                textBox4.Hide();
                label6.Hide();
                textBox5.Hide();
                button5.Hide();
                button2.Hide();
                button1.Show();
                label4.Show();
                textBox3.Show();
                label3.Show();
                label7.Show();
                button3.Hide();
                button1.Text = "Search Employee";
                button2.Text = "Bonus Roulete!";
                button1.Text = "Search Employee";
            }
            else
            {
                label5.Hide();
                label2.Hide();
                textBox4.Hide();
                textBox1.Hide();
                label6.Hide();
                textBox5.Hide();
                button5.Hide();
                button2.Hide();
                button1.Hide();
                label4.Hide();
                textBox3.Hide();
                label3.Hide();
                label7.Hide();
                button3.Hide();
                button2.Text = "Bonus Roulete!";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pay_rate = textBox1.Text; // pay rate
            string name = textBox3.Text; // name of new employee
            string hours = textBox4.Text; // hours worked for hourly people
            double time;
            double result;

            if (double.TryParse(pay_rate, out number))
            {
                if(comboBox1.SelectedIndex == 0) // salary
                {
                    SalaryEmployee temp = new SalaryEmployee(name, number);
                    salaryEmployees.Add(temp);
                    label7.Text = String.Format("{0:0,0.00}", salaryEmployees[salaryEmployees.Count()-1].getPayCheck()); // calculated solution outputted to text box
                    salaryEmployees[salaryEmployees.Count()-1].viewCheck();
                }
                else if(comboBox1.SelectedIndex == 1) // hourly
                {
                    if (double.TryParse(hours, out time))
                    {
                        HourlyEmployee temp = new HourlyEmployee(name, number, time);
                        hourlyEmployees.Add(temp);
                        label7.Text = String.Format("{0:0,0.00}", hourlyEmployees[hourlyEmployees.Count() - 1].getPayCheck());
                        hourlyEmployees[hourlyEmployees.Count() - 1].viewCheck();
                    }
                    else
                    {
                        label7.Text = "?!?!INVALID?!?!";
                    }  
                }
                else if(comboBox1.SelectedIndex == 2) // commission
                {
                    CommissionEmployee temp = new CommissionEmployee(name, number);
                    commissionEmployees.Add(temp);
                    label7.Text = String.Format("{0:0,0.00}", commissionEmployees[commissionEmployees.Count() - 1].getPayCheck());
                    commissionEmployees[commissionEmployees.Count() - 1].viewCheck();
                }
                else if(comboBox1.SelectedIndex == 3) // display paycheck
                {
                    string searchName = textBox3.Text;
                    int index = 0;
                    Boolean found = false;
                    while (!found)
                    {
                        if (index < salaryEmployees.Count())
                        {
                            if (salaryEmployees[index].getEmployee().ToLower() == searchName.ToLower())
                            {
                                found = true;
                                label7.Text = String.Format("{0:0,0.00}", salaryEmployees[index].getPayCheck());
                            }
                        }
                        if (index < hourlyEmployees.Count())
                        {
                            if (hourlyEmployees[index].getEmployee().ToLower() == searchName.ToLower())
                            {
                                found = true;
                                label7.Text = String.Format("{0:0,0.00}", hourlyEmployees[index].getPayCheck());
                            }
                        }
                        if (index < commissionEmployees.Count())
                        {
                            if (commissionEmployees[index].getEmployee().ToLower() == searchName.ToLower())
                            {
                                found = true;
                                label7.Text = String.Format("{0:0,0.00}", commissionEmployees[index].getPayCheck());
                            }
                        }
                        if ((salaryEmployees.Count()-1>index && hourlyEmployees.Count()-1>index && commissionEmployees.Count()-1>index) || index>100)
                        { // ends loop if employee isn't in database
                            found = true;
                            MessageBox.Show("Employee Not Found");
                        }
                        index++;
                    }
                }
                else
                {
                    label7.Text = "!?INVALID?!";
                }
            }
            else
            {
                label7.Text = "!?INVALID?!"; // text box of soutions shows it's not valid
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            value = randomBonus(value);
            label7.Text = String.Format("{0:0,0.00}", commissionEmployees[commissionEmployees.Count()-1].getPayCheck()); // calculated solution outputted to text box
            label6.Show();
            textBox5.Show();
        }

        public double commission_check(int sales)
        {
            return sales * commission;
        }

        public double randomBonus(double amount) // bonus ammount calculated and returned.
        {
            chuching.Play();
            int bonus = rnd.Next(1, 11); // random percentage bonus between 1-10 %
            button2.Text = "Bonus " + bonus.ToString() + "%"; // change button to display bonus pay
            bonusPercent = bonus;
            return bonus;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Text = "Print Payroll"; // prints payroll to file
            string employeeHeader = "Employee";
            string taxHeader = "Tax Amount";
            string payHeader = "Pay Check";
            string file_path = "C:/Users/Ken Carr/Dropbox (CR)/Ken Files/Collage/C#/checks.txt"; // file location
            string print_employee = "";
            double print_tax = 0.0;
            double print_check = 0.0;
            StreamWriter FileOut = new StreamWriter(file_path); // create file stream
            FileOut.WriteLine($"{employeeHeader,-12} {taxHeader,-14} {payHeader,-12} \n"); // formarts to keep 

            for (int i = 0; i < salaryEmployees.Count; i++)
            {
                print_employee = salaryEmployees[i].getEmployee();
                print_tax = salaryEmployees[i].getTaxAmount();
                print_check = salaryEmployees[i].getPayCheck();
                FileOut.WriteLine($"{print_employee,-12} {print_tax,-14:C} {print_check,-12:C}");
                FileOut.Flush();
            }
            for (int i = 0; i < hourlyEmployees.Count; i++)
            {
                print_employee = hourlyEmployees[i].getEmployee();
                print_tax = hourlyEmployees[i].getTaxAmount();
                print_check = hourlyEmployees[i].getPayCheck();
                FileOut.WriteLine($"{print_employee,-12} {print_tax,-14:C} {print_check,-12:C}");
                FileOut.Flush();
            }
            for (int i = 0; i < commissionEmployees.Count; i++)
            {
                print_employee = commissionEmployees[i].getEmployee();
                print_tax = commissionEmployees[i].getTaxAmount();
                print_check = commissionEmployees[i].getPayCheck();
                FileOut.WriteLine($"{print_employee,-12} {print_tax,-14:C} {print_check,-12:C}");
                FileOut.Flush();
            }
            FileOut.Close();

            MessageBox.Show("Payroll Printed"); // lets user know checks are printed to text file
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            employee = textBox3.Text;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            button5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            approved = true; // approved bonus to put into paycheck
            if(comboBox1.SelectedIndex == 2)
            {
                int index = commissionEmployees.Count() - 1; // last index location added
                commissionEmployees[index].approveBonus(bonusPercent, approved);
                label7.Text = String.Format("{0:0,0.00}", commissionEmployees[index].getPayCheck());
                MessageBox.Show("BONUS OF $" + String.Format("{0:0,0.00}", commissionEmployees[index].getBonus()) + "!\nPaycheck Updated");
            }
            approved = false;
        }
    }
}
