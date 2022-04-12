#include<iostream.h>
#include<conio.h>
class A{
public:
	void sample()
	{
	 cout<<"hello sample";
	 }
	 void sample1();
	 };
	 void A::sample1()
	  {
	  cout<<"sample1";
	  };
	  void main()
	  {
	   clrscr();
	   A obj;
	   obj.sample();
	   cout<<endl;
	   obj.sample1();
	   getch();
	   }