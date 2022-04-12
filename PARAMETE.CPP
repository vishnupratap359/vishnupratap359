#include<iostream.h>
#include<conio.h>
class chetu{
private:
	 int room,croom;
public:
	chetu(){}
	chetu(int x,int y){
	room = x;
	croom = y;
	}
	void pdata(){
	cout<<room<<endl<<croom;
	}
	};
	void main()
	{
	  chetu emp(100,200);
	  chetu emp1;
	  emp1.pdata();
	  emp.pdata();
	  getch();
	  }