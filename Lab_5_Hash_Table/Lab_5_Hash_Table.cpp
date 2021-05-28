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
    //void AddKeys();

}; //HashTable

HashTable::HashTable(int tableSize) {

    primeTableSize = 101;
    table = new NodePtr[primeTableSize];

    for (int j = 0; j < primeTableSize; j++) table[j] = NULL;

    //AddKeys();

}//constructor


int main()
{
    std::cout << "Hello World!\n";
}
