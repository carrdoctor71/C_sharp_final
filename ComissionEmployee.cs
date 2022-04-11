using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_Company_Benefits
{
    class ComissionEmployee : EmployeeCheck
    {
        double sales; // amount of sales
        double commissionRate; // percentage of sales for commission as a decimal
        public ComissionEmployee(string name)
        {
            base.employee = name;
            this.sales = 0.0;
            this.commissionRate = 0.0;
        }
        public ComissionEmployee(string name, double rate) // rate as percentage
        {
            base.employee = name;
            this.commissionRate = rate / 100; // percent rate turned into decimal for math
        }
        public ComissionEmployee(string name, double rate, double sale)
        {
            base.employee = name;
            this.commissionRate = rate / 100;
            this.sales = sale;
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
        public void calculateCheck()
        {
            base.payCheck = sales * commissionRate;
        }
        public void setCommissionRate(double percent)
        {
            this.commissionRate = percent / 100; // input is percentage and turned into decimal for math
        }
    }
}
