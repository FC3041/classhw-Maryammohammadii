#include <iostream>
#include <cstdlib>
#include<math.h>

using namespace std;

class MyList
{
public:
    int m_size;
    int* m_Pnums;

    MyList(int size, int* nums)
    {
        m_size = size;
        m_Pnums = (int*)malloc(sizeof(int) * m_size);
        for (int i = 0; i < m_size; i++) {
            m_Pnums[i] = nums[i];
        }
    }

    void append(int x)
    {
        resize(m_size + 1);
        m_Pnums[m_size - 1] = x;
    }

    void pop()
    {
        if (m_size == 0) return;
        resize(m_size - 1);
    }

    void print()
    {
        cout << "[";
        for (int i = 0; i < m_size; i++) {
            cout << m_Pnums[i];
            if (i < m_size - 1) cout << ", ";
        }
        cout << "]" << endl;
    }

    ~MyList()
    {
        free(m_Pnums);
    }

private:
    void resize(int newsize)
    {
        int* newMem = (int*)malloc(sizeof(int) * newsize);
        for (int i = 0; i < m_size && i < newsize; i++) {
            newMem[i] = m_Pnums[i];
        }
        free(m_Pnums);
        m_Pnums = newMem;
        m_size = newsize;
    }
};

int main()
{
    int nums[5] = {1, 2, 3, 4, 5};
    MyList m(5, nums);

    m.print();

    m.append(14);
    m.print();

    m.pop();
    m.print();

    return 0;
}