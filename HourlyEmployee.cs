using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Startup_Company_Benefits
{
    class HourlyEmployee : EmployeeCheck
    {
        private double hourlyRate;
        private double hoursWorked;
        private double overtimeHours;

        public HourlyEmployee()
        {
            base.employee = "";
            this.hourlyRate = 0.0;
            this.hoursWorked = 0.0;
            this.overtimeHours = 0.0;
        }
        public HourlyEmployee(string name)
        {
            base.employee = name;
            this.hourlyRate = 0.0;
            this.hoursWorked = 0.0;
            this.overtimeHours = 0.0;
        }
        public HourlyEmployee(string name, double pay)
        {
            base.employee = name;
            this.hourlyRate = pay;
            this.hoursWorked = 0.0;
            this.overtimeHours = 0.0;
        }
        public HourlyEmployee(string name, double pay, double hours)
        {
            base.employee = name;
            this.hourlyRate = pay;
            this.hoursWorked = hours;
            this.overtimeHours = 0.0;
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
            if(hoursWorked>40)
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
            if(approved==true)
            {
                this.overtimeHours = hours;
            }
        }
        public void calculateCheck()
        {
            if(hoursWorked>40) // accounts for overtime
            {
                overtimeHours = hoursWorked - 40;
                base.payCheck = hourlyRate * hoursWorked;
                base.payCheck = base.payCheck + hourlyRate * overtimeHours * 1.5;
            }
            else // no overtime
            {
                base.payCheck = hourlyRate * hoursWorked;
            }
        }
    }
}
