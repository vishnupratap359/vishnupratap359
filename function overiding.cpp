#include<iostream>
using namespace std;

class bank{
    public:
            float a,interest,totalbalance;
         void calcinterest(float balance){
             a=balance;
             interest = a*4/100;
             totalbalance=a+interest;
             cout<<"your interest is :"<<interest<<endl;
             cout<<"your total balance is :"<<totalbalance;
         }   
};
class sbi:public bank
{
   public:
           void calcinterest(float balance){
               a=balance;
               interest =a*5/100;
               totalbalance=a+interest;
               cout<<"your interest is: "<<interest<<endl;
               cout<<"your total balance is :"<<totalbalance;
           }
};
 int main()
 {
     sbi obj;
     obj.calcinterest(500);
     return 0;
 }
