using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_Company_Benefits
{
    class SalaryEmployee : EmployeeCheck
    {
        private double annualSalary;
        public SalaryEmployee()
        {
            base.employee = "";
            this.annualSalary = 0.0;
        }
        public SalaryEmployee(string name)
        {
            base.employee = name;
            this.annualSalary = 0.0;
        }
        public SalaryEmployee(string name, double offer)
        {
            base.employee = name;
            this.annualSalary = offer;
        }
        public void setAnnualSalary(double offer)
        {
            this.annualSalary = offer;
        }
        public double getAnnualSalary()
        {
            return annualSalary;
        }
        public void calculateCheck() // paycheck calculated for salary employee and passed to employee class
        {
            base.payCheck = annualSalary / 26;
        }
        public override bool isHired()
        {
            if(base.isHired() && annualSalary>45000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
