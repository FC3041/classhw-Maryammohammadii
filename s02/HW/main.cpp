#include<iostream>
#include<math.h>
using namespace std;

class Circle 
{
    public:
        double cx; 
        double cy; 
        double r;  

        
        Circle(double a, double b, double c)
        {
            cx = a;
            cy = b;
            r = c;
        }

        
        double S()
        {
            return 3.14 * r * r;
        }

        
        double P()
        {
            return 2 * 3.14 * r;
        }

        
        double dist(double px, double py)
        {
            double dx = px - cx;
            double dy = py - cy;
            return sqrt(dx * dx + dy * dy);
        }

        
        int is_inside(double px, double py)
        {
            double d = dist(px, py);
            if (d <= r)
                return 1; 
            else
                return 0; 
            
        }
};

int main()
{
    Circle c(3, 4, 5);

    cout << "s: " << c.S() << endl;

    cout << "p: " << c.P() << endl;

    double d = c.dist(7, 8);
    cout << "Distance: " << d << endl;

    int r = c.is_inside(7, 8);
    if (r == 1)
        cout << "Inside" << endl;
    else
        cout << "Outside" << endl;
    return 0;
}
