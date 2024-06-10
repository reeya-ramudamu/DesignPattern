//Factory design pattern demo

using System;

public interface Employee{
    int salary();
}

public class WebDeveloper : Employee
{
    public int salary(){
        Console.Write("Getting Web Developer Salary...");
        return 50000;
    }
}

public class AndroidDeveloper : Employee
{
    public int salary(){
        Console.Write("Getting Android  Developer Salary..");

        return 60000;
    }
}
// main class responsible for determining which sub class method(i.e. salary) to get object subclasses based on input(requirement)  
//factory class contains such kind of method which returns the object of the class based on requirement
public class EmployeeFactory{
    public static Employee getEmployee(string empType){
        if (empType == "AndroidDeveloper"){
            return new AndroidDeveloper();
        }
        else if (empType == "WebDeveloper"){
            return new WebDeveloper();
        }
        else{
            return null;
        }
    }
}

public class Client{
    public static void Main(string[] args){
        Employee emp1 = EmployeeFactory.getEmployee(empType:"AndroidDeveloper");
        int sal1 = emp1.salary();
        Console.WriteLine("Salary: " + sal1);
        
        Employee emp2 = EmployeeFactory.getEmployee(empType:"WebDeveloper");
        int sal2 = emp2.salary();
        Console.WriteLine("Salary: " + sal2);
    }
}

/*Factory Design Pattern

=> When there is superclass and multiple subclasses we want to get object of subclasses based on input and requirement

=> then we create factory class which takes the responsibility of creating object of class based on input 

Advantages
=> focus on creating object for interface rather than implementation .
=> Loose coupling , more robust code.

*/