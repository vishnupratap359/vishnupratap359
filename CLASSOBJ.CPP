#include<iostream.h>
#include<conio.h>
class admissionform {
private:
	  char name[20];
	  char fname[20];
	  int age;
	long int mobileno;
public:
	void completeform()
	{
	 cout<<"enter your name = ";
	 cin>>name;
	 cout<<"enter your fname =";
	 cin>>fname;
	 cout<<"enter your age = ";
	 cin>>age;
	 cout<<"enter your mobileno =";
	 cin>>mobileno;
	 }
  void showinfo()
  {
    cout<<endl;
    cout<<"your name is = "<<name<<endl;
    cout<<"your fname is ="<<fname<<endl;
    cout<<"your age is = "<<age<<endl;
    cout<<"your mobileno is ="<<mobileno<<endl;
    }
    };
     void main()
    {
      admissionform ramesh1,suresh1;
      ramesh1.completeform();
      suresh1.completeform();
      ramesh1.showinfo();
      suresh1.showinfo();
      getch();
      }
