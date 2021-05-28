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
        table[index] = a;
    }
}//insert


int main()
{
    std::cout << "Hello World!\n";
}
