#include <iostream>

using namespace std;

class List {

public:
	List(int = 10);
	~List();
	bool isFull();
	bool isEmpty();
	int length(); //The number of list items is returned.
	void makeEmpty();
	void addItem(int item); //It inserts an item at the list end.
	int deleteItem(int item); //It deletes and returns an item.
	void printList();
	void HeapSort();

protected:
	int max; //array size
	int last; //index of the last list item
	//Note: element[0] is not used.
	int* array; //pointer to the first element of a dynamic array
	void swap(int item1, int item2);
	void settleRoot(int root, int last); //used in heapSort
};

void main()
{
   
}