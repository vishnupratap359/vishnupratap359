#include<iostream.h>
#include<conio.h>
class demo {
	       float basicsalary,totalsalary,leave,onedaysalary,workingdays;
 public:
	 demo()
       {
	 cout<<"welcome to salary manager  software"<<endl;
	 }

      void getinfo()
    {
       cout<<"enter your basic salary :";
       cin>>basicsalary;
       cout<<endl<<"enter your total leave :";
       cin>>leave;

	onedaysalary = basicsalary/30;
	workingdays = 30 - leave;
	totalsalary = workingdays*onedaysalary;

	cout<<endl<<"you will get : "<<totalsalary<<"rupees";
	}

	~demo()
       {
	 cout<<endl<<endl;
	 cout<<"thanks for using this software ";
	}
    };
       void main()
     {
	clrscr();
	 demo obj;
	 obj.getinfo();
	 getch();
       }