#include<iostream.h>
#include<conio.h>
class demo{
private:
	 int a,b,c;
	 friend int dostfunction(demo);  //friend function
    };
      int dostfunction(demo x)
      {
      x.a=2;
      x.b=3;
      x.c= x.a+x.b;
      return(x.c);
   }
   void main()
 {
  clrscr();
  demo obj;
  cout<<dostfunction(obj);
  getch();
  }