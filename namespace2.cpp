#include<iostream>
using namespace std;

namespace vishal{
    int a=50;
    int value(int m)
    {
        return m*2;
    }
}
 namespace vishal1
 {
     double x=55.66;
     double value(double x)
     {
         return x +200;
         
     }
 }
  int main()
  {
      cout<<vishal::value(9)<<endl;
      cout<<vishal1::value(5)<<endl;
      return 0;
      
  }