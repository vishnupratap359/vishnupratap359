#include<iostream.h>
#include<conio.h>
class abc;
class xyz{
private:
	 int a;
	 friend void fun(xyz,abc);     //friend function
  };
  class abc{
  private:
	   int b;
	   friend void fun(xyz,abc);
     };
       void fun(xyz t1,abc t2){
       t1.a = 2;
       t2.b = 5;
       cout<<t1.a + t2.b;
    }
      int main()
    {
      xyz obj1;
      abc obj2;
      fun(obj1,obj2)
      getch();
    }
