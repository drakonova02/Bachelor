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
	int* arr; //pointer to the first element of a dynamic array
	int search(int item); //search item in array.
	void swap(int item1, int item2);
	void settleRoot(int root, int last); //used in heapSort
};

//constructor List
List::List(int n) {
	max = n + 1; //max number of element + arr[0] isn`t used
	last = 0;
	arr = new int[max]; // create dynamic array
}

//destructor List
List::~List() {
	delete []arr;
	last = 0;
}

//Create metods of class List
bool List::isFull() {
	return (last == max - 1);
}

bool List::isEmpty() {
	return(last == 0);
}

int List::length() {
	return last;
}

void List::makeEmpty(){
	last = 0;
}

void List::addItem(int item) {
	if (!(isFull())) {
		cout << "List overflow: item cannot be added.\n";
			return;
	}
	arr[++last] = item;
}

int List::search(int item) {
	for (int i = 1; i < max; ++i) if (item == arr[i]) return i;
	return -1;
}

int List::deleteItem(int item) {
	if (isEmpty()) {
		cout << "List is empty: item cannot be deleted.\n";
		return;
	}
	if (search(item) == -1) {
		cout << "Item isn`t in List.\n";
		return;
	}
	int index = search(item);
	while (index != -1) {
		int temp = arr[index];
		arr[index] = arr[last--];
		index = search(item);
	}
	return item;
}

void main()
{
   
}