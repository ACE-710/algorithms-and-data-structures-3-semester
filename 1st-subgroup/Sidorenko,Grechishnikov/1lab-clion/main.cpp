#include <iostream>
#include "MyList.h"
using namespace std;

int nl1, nl2;


void main() {
    List<int> l1, l2, lout;
    int n = 0, a;

    cout << "Enter first List" << endl;
    cout << "Number of elements: ";

    cin >> nl1;
    for (int i = 0; i < nl1; i++) {
        cout << i + 1 << " elemet: ";
        cin >> a;
        l1.add(a);
    }
    l1.del(1);

    for (int i = 0; i < l1.getSize(); i++) {
        cout << l1.get(i) << endl;
    }
    system("pause");
}