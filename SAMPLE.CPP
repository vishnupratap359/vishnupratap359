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
	 void A::sample()
	  {
	  cout<<"sample1";
	  };
	  void main()
	  {
	   clrscr();
	   A obj;
	   obj.sample();
	   cout<<endl;
	   obj.simple();
	   getch();
	   }