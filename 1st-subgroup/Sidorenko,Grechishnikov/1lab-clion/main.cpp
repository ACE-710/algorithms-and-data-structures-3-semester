#include <iostream>
#include "MyList.h"

void performOperation(int menuItem);

using namespace std;

void printMenu() {
    cout << "1. Add element" << endl;
    cout << "2. Add element to position" << endl;
    cout << "3. Show list" << endl;
}



void performOperation(int menuItem, List<int> list) {
    switch (menuItem) {
        case 1: {
            int elem = 0;
            cout << "Add number: ";
            cin >> elem;
            list.add(elem);
            break;
        }
        case 3:{
            for (int i = 0; i < list.getSize(); i++) {
                cout << list.get(i) << " ";
            }
            break;
        }
        default: {
            break;
        }
    }
}

int main() {
    setlocale(0, "");

    List<int> l1, l2, lout;
    int n = 0, a, listSize = 0;

    int menuItem = -1;

    printMenu();

    while (menuItem != 0) {
        cout << ">>> ";
        cin >> menuItem;
        performOperation(menuItem, l1);
        l1.get(0);
    }

    l1.del(1);

    system("pause");
    return 0;
}
