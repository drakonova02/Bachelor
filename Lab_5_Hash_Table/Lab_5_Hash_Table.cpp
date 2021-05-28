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

private:
    int primeTableSize;
    NodePtr* table; //pointer to a dynamic array of pointers

}; //HashTable


int main()
{
    std::cout << "Hello World!\n";
}
