#include <iostream>

using namespace std;

struct NodeType {

    int key;
    NodeType* next;
};

typedef NodeType* NodePtr;

class HashTable {

public:
    HashTable(int);
    ~HashTable();
    int Collision() { return collis; };
    void printTable();

private:
    int primeTableSize;
    int collis;
    NodePtr* table; //pointer to a dynamic array of pointers
    int count;

    int h(int k) { return k % primeTableSize;};     //division hash function
    void AddKeys();

}; //HashTable

HashTable::HashTable(int n) {

    primeTableSize = 101;
    collis = 0;
    count = n;
    table = new NodePtr[primeTableSize];

    for (int j = 0; j < primeTableSize; j++) table[j] = NULL;

    AddKeys();

}//constructor

HashTable::~HashTable() {

    for (int i = 0; i < primeTableSize; i++) {

        NodePtr current, temp;

        if (table[i] != NULL) {

            current = table[i];

            while (current != NULL) {
                temp = current;
                current = current->next;

                delete temp;
            }
        }
    }
}//destructor

void HashTable::AddKeys() {
    for (int i = 1; i != count + 1; ++i) {

        int k = rand() % 449 + 1;   //random item
        int index = h(k); // index is the hash address for item .
        NodePtr a = new NodeType;
        a->key = k;
        a->next = table[index];
        if (table[index] != NULL) ++collis;
        table[index] = a;
    }
}//insert

void HashTable::printTable() {

    cout << "\nContents of hash table of size " << primeTableSize - 1 << ":\n";

    for (int i = 0; i < primeTableSize; ++i) {

        if (table[i] == NULL) cout << "List is empty\n";
        else {
            NodePtr current = table[i];

            while (current != NULL) {
                cout << current->key << ", ";
                current = current->next;
            }//while

            cout << endl;
        }
    }
}//printTable


int main()
{
    HashTable a(60);
    cout << a.Collision() << endl;
    a.printTable();

    HashTable b(90);
    cout << b.Collision() << endl;
    b.printTable();
}
