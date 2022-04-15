#include<iostream.h>
#include<conio.h>
int a = 0;
class complex{
public:
	complex(){
	a++;
	cout<<"const running "<<a;
	}
      ~complex()
      {
	cout<<"distructor is working "<<a;
	a--;
	}
   };

   int main()
   {
   complex m1;
   {
     cout<<"local block entry "<<endl;
     complex m2,m3;
     cout<<"back to main program "<<endl;
     }
     return 0;
  }