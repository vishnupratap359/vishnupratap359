#include<iostream.h>
#include<conio.h>
class demo{
  int a;
public :
	  demo()
	  {
	    a=2;
	    cout<<a<<endl;      //default constructor
	    }
	    demo(int x)
	    {
	      a=x;
	      cout<<a;  // parametized constructor
	      }

};

void main()
{          clrscr();
   demo obj1;
   demo obj2(123);
   getch();
   }

