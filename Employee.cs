using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_Company_Benefits
{
    class EmployeeCheck
    {
        protected string employee;
        protected double payCheck; // bi-weekly paycheck accessable by child classes to quantify
        private double taxRate; // b-weekly tax rate accessable by child classes to quantify
        private double bonus; // must be approved with a true boolean through setter
        private int vacationDays;

        public EmployeeCheck()
        {
            this.employee = "";
            this.payCheck = 0.0;
            this.taxRate = .13;
            this.bonus = 0.0;
            this.vacationDays = 0;
        }
        public EmployeeCheck(string name)
        {
            this.employee = name;
            this.payCheck = 0.0;
            this.taxRate = 0.13;
            this.bonus = 0.0;
            this.vacationDays = 0;
        }
        public EmployeeCheck(string name, double pay)
        {
            this.employee = name;
            this.payCheck = pay;
            this.taxRate = 0.13;
            this.bonus = 0.0;
            this.vacationDays = 0;
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
        public void calculateTax()
        {
            this.payCheck = this.payCheck * this.taxRate;
        }
        public void setBonus(double bonusRate, Boolean approved)
        {
            if(approved==true)
            {
                this.bonus = bonusRate;
            }   
        }
        public void setVacationDays(int days, Boolean approved)
        {
            if(approved==true)
            {
                this.vacationDays = days;
            }
        }
        public virtual Boolean isHired()
        {
            if(this.payCheck>0 && this.taxRate>0)
            {
                return true; // returns true if a pay rate and tax are accounted for, bonuses are optional
            }
            else
            {
                return false;
            }
        }
        public void printCheck()
        {
            // file print to check funtion using .append with file IO
        }
    }
}
